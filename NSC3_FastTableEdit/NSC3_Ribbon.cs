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
                if (Class_Table.SetLastConnection() && Class_Connection.connection_Company != "" && Class_Connection.connection_Instance != "" && Class_Connection.connection_Port != "" && Class_Connection.connection_Server != "")
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

            if (Form_TableColumnsLoad.typeDictionary == null)
                Form_TableColumnsLoad.CreateTypeDictionary(Class_Table.tableNumber.ToString());

            char invisible = '\u2063';
            int column = 1;
            bool headerPresent = false;
            while(((Excel.Range)activeWorksheet.Cells[3, column]).Value2 != null)
            {
                string text = ((Excel.Range)activeWorksheet.Cells[3, column]).Text;
                if (text.Contains(invisible))
                {
                    headerPresent = true;
                    ((Excel.Range)activeWorksheet.Cells[3, column]).Value2 = null;
                }
                column++;
            }

            if(!headerPresent)
            {
                Excel.Range line = (Excel.Range)activeWorksheet.Rows[3];
                line.Insert(Excel.XlInsertShiftDirection.xlShiftDown,false);
            }
            int iterator = 0;
            for (int i = 0; i < headerList.Count; i++)
            {
                iterator = i + 1;
                
                ((Excel.Range)activeWorksheet.Cells[3, iterator]).Value2 = invisible + headerList[i];
                ((Excel.Range)activeWorksheet.Cells[3, iterator]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
                ((Excel.Range)activeWorksheet.Cells[3, iterator]).ColumnWidth = 15;
                ((Excel.Range)activeWorksheet.Range[activeWorksheet.Cells[3, 1], activeWorksheet.Cells[3, headerList.Count]]).EntireColumn.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                string trimmedHeader;
                trimmedHeader = headerList[i].TrimStart('*');
                trimmedHeader = trimmedHeader.TrimStart(' ');
                ((Excel.Range)activeWorksheet.Cells[2, iterator]).Value2 = invisible + Form_TableColumnsLoad.typeDictionary[trimmedHeader];
                ((Excel.Range)activeWorksheet.Cells[2, iterator]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
                ((Excel.Range)activeWorksheet.Cells[2, iterator]).ColumnWidth = 15;
                ((Excel.Range)activeWorksheet.Range[activeWorksheet.Cells[2, 1], activeWorksheet.Cells[3, headerList.Count]]).EntireColumn.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            ((Excel.Range)activeWorksheet.Cells[1, 1]).Value2 = invisible + Class_Template.currentTemplate.Name;
            ((Excel.Range)activeWorksheet.Cells[1, 2]).Value2 = invisible + Class_Table.tableName;

            Globals.ThisAddIn.Application.Cells.Locked = false;
            ((Excel.Range)activeWorksheet.Cells[1, 1]).Locked = true;
            ((Excel.Range)activeWorksheet.Cells[1, 1]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
            ((Excel.Range)activeWorksheet.Cells[1, 2]).Locked = true;
            ((Excel.Range)activeWorksheet.Cells[1, 2]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
            ((Excel.Range)activeWorksheet.Range[activeWorksheet.Cells[2, 1], activeWorksheet.Cells[2, headerList.Count]]).Locked = true;
            activeWorksheet.Protect();
        }

        private void button_SendToNAV_Click(object sender, RibbonControlEventArgs e)
        {
            if (WorkbookMeetsUsageCriteria())
            {
                if (Class_Table.SetLastConnection() && Class_Connection.connection_Company != "" && Class_Connection.connection_Instance != "" && Class_Connection.connection_Port != "" && Class_Connection.connection_Server != "")
                {
                    if (Class_Template.currentTemplate == null)
                    {
                        char invisible = '\u2063';
                        Excel.Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
                        string cell = ((Excel.Range)activeWorksheet.Cells[1, 1]).Text;
                        if (cell.Contains(invisible))
                        {
                            string noInvCell = cell.Substring(cell.IndexOf(invisible) + 1);
                            noInvCell = noInvCell.ToUpper();
                            List<Class_Template> tempList = Class_Table.GetTemplateList();
                            int index = tempList.FindIndex(f => f.Name == noInvCell);
                            if (index >= 0)
                            {
                                Class_Template.currentTemplate = tempList[index];
                                Class_Table.SetTable(Class_Template.currentTemplate.TableNo,                     Class_Template.currentTemplate.Fields);
                                Globals.ThisAddIn.Application.ActiveWorkbook.Save();
                                SaveDataToXML();
                                if(!errorOccured)
                                    MessageBox.Show("Successfully inserted records", "Success", MessageBoxButtons.OK,           MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please insert a header and template first", "No header and template", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        Class_Table.SetTable(Class_Template.currentTemplate.TableNo, Class_Template.currentTemplate.Fields);
                        Globals.ThisAddIn.Application.ActiveWorkbook.Save();

                        SaveDataToXML();
                        if(!errorOccured)
                            MessageBox.Show("Successfully inserted records", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        errorOccured = false;
                    }
                }
                else
                {
                    MessageBox.Show("Please choose the connection first", "No connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

            XmlElement tableName = NewElement("tablename");
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
            int rowCounter = 4;

            currentTableChosenColumns = Class_Table.tableFieldList;

            if (Form_TableColumnsLoad.numberDictionary == null)
                Form_TableColumnsLoad.CreateDictionary(Class_Table.tableNumber.ToString());

            while (true)
            {
                bool rowIsEmpty = true;
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
                   

                    XmlElement field = NewElement("f" + Form_TableColumnsLoad.numberDictionary[key].ToString());
                    XmlText text = NewText(((Excel.Range)activeWorksheet.Cells[rowCounter, i + 1]).Text);

                    if (text.Value != "")
                        rowIsEmpty = false;

                    field.AppendChild(text);
                    record.AppendChild(field);
                }
                if (rowIsEmpty)
                    break;

                tableContent.AppendChild(record);
                rowCounter++;
                //data.Save(@"C:/datata.txt");
            }
            try
            {
                //MessageBox.Show(Class_Connection.navCodeunitService.UseDefaultCredentials.ToString());
                //MessageBox.Show(Class_Connection.navCodeunitService.Url);
                Class_Connection.navCodeunitService.ProcessData(data.InnerXml);
            }
            catch(Exception ex)
            {
                string exceptionMessage = ex.Message;
                MessageBox.Show(exceptionMessage, "NAV Processing exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorOccured = true;
                
            }
            //data.Save(@"C:\data.xml");
        }
        XmlDocument data = new XmlDocument();
        List<string> currentTableChosenColumns = Class_Table.tableFieldList;
        bool errorOccured = false;
    }
}
