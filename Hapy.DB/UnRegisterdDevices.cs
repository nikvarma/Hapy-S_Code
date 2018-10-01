using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class UnRegisterdDevices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid uRId { get; set; }

        public int uRDtype { get; set; }


        [ForeignKey("uRDtype")]
        public Device Devices { get; set; }


        public Guid TokenId { get; set; }

        [ForeignKey("TokenId")]
        public FToken FToken { get; set; }

        public string uRDId { get; set; }
        [StringLength(80)]
        public string uRDNumber { get; set; }
        [Required]
        public bool uIsActive { get; set; }
        [Required]
        public bool uIsVerifyed { get; set; }

    }
}
