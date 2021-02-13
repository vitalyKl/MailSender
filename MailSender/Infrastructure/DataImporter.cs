using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailSender.Infrastructure
{
    public class DataImporter
    {
        private Regex _reg = new Regex(@"(?<serverName>\w*\.*\w*)\s(?<url>\w*\.\w*\.\w*)\s(?<port>\d*)\s");
        

        public DataImporter()
        {

        }
    }
}
