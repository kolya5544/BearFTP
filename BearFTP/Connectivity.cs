using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace BearFTP
{
    class Connectivity
    {

        //A class used as a bridge between MAIN port and PASV port.
        public StreamWriter sw;
        public StreamReader sr;
        public TcpClient tcp;
        public bool transfer = false;
    }
}
