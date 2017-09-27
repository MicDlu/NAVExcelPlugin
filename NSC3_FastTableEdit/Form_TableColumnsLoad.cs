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
    public partial class Form_TableColumnsLoad : Form
    {
        public Form_TableColumnsLoad()
        {
            InitializeComponent();
        }

        public List<string> Columns()
        {
            return listBox_Columns.Items.Cast<string>().ToList();
        }
    }
}
