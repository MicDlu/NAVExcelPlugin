using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace NSC3_FastTableEdit
{
    static public class Class_Table
    {
        static string directoryPath = System.IO.Path.GetTempPath() + @"NAVTableEdit\";
        static string templatePath = directoryPath + @"Table templates.txt";
        
        static public string tableName;
        static public int tableNumber;
        static public List<String> tableFieldList = new List<string>();



        static public void SetTable(string name, List<String> fieldList)
        {
            tableNumber = Int32.Parse(name.Substring(0, name.IndexOf(' ')));
            tableName = name.Substring(name.IndexOf(' ') +1);
            tableFieldList = fieldList;
        }

        static public bool SaveTemplate(string templateName)
        {
            if (!System.IO.Directory.Exists(directoryPath))
                System.IO.Directory.CreateDirectory(directoryPath);
            if (!System.IO.File.Exists(templatePath))
                System.IO.File.Create(templatePath).Close();


            List<string> templateContent = new List<string>();
            templateContent.Add("#" + templateName);
            templateContent = templateContent.Concat(tableFieldList).ToList();
            List<string> fileContent = System.IO.File.ReadAllLines(templatePath).ToList();

            if (fileContent.Contains(templateContent[0]))
            {
                string oldTemplate = "-" + string.Join("\n-", tableFieldList.ToArray());
                string newTemplate = "-" + string.Join("\n-", templateContent.Skip(1).ToArray());
                string dialogText = "Do you want to overwrite template \"" + templateName + "\"?\n\n" + oldTemplate + "\n\nwith\n\n" + newTemplate;
                string dialogTitle = "\"" + templateName + "\" template overwrite";
                DialogResult dialogResult = MessageBox.Show(dialogText, dialogTitle, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    return false;

                int index = fileContent.IndexOf(templateContent[0]);
                while (fileContent.Count > index + 1 && !fileContent[index+1].StartsWith("#"))
                {
                    fileContent.RemoveAt(index);
                }

                fileContent.InsertRange(index, templateContent);
                System.IO.File.WriteAllLines(templatePath, fileContent);
            }
            else
            {
                templateContent.Add("");
                System.IO.File.AppendAllLines(templatePath, templateContent);
            }
            return true;
        }

        static public List<string> GetTemplateList()
        {
            List<string> templateList = new List<string>();
            if (!System.IO.File.Exists(templatePath))
                return templateList;

            string[] fileContent = System.IO.File.ReadAllLines(templatePath);
            foreach (var line in fileContent)
            {
                if (line.StartsWith("#"))
                {
                    templateList.Add(line.Substring(1));
                }
            }
            return templateList;
        }

        static public bool GetTemplate(string templateName)
        {
            if (!System.IO.File.Exists(templatePath))
                return false;

            List<string> fileContent = System.IO.File.ReadAllLines(templatePath).ToList();
            int index = fileContent.IndexOf("#" + templateName);

            if (tableFieldList.Any())
                tableFieldList.Clear();

            while (++index < fileContent.Count() && fileContent[index] != "")
            {
                tableFieldList.Add(fileContent[index]);
            }

            return true;
        }

        static public bool SetLastConnection()
        {
            bool conExists = false;
            foreach (Excel.Worksheet worksheet in Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets)
            {
                if (worksheet.Name == "Connections")
                {
                    conExists = true;
                    break;
                }
            }
            if (conExists)
            {
                Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets["Connections"];
                if (((Excel.Range)worksheet.Cells[1, 6]).Value2 == "LAST_CONNECTION")
                {
                    Class_Connection.SetConnection(((Excel.Range)worksheet.Cells[1, 7]).Text, (string)((Excel.Range)worksheet.Cells[1, 8]).Text, (string)((Excel.Range)worksheet.Cells[1, 9]).Text, (string)((Excel.Range)worksheet.Cells[1, 10]).Text);
                    Class_Connection.ConnectToWebService();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }

    

    public class Class_Column
    {
        public string TableNo;
        public string No;
        public string TableName;
        public string FieldName;
        public string Type;
        public string Len;
        public string Class;
        public string Enabled;
        public string FieldCaption;
        public string OptionString;

        public void SetColumns()
        {
            //
        }
    }
}
