using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class LocationDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AID { get; set; }
        public string Address { get; set; }
        public string ACountry { get; set; }
        public string ACode { get; set; }
        public string ALocation { get; set; }
        public string AStrees { get; set; }
        public string ACity { get; set; }
        public string AState { get; set; }
        public double ALat { get; set; }
        public double ALng { get; set; }
        public bool IsActive { get; set; }
        public Guid Refernceid { get; set; }
        public string GooglePlaceId { get; set; }
    }
}
