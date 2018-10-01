using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class Registration
    {
        public string MobileNumber { get; set; }
        public int CountryCode { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public bool IsLogin { get; set; }
        public bool IsForOTP { get; set; }
    }
}
