using MailSender.View;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.Infrastructure
{
    class MessagesRepository
    {
        private List<Message> _messages;

        public MessagesRepository()
        {
            _messages = Enumerable.Range(1, 10).Select(i => new Message
            {
                MailBody = $"Тело сообщения {i}",
                Subject = $"Заголовок письма {i}"
            }).ToList();
        }
        public IEnumerable<Message> GetAll() => _messages;
        public void Add(Message message)
        {
            _messages.Add(message);
        }
        public void Delete(Message message)
        {
            _messages.Remove(message);
        }
    }
}
