using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class Device
    {
        [Key]
        public int dId { get; set; }
        [Required]
        [StringLength(50)]
        public string dName { get; set; }
        [Required]
        [StringLength(50)]
        public string dType { get; set; }
        [Required]
        public bool dIsActive { get; set; }


        public ICollection<UnRegisterdDevices> UnRegisterdDevices { get; set; }
    }
}
