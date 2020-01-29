using System;
using System.Collections.Generic;
using System.Text;

namespace BearFTP
{
    class Active
    {
        public string hostname = "";
        public int connected = 0;

        public Active(string hostname, int connected)
        {
            this.hostname = hostname;
            this.connected = connected;
        }

        public static bool CheckExists(string hostname, List<Active> list)
        {
            foreach (Active act in list)
            {
                if (act.hostname == hostname)
                {
                    return true;
                }
            }
            return false;
        }

        public static int GetConnections(string hostname, List<Active> list)
        {
            foreach (Active act in list)
            {
                if (act.hostname == hostname)
                {
                    return act.connected;
                }
            }
            return -1;
        }

        public static void SetConnections(string hostname, List<Active> list, int connections)
        {
            foreach (Active act in list)
            {
                if (act.hostname == hostname)
                {
                    act.connected = connections;
                }
            }
        }
    }
}
