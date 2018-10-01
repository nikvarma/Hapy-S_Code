using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class FToken: BaseObject
    {
        public Guid Id { get; set; }
        [Required]
        public string DeviceUUID { get; set; }
        [Required]
        public string Token { get; set; }

    }
}
