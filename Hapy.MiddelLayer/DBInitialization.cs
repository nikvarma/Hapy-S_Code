using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.MiddelLayer
{
    public class DBInitialization
    {
        public void DbContextInitialization()
        {
            new DB.HapyDBContext().DbContextInitialization();
        }
    }
}
