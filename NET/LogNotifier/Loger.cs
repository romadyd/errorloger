using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogNotifier.Model;
using System.Configuration;

namespace LogNotifier
{
    public class Loger
    {
        private string _appname;
        private string _recipient;

        public Loger()
        {
            _appname = Common.AppName();
            _recipient = Common.DefaultRecipient();
        }

        public Loger(string appname, string recipient)
        {
            _appname = appname;
            _recipient = recipient;
        }

        public string Write(Exception ex)
        {
            Notification _notification = new Model.Notification(_appname);
            Log _log = new Model.Log(_appname)
            {
                TimeStamp = DateTime.Now,
                Message = ex.Message,
                Source = ex.Source,
                StackTrace = ex.StackTrace
            };

            string logFile = _log.Write();

            _notification.AddRecipient(_recipient);
            _notification.AddAttachment(logFile);
            _notification.SendNotification();

            return logFile;
        }
    }
}
