using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class Share
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid FromId { get; set; }
        public bool IsActive { get; set; }
        public bool Status { get; set; }
    }
}
