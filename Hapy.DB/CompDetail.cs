using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class CompDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CId { get; set; }
        public string CName { get; set; }
        public bool CStatus { get; set; }
        [NotMapped]
        public Guid CAID { get; set; }
        [NotMapped]
        public ICollection<LocationDetail> LocationDetail { get; set; }
        public bool IsActive { get; set; }
    }
}
