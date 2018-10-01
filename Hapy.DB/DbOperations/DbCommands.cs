using CommonLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Hapy.DB
{
    public class DbCommands<T> : IDbCommands<T> where T : class
    {
        private DbContext _dbContext { get; set; }
        public DbCommands()
        {
            _dbContext = new HapyDBContext();
        }

        private DbSet<T> GetEntity()
        {
            return _dbContext.Set<T>();
        }

        public bool Save()
        {
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logger.AutoLogException(ex, false);
                if (ex.InnerException != null)
                {
                    Logger.AutoLogException(ex.InnerException, false);
                }
                return false;
            }
        }

        public IEnumerable<TBase> FetchRecords<TBase>(string propertyName, object propertyValue) where TBase : class
        {
            return _dbContext.Set<TBase>().Where(Expressions.GetExpression<TBase>(propertyName, propertyValue, CommonLibrary.Operation.EqualTo));
        }

        public IEnumerable<TBase> FetchRecords<TBase>(Filter filter) where TBase : class
        {
            return _dbContext.Set<TBase>().Where(Expressions.GetExpression<TBase>(filter.FilterOn));
        }

        public IEnumerable<TBase> FetchRecords<TBase>(Filter filter, string[] loadEntity) where TBase : class
        {
            var includeEntity = _dbContext.Set<TBase>();
            foreach (var item in loadEntity) includeEntity.Include(item);
            return includeEntity.Where(Expressions.GetExpression<TBase>(filter.FilterOn));
        }

        public IEnumerable<TBase> FetchSelectRecords<TBase>(Filter filter) where TBase : class
        {
            return _dbContext.Set<TBase>().Where(Expressions.GetExpression<TBase>(filter.FilterOn)).Select(Expressions.CreateNewStatement<TBase>(filter.SelectFileds));
        }

        public TBase FetchSingleRecord<TBase>(dynamic id) where TBase : class
        {
            return _dbContext.Set<TBase>().Find(id);
        }

        public void Insert<TBase>(TBase dataObject) where TBase : class
        {
            _dbContext.Set<TBase>().Add(dataObject);
        }

        public IEnumerable<T> FetchRecords()
        {
            return GetEntity().AsNoTracking().ToList();
        }

        public GetId InsertGetId<TBase, GetId>(TBase dataObject) where TBase : class
        {
            dynamic dynamicId = _dbContext.Set<TBase>().Add(dataObject);
            return dynamicId;
        }

        public void ActionState<TBase>(TBase dataObject, EntityState entityState) where TBase : class
        {
            _dbContext.Entry<TBase>(dataObject).State = entityState;
        }

        public void DeleteByID<TBase>(dynamic id) where TBase : class
        {
            _dbContext.Set<TBase>().Remove(FetchSingleRecord<TBase>(id));
        }

        public IEnumerable<TBase> SqlQuery<TBase>(string spName, params object[] spParams)
        {
            return _dbContext.Database.SqlQuery<TBase>(spName, spParams);
        }

        public IEnumerable<TBase> GetOnSP<TBase>(string spName, Guid searchBy, int pageNumber, int pageSize, Guid? id, string searchTxt, string searchOn, object searchType, bool? searchIsActive, bool? searchStatus)
        {
            try
            {
                return _dbContext.Database.SqlQuery<TBase>(spName, new SqlParameter()
                {
                    Value = searchBy,
                    DbType = System.Data.DbType.Guid,
                    ParameterName = "@searchBy"
                }, new SqlParameter()
                {
                    Value = searchTxt,
                    DbType = System.Data.DbType.String,
                    ParameterName = "@searchTxt"
                }, new SqlParameter()
                {
                    Value = searchOn,
                    DbType = System.Data.DbType.String,
                    ParameterName = "@searchOn"
                }, new SqlParameter()
                {
                    Value = searchType,
                    DbType = System.Data.DbType.String,
                    ParameterName = "@searchType"
                }, new SqlParameter()
                {
                    Value = pageNumber,
                    DbType = System.Data.DbType.Int16,
                    ParameterName = "@pageNumber"
                }, new SqlParameter()
                {
                    Value = pageSize,
                    DbType = System.Data.DbType.Int16,
                    ParameterName = "@pageSize"
                }, new SqlParameter()
                {
                    Value = (id == null) ? (object)DBNull.Value : id,
                    DbType = System.Data.DbType.Guid,
                    ParameterName = "@id"
                }, new SqlParameter()
                {
                    Value = (searchStatus == null) ? (object)DBNull.Value : searchStatus,
                    DbType = System.Data.DbType.Boolean,
                    ParameterName = "@searchStatus"
                }, new SqlParameter()
                {
                    Value = (searchIsActive == null) ? (object)DBNull.Value : searchIsActive,
                    DbType = System.Data.DbType.Boolean,
                    ParameterName = "@searchIsActive"
                }).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}