using System;
using System.Net;
using System.Net.Mail;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var from = new MailAddress("vital5991@yandex.ru", "Vitali");
            var to = new MailAddress("vital5991@yandex.ru", "Vitali");
            var message = new MailMessage(from, to);
            message.Body = "YO!";
            message.Subject = "YO!";


            var client = new SmtpClient("smpt.yandex.ru", 465);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential
            {
                UserName = "mstester27102020@yandex.ru",
                Password = "mstester27102020"
            };

            client.Send(message);
        }
    }
}
