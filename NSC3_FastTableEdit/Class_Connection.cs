using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSC3_FastTableEdit
{
    static class Class_Connection
    {
        static public string connection_Server;
        static public string connection_Instance;
        static public string connection_Firm;
        static public string connection_Port;

        static public void SetConnection(string server, string instance, string firm, string port)
        {
            connection_Server = server;
            connection_Instance = instance;
            connection_Firm = firm;
            connection_Port = port;
        }
    }
}
