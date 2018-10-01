using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class CallChatSetting
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CId { get; set; }

        public Guid CFromId { get; set; }
        [ForeignKey("CFromId")]
        public UsersInfo UsersInfoF { get; set; }

        public Guid CToId { get; set; }
        [ForeignKey("CToId")]
        public UsersInfo UsersInfoT { get; set; }

        public bool CCallBlocked { get; set; }
        public bool CChatBlocked { get; set; }
        public bool isActive { get; set; }
        public bool Status { get; set; }
    }
}
