using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class SendMail
    {
        public class SendDetails
        {
            public string Subject { get; set; }
            public string Body { get; set; }
            public bool IsImportant { get; set; }
            public bool isAttachment { get; set; }
            public List<string> ToAddress { get; set; }
            public List<string> FromAddress { get; set; }
            public List<string> CCAddress { get; set; }
            public List<string> BCCAddress { get; set; }
            public List<string> Attachment { get; set; }
        }

        public static void Send(SendDetails sendDetails)
        {

        }
    }
}
