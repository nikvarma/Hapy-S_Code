using Hapy.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hapy.Models;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CommonLibrary;

namespace Hapy.MiddelLayer
{
    public class Posts : DbCommands<Post>, IPosts
    {
        private DbCommands<Post> _dbCommands;
        Dictionary<string, FilterCondition> filter;
        public Posts()
        {
            _dbCommands = new DbCommands<Post>();
            filter = new Dictionary<string, FilterCondition>();
        }

        public ActionReturn Insert(BasePost post)
        {
            Post _post = Assgin(post);
            _dbCommands.Insert(_post);
            bool status = _dbCommands.Save();
            SaveActionTime(new RecordActionTimes()
            {
                RefId = _post.Id,
                Fromtable = "Posts"
            });
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
                jsonResult = _dbCommands.SqlQuery<SearchPosts>("getSP_Posts @fromId, @toId, @pageNumber, @pageSize",
                new SqlParameter() { ParameterName = "@fromId", DbType = System.Data.DbType.Guid, Value = search.FromId },
                new SqlParameter() { ParameterName = "@toId", DbType = System.Data.DbType.Guid, Value = search.ToId },
                new SqlParameter() { ParameterName = "@pageNumber", DbType = System.Data.DbType.Guid, Value = search.ToId },
                new SqlParameter() { ParameterName = "@pageSize", DbType = System.Data.DbType.Guid, Value = search.ToId }
                ).SingleOrDefault()
            };
        }

        public ActionReturn Share(Models.Share share)
        {
            DB.Share _share = new DB.Share()
            {
                PostId = share.PostId,
                FromId = share.FromId,
                Status = true,
                IsActive = true
            };
            _dbCommands.Insert(_share);
            bool status = _dbCommands.Save();
            SaveActionTime(new RecordActionTimes()
            {
                RefId = _share.Id,
                Fromtable = "Shares"
            });
            return new ActionReturn()
            {
                Id = _share.Id,
                Status = status
            };
        }

        public ActionReturn Like(Likes likes)
        {
            filter.Add("PId", new FilterCondition()
            {
                Condition = Condition.AndAlso,
                Operation = CommonLibrary.Operation.EqualTo,
                Value = likes?.PostId.ToString()
            });
            filter.Add("FromId", new FilterCondition()
            {
                Condition = Condition.AndAlso,
                Operation = CommonLibrary.Operation.EqualTo,
                Value = likes?.FromId.ToString()
            });
            PostLike _like = _dbCommands.FetchRecords<PostLike>(new Filter()
            {
                FilterOn = filter
            }).SingleOrDefault();
            if (_like != null)
            {
                _dbCommands.ActionState(_like, System.Data.Entity.EntityState.Deleted);
            }
            else
            {
                _dbCommands.Insert(new PostLike()
                {
                    Status = true,
                    PId = likes.Id,
                    IsActive = true,
                    FromId = likes.FromId
                });
            }
            bool status = _dbCommands.Save();
            SaveActionTime(new RecordActionTimes()
            {
                RefId = _like.Id,
                Fromtable = "PostLikes"
            });
            return new ActionReturn()
            {
                Status = status,
                Id = _like.Id
            };
        }

        private void SaveActionTime(RecordActionTimes recordAction)
        {
            _dbCommands.Insert(new RecordActionTimes()
            {
                RefId = recordAction.RefId,
                Fromtable = recordAction.Fromtable,
                CreateDate = DateTime.Now
            });
            _dbCommands.Save();
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
