using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class LocationImage
    {
        public string Center { get; set; }
        public string Size { get; set; } = "400x400";
        public int Zoom { get; set; } = 14;
        public string MapURL { get; set; }
        public string APIKey { get; set; }
        public string Markers { get; set; } = "markers=color:blue|label:S";
        public string ImageFormat { get; set; }
    }
}
