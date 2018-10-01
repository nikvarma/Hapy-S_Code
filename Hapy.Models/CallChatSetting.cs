using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class CallChatSetting
    {
        public Guid Id { get; set; }
        public Guid FromId { get; set; }
        public Guid ToId { get; set; }
        public bool CallBlocked { get; set; }
        public bool ChatBlocked { get; set; }
        public bool IsActive { get; set; }
        public bool Status { get; set; }
        public bool isSave { get; set; }
    }
}
