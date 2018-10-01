using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public interface IFilterStatement
    {
        string PropertyName { get; set; }
        Operation Operation { get; set; }
        object Value { get; set; }
    }
}
