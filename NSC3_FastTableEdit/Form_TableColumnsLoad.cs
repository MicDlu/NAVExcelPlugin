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
            return listBox_ChosenColumns.Items.Cast<string>().ToList();
        }

        private void comboBox_Table_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadFieldList();
        }

        private void ChooseField_Click(object sender, EventArgs e)
        {
            if (listBox_Columns.SelectedIndex != -1)
            {
                int index = listBox_Columns.SelectedIndex;
                listBox_ChosenColumns.Items.Add(listBox_Columns.SelectedItem);
                listBox_Columns.Items.RemoveAt(listBox_Columns.SelectedIndex);
                if (listBox_Columns.Items.Count > index + 1)
                {
                    listBox_Columns.SetSelected(index, true);
                }
                else
                {
                    if (listBox_Columns.Items.Count > 0)
                        listBox_Columns.SetSelected(listBox_Columns.Items.Count - 1, true);
                }
            }
        }

        private void RevertField_Click(object sender, EventArgs e)
        {
            if (listBox_ChosenColumns.SelectedIndex != -1 && !(listBox_ChosenColumns.SelectedItem.ToString().StartsWith("* "))) 
            {
                int index = listBox_ChosenColumns.SelectedIndex;
                listBox_ChosenColumns.Items.RemoveAt(listBox_ChosenColumns.SelectedIndex);
                string[] comparer = new string[listBox_ChosenColumns.Items.Count];
                listBox_ChosenColumns.Items.CopyTo(comparer, 0);
                listBox_Columns.Items.Clear();
                listBox_Columns.Items.AddRange(currentTableFieldList.Except(comparer).ToArray());

                if (listBox_ChosenColumns.Items.Count > index + 1)
                {
                    listBox_ChosenColumns.SetSelected(index, true);
                }
                else
                {
                    if (listBox_ChosenColumns.Items.Count > 0)
                        listBox_ChosenColumns.SetSelected(listBox_ChosenColumns.Items.Count - 1, true);
                }
            }
        }

        private void MoveItemUp_Click(object sender, EventArgs e)
        {
            if (listBox_ChosenColumns.SelectedIndex != 0 && listBox_ChosenColumns.Items.Count > 0 && !(listBox_ChosenColumns.SelectedItem.ToString().StartsWith("* ")))
            {
                string temp = listBox_ChosenColumns.SelectedItem.ToString();
                int index = listBox_ChosenColumns.SelectedIndex;
                if (!listBox_ChosenColumns.Items[listBox_ChosenColumns.SelectedIndex - 1].ToString().StartsWith("* "))
                {
                    listBox_ChosenColumns.Items.RemoveAt(index);
                    listBox_ChosenColumns.Items.Insert(index - 1, temp);
                    listBox_ChosenColumns.SetSelected(index - 1, true);
                }
            }
        }

        private void MoveItemDown_Click(object sender, EventArgs e)
        {
            if(listBox_ChosenColumns.SelectedIndex != listBox_ChosenColumns.Items.Count - 1 && listBox_ChosenColumns.Items.Count > 0 && !(listBox_ChosenColumns.SelectedItem.ToString().StartsWith("* ")))
            {
                string temp = listBox_ChosenColumns.SelectedItem.ToString();
                int index = listBox_ChosenColumns.SelectedIndex;
                if(!listBox_ChosenColumns.Items[listBox_ChosenColumns.SelectedIndex + 1].ToString().StartsWith("* "))
                {
                    listBox_ChosenColumns.Items.RemoveAt(index);
                    listBox_ChosenColumns.Items.Insert(index + 1, temp);
                    listBox_ChosenColumns.SetSelected(index + 1, true);
                }
            }
        }

        private void ChooseAllColumns(object sender, EventArgs e)
        {
            if(listBox_Columns.Items.Count > 0)
            {
                listBox_ChosenColumns.Items.AddRange(listBox_Columns.Items);
                listBox_Columns.Items.Clear();
                listBox_ChosenColumns.SelectedIndex = 0;
            }
        }

        private void RevertAllColumns(object sender, EventArgs e)
        {
            if(currentTableFieldList != null)
            {
                listBox_ChosenColumns.Items.Clear();
                listBox_ChosenColumns.Items.AddRange(currentTablePKeyList);
                listBox_Columns.Items.Clear();
                listBox_Columns.Items.AddRange(currentTableFieldList);
                listBox_Columns.SelectedIndex = 0;
                listBox_ChosenColumns.SelectedIndex = 0;
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
               // Class_Table.SaveTemplate(comboBox_Templates.Text);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            SetTemplateParams();
        }
    }
}
