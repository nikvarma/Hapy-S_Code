using CommonLibrary;
using Hapy.DB;
using Hapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.MiddelLayer
{
    public class AppUserSettings : DbCommands<DB.AppUserSettings>, IAppUserSettings
    {
        Dictionary<string, FilterCondition> filter;
        private DbCommands<DB.AppUserSettings> _dbCommands;
        public AppUserSettings()
        {
            filter = new Dictionary<string, FilterCondition>();
            _dbCommands = new DbCommands<DB.AppUserSettings>();
        }

        public ActionReturn Insert(Models.AppUserSettings settings)
        {
            filter.Add("Uid", new FilterCondition()
            {
                Operation = CommonLibrary.Operation.EqualTo,
                Value = settings.Uid.ToString()
            });
            filter.Add("isactive", new FilterCondition()
            {
                Operation = CommonLibrary.Operation.EqualTo,
                Value = "true"
            });
            DB.AppUserSettings userSettings = _dbCommands.FetchRecords<DB.AppUserSettings>(new Filter()
            {
                FilterOn = filter
            }).SingleOrDefault();
            if (userSettings != null)
            {
                return new ActionReturn() { Id = userSettings.SId, Status = userSettings.Status };
            }
            userSettings = Assgin(settings);
            _dbCommands.Insert(userSettings);
            bool status = _dbCommands.Save();
            return new ActionReturn() { Id = userSettings.SId, Status = status };
        }

        public ActionReturn Update(Models.AppUserSettings settings)
        {
            _dbCommands.ActionState(Assgin(settings), System.Data.Entity.EntityState.Modified);
            bool status = _dbCommands.Save();
            return new ActionReturn() { Id = settings.Id, Status = status };
        }

        public IEnumerable<Models.AppUserSettings> Get(SearchParams search)
        {
            List<Models.AppUserSettings> settingList = new List<Models.AppUserSettings>();
            _dbCommands.FetchRecords<DB.AppUserSettings>(new Filter() { FilterOn = search.FilterOn }).ToList().ForEach(x =>
              {
                  settingList.Add(Assgin(x));
              });
            return settingList;
        }

        internal Models.AppUserSettings Assgin(DB.AppUserSettings settings)
        {
            if (settings == null)
            {
                return new Models.AppUserSettings();
            }
            return new Models.AppUserSettings()
            {
                Id = settings.SId,
                Uid = settings.Uid,
                ArchiveChat = settings.ArchiveChat,
                AutoCallRecorder = settings.SAutoCallRecorder,
                Backup = settings.MBackup,
                BackupChat = settings.BackupChat,
                DeleteCallLogs = settings.SDeleteCallLogs,
                DeleteChat = settings.DeleteChat,
                HIdeDeliveredStatus = settings.SHIdeDeliveredStatus,
                HideProfile = settings.SHideProfile,
                HideStatus = settings.SHideStatus,
                Notification = settings.MNotification,
                Location = settings.MSettingLocation,
                PostVisible = settings.SPostVisible,
                SettingLocation = settings.SLocation,
                ShowCallerId = settings.SShowCallerId,
                VideoCall = settings.SVideoCall,
                VideoCallVolumn = settings.SVideoCallVolumn,
                VisibletoContactList = settings.SVisibletoContactList,
                VoiceCall = settings.SVoiceCall,
                VoiceCallVolumn = settings.SVoiceCallVolumn,
                MSettingLocation = settings.MSettingLocation,
                PostOnWall = settings.PostOnWall,
                Volumn = settings.SVolumn,
                Status = settings.Status,
                isActive = settings.isActive
            };
        }

        internal DB.AppUserSettings Assgin(Models.AppUserSettings settings)
        {
            if (settings == null)
            {
                return new DB.AppUserSettings();
            }
            return new DB.AppUserSettings()
            {
                SId = settings.Id,
                Uid = settings.Uid,
                ArchiveChat = settings.ArchiveChat,
                BackupChat = settings.BackupChat,
                DeleteChat = settings.DeleteChat,
                MNotification = settings.Notification,
                MSettingLocation = settings.Location,
                SAutoCallRecorder = settings.AutoCallRecorder,
                SDeleteCallLogs = settings.DeleteCallLogs,
                SHIdeDeliveredStatus = settings.HIdeDeliveredStatus,
                SHideStatus = settings.HideStatus,
                SHideProfile = settings.HideProfile,
                SLocation = settings.SettingLocation,
                MBackup = settings.Backup,
                SPostVisible = settings.PostVisible,
                SShowCallerId = settings.ShowCallerId,
                SVideoCall = settings.VideoCall,
                SVideoCallVolumn = settings.VideoCallVolumn,
                SVisibletoContactList = settings.VisibletoContactList,
                SVoiceCall = settings.VoiceCall,
                SVoiceCallVolumn = settings.VoiceCallVolumn,
                PostOnWall = settings.PostOnWall,
                SVolumn = settings.Volumn,
                Status = settings.Status,
                isActive = settings.isActive
            };
        }
    }
}
