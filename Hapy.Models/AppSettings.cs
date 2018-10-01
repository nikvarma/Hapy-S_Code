using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class AppSettings
    {
        public Guid Id { get; set; }
        public double Version { get; set; }
        public string Name { get; set; }
        public string DeviceId { get; set; }
    }
}