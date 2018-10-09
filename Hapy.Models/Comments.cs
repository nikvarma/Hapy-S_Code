using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class Comments: BasePost
    {
        public Guid PostId { get; set; }
    }

    public class SubComments : Comments
    {
        public Guid CommentId { get; set; }
    }
}
