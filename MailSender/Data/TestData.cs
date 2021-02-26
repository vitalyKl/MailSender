using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Data
{
    public static class TestData
    {
        public static List<RecipientUser> Reccipients { get; } = Enumerable.Range(1, 10)
            .Select(i => new RecipientUser
            {
                Name = $"Получатель {i}",
                Surname = $"Фамилия {i}",
                MailAdress = $"recipient{i}@mail.ru"
            }).ToList();

        public static List<SendUser> SendUsers { get; } = Enumerable.Range(1, 10)
            .Select(i => new SendUser
            {
                Name = $"sender{i}",
                Surname = $"senderSurname{i}",
                MailAdress = $"sendMail{i}@gmail.com",
                Login = $"login{i}",
                Password = new SecureString()
            }).ToList();
    }
}
