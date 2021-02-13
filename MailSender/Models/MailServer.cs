using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Models
{
    public class MailServer
    {
        private string _serverName;
        private string _url;
        private int _port;

        public string ServerName
        {
            get => _serverName;
            private set => _serverName = value;
        }
        public string Url
        {
            get => _url;
            private set => _url = value;
        }
        public int Port
        {
            get => _port;
            private set => _port = value;
        }

        public MailServer(string serverName, string url, int port)
        {
            ServerName = serverName;
            Url = url;
            Port = port;
        }
    }
}
