using Hapy.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.MiddelLayer
{
    public class Logging: DbCommands<DB.Logging>, ILogging
    {
        private DbCommands<DB.Logging> _dbCommands { get; set; }
        public Logging()
        {
            _dbCommands = new DbCommands<DB.Logging>();
        }

        public bool Insert(Models.Logging logging)
        {
            DB.Logging _logging = new DB.Logging()
            {
                LMessage = logging.Message,
                LClassname = logging.ClassName,
                LMethodeName = logging.MethodName,
                LExtraInformation = logging.ExtraInfo
            };
            _dbCommands.Insert(_logging);
            return _dbCommands.Save();
        }
    }
}

