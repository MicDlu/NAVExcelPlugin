using NSC3_FastTableEdit.NAVFieldsService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace NSC3_FastTableEdit
{
    public partial class Form_TableColumnsLoad : Form
    {
        private List<string> currentTemplateFields = new List<string>();

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
            loadedTemplates = Class_Table.GetTemplateList();
            comboBox_Templates.Items.Clear();
            comboBox_Templates.Items.AddRange(loadedTemplates.ToArray());
            comboBox_Templates.DisplayMember = "Name";
        }

        private void comboBox_Templates_SelectedValueChanged(object sender, EventArgs e)
        {
            currentTempName = comboBox_Templates.Text;
            Class_Template chosenTemplate = (Class_Template)comboBox_Templates.SelectedItem;
            string searchString = chosenTemplate.TableNo + " ";
            this.comboBox_Table.SelectedIndex = comboBox_Table.FindString(searchString);
            ReloadFieldList();
            currentTemplateFields = chosenTemplate.Fields;
            
            foreach (string item in chosenTemplate.Fields)
            {
                string PKitem = "* " + item;
                if (!(listBox_ChosenColumns.Items.Contains(PKitem)))
                {
                    listBox_ChosenColumns.Items.Add(item);
                }
                
                if(listBox_Columns.Items.Contains(item))
                {
                    listBox_Columns.Items.Remove(item);
                }
            }
        }

        public void SetTemplateParams()
        {
            Class_Table.SetTable(comboBox_Table.Text, listBox_ChosenColumns.Items.Cast<String>().ToList());
        }

        public void SetCurrentTemplate()
        {
            Class_Template.currentTemplate = new Class_Template(comboBox_Templates.Text, Class_Table.tableNumber, listBox_ChosenColumns.Items.Cast<String>().ToList());
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if(comboBox_Templates.Text != "")
            {
                try
                {
                    SetTemplateParams();
                    SendTemplateXml();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("You don't have the permission to modify this template", "Permission exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill in the template name before proceeding", "Empty template name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            loadedTemplates = Class_Table.GetTemplateList();
            comboBox_Templates.Items.Clear();
            comboBox_Templates.Items.AddRange(loadedTemplates.ToArray());
            if (comboBox_Table.Text != "")
            {
                if (comboBox_Templates.Text != "")
                {
                    List<string> chosenColumnsFixed = listBox_ChosenColumns.Items.Cast<string>().ToList().Select(s => s.Replace("* ", "")).ToList();
                    var areEquivalent = (chosenColumnsFixed.Count == currentTemplateFields.Count) && !chosenColumnsFixed.Except(currentTemplateFields).Any();
                    if (!areEquivalent && currentTempName != comboBox_Templates.Text)
                    {
                        try
                        {
                            SetTemplateParams();
                            SetCurrentTemplate();
                            SendTemplateXml();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Saving exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.DialogResult = DialogResult.None;
                        }
                    }
                    else
                    {
                        SetTemplateParams();
                        SetCurrentTemplate();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in the template name before proceeding", "Empty template name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Please select a table before proceeding", "No table selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }

        private void SendTemplateXml()
        {
            template = new XmlDocument();
            XmlDeclaration declaration = template.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = template.DocumentElement;
            template.InsertBefore(declaration, root);

            XmlElement package = NewElement("package");
            XmlElement name = NewElement("name");
            XmlElement table = NewElement("tabno");
            XmlElement fields = NewElement("fields");

            XmlText pkgName = NewText(comboBox_Templates.Text);
            XmlText tabNo = NewText(Class_Table.tableNumber.ToString());
            
            name.AppendChild(pkgName);
            table.AppendChild(tabNo);

            foreach(string field in listBox_ChosenColumns.Items)
            {
                string key;
                if (field.StartsWith("*"))
                {
                    key = field.Substring(field.IndexOf("* ") + 2);
                }
                else
                {
                    key = field;
                }

                XmlElement fieldno = NewElement("fieldno");
                XmlText nameToNo = NewText(numberDictionary[key].ToString());

                fieldno.AppendChild(nameToNo);
                fields.AppendChild(fieldno);
            }

            template.AppendChild(package);
            package.AppendChild(name);
            package.AppendChild(table);
            package.AppendChild(fields);

            Class_Connection.navTemplateService.CreateTemplate(template.InnerXml);
        }

        public static void CreateDictionary(string key)
        {
            List<Fields_Filter> filterArray = new List<Fields_Filter>();
            Fields_Filter fieldFilter = new Fields_Filter();
            fieldFilter.Field = Fields_Fields.TableNo;
            fieldFilter.Criteria = key;
            filterArray.Add(fieldFilter);

            Fields[] tableFieldList = Class_Connection.navFieldsService.ReadMultiple(filterArray.ToArray(), null, 0);

            numberDictionary = new Dictionary<string, int>();
            numberDictionary = tableFieldList.Select(x => new { num = x.No, name = x.FieldName }).ToDictionary(d => d.name, d => d.num);
        }

        private XmlElement NewElement(string name)
        {
            return template.CreateElement(string.Empty, name, string.Empty);
        }

        private XmlText NewText(string content)
        {
            return template.CreateTextNode(content);
        }

        XmlDocument template = new XmlDocument();
        string currentTempName = "";
        List<Class_Template> loadedTemplates = new List<Class_Template>();

        private void Form_TableColumnsLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                List<Class_Template> templates = comboBox_Templates.Items.Cast<Class_Template>().ToList();
                List<string> templateNames = templates.Select(x => x.Name).ToList();
                if (!templateNames.Contains(comboBox_Templates.Text) && comboBox_Templates.Text != "")
                {
                    DialogResult result = MessageBox.Show("Template was not saved, do you want to save it under the current name?", "Template not saved", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (comboBox_Templates.Text != "")
                        {
                            SendTemplateXml();
                        }
                        else
                        {
                            MessageBox.Show("Please fill in the template name before proceeding", "Empty template name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.DialogResult = DialogResult.None;
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
    }
}
