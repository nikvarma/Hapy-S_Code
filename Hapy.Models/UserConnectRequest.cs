using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class UserConnectRequest
    {
        public Guid Id { get; set; }
        public Guid FromId { get; set; }
        public UserInfo UsersInfoForm { get; set; }
        public Guid ToId { get; set; }

        public UserInfo UsersInfoTo { get; set; }
        public string RequestMessage { get; set; }
        public bool IsRequestAccpted { get; set; }
        public bool IsBlocked { get; set; }
        public bool Status { get; set; }
    }
}
