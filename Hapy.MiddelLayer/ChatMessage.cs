using CommonLibrary;
using Hapy.DB;
using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.MiddelLayer
{
    public class ChatMessage : DbCommands<DB.ChatMessage>, IChatMessage
    {
        Dictionary<string, FilterCondition> filter;
        private DbCommands<ChatMessage> _dbCommands;
        public ChatMessage()
        {
            filter = new Dictionary<string, FilterCondition>();
            _dbCommands = new DbCommands<ChatMessage>();
        }

        public ActionReturn Insert(Models.CallChatSetting setting)
        {

            bool status = false;
            DB.CallChatSetting chatSestting = _dbCommands.SqlQuery<DB.CallChatSetting>("getSP_ChatId @fid, @tid",
                new SqlParameter() { ParameterName = "@fid", DbType = System.Data.DbType.Guid, Value = setting.FromId },
                new SqlParameter() { ParameterName = "@tid", DbType = System.Data.DbType.Guid, Value = setting.ToId }).SingleOrDefault();
            if (chatSestting == null && setting.isSave)
            {
                chatSestting = Assgin(setting);
                _dbCommands.Insert(chatSestting);
                status = _dbCommands.Save();
            }
            return new ActionReturn()
            {
                Id = chatSestting?.CId,
                Status = status,
            };
        }

        public ActionReturn UpdateSetting(Models.CallChatSetting setting)
        {
            bool status = false;
            DB.CallChatSetting chatSestting = _dbCommands.FetchSingleRecord<DB.CallChatSetting>(setting.Id);
            if (chatSestting != null)
            {
                if (chatSestting.CCallBlocked != setting.CallBlocked)
                {
                    chatSestting.CCallBlocked = setting.CallBlocked;
                }
                if (chatSestting.CChatBlocked != setting.ChatBlocked)
                {
                    chatSestting.CChatBlocked = setting.CallBlocked;
                }
                status = _dbCommands.Save();
            }
            return new ActionReturn()
            {
                Id = setting.Id,
                Status = status
            };
        }

        public IEnumerable<Models.CallChatSetting> GetSetting(SearchParams search)
        {
            List<Models.CallChatSetting> list = new List<Models.CallChatSetting>();
            _dbCommands.FetchRecords<DB.CallChatSetting>(new Filter() { FilterOn = search.FilterOn }, new string[] { "UsersInfoF", "UsersInfoT" }).ToList().ForEach(x => { list.Add(Assgin(x)); });
            return list;
        }

        public ActionReturn Delete(Models.CallChatSetting setting)
        {
            bool status = false;
            DB.CallChatSetting chatSestting = _dbCommands.FetchSingleRecord<DB.CallChatSetting>(setting.Id);
            if (chatSestting != null)
            {
                _dbCommands.ActionState(chatSestting, System.Data.Entity.EntityState.Deleted);
                status = _dbCommands.Save();
            }
            return new ActionReturn()
            {
                Id = setting.Id,
                Status = status
            };
        }

        protected DB.CallChatSetting Assgin(Models.CallChatSetting setting)
        {
            if (setting == null)
            {
                return null;
            }
            return new DB.CallChatSetting()
            {
                CId = setting.Id,
                CToId = setting.ToId,
                CFromId = setting.FromId,
                CCallBlocked = setting.CallBlocked,
                CChatBlocked = setting.ChatBlocked,
                isActive = setting.IsActive,
                Status = setting.Status
            };
        }

        protected Models.CallChatSetting Assgin(DB.CallChatSetting setting)
        {
            if (setting == null)
            {
                return null;
            }
            return new Models.CallChatSetting()
            {
                Id = setting.CId,
                ToId = setting.CToId,
                FromId = setting.CFromId,
                CallBlocked = setting.CCallBlocked,
                ChatBlocked = setting.CChatBlocked,
                IsActive = setting.isActive,
                Status = setting.Status
            };
        }
    }
}
