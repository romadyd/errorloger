using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogNotifier.Interface;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Net;

namespace LogNotifier.Model
{
    public class Notification : INotification
    {
        private string _appname;
        private List<MailAddress> _recipient = new List<MailAddress>();
        private List<Attachment> _attachments = new List<Attachment>();

        public Notification (string appname)
        {
            _appname = appname;
        }

        public virtual void SendNotification()
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential basicCredential = new NetworkCredential("yudi2610@gmail.com", "Success2018");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            smtpClient.EnableSsl = true;

            foreach (var recipient in _recipient)
            {
                MailMessage mail = new MailMessage(new MailAddress("noreply@lognotifier.com"), recipient);
                mail.Subject = $"LogNotifier Error Notification - {_appname}";
                mail.Body = $"Dear Administrator/Application Support\n\nYou have an error in your {_appname} Application.\nAs attached in this e-mail.";

                foreach (var attachment in _attachments)
                {
                    mail.Attachments.Add(attachment);
                }

                smtpClient.Send(mail);
            }
        }

        public void AddRecipient(string email)
        {
            _recipient.Add(new MailAddress(email));
        }

        public void AddAttachment(string filepath)
        {
            if(File.Exists(filepath))
            {
                _attachments.Add(new Attachment(filepath));
            }
        }
    }
}
