using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class Logging
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string PageName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string ExtraInfo { get; set; }
    }
}
