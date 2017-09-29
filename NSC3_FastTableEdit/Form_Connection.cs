using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace NSC3_FastTableEdit
{
    public partial class Form_Connection : Form
    {
        Excel.Workbook activeWorkbook = Globals.ThisAddIn.Application.ActiveWorkbook;

        public Form_Connection()
        {
            InitializeComponent();
        }

        public void SetConnectionParams()
        {
            Class_Connection.SetConnection(textBox_Server.Text, textBox_Instance.Text, textBox_Firm.Text, textBox_Port.Text);
        }

        private void Form_Connection_Load(object sender, EventArgs e)
        {
            Class_Connection.GetConnection("LAST_CONNECTION");
            textBox_Server.Text = Class_Connection.connection_Server;
            textBox_Instance.Text = Class_Connection.connection_Instance;
            textBox_Firm.Text = Class_Connection.connection_Company;
            textBox_Port.Text = Class_Connection.connection_Port;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            SetConnectionParams();
            Class_Connection.ConnectToWebService();
            Class_Connection.SaveConnection("LAST_CONNECTION");
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SetConnectionParams();
            //if (true)   //  test
            //    Class_Connection.SaveConnection(comboBox_Templates.Text);
            bool conExists = false;
            foreach(Excel.Worksheet worksheet in Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets)
            {
                if(worksheet.Name == "Connections")
                {
                    conExists = true;
                    break;
                }
            }
            if(!conExists)
            {
                Excel.Worksheet actWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
                Excel.Worksheet worksheet = activeWorkbook.Worksheets.Add(Type.Missing, activeWorkbook.Worksheets[activeWorkbook.Worksheets.Count]);
                worksheet.Name = "Connections";

                ((Excel.Range)worksheet.Cells[1, 1]).Value2 = "Name";
                ((Excel.Range)worksheet.Cells[1, 2]).Value2 = "Server";
                ((Excel.Range)worksheet.Cells[1, 3]).Value2 = "Instance";
                ((Excel.Range)worksheet.Cells[1, 4]).Value2 = "Company";
                ((Excel.Range)worksheet.Cells[1, 5]).Value2 = "Port";
                ((Excel.Range)worksheet.Range[worksheet.Cells[1,1],worksheet.Cells[1,5]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                ((Excel.Range)worksheet.Cells[2, 1]).Value2 = comboBox_Templates.Text;
                ((Excel.Range)worksheet.Cells[2, 2]).Value2 = Class_Connection.connection_Server;
                ((Excel.Range)worksheet.Cells[2, 3]).Value2 = Class_Connection.connection_Instance;
                ((Excel.Range)worksheet.Cells[2, 4]).Value2 = Class_Connection.connection_Company;
                ((Excel.Range)worksheet.Cells[2, 5]).Value2 = Class_Connection.connection_Port;
                ((Excel.Range)worksheet.Range[worksheet.Cells[2,1],worksheet.Cells[2,5]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

                actWorksheet.Activate();
            }
            else
            {
                //Excel.Worksheet worksheet = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets["Connections"];

                Excel.Worksheet worksheet = activeWorkbook.Worksheets["Connections"];
                
                int currentRow = 1, newRow = 0;
                while(((Excel.Range)worksheet.Cells[currentRow, 1]).Value2 != null)
                {
                    if(((Excel.Range)worksheet.Cells[currentRow, 1]).Value2 == comboBox_Templates.Text)
                    {
                        newRow = currentRow;
                        break;
                    }
                    currentRow++;
                    newRow = currentRow;
                }

                ((Excel.Range)worksheet.Cells[newRow, 1]).Value2 = comboBox_Templates.Text;
                ((Excel.Range)worksheet.Cells[newRow, 2]).Value2 = Class_Connection.connection_Server;
                ((Excel.Range)worksheet.Cells[newRow, 3]).Value2 = Class_Connection.connection_Instance;
                ((Excel.Range)worksheet.Cells[newRow, 4]).Value2 = Class_Connection.connection_Company;
                ((Excel.Range)worksheet.Cells[newRow, 5]).Value2 = Class_Connection.connection_Port;
                ((Excel.Range)worksheet.Range[worksheet.Cells[newRow, 1], worksheet.Cells[newRow, 5]]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

                // = (Excel.Worksheet)Globals.ThisAddIn.Application.ActiveWorkbook.;

            }

        }

        private void comboBox_Templates_DropDown(object sender, EventArgs e)
        {
            comboBox_Templates.Items.Clear();
            comboBox_Templates.Items.AddRange(Class_Connection.GetTemplateList().ToArray());
        }

        private void comboBox_Templates_SelectedValueChanged(object sender, EventArgs e)
        {
            Class_Connection.GetConnection(comboBox_Templates.Text);
            textBox_Server.Text = Class_Connection.connection_Server;
            textBox_Instance.Text = Class_Connection.connection_Instance;
            textBox_Firm.Text = Class_Connection.connection_Company;
            textBox_Port.Text = Class_Connection.connection_Port;
        }
    }
}
