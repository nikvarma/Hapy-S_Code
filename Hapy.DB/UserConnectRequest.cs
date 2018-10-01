using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class UserConnectRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid FromId { get; set; }
        [ForeignKey("FromId")]
        public UsersInfo UsersInfoForm { get; set; }
        public Guid ToId { get; set; }
        [ForeignKey("ToId")]
        public UsersInfo UsersInfoTo { get; set; }
        public string RequestMessage { get; set; }
        public bool IsRequestAccpted { get; set; }
        public bool IsBlocked { get; set; }
        public bool Status { get; set; }
    }
}
