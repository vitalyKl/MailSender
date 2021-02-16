using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.View
{
    public interface IMailMessage
    {
        public string Subject { get; }
        public string MailBody { get; }
        public string Recipient { get; }
    }
}
