using Hapy.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.MiddelLayer
{
    interface IDevice: IDbCommands<DB.Device>
    {
        IEnumerable<Models.Device> GetDevice();
    }
}
