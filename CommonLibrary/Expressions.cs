using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public static class Expressions
    {
        public static Expression<Func<T, bool>> GetExpression<T>(string propertyName, object propertyValue, Operation operation)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            MemberExpression member = Expression.Property(param, propertyName);

            Type propertyType = ((PropertyInfo)member.Member).PropertyType;
            TypeConverter converter = TypeDescriptor.GetConverter(propertyType);

            if (!converter.CanConvertFrom(typeof(string)))
                throw new NotSupportedException();

            object value = converter.ConvertFromInvariantString(propertyValue.ToString());
            ConstantExpression constant = Expression.Constant(value);
            UnaryExpression valueExpression = Expression.Convert(constant, propertyType);

            BinaryExpression body = Expression.Equal(member, valueExpression);
            Expression<Func<T, bool>> finalExpression = Expression.Lambda<Func<T, bool>>(body, param);
            return finalExpression;
        }

        public static Expression<Func<T, bool>> GetExpression<T>(IDictionary<string, FilterCondition> filter)
        {
            Expression conditionExpression = null;
            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            foreach (var item in filter.ToList())
            {
                MemberExpression member = Expression.Property(param, item.Key);

                Type propertyType = ((PropertyInfo)member.Member).PropertyType;
                TypeConverter converter = TypeDescriptor.GetConverter(propertyType);

                if (!converter.CanConvertFrom(typeof(string)))
                    throw new NotSupportedException();

                string searchValue = (string.IsNullOrWhiteSpace(item.Value.Value)) ? string.Empty : item.Value.Value;


                object value = converter.ConvertFromInvariantString(searchValue);
                ConstantExpression constant = Expression.Constant(value);
                UnaryExpression valueExpression = Expression.Convert(constant, propertyType);


                if (item.Value.Operation == Operation.EqualTo)
                    conditionExpression = CombineExpress<T>(conditionExpression, Expression.Equal(member, valueExpression), item.Value.Condition);

                if (item.Value.Operation == Operation.Contains)
                {
                    MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    conditionExpression = CombineExpress<T>(conditionExpression, Expression.Call(member, method, constant), item.Value.Condition);
                }

            };
            Expression<Func<T, bool>> expression = Expression.Lambda<Func<T, bool>>(conditionExpression, param);
            return expression;
        }

        public static Expression CombineExpress<T>(Expression lExpression, Expression fExpression, Condition condition)
        {
            Expression expression;
            if (lExpression != null)
            {
                switch (condition)
                {
                    case Condition.And:
                        expression = Expression.And(lExpression, fExpression);
                        break;
                    case Condition.Or:
                        expression = Expression.Or(lExpression, fExpression);
                        break;
                    case Condition.OrElse:
                        expression = Expression.OrElse(lExpression, fExpression);
                        break;
                    case Condition.AndAlso:
                        expression = Expression.AndAlso(lExpression, fExpression);
                        break;
                    default:
                        expression = null;
                        break;
                }
                return expression;
            }
            return fExpression;
        }

        public static Func<T, T> CreateNewStatement<T>(string fields)
        {
            var xParameter = Expression.Parameter(typeof(T), "a");

            var xNew = Expression.New(typeof(T));

            var bindings = fields.Split(',').Select(o => o.Trim())
                .Select(o =>
                {
                    var mi = typeof(T).GetProperty(o);

                    var xOriginal = Expression.Property(xParameter, mi);

                    return Expression.Bind(mi, xOriginal);
                }
            );

            var xInit = Expression.MemberInit(xNew, bindings);

            var lambda = Expression.Lambda<Func<T, T>>(xInit, xParameter);

            return lambda.Compile();
        }
    }
}