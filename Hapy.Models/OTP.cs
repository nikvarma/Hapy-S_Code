using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class OTPSend: BaseObject
    {
        public object Code { get; set; }
        public bool isMixCode { get; set; }
    }
    
    public class OTP : OTPSend
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public bool isVerifyed { get; set; }
        public string Account { get; set; }
    }
}
