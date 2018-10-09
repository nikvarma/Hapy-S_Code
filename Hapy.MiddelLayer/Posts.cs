using Hapy.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hapy.Models;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hapy.MiddelLayer
{
    public class Posts : DbCommands<Post>, IPosts
    {
        private DbCommands<Post> _dbCommands;
        public Posts()
        {
            _dbCommands = new DbCommands<Post>();
        }

        public ActionReturn Insert(BasePost post)
        {
            Post _post = Assgin(post);
            _dbCommands.Insert(_post);
            bool status = _dbCommands.Save();
            return new ActionReturn()
            {
                Id = _post.Id,
                Status = status
            };
        }

        private Post Assgin(BasePost post)
        {
            if (post == null)
            {
                return null;
            }
            return new Post()
            {
                Id = post.Id,
                FromId = post.FromId,
                ToId = post.ToId,
                IsActive = post.IsActive,
                ContentText = post.ContentText?.ToString(),
                PIsBadReported = post.IsBadReported,
                PLocation = post.Location?.ToString(),
                PFeelingIcon = post.FeelingIcon?.ToString(),
                PTaggedTo = post.TaggedTo?.ToString(),
                Status = post.Status,
                Type = post.Type,
                PMedia = post.Media?.ToString(),
                VisibleTo = post.VisibleTo
            };
        }

        public ActionReturn GetSubCommentRecords(SearchParams search)
        {
            return new ActionReturn()
            {
            };
        }

        public ActionReturn GetCommentRecords(SearchParams search)
        {
            return new ActionReturn()
            {
            };
        }

        public SearchPosts GetPostRecords(PostIds search)
        {
            return new SearchPosts()
            {
                jsonResult = _dbCommands.SqlQuery<SearchPosts>("getSP_Post",
                new SqlParameter() { ParameterName = "@uId", DbType = System.Data.DbType.Guid },
                new SqlParameter() { ParameterName = "@fromId", DbType = System.Data.DbType.Guid }
                ).SingleOrDefault()
            };
        }

        public ActionReturn Share(Models.Share share)
        {
            return new ActionReturn()
            {

            };
        }

        public ActionReturn Like(Likes likes)
        {
            return new ActionReturn()
            {

            };
        }

        public ActionReturn HideRecords(PostIds search, string hideType)
        {
            return new ActionReturn()
            {

            };
        }

        public ActionReturn Comment(Comments comments)
        {
            return new ActionReturn()
            {

            };
        }

        public ActionReturn SubComment(SubComments comments)
        {
            return new ActionReturn()
            {

            };
        }

        public ActionReturn Update(Comments comments, string action)
        {
            return new ActionReturn()
            {

            };
        }

        public ActionReturn Update(SubComments comments, string action)
        {
            return new ActionReturn()
            {

            };
        }
    }
}
