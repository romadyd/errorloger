using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LogNotifier.Interface
{
    interface INotification
    {
        void SendNotification();
        void AddRecipient(string recipient);
        void AddAttachment(string filepath);
    }
}
