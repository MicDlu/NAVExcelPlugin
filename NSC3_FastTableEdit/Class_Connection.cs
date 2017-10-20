using System;
using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace NSC3_FastTableEdit
{
    static class Class_Connection
    {
        //static public Excel.Workbook activeWorkbook = Globals.ThisAddIn.Application.ActiveWorkbook;

        static string directoryPath = System.IO.Path.GetTempPath() + @"NAVTableEdit\";
        static string connectionPath = directoryPath + @"Connections.txt";

        static public string connection_Server;
        static public string connection_Instance;
        static public string connection_Company;
        static public string connection_Port;
        static public NAVFieldsService.Fields_Binding navFieldsService = new NAVFieldsService.Fields_Binding();
        static public NAVFieldsService.FieldsCUExtension_Binding navCodeunitService = new NAVFieldsService.FieldsCUExtension_Binding();
        static public NAVFieldsService.TemplateService_Binding navTemplateService = new NAVFieldsService.TemplateService_Binding();
        static public NAVFieldsService.TemplatePage_Binding navTemplateReadService = new NAVFieldsService.TemplatePage_Binding();
        

        static public void SetConnection(string server, string instance, string firm, string port)
        {
            connection_Server = server;
            connection_Instance = instance;
            connection_Company = firm;
            connection_Port = port;
        }

        static public bool ConnectionsExist()
        {
            foreach (Excel.Worksheet worksheet in Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets)
            {
                if (worksheet.Name == "Connections")
                {
                    return true;
                }
            }
            return false;
        }

        static public void SaveLastConnection()
        {
            if (!ConnectionsExist())
            {
                Excel.Worksheet actWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
                Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Add(Type.Missing, Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Count]);
                worksheet.Name = "Connections";

                ((Excel.Range)worksheet.Cells[1, 6]).Value2 = "LAST_CONNECTION";
                ((Excel.Range)worksheet.Cells[1, 7]).Value2 = connection_Server;
                ((Excel.Range)worksheet.Cells[1, 8]).Value2 = connection_Instance;
                ((Excel.Range)worksheet.Cells[1, 9]).Value2 = connection_Company;
                ((Excel.Range)worksheet.Cells[1, 10]).Value2 = connection_Port;
                ((Excel.Range)worksheet.Range[worksheet.Cells[1, 6], worksheet.Cells[1, 10]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Firebrick);

                actWorksheet.Activate();
            }
            else
            {
                Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets["Connections"];

                ((Excel.Range)worksheet.Cells[1, 6]).Value2 = "LAST_CONNECTION";
                ((Excel.Range)worksheet.Cells[1, 7]).Value2 = connection_Server;
                ((Excel.Range)worksheet.Cells[1, 8]).Value2 = connection_Instance;
                ((Excel.Range)worksheet.Cells[1, 9]).Value2 = connection_Company;
                ((Excel.Range)worksheet.Cells[1, 10]).Value2 = connection_Port;
                ((Excel.Range)worksheet.Range[worksheet.Cells[1, 6], worksheet.Cells[1, 10]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Firebrick);
            }
        }

        static public void SaveConnection(string ConnectionName)
        {
            Globals.ThisAddIn.Application.ActiveWorkbook.Save();
            if (!ConnectionsExist())
            {
                Excel.Worksheet actWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
                Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Add(Type.Missing, Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Count]);
                worksheet.Name = "Connections";

                ((Excel.Range)worksheet.Cells[1, 1]).Value2 = "Name";
                ((Excel.Range)worksheet.Cells[1, 2]).Value2 = "Server";
                ((Excel.Range)worksheet.Cells[1, 3]).Value2 = "Instance";
                ((Excel.Range)worksheet.Cells[1, 4]).Value2 = "Company";
                ((Excel.Range)worksheet.Cells[1, 5]).Value2 = "Port";
                ((Excel.Range)worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                ((Excel.Range)worksheet.Cells[2, 1]).Value2 = ConnectionName;
                ((Excel.Range)worksheet.Cells[2, 2]).Value2 = connection_Server;
                ((Excel.Range)worksheet.Cells[2, 3]).Value2 = connection_Instance;
                ((Excel.Range)worksheet.Cells[2, 4]).Value2 = connection_Company;
                ((Excel.Range)worksheet.Cells[2, 5]).Value2 = connection_Port;
                ((Excel.Range)worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 5]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

                actWorksheet.Activate();
            }
            else
            {
                Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets["Connections"];
                if (((Excel.Range)worksheet.Cells[1, 1]).Text == "Name")
                {
                    int currentRow = 1, newRow = 0;
                    while (((Excel.Range)worksheet.Cells[currentRow, 1]).Value2 != null)
                    {
                        if (((Excel.Range)worksheet.Cells[currentRow, 1]).Value2 == ConnectionName)
                        {
                            newRow = currentRow;
                            break;
                        }
                        currentRow++;
                        newRow = currentRow;
                    }

                    ((Excel.Range)worksheet.Cells[newRow, 1]).Value2 = ConnectionName;
                    ((Excel.Range)worksheet.Cells[newRow, 2]).Value2 = connection_Server;
                    ((Excel.Range)worksheet.Cells[newRow, 3]).Value2 = connection_Instance;
                    ((Excel.Range)worksheet.Cells[newRow, 4]).Value2 = connection_Company;
                    ((Excel.Range)worksheet.Cells[newRow, 5]).Value2 = connection_Port;
                    ((Excel.Range)worksheet.Range[worksheet.Cells[newRow, 1], worksheet.Cells[newRow, 5]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                }
                else
                {
                    ((Excel.Range)worksheet.Cells[1, 1]).Value2 = "Name";
                    ((Excel.Range)worksheet.Cells[1, 2]).Value2 = "Server";
                    ((Excel.Range)worksheet.Cells[1, 3]).Value2 = "Instance";
                    ((Excel.Range)worksheet.Cells[1, 4]).Value2 = "Company";
                    ((Excel.Range)worksheet.Cells[1, 5]).Value2 = "Port";
                    ((Excel.Range)worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                    ((Excel.Range)worksheet.Cells[2, 1]).Value2 = ConnectionName;
                    ((Excel.Range)worksheet.Cells[2, 2]).Value2 = Class_Connection.connection_Server;
                    ((Excel.Range)worksheet.Cells[2, 3]).Value2 = Class_Connection.connection_Instance;
                    ((Excel.Range)worksheet.Cells[2, 4]).Value2 = Class_Connection.connection_Company;
                    ((Excel.Range)worksheet.Cells[2, 5]).Value2 = Class_Connection.connection_Port;
                    ((Excel.Range)worksheet.Range[worksheet.Cells[2, 1], worksheet.Cells[2, 5]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                }
               
            }
        }

        static public List<string> GetTemplateList()
        {
            List<string> templateLists = new List<string>();
            if (ConnectionsExist())
            {
                Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets["Connections"];
                int currentRow = 1;
                while (((Excel.Range)worksheet.Cells[currentRow, 1]).Value2 != null)
                {
                    if (((Excel.Range)worksheet.Cells[currentRow, 1]).Value2 != "Name")
                    {
                        templateLists.Add(((Excel.Range)worksheet.Cells[currentRow, 1]).Text);
                    }
                    currentRow++;
                }
            }
            return templateLists;
        }

        static public void GetConnection(int selectedIndex)
        {
            Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets["Connections"];
            connection_Server = ((Excel.Range)worksheet.Cells[selectedIndex+2, 2]).Text;
            connection_Instance = ((Excel.Range)worksheet.Cells[selectedIndex+2, 3]).Text;
            connection_Company = ((Excel.Range)worksheet.Cells[selectedIndex+2, 4]).Text;
            connection_Port = ((Excel.Range)worksheet.Cells[selectedIndex+2, 5]).Text;
        }

        static public bool GetLastConnection()
        {
            if (ConnectionsExist())
            {
                Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets["Connections"];
                if (((Excel.Range)worksheet.Cells[1, 6]).Value2 == "LAST_CONNECTION")
                {
                    connection_Server = ((Excel.Range)worksheet.Cells[1, 7]).Text;
                    connection_Instance = ((Excel.Range)worksheet.Cells[1, 8]).Text;
                    connection_Company = ((Excel.Range)worksheet.Cells[1, 9]).Text;
                    connection_Port = ((Excel.Range)worksheet.Cells[1, 10]).Text;
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

        //static public void 

        static public void ConnectToWebService()
        {
            string companyname = System.Uri.EscapeDataString(connection_Company.Trim());

            navFieldsService.Url = @"http://" + connection_Server + @":" + connection_Port + @"/" + connection_Instance + @"/WS/" + companyname + @"/" + "Page" + @"/" + "Fields";
            navFieldsService.UseDefaultCredentials = true;

            navCodeunitService.Url = @"http://" + connection_Server + @":" + connection_Port + @"/" + connection_Instance + @"/WS/" + companyname + @"/" + "Codeunit" + @"/" + "FieldsCUExtension";
            navCodeunitService.UseDefaultCredentials = true;

            navTemplateService.Url = @"http://" + connection_Server + @":" + connection_Port + @"/" + connection_Instance + @"/WS/" + companyname + @"/" + "Codeunit" + @"/" + "TemplateService";
            navTemplateService.UseDefaultCredentials = true;

            //navTemplateReadService.Url = @"http://" + connection_Server + @":" + connection_Port + @"/" + connection_Instance + @"/WS/" + companyname + @"/" + "Page" + @"/" + "TemplatePage";
            //navTemplateReadService.UseDefaultCredentials = true;

        }

        static bool TestConnection()
        {
            return false;
        }
    }
}
