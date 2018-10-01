using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DB
{
    public class AppUserSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SId { get; set; }


        public Guid Uid { get; set; }
        [ForeignKey("Uid")]
        public UsersInfo UsersInfo { get; set; }

        public bool SVoiceCall { get; set; }
        public bool SVideoCall { get; set; }
        public bool SShowCallerId { get; set; }
        public bool SAutoCallRecorder { get; set; }
        public bool SDeleteCallLogs { get; set; }
        public bool SVolumn { get; set; }
        public bool SVoiceCallVolumn { get; set; }
        public bool SVideoCallVolumn { get; set; }
        public bool SHideStatus { get; set; }
        public bool SHIdeDeliveredStatus { get; set; }
        public bool SHideProfile { get; set; }
        public bool SVisibletoContactList { get; set; }
        public int DeleteChat { get; set; }
        public int ArchiveChat { get; set; }
        public int BackupChat { get; set; }
        public bool SLocation { get; set; }
        public string SPostVisible { get; set; }
        public string PostOnWall { get; set; }
        public bool MSettingLocation { get; set; }
        public bool MBackup { get; set; }
        public bool MNotification { get; set; }
        public bool isActive { get; set; }
        public bool Status { get; set; }
    }
}
