using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Xml;

namespace NSC3_FastTableEdit
{
    public partial class NSC3_Ribbon
    {

        private void NSC3_Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        public static bool WorkbookMeetsUsageCriteria()
        {
            if (Globals.ThisAddIn.Application.ActiveWorkbook.Path != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please save the worksheet first", "Worksheet not saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LoadConnection()
        {
            string SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\NAVExcelInferfaceFiles\Config.txt";
            string[] separator = { @"@#$%" };

            if (File.Exists(SettingsPath) && !Class_Connection.ConnectionsExist())
            {
                char[] charSeparators = new char[] { '\n' };
                string[] contents = File.ReadAllText(SettingsPath).Replace("\r", "").Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

                Excel.Worksheet actWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
                Excel.Worksheet lastWorksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets[Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Count];
                Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets.Add(After:lastWorksheet);

                worksheet.Name = "Connections";
                bool foundTemplates = false;
                int writeRow = 2;
                foreach (string connection in contents)
                {
                    if (connection.StartsWith("LAST_CONNECTION"))
                    {
                        string[] connectionData = connection.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        ((Excel.Range)worksheet.Cells[1, 6]).Value2 = "LAST_CONNECTION";
                        ((Excel.Range)worksheet.Cells[1, 7]).Value2 = connectionData[1];
                        ((Excel.Range)worksheet.Cells[1, 8]).Value2 = connectionData[2];
                        ((Excel.Range)worksheet.Cells[1, 9]).Value2 = connectionData[3];
                        ((Excel.Range)worksheet.Cells[1, 10]).Value2 = connectionData[4];
                        ((Excel.Range)worksheet.Range[worksheet.Cells[1, 6], worksheet.Cells[1, 10]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Firebrick);
                    }
                    else
                    {
                        string[] connectionData = connection.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        foundTemplates = true;
                        ((Excel.Range)worksheet.Cells[writeRow, 1]).Value2 = connectionData[0];
                        ((Excel.Range)worksheet.Cells[writeRow, 2]).Value2 = connectionData[1];
                        ((Excel.Range)worksheet.Cells[writeRow, 3]).Value2 = connectionData[2];
                        ((Excel.Range)worksheet.Cells[writeRow, 4]).Value2 = connectionData[3];
                        ((Excel.Range)worksheet.Cells[writeRow, 5]).Value2 = connectionData[4];
                        ((Excel.Range)worksheet.Range[worksheet.Cells[writeRow, 1], worksheet.Cells[writeRow, 5]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                        writeRow++;
                    }
                    if (foundTemplates)
                        GenerateHeader();
                }
                actWorksheet.Activate();
            }
        }

        private void GenerateHeader()
        {
            Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets["Connections"];

            ((Excel.Range)worksheet.Cells[1, 1]).Value2 = "Name";
            ((Excel.Range)worksheet.Cells[1, 2]).Value2 = "Server";
            ((Excel.Range)worksheet.Cells[1, 3]).Value2 = "Instance";
            ((Excel.Range)worksheet.Cells[1, 4]).Value2 = "Company";
            ((Excel.Range)worksheet.Cells[1, 5]).Value2 = "Port";
            ((Excel.Range)worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 5]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
        }

        private void button_LoadTableHeader_Click(object sender, RibbonControlEventArgs e)
        {
            if (WorkbookMeetsUsageCriteria())
            {
                Globals.ThisAddIn.Application.ActiveWorkbook.Save();
                LoadConnection();
                if (Class_Table.SetLastConnection())
                {
                    Form_TableColumnsLoad loadHeaderForm = new Form_TableColumnsLoad();
                    if (loadHeaderForm.ShowDialog() == DialogResult.OK)
                    {
                        currentTableChosenColumns = loadHeaderForm.Columns();
                        CreateTableHeader(currentTableChosenColumns);
                    }
                }
                else
                {
                    MessageBox.Show("Please choose the connection first", "No connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Clear entire header row and set new header cells
        private static void CreateTableHeader(List<string> headerList)
        {
            Excel.Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
            activeWorksheet.Unprotect();
            Globals.ThisAddIn.Application.Cells.Locked = false;
            activeWorksheet.UsedRange.EntireColumn.ClearFormats();
            activeWorksheet.UsedRange.EntireColumn.Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            for (int i = 0; i < headerList.Count; i++)
            {
                int iterator = i + 1;
                char invisible = '\u2063';
                ((Excel.Range)activeWorksheet.Cells[1, iterator]).Value2 = invisible + headerList[i];
                ((Excel.Range)activeWorksheet.Cells[1, iterator]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
                ((Excel.Range)activeWorksheet.Cells[1, iterator]).ColumnWidth = 15;
                ((Excel.Range)activeWorksheet.Range[activeWorksheet.Cells[1, 1], activeWorksheet.Cells[1, headerList.Count]]).EntireColumn.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            Globals.ThisAddIn.Application.Cells.Locked = false;
            ((Excel.Range)activeWorksheet.Range[activeWorksheet.Cells[1, 1], activeWorksheet.Cells[1, headerList.Count]]).Locked = true;
            activeWorksheet.Protect();
        }

        private void button_SendToNAV_Click(object sender, RibbonControlEventArgs e)
        {
            if (WorkbookMeetsUsageCriteria())
            {
                Globals.ThisAddIn.Application.ActiveWorkbook.Save();
                SaveDataToXML();
            }
            //Class_ValidateRecords.SelectRows();
        }

        private void buttonSetConnection_Click(object sender, RibbonControlEventArgs e)
        {
            if (WorkbookMeetsUsageCriteria())
            {
                Globals.ThisAddIn.Application.ActiveWorkbook.Save();
                Form_Connection connectionForm = new Form_Connection();
                if (connectionForm.ShowDialog() == DialogResult.OK)
                {
                    connectionForm.SetConnectionParams();
                }
            }
        }

        private XmlElement NewElement(string name)
        {
            return data.CreateElement(string.Empty, name, string.Empty);
        }

        private XmlText NewText(string content)
        {
            return data.CreateTextNode(content);
        }

        private void SaveDataToXML()
        {
            data = new XmlDocument();
            XmlDeclaration declaration = data.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = data.DocumentElement;
            data.InsertBefore(declaration, root);

            XmlElement table = NewElement("table");
            XmlElement tableData = NewElement("tabledata");
            XmlElement tableContent = NewElement("tablecontent");

            XmlElement tableName = NewElement("tablenumber");
            XmlText name = NewText(Class_Table.tableName);
            tableName.AppendChild(name);

            XmlElement tableNumber = NewElement("tableno");
            XmlText number = NewText(Class_Table.tableNumber.ToString());
            tableNumber.AppendChild(number);

            tableData.AppendChild(tableNumber);
            tableData.AppendChild(tableName);

            table.AppendChild(tableData);
            table.AppendChild(tableContent);
            data.AppendChild(table);

            Excel.Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
            int rowCounter = 2;
            while (((Excel.Range)activeWorksheet.Cells[rowCounter, 1]).Value2 != null)
            {
                //List<string> chosenFields = Form_TableColumnsLoad.Columns();
                XmlElement record = NewElement("record");
                for (int i=0; i < currentTableChosenColumns.Count; i++)
                {
                    string key;
                    if(currentTableChosenColumns[i].StartsWith("*"))
                    {
                        key = currentTableChosenColumns[i].Substring(currentTableChosenColumns[i].IndexOf("* ")+2);
                    }
                    else
                    {
                        key = currentTableChosenColumns[i];
                    }
                    XmlElement field = NewElement(Form_TableColumnsLoad.numberDictionary[key].ToString());
                    XmlText text = NewText(((Excel.Range)activeWorksheet.Cells[rowCounter, i + 1]).Text);
                    field.AppendChild(text);
                    record.AppendChild(field);
                }
                tableContent.AppendChild(record);
                rowCounter++;
            }
            
            data.Save(@"C:\data.xml");
        }
        XmlDocument data = new XmlDocument();
        List<string> currentTableChosenColumns;
    }
}
