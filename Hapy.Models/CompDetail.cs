using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class CompDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public Guid LocationID { get; set; }
        public IEnumerable<LocationDetail> Location { get; set; }
        public bool IsActive { get; set; }
    }
}