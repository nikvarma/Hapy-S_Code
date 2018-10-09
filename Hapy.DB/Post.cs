using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Type { get; set; }
        public Guid ToId { get; set; }
        public bool Status { get; set; }
        public Guid FromId { get; set; }
        public bool IsActive { get; set; }
        public string PMedia { get; set; }
        public string VisibleTo { get; set; }
        public string PLocation { get; set; }
        public string PTaggedTo { get; set; }
        public string ContentText { get; set; }
        public string PFeelingIcon { get; set; }
        public bool PIsBadReported { get; set; }
    }
}
