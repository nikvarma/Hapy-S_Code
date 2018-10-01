using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.Models
{
    public class UserCompDetail
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid CompId { get; set; }
        public Guid UUID { get; set; }
        public UserInfo UsersInfo { get; set; }
        public IEnumerable<CompDetail> CompDetail { get; set; }
        public bool IsActive { get; set; }
    }
}