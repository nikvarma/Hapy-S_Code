using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class AppUserSettings
    {
        public Guid Id { get; set; }
        public Guid Uid { get; set; }
        public bool VoiceCall { get; set; }
        public bool VideoCall { get; set; }
        public bool ShowCallerId { get; set; }
        public bool AutoCallRecorder { get; set; }
        public bool DeleteCallLogs { get; set; }
        public bool Volumn { get; set; }
        public bool VoiceCallVolumn { get; set; }
        public bool VideoCallVolumn { get; set; }
        public bool HideStatus { get; set; }
        public bool HIdeDeliveredStatus { get; set; }
        public bool HideProfile { get; set; }
        public bool VisibletoContactList { get; set; }
        public int DeleteChat { get; set; }
        public int ArchiveChat { get; set; }
        public int BackupChat { get; set; }
        public bool Location { get; set; }
        public string PostVisible { get; set; }
        public string PostOnWall { get; set; }
        public bool MSettingLocation { get; set; }
        public bool SettingLocation { get; set; }
        public bool Backup { get; set; }
        public bool Notification { get; set; }
        public bool isActive { get; set; }
        public bool Status { get; set; }
    }
}
