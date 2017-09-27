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

        static public bool SaveConnection(string ConnectionName)
        {
            string directoryPath = System.IO.Path.GetTempPath() + @"NAVTableEdit\";
            if (!System.IO.Directory.Exists(directoryPath))
                System.IO.Directory.CreateDirectory(directoryPath);
            string filePath = directoryPath + @"Connections.txt";
            if (!System.IO.File.Exists(filePath))
                System.IO.File.Create(filePath).Close();

            string[] ConnectionContent = new string[] { "#" + ConnectionName,
                "Server\t#" + connection_Server,
                "Instance\t#" + connection_Instance,
                "Firm\t\t#" + connection_Firm,
                "Port\t\t#" + connection_Port, "" };
            string[] fileContent = System.IO.File.ReadAllLines(filePath);

            if (fileContent.Contains(ConnectionContent[0]))
            {
                int index = Array.IndexOf(fileContent, ConnectionContent[0]);
                fileContent[index + 1] = "Server\t#" + connection_Server;
                fileContent[index + 2] = "Instance\t#" + connection_Instance;
                fileContent[index + 3] = "Firm\t\t#" + connection_Firm;
                fileContent[index + 4] = "Port\t\t#" + connection_Port;
                System.IO.File.WriteAllLines(filePath, fileContent);
            }
            else
            {
                System.IO.File.AppendAllLines(filePath, ConnectionContent);
            }

            return true;
        }

        static public List<string> GetTemplateList()
        {
            List<string> templateLists = new List<string>();
            string filePath = System.IO.Path.GetTempPath() + @"NAVTableEdit\Connections.txt";
            if (!System.IO.File.Exists(filePath))
                return templateLists;

            string[] fileContent = System.IO.File.ReadAllLines(filePath);
            for (int i = 0; i < fileContent.Count(); i+=6)
            {
                templateLists.Add(fileContent[i].Substring(1));
            }
            return templateLists;
        }

        static public bool GetConnection(string ConnectionName)
        {
            string filePath = System.IO.Path.GetTempPath() + @"NAVTableEdit\Connections.txt";
            if (!System.IO.File.Exists(filePath))
                return false;

            string[] fileContent = System.IO.File.ReadAllLines(filePath);
            int index = Array.IndexOf(fileContent, "#" + ConnectionName);
            connection_Server = fileContent[index + 1].Substring(fileContent[index + 1].IndexOf('#') + 1);
            connection_Instance = fileContent[index + 2].Substring(fileContent[index + 2].IndexOf('#') + 1);
            connection_Firm = fileContent[index + 3].Substring(fileContent[index + 3].IndexOf('#') + 1);
            connection_Port = fileContent[index + 4].Substring(fileContent[index + 4].IndexOf('#') + 1);
            return true;
            
        }
    }
}
