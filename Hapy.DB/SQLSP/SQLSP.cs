using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public partial class SQLSP : HapyDBContext
    {
        HapyDBContext _dbContext;
        
        public SQLSP(DbContext context)
        {
            _dbContext = (HapyDBContext)context;
        }
        public IEnumerable<T> GetFromSP<T>(string spName, object[] spParams)
        {
            return _dbContext.Database.SqlQuery<T>(spName, spParams);
        }
    }
}
