using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class SubComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid CommentId { get; set; }
        public Guid FromId { get; set; }
        public bool IsActive { get; set; }
        public bool Status { get; set; }
        public string ContentText { get; set; }
    }
}
