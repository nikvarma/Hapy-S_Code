using Hapy.DB;
using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.MiddelLayer
{
    public class RegisterDevice: DbCommands<DB.UnRegisterdDevices>, IRegisterDevice
    {
        private DbCommands<DB.UnRegisterdDevices> _dbCommands;
        public RegisterDevice()
        {
            _dbCommands = new DbCommands<DB.UnRegisterdDevices>();
        }

        public ActionReturn Insert(Models.UnRegisteredDevice unRegisteredDevice)
        {
            DB.UnRegisterdDevices registerdDevices = new UnRegisterdDevices()
            {
                uIsVerifyed = false,
                uIsActive = true,
                uRDNumber = unRegisteredDevice.DeviceNumber,
                uRDtype = unRegisteredDevice.TypeId,
                uRDId = unRegisteredDevice.DeviceId
            };
            _dbCommands.Insert(registerdDevices);
            bool status = _dbCommands.Save();
            return new ActionReturn() {
                Id = registerdDevices.uRId,
                Status = status
            };
        }
    }
}