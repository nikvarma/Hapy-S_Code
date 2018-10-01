using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class ChatMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MId { get; set; }
        public string MContent { get; set; }

        public Guid CCSId { get; set; }
        [ForeignKey("CCSId")]
        public CallChatSetting CallChatSestting { get; set; }
    }
}
