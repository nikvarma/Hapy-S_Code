using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class UserInfo: UserAbout
    {
        public string Name { get; set; }
        public string Fname { get; set; }
        public string LName { get; set; }

        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public int Primarynumbercode { get; set; }
        public Int64 Primarynumber { get; set; }
        public string Emailid { get; set; }
        public int Secondarycode { get; set; }
        public Int64 Secondarynumber { get; set; }
        public bool Status { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<UserCompDetail> UserCompDetail { get; set; }
        public IEnumerable<LocationDetail> LocationDetail { get; set; }

    }

    public class UserAbout: UserImage
    {
        public string About { get; set; }
        public string Desc { get; set; }
    }

    public class UserImage: IdKey
    {
        public string Wallimage { get; set; }
        public string Profileimage { get; set; }
    }

    public class IdKey
    {
        public Guid UId { get; set; }
    }
}
