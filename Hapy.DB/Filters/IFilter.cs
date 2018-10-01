using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public interface IFilter<TClass> where TClass : class
    {
        List<IFilterStatement> Statement { get; set; }
        Expression<Func<TClass, bool>> BuildExpression();
    }
}
