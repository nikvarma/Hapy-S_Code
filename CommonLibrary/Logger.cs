using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonLibrary
{
    public class LoggerDetail
    {
        public string Message { get; set; }
        public string MessageType { get; set; }
        public string ActionType { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
    }

    public static class Logger
    {
        public static void CreateLoggerDir()
        {
            Util.IsDirExists("Logger", true);
        }

        public static void AutoLogException(Exception exception, bool notifyIfloggerFail = false)
        {
            string _File = DateTime.Now.Hour.ToString();
            string _FolderDate = DateTime.Now.ToShortDateString();
            string _keyNofityValue = ConfigurationManager
                .AppSettings["notifyIfloggerFail"];
            bool _notifyIfloggerFail = Convert.ToBoolean
                ((!string.IsNullOrWhiteSpace(_keyNofityValue))
                ? _keyNofityValue : false.ToString());
            if (notifyIfloggerFail == false)
                notifyIfloggerFail = _notifyIfloggerFail;
            try
            {
                Util.IsDirExists("Logger/" + _FolderDate, true);
                Util.IsFileExists("Logger/" + _FolderDate + "/" + _File, true);
                string fileName = Util.ServerPath("Logger/" + _FolderDate);
                IEnumerable<string> _logtxt = new string[] {
                    "message - " + exception.Message,
                    " stacktrace " + exception.StackTrace,
                    " classname " + exception.GetType().FullName,
                    " methodname " + exception.GetType().Name,
                    " DateTime" + DateTime.Now.ToLongDateString()
                    +"------------------"+ DateTime.Now.ToLongDateString() +"---------------------"
                };

                File.AppendAllLines(fileName, _logtxt);
            }
            catch (Exception ex)
            {
                if (notifyIfloggerFail)
                {
                    try
                    {
                        SendMail.Send(new SendMail.SendDetails()
                        {

                        });
                    }
                    catch (Exception Ex)
                    {
                        throw;
                    }
                }
            }
        }

        public static void Log(LoggerDetail loggerDetail, bool notifyIfloggerFail = false)
        {
            string _File = DateTime.Now.Hour.ToString();
            string _FolderDate = DateTime.Now.ToShortDateString();
            string _keyNofityValue = ConfigurationManager
                .AppSettings["notifyIfloggerFail"];
            bool _notifyIfloggerFail = Convert.ToBoolean
                ((!string.IsNullOrWhiteSpace(_keyNofityValue))
                ? _keyNofityValue : false.ToString());
            if (notifyIfloggerFail == false)
                notifyIfloggerFail = _notifyIfloggerFail;
            try
            {
                Util.IsDirExists("Logger/" + _FolderDate, true);
                Util.IsFileExists("Logger/" + _FolderDate + "/" + _File, true);
                string fileName = Util.ServerPath("Logger/" + _FolderDate);
                IEnumerable<string> _logtxt = new string[] {
                    "message - " + loggerDetail.Message,
                    " messagetype " + loggerDetail.MessageType,
                    " actiontype " + loggerDetail.ActionType,
                    " classname " + loggerDetail.ClassName,
                    " methodname " + loggerDetail.MethodName,
                    "------------------"+ DateTime.Now.ToLongDateString() +"---------------------"
                };

                File.AppendAllLines(fileName, _logtxt);
            }
            catch (Exception ex)
            {
                if (notifyIfloggerFail)
                {
                    try
                    {
                        SendMail.Send(new SendMail.SendDetails()
                        {

                        });
                    }
                    catch (Exception Ex)
                    {
                        throw;
                    }
                }
            }
        }
    }
}
