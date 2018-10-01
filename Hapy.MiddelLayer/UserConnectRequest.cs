using Hapy.DB;
using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.MiddelLayer
{
    public class UserConnectRequest : DbCommands<DB.UserConnectRequest>, IUserConnectRequest
    {
        private DbCommands<DB.UserConnectRequest> _dbCommand;
        public UserConnectRequest()
        {
            _dbCommand = new DbCommands<DB.UserConnectRequest>();
        }
        public ActionReturn AddFriend(Models.UserConnectRequest connectRequest)
        {
            DB.UserConnectRequest userConnect = Assgin(connectRequest);
            _dbCommand.Insert(userConnect);
            bool status = _dbCommand.Save();
            return new ActionReturn()
            {
                Id = userConnect.Id,
                Status = status,
                Message = "Friend request sent."
            };
        }

        public ActionReturn RemoveFriend(Models.UserConnectRequest connectRequest)
        {
            _dbCommand.DeleteByID<DB.UserConnectRequest>(connectRequest.Id);
            bool status = _dbCommand.Save();
            return new ActionReturn()
            {
                Id = connectRequest.Id,
                Status = status,
                Message = "Friend request removed."
            };
        }

        public ActionReturn UpdateFriend(Models.UserConnectRequest connectRequest)
        {
            DB.UserConnectRequest request = _dbCommand.FetchSingleRecord<DB.UserConnectRequest>(connectRequest.Id);
            request.IsBlocked = connectRequest.IsBlocked;
            request.IsRequestAccpted = connectRequest.IsRequestAccpted;
            request.RequestMessage = (string.IsNullOrWhiteSpace(connectRequest.RequestMessage)) ? request.RequestMessage : connectRequest.RequestMessage;
            bool status = _dbCommand.Save();
            return new ActionReturn()
            {
                Id = connectRequest.Id,
                Status = status,
                Message = "Friend request removed."
            };
        }

        private DB.UserConnectRequest Assgin(Models.UserConnectRequest connectRequest)
        {
            if (connectRequest == null)
            {
                return null;
            }
            return new DB.UserConnectRequest()
            {
                Id = connectRequest.Id,
                ToId = connectRequest.ToId,
                FromId = connectRequest.FromId,
                Status = connectRequest.Status,
                IsBlocked = connectRequest.IsBlocked,
                RequestMessage = connectRequest.RequestMessage,
                IsRequestAccpted = connectRequest.IsRequestAccpted,
            };
        }

        private Models.UserConnectRequest Assgin(DB.UserConnectRequest connectRequest)
        {
            if (connectRequest == null)
            {
                return null;
            }
            return new Models.UserConnectRequest()
            {
                Id = connectRequest.Id,
                ToId = connectRequest.ToId,
                FromId = connectRequest.FromId,
                Status = connectRequest.Status,
                IsBlocked = connectRequest.IsBlocked,
                RequestMessage = connectRequest.RequestMessage,
                IsRequestAccpted = connectRequest.IsRequestAccpted,
            };
        }
    }
}