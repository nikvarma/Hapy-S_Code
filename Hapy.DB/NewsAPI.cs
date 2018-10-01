using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class NewsAPI
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid NId { get; set; }

        public string Nauthor { get; set; }
        public string Ntitle { get; set; }
        public string Ndescription { get; set; }
        public string NpublishedAt { get; set; }
        public string NurlToImage { get; set; }
        public string Nurl { get; set; }
        public string NUrlid { get; set; }
        public string Nname { get; set; }
        public string NType { get; set; }
    }
}
