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
            initTableComboBox();
        }

        public List<string> Columns()
        {
            return listBox_Columns.Items.Cast<string>().ToList();
        }

        private void comboBox_Table_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadFieldList();
        }

        private void ChooseField_Click(object sender, EventArgs e)
        {
            if (this.listBox_Columns.SelectedIndex != -1)
            {
                int index = this.listBox_Columns.SelectedIndex;
                this.listBox_ChosenColumns.Items.Add(this.listBox_Columns.SelectedItem);
                this.listBox_Columns.Items.RemoveAt(this.listBox_Columns.SelectedIndex);
                if (this.listBox_Columns.Items.Count > index + 1)
                {
                    this.listBox_Columns.SetSelected(index, true);
                }
                else
                {
                    if (this.listBox_Columns.Items.Count > 0)
                        this.listBox_Columns.SetSelected(this.listBox_Columns.Items.Count - 1, true);
                }
            }
        }

        private void RevertField_Click(object sender, EventArgs e)
        {
            if (this.listBox_ChosenColumns.SelectedIndex != -1 && !(this.listBox_ChosenColumns.SelectedItem.ToString().StartsWith("* "))) 
            {
                int index = this.listBox_ChosenColumns.SelectedIndex;
                this.listBox_ChosenColumns.Items.RemoveAt(this.listBox_ChosenColumns.SelectedIndex);
                string[] comparer = new string[this.listBox_ChosenColumns.Items.Count];
                this.listBox_ChosenColumns.Items.CopyTo(comparer, 0);
                this.listBox_Columns.Items.Clear();
                this.listBox_Columns.Items.AddRange(currentTableFieldList.Except(comparer).ToArray());

                if (this.listBox_ChosenColumns.Items.Count > index + 1)
                {
                    this.listBox_ChosenColumns.SetSelected(index, true);
                }
                else
                {
                    if (this.listBox_ChosenColumns.Items.Count > 0)
                        this.listBox_ChosenColumns.SetSelected(this.listBox_ChosenColumns.Items.Count - 1, true);
                }
            }
        }

        private void MoveItemUp_Click(object sender, EventArgs e)
        {
            if (this.listBox_ChosenColumns.SelectedIndex != 0 && this.listBox_ChosenColumns.Items.Count > 0 && !(this.listBox_ChosenColumns.SelectedItem.ToString().StartsWith("* ")))
            {
                string temp = this.listBox_ChosenColumns.SelectedItem.ToString();
                int index = this.listBox_ChosenColumns.SelectedIndex;
                if (!this.listBox_ChosenColumns.Items[this.listBox_ChosenColumns.SelectedIndex - 1].ToString().StartsWith("* "))
                {
                    this.listBox_ChosenColumns.Items.RemoveAt(index);
                    this.listBox_ChosenColumns.Items.Insert(index - 1, temp);
                    this.listBox_ChosenColumns.SetSelected(index - 1, true);
                }
            }
        }

        private void MoveItemDown_Click(object sender, EventArgs e)
        {
            if(this.listBox_ChosenColumns.SelectedIndex != this.listBox_ChosenColumns.Items.Count - 1 && this.listBox_ChosenColumns.Items.Count > 0 && !(this.listBox_ChosenColumns.SelectedItem.ToString().StartsWith("* ")))
            {
                string temp = this.listBox_ChosenColumns.SelectedItem.ToString();
                int index = this.listBox_ChosenColumns.SelectedIndex;
                if(!this.listBox_ChosenColumns.Items[this.listBox_ChosenColumns.SelectedIndex + 1].ToString().StartsWith("* "))
                {
                    this.listBox_ChosenColumns.Items.RemoveAt(index);
                    this.listBox_ChosenColumns.Items.Insert(index + 1, temp);
                    this.listBox_ChosenColumns.SetSelected(index + 1, true);
                }
            }
        }

        private void ChooseAllColumns(object sender, EventArgs e)
        {
            if(this.listBox_Columns.Items.Count > 0)
            {
                this.listBox_ChosenColumns.Items.AddRange(this.listBox_Columns.Items);
                this.listBox_Columns.Items.Clear();
                this.listBox_ChosenColumns.SelectedIndex = 0;
            }
        }

        private void RevertAllColumns(object sender, EventArgs e)
        {
            if(this.currentTableFieldList != null)
            {
                this.listBox_ChosenColumns.Items.Clear();
                this.listBox_ChosenColumns.Items.AddRange(currentTablePKeyList);
                this.listBox_Columns.Items.AddRange(currentTableFieldList);
                this.listBox_Columns.SelectedIndex = 0;
                this.listBox_ChosenColumns.SelectedIndex = 0;
            }
        }

        private void comboBox_Templates_DropDown(object sender, EventArgs e)
        {
            comboBox_Templates.Items.Clear();
            comboBox_Templates.Items.AddRange(Class_Table.GetTemplateList().ToArray());
        }

        private void comboBox_Templates_SelectedValueChanged(object sender, EventArgs e)
        {
            Class_Table.GetTemplate(comboBox_Templates.Text);
            listBox_ChosenColumns.Items.Clear();
            foreach (var item in Class_Table.tableFieldList)
            {
                listBox_ChosenColumns.Items.Add(item);
            }
        }

        public void SetTemplateParams()
        {
            Class_Table.SetTable(comboBox_Table.Text, listBox_ChosenColumns.Items.Cast<String>().ToList());
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SetTemplateParams();
            if (true)   //  test
                Class_Table.SaveTemplate(comboBox_Templates.Text);
        }
    }
}
