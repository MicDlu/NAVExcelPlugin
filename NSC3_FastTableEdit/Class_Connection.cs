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
        static string directoryPath = System.IO.Path.GetTempPath() + @"NAVTableEdit\";
        static string connectionPath = directoryPath + @"Connections.txt";

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

        static public bool SaveConnection(string ConnectionName)
        {
            if (!System.IO.Directory.Exists(directoryPath))
                System.IO.Directory.CreateDirectory(directoryPath);
            if (!System.IO.File.Exists(connectionPath))
                System.IO.File.Create(connectionPath).Close();

            string[] ConnectionContent = new string[] { "#" + ConnectionName,
                "Server\t#" + connection_Server,
                "Instance\t#" + connection_Instance,
                "Firm\t\t#" + connection_Firm,
                "Port\t\t#" + connection_Port, "" };
            string[] fileContent = System.IO.File.ReadAllLines(connectionPath);

            if (fileContent.Contains(ConnectionContent[0]))
            {
                int index = Array.IndexOf(fileContent, ConnectionContent[0]);
                fileContent[index + 1] = "Server\t#" + connection_Server;
                fileContent[index + 2] = "Instance\t#" + connection_Instance;
                fileContent[index + 3] = "Firm\t\t#" + connection_Firm;
                fileContent[index + 4] = "Port\t\t#" + connection_Port;
                System.IO.File.WriteAllLines(connectionPath, fileContent);
            }
            else
            {
                System.IO.File.AppendAllLines(connectionPath, ConnectionContent);
            }
            return true;
        }

        static public List<string> GetTemplateList()
        {
            List<string> templateLists = new List<string>();
            if (!System.IO.File.Exists(connectionPath))
                return templateLists;

            string[] fileContent = System.IO.File.ReadAllLines(connectionPath);
            for (int i = 0; i < fileContent.Count(); i+=6)
            {
                templateLists.Add(fileContent[i].Substring(1));
            }
            return templateLists;
        }

        static public bool GetConnection(string ConnectionName)
        {
            if (!System.IO.File.Exists(connectionPath))
                return false;

            string[] fileContent = System.IO.File.ReadAllLines(connectionPath);
            int index = Array.IndexOf(fileContent, "#" + ConnectionName);
            connection_Server = fileContent[index + 1].Substring(fileContent[index + 1].IndexOf('#') + 1);
            connection_Instance = fileContent[index + 2].Substring(fileContent[index + 2].IndexOf('#') + 1);
            connection_Firm = fileContent[index + 3].Substring(fileContent[index + 3].IndexOf('#') + 1);
            connection_Port = fileContent[index + 4].Substring(fileContent[index + 4].IndexOf('#') + 1);
            return true;
        }
    }
}
