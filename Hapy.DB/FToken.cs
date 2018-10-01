using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class FToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Tid { get; set; }
        [Required]
        public string TDeviceUUid { get; set; }
        [Required]
        public string TToken { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
