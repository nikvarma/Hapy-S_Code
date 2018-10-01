using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hapy.Models;
using Hapy.DB;

namespace Hapy.MiddelLayer
{
    public class FirebaseToken : DbCommands<DB.FToken>, IFirebaseToken
    {
        private DbCommands<DB.FToken> _dbCommands;
        public FirebaseToken()
        {
            _dbCommands = new DbCommands<DB.FToken>();
        }

        public ActionReturn Insert(Models.FToken fToken)
        {
            DB.FToken _fToken = new DB.FToken()
            {
                TDeviceUUid = fToken.DeviceUUID,
                TToken = fToken.Token,
                IsActive = fToken.IsActive
            };
            _dbCommands.Insert(_fToken);
            bool status = _dbCommands.Save();
            return new ActionReturn()
            {
                Id = _fToken.Tid,
                Status = status
            };
        }
    }
}