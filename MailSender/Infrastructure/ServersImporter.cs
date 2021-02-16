using MailSender.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailSender.Infrastructure
{
    public class ServersImporter
    {
        private Regex _reg = new Regex(@"(?<serverName>\w+\.?\w*)\s(?<url>\w+\.\w+\.\w+)\s(?<port>\d+)", RegexOptions.Compiled);
        string dataPath = @"Data\Services.txt";
        public ObservableCollection<MailServer> servers = new ObservableCollection<MailServer>();
        

        public ServersImporter()
        {
            string input = "";
            using (StreamReader sr = new StreamReader(dataPath))
            {
                while (!sr.EndOfStream)
                {
                    input = sr.ReadLine();
                    var match = _reg.Match(input);
                    if (match == null) return;
                    servers.Add(new MailServer(match.Groups["serverName"].Value, match.Groups["url"].Value, Convert.ToInt32(match.Groups["port"].Value)));
                }
            }
        }
    }
}
