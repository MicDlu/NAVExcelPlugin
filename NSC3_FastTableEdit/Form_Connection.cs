using System;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace NSC3_FastTableEdit
{
    public partial class Form_Connection : Form
    {
        public Form_Connection()
        {
            InitializeComponent();
        }

        public void SetConnectionParams()
        {
            Class_Connection.SetConnection(textBox_Server.Text, textBox_Instance.Text, textBox_Firm.Text, textBox_Port.Text);
        }

        public void SetNoConnection()
        {
            Class_Connection.SetConnection("", "", "", "");
        }

        private void Form_Connection_Load(object sender, EventArgs e)
        {
            if (Class_Connection.GetLastConnection())
            {
                textBox_Server.Text = Class_Connection.connection_Server;
                textBox_Instance.Text = Class_Connection.connection_Instance;
                textBox_Firm.Text = Class_Connection.connection_Company;
                textBox_Port.Text = Class_Connection.connection_Port;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            SetConnectionParams();
            Class_Connection.ConnectToWebService();
            Class_Connection.SaveLastConnection();
            if(!Class_Connection.TestWSConnection())
            {
                this.DialogResult = DialogResult.None;
                SetNoConnection();
                Class_Connection.SaveLastConnection();
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SetConnectionParams();
            Class_Connection.SaveConnection(comboBox_Templates.Text);
        }

        private void button_SaveToFile_Click(object sender, EventArgs e)
        {
            string appDataSettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\NAVExcelInferfaceFiles";
            string separator = @"@#$%";
            DirectoryInfo directoryInfo = Directory.CreateDirectory(appDataSettingsPath);

            if (Class_Connection.ConnectionsExist())
            {
                Excel.Worksheet worksheet = Globals.ThisAddIn.Application.ActiveWorkbook.Worksheets["Connections"];
                int currentRow = 2;

                if(File.Exists(appDataSettingsPath + @"\Config.txt"))
                    File.Delete(appDataSettingsPath + @"\Config.txt");

                if (((Excel.Range)worksheet.Cells[1, 6]).Value2 != null)
                {

                    File.AppendAllText(appDataSettingsPath + @"\Config.txt", 
                        ((Excel.Range)worksheet.Cells[1, 6]).Text + separator + 
                        ((Excel.Range)worksheet.Cells[1, 7]).Text + separator + 
                        ((Excel.Range)worksheet.Cells[1, 8]).Text + separator + 
                        ((Excel.Range)worksheet.Cells[1, 9]).Text + separator + 
                        ((Excel.Range)worksheet.Cells[1, 10]).Text + Environment.NewLine);
                }

                while (((Excel.Range)worksheet.Cells[currentRow, 1]).Value2 != null)
                {
                    File.AppendAllText(appDataSettingsPath + @"\Config.txt", 
                        ((Excel.Range)worksheet.Cells[currentRow, 1]).Text + separator + 
                        ((Excel.Range)worksheet.Cells[currentRow, 2]).Text + separator + 
                        ((Excel.Range)worksheet.Cells[currentRow, 3]).Text + separator + 
                        ((Excel.Range)worksheet.Cells[currentRow, 4]).Text + separator + 
                        ((Excel.Range)worksheet.Cells[currentRow, 5]).Text + Environment.NewLine);
                    currentRow++;
                }
                MessageBox.Show("Connections saved successfully", "File saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No connections have been saved yet", "No connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void comboBox_Templates_DropDown(object sender, EventArgs e)
        {
            comboBox_Templates.Items.Clear();
            comboBox_Templates.Items.AddRange(Class_Connection.GetTemplateList().ToArray());
        }

        private void comboBox_Templates_SelectedValueChanged(object sender, EventArgs e)
        {
            Class_Connection.GetConnection(comboBox_Templates.SelectedIndex);
            textBox_Server.Text = Class_Connection.connection_Server;
            textBox_Instance.Text = Class_Connection.connection_Instance;
            textBox_Firm.Text = Class_Connection.connection_Company;
            textBox_Port.Text = Class_Connection.connection_Port;
        }

        private void label_Firm_Click(object sender, EventArgs e)
        {

        }
    }
}
