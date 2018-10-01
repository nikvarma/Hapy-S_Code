using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class Filter<TClass> : IFilter<TClass> where TClass : class
    {
        public List<IFilterStatement> Statement { get; set; }

        public Expression<Func<TClass, bool>> BuildExpression()
        {
            throw new NotImplementedException();
        }

        //public Expression<Func<TClass, bool>> BuildExpression()
        //{
        //    //this is in case the list of statements is empty
        //    Expression finalExpression = Expression.Constant(true);
        //    var parameter = Expression.Parameter(typeof(TClass), "x");
        //    foreach (var statement in Statement)
        //    {
        //        var member = Expression.Property(parameter, statement.PropertyName);
        //        var constant = Expression.Constant(statement.Value);
        //        Expression expression = null;
        //        switch (statement.Operation)
        //        {
        //            case Operation.EqualTo:
        //                expression = Expression.Equal(member, constant);
        //                break;
        //            case Operation.GreaterThanOrEqualTo:
        //                expression = Expression.GreaterThanOrEqual(member, constant);
        //                break;
        //                ///and so on...
        //        }

        //        finalExpression = Expression.AndAlso(finalExpression, expression);
        //    }

        //    return finalExpression;
        //}


        public Expression<Func<T, bool>> GetExpression<T>(string propertyName, object propertyValue)
        {
            var param = Expression.Parameter(typeof(T), propertyName);
            var member = Expression.Property(param, "Id"); //x.Id
            var constant = Expression.Constant(propertyValue);
            var body = Expression.GreaterThanOrEqual(member, constant); //x.Id >= 3
            var finalExpression = Expression.Lambda<Func<T, bool>>(body, param); //x => x.Id >= 3
            return finalExpression;
        }

        public MemberExpression GetMemberExpression(Expression param, string propertyName)
        {
            if (propertyName.Contains("."))
            {
                int index = propertyName.IndexOf(".");
                var subParam = Expression.Property(param, propertyName.Substring(0, index));
                return GetMemberExpression(subParam, propertyName.Substring(index + 1));
            }

            return Expression.Property(param, propertyName);
        }
    }
}
