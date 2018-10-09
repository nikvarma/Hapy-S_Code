using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class PostDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PDId { get; set; }
        public Guid PId { get; set; }
        public string PMediaURL { get; set; }
        public int PMediaType { get; set; }
        public bool isActive { get; set; }
        public bool Status { get; set; }
    }
}
