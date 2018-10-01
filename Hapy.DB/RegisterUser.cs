using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class RegisterUser
    {
        [Key]
        public Guid rid { get; set; }
        public string rCountryCode { get; set; }
        public string rMobileNumber { get; set; }
        public string rOTP { get; set; }
        public bool rIsVerifyed { get; set; }
        public string rUname { get; set; }
        public string rWallProfileImage { get; set; }
        public string profileImage { get; set; }
        public string rDeviceId { get; set; }
    }
}
