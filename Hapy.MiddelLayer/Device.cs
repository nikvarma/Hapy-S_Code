using Hapy.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.MiddelLayer
{
    public class Device : DbCommands<DB.Device>, IDevice
    {
        private DbCommands<DB.Device> _dbCommands;
        public Device()
        {
            _dbCommands = new DbCommands<DB.Device>();
        }

        public void Insert(Models.Device device)
        {
            DB.Device devices = new DB.Device()
            {
                dIsActive = device.IsActive,
                dName = device.Name,
                dType = device.Type
            };
            // _dbCommands.Insert<DB.Device>(devices);
        }

        public IEnumerable<Models.Device> GetDevice()
        {
            IEnumerable<DB.Device> devices = _dbCommands.FetchRecords();
            List<Models.Device> device = new List<Models.Device>();
            foreach (var item in devices)
            {
                device.Add(new Models.Device()
                {
                    Id = item.dId,
                    IsActive = item.dIsActive,
                    Name = item.dName,
                    Type = item.dType
                });
            }
            return device;
        }

    }
}
