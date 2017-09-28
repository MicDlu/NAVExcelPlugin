using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSC3_FastTableEdit
{
    static public class Class_Table
    {
        static string directoryPath = System.IO.Path.GetTempPath() + @"NAVTableEdit\";
        static string templatePath = directoryPath + @"Table templates.txt";
        
        static public string tableName;
        //static public List<Class_Column> tableColumns;
        static public List<String> tableFieldList = new List<string>();



        static public void SetTable(string name, List<String> fieldList)
        {
            tableName = name;
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
                DialogResult dialogResult = MessageBox.Show("Do you want to overwrite?", "Template overwrite", MessageBoxButtons.YesNo);
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
