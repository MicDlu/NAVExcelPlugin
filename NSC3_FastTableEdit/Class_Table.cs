using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
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

        static public void SetTable(int number , List<string> fieldList)
        {
            tableName = "";
            tableNumber = number;
            tableFieldList = fieldList;
        }

        //static public void SetTable(int number, )
      //  {

       // }

        static public List<Class_Template> GetTemplateList()
        {
            List<Class_Template> returnList = new List<Class_Template>();
            
            string xmlString = Class_Connection.navTemplateService.ListTemplates();

            XmlDocument templates = new XmlDocument();
            templates.LoadXml(xmlString);

            XmlNodeList templateList = templates.SelectNodes("//template");

            foreach(XmlNode template in templateList)
            {
                XmlNode name = template.SelectSingleNode(".//name");
                XmlNode tabNo = template.SelectSingleNode(".//tabno");
                Class_Template templateObject = new Class_Template(name.InnerText, Int32.Parse(tabNo.InnerText));
                XmlNodeList fields = template.SelectNodes(".//field");

                foreach(XmlNode field in fields)
                {
                    templateObject.Fields.Add(field.InnerText);
                }
                returnList.Add(templateObject);
            }
            return returnList;
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
