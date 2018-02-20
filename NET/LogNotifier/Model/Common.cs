using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogNotifier.Model
{
    public static class Common
    {
        public static string AppName()
        {
            return ConfigurationSettings.AppSettings["ApplicationName"];
        }

        public static string DefaultRecipient()
        {
            return ConfigurationSettings.AppSettings["ErrorNotification"];
        }
    }
}
