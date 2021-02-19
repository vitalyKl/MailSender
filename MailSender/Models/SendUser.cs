using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Models
{
    class SendUser: User
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
