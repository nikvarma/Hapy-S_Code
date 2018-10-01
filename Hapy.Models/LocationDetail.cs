using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class LocationDetail
    {
        public Guid ID { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public string Strees { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public bool IsActive { get; set; }
        public Guid Refernceid { get; set; }
        public string GooglePlaceId { get; set; }
    }
}
