using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void Form_Connection_Load(object sender, EventArgs e)
        {
            textBox_Server.Text = Class_Connection.connection_Server;
            textBox_Instance.Text = Class_Connection.connection_Instance;
            textBox_Firm.Text = Class_Connection.connection_Firm;
            textBox_Port.Text = Class_Connection.connection_Port;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            SetConnectionParams();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SetConnectionParams();
            if (true)   //  test
                Class_Connection.SaveConnection(textBox_Save.Text);
        }
    }
}
