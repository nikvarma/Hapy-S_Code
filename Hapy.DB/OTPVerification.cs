using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hapy.DB
{
    public class OTPVerification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid oId { get; set; }
        [Required]
        public string oCode { get; set; }
        [Required]
        public string oToken { get; set; }
        [Required]
        public bool oVerifyed { get; set; }
        [Required]
        [StringLength(50)]
        public string oAccount { get; set; }
    }
}
