using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BearFTP
{
    class Client
    {
        public string username;
        public string password;
        public string hostname;
        public string directory = "/";

        public bool Connected = true;
        public bool passive = false;

        public Client(string username, string password, string hostname)
        {
            this.username = username;
            this.password = password;
            this.hostname = hostname;
        }
    }
}
