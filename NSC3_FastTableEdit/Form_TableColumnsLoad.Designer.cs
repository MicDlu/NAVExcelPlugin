namespace NSC3_FastTableEdit
{
    using NSC3_FastTableEdit.NAVFieldsService;
    using System.Collections.Generic;
    using System.Linq;

    partial class Form_TableColumnsLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox_Columns = new System.Windows.Forms.ListBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_Columns = new System.Windows.Forms.Label();
            this.comboBox_Table = new System.Windows.Forms.ComboBox();
            this.label_Table = new System.Windows.Forms.Label();
            this.listBox_ChosenColumns = new System.Windows.Forms.ListBox();
            this.label_ChosenColumns = new System.Windows.Forms.Label();
            this.MoveItemUp = new System.Windows.Forms.Button();
            this.ChooseField = new System.Windows.Forms.Button();
            this.RevertField = new System.Windows.Forms.Button();
            this.MoveItemDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_Columns
            // 
            this.listBox_Columns.FormattingEnabled = true;
            this.listBox_Columns.Location = new System.Drawing.Point(273, 25);
            this.listBox_Columns.Name = "listBox_Columns";
            this.listBox_Columns.Size = new System.Drawing.Size(264, 225);
            this.listBox_Columns.TabIndex = 0;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(731, 256);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(812, 256);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // label_Columns
            // 
            this.label_Columns.AutoSize = true;
            this.label_Columns.Location = new System.Drawing.Point(270, 9);
            this.label_Columns.Name = "label_Columns";
            this.label_Columns.Size = new System.Drawing.Size(127, 13);
            this.label_Columns.TabIndex = 3;
            this.label_Columns.Text = "Dynamics NAV Fields (all)";
            // 
            // comboBox_Table
            // 
            this.comboBox_Table.FormattingEnabled = true;
            this.comboBox_Table.Location = new System.Drawing.Point(12, 25);
            this.comboBox_Table.Name = "comboBox_Table";
            this.comboBox_Table.Size = new System.Drawing.Size(255, 21);
            this.comboBox_Table.TabIndex = 4;
            this.comboBox_Table.SelectedIndexChanged += new System.EventHandler(this.comboBox_Table_SelectedIndexChanged);
            // 
            // label_Table
            // 
            this.label_Table.AutoSize = true;
            this.label_Table.Location = new System.Drawing.Point(9, 9);
            this.label_Table.Name = "label_Table";
            this.label_Table.Size = new System.Drawing.Size(108, 13);
            this.label_Table.TabIndex = 5;
            this.label_Table.Text = "Dynamics NAV Table";
            // 
            // listBox_ChosenColumns
            // 
            this.listBox_ChosenColumns.FormattingEnabled = true;
            this.listBox_ChosenColumns.Location = new System.Drawing.Point(624, 25);
            this.listBox_ChosenColumns.Name = "listBox_ChosenColumns";
            this.listBox_ChosenColumns.Size = new System.Drawing.Size(264, 225);
            this.listBox_ChosenColumns.TabIndex = 6;
            // 
            // label_ChosenColumns
            // 
            this.label_ChosenColumns.AutoSize = true;
            this.label_ChosenColumns.Location = new System.Drawing.Point(621, 9);
            this.label_ChosenColumns.Name = "label_ChosenColumns";
            this.label_ChosenColumns.Size = new System.Drawing.Size(154, 13);
            this.label_ChosenColumns.TabIndex = 7;
            this.label_ChosenColumns.Text = "Dynamics NAV Fields (to insert)";
            // 
            // MoveItemUp
            // 
            this.MoveItemUp.Location = new System.Drawing.Point(543, 81);
            this.MoveItemUp.Name = "MoveItemUp";
            this.MoveItemUp.Size = new System.Drawing.Size(75, 23);
            this.MoveItemUp.TabIndex = 8;
            this.MoveItemUp.Text = "Move Up";
            this.MoveItemUp.UseVisualStyleBackColor = true;
            this.MoveItemUp.Click += new System.EventHandler(this.MoveItemUp_Click);
            // 
            // ChooseField
            // 
            this.ChooseField.Location = new System.Drawing.Point(543, 110);
            this.ChooseField.Name = "ChooseField";
            this.ChooseField.Size = new System.Drawing.Size(75, 23);
            this.ChooseField.TabIndex = 9;
            this.ChooseField.Text = ">>";
            this.ChooseField.UseVisualStyleBackColor = true;
            this.ChooseField.Click += new System.EventHandler(this.ChooseField_Click);
            // 
            // RevertField
            // 
            this.RevertField.Location = new System.Drawing.Point(543, 139);
            this.RevertField.Name = "RevertField";
            this.RevertField.Size = new System.Drawing.Size(75, 23);
            this.RevertField.TabIndex = 10;
            this.RevertField.Text = "<<";
            this.RevertField.UseVisualStyleBackColor = true;
            this.RevertField.Click += new System.EventHandler(this.RevertField_Click);
            // 
            // MoveItemDown
            // 
            this.MoveItemDown.Location = new System.Drawing.Point(543, 168);
            this.MoveItemDown.Name = "MoveItemDown";
            this.MoveItemDown.Size = new System.Drawing.Size(75, 23);
            this.MoveItemDown.TabIndex = 11;
            this.MoveItemDown.Text = "Move Down";
            this.MoveItemDown.UseVisualStyleBackColor = true;
            // 
            // Form_TableColumnsLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 288);
            this.Controls.Add(this.MoveItemDown);
            this.Controls.Add(this.RevertField);
            this.Controls.Add(this.ChooseField);
            this.Controls.Add(this.MoveItemUp);
            this.Controls.Add(this.label_ChosenColumns);
            this.Controls.Add(this.listBox_ChosenColumns);
            this.Controls.Add(this.label_Table);
            this.Controls.Add(this.comboBox_Table);
            this.Controls.Add(this.label_Columns);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.listBox_Columns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_TableColumnsLoad";
            this.Text = "Insert Headers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ReloadFieldList()
        {
            List<Fields_Filter> filterArray = new List<Fields_Filter>();
            Fields_Service fieldService = new Fields_Service();
            fieldService.UseDefaultCredentials = true;
            Fields_Filter fieldFilter = new Fields_Filter();
            fieldFilter.Field = Fields_Fields.TableNo;
            string currSelection = this.comboBox_Table.SelectedItem.ToString();
            fieldFilter.Criteria = currSelection.Substring(0, currSelection.IndexOf(' '));
            filterArray.Add(fieldFilter);
            Fields[] tableFieldList = fieldService.ReadMultiple(filterArray.ToArray(), null, 0);

            string[] uniqueTableFieldList = tableFieldList.Select(x => x.FieldName.ToString()).Distinct().ToArray(); //string.Concat(x.FieldName + " \"" + x.Field_Caption + "\"") - dla nazwy i captiona
            this.listBox_Columns.Items.Clear();
            this.currentTableFieldList = uniqueTableFieldList;
            this.listBox_Columns.Items.AddRange(uniqueTableFieldList);
        }

        private void initTableComboBox()
        {
            List<Fields_Filter> filterArray = new List<Fields_Filter>();
            Fields_Service fieldService = new Fields_Service();
            fieldService.UseDefaultCredentials = true;
            Fields_Filter fieldFilter = new Fields_Filter();
            filterArray.Add(fieldFilter);
            Fields[] tableFieldList = fieldService.ReadMultiple(filterArray.ToArray(), null, 0);

            Fields[] allFieldList = fieldService.ReadMultiple(filterArray.ToArray(), null, 0);
            string[] uniqueFieldList = tableFieldList.Select(x => string.Concat(x.TableNo, ' ', x.TableName)).Distinct().ToArray();
            this.comboBox_Table.Items.AddRange(uniqueFieldList);
        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Columns;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_Columns;
        private System.Windows.Forms.ComboBox comboBox_Table;
        private System.Windows.Forms.Label label_Table;
        private System.Windows.Forms.ListBox listBox_ChosenColumns;
        private System.Windows.Forms.Label label_ChosenColumns;
        private System.Windows.Forms.Button MoveItemUp;
        private System.Windows.Forms.Button ChooseField;
        private System.Windows.Forms.Button RevertField;
        private System.Windows.Forms.Button MoveItemDown;
        private string[] currentTableFieldList;
    }

    
}