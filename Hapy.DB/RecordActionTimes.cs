using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class RecordActionTimes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid RefId { get; set; }
        public string Fromtable { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime CreateTimeStamp { get; set; }
    }
}
