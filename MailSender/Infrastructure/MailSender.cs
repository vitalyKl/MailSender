using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using MailSender.Models;
using MailSender.View;

namespace MailSender.Infrastructure
{
    public class MailSender
    {
        private string _login;
        private SecureString _password;
        private string _mailSubject;
        private string _mailBody;
        private string _recipient;
        private MailServer server;
        private SmtpClient client;



        public string Login
        {
            get => _login;
            private set => _login = value;
        }
        public SecureString Password
        {
            get => _password;
            private set => _password = value;
        }
        public string MailSubject { get => _mailSubject; private set => _mailSubject = value; }
        public string MailBody { get => _mailBody; private set => _mailBody = value; }
        public string Recipient { get => _recipient; private set => _recipient = value; }

        public MailSender()
        {

        }

        public void Authorize(MailServer server, string login, SecureString password)
        {
            MailMessage x = new MailMessage($"{login}", $"{login}");
            x.Subject = "Test";
            x.Body = "Test";
            x.IsBodyHtml = false;
            client = new SmtpClient(server.Url, server.Port);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential
            {
                UserName = login,
                SecurePassword = password
            };            
            client.Send(x);
        }
        public void Send(IUser user, IMailMessage message, MailServer server)
        {
            client = new SmtpClient(server.Url, server.Port);
            MailMessage x = new MailMessage(user.Login, message.Recipient);
            x.Subject = message.Subject;
            x.Body = message.MailBody;
            x.IsBodyHtml = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential
            {
                UserName = user.Login,
                SecurePassword = user.Password
            };
            client.Send(x);
        }
    }
}
