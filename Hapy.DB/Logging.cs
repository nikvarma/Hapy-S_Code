using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class Logging
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LID { get; set; }
        public string LMessage { get; set; }
        public string LClassname { get; set; }
        public string LMethodeName { get; set; }
        public string LExtraInformation { get; set; }
    }
}
