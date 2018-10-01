using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class UsersInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UId { get; set; }
        public string UName { get; set; }
        public string UFname { get; set; }
        public string ULName { get; set; }

        public DateTime UDOB { get; set; }
        public string UGender { get; set; }
        public int UPrimarynumbercode { get; set; }
        public Int64 UPrimarynumber { get; set; }
        public string UEmailid { get; set; }
        public int USecondarycode { get; set; }
        public Int64 USecondarynumber { get; set; }
        public string UAbout { get; set; }
        public string UDesc { get; set; }
        public string UWallimage { get; set; }
        public string UProfileimage { get; set; }

        [NotMapped]
        public ICollection<LocationDetail> LocationDetail { get; set; }
        [NotMapped]
        public ICollection<UserCompDetail> UserCompDetail { get; set; }


        public bool UStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
