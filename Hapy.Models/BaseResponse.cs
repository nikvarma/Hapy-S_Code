using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class BaseResponse
    {
        public Object ResponseObject { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string LogMessage { get; set; }
    }

    public class ActionReturn
    {
        public bool Status { get; set; }
        public object Id { get; set; }
        public string Message { get; set; }
    }
}
