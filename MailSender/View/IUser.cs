using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.View
{
    public interface IUser
    {
        public string Login { get;}
        public SecureString Password { get;}
    }
}
