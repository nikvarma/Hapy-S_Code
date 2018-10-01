using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.MiddelLayer
{
    public class Search<T> : DB.DbCommands<T>, ISearch where T : class
    {

    }
}
