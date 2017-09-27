using System;
using System.Collections.Generic;
using System.IO;
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

        static public string SaveConnection(string ConnectionName)
        {
            string directoryPath = System.IO.Path.GetTempPath() + @"NAVTableEdit\";
            if (!Directory.Exists(directoryPath))
                System.IO.Directory.CreateDirectory(directoryPath);
            string filePath = directoryPath + @"Connections.txt";
            string[] ConnectionContent = new string[] { "# ConnectionName", connection_Server, connection_Instance, connection_Firm, connection_Port };
            System.IO.File.WriteAllLines(filePath, ConnectionContent);
            return filePath;
        }
    }
}
