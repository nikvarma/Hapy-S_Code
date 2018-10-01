using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class UserCompDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UCId { get; set; }
        public DateTime UCStartDate { get; set; }
        public DateTime UCEndDate { get; set; }

        public Guid UUID { get; set; }
        [ForeignKey("UUID")]
        public UsersInfo UsersInfo { get; set; }

        public Guid UCCOMPID { get; set; }
        [ForeignKey("UCCOMPID")]
        ICollection<CompDetail> CompDetail { get; set; }
        
        public bool IsActive { get; set; }
    }
}