using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogNotifier.Interface;
using LogNotifier.Model;

namespace LogNotifier.Model
{
    public class Log : ILog
    {
        private string _appname;
        public DateTime TimeStamp { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public Log (string appname)
        {
            _appname = appname;
        }

        public virtual string Write ()
        {
            string logDir = "Log";
            string fileName = string.Format("Log_{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
            string filePath = string.Format("{0}//{1}", logDir, fileName);

            if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("TimeStamp : {0}", TimeStamp.ToString("yyyy-MM-dd hh:mm:ss"));
                writer.WriteLine("MethodName : {0}", Source);
                writer.WriteLine("Message : {0}", Message);
                writer.WriteLine("StackTrace : {0}", StackTrace);
                writer.WriteLine("");
            }

            return filePath.Replace("//", "\\");
        }
    }
}
