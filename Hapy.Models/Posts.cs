using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class Posts: BasePost
    {
        public Guid ViewId { get; set; }
        public Guid LikeId { get; set; }
        public Guid ShareId { get; set; }
        public Int32 LikeCount { get; set; }
        public Int32 ViewCount { get; set; }
        public Int32 ShareCount { get; set; }
        public Int32 CommentCount { get; set; }
        public IEnumerable<Views> Views { get; set; }
        public IEnumerable<Share> Share { get; set; }
        public IEnumerable<Likes> Likes { get; set; }
        public IEnumerable<Guid> MediaId { get; set; }
        public IEnumerable<Medias> Medias { get; set; }
        public IEnumerable<Comments> Comments { get; set; }
    }

    public class BasePost: BaseObject
    {
        public Guid Id { get; set; }
        public Guid ToId { get; set; }
        public Guid FromId { get; set; }
        public string ContentText { get; set; }
    }
}
