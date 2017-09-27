namespace NSC3_FastTableEdit
{
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
            this.SuspendLayout();
            // 
            // listBox_Columns
            // 
            this.listBox_Columns.FormattingEnabled = true;
            this.listBox_Columns.Items.AddRange(new object[] {
            "TEST No.",
            "TEST Name",
            "TEST Search Name",
            "TEST Name 2",
            "TEST Address",
            "TEST Address 2",
            "TEST City",
            "TEST Contact",
            "TEST Phone No."});
            this.listBox_Columns.Location = new System.Drawing.Point(145, 29);
            this.listBox_Columns.Name = "listBox_Columns";
            this.listBox_Columns.Size = new System.Drawing.Size(156, 225);
            this.listBox_Columns.TabIndex = 0;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(145, 268);
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
            this.button_Cancel.Location = new System.Drawing.Point(226, 268);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // label_Columns
            // 
            this.label_Columns.AutoSize = true;
            this.label_Columns.Location = new System.Drawing.Point(142, 9);
            this.label_Columns.Name = "label_Columns";
            this.label_Columns.Size = new System.Drawing.Size(97, 13);
            this.label_Columns.TabIndex = 3;
            this.label_Columns.Text = "NAV table columns";
            // 
            // comboBox_Table
            // 
            this.comboBox_Table.FormattingEnabled = true;
            this.comboBox_Table.Location = new System.Drawing.Point(15, 63);
            this.comboBox_Table.Name = "comboBox_Table";
            this.comboBox_Table.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Table.TabIndex = 4;
            // 
            // label_Table
            // 
            this.label_Table.AutoSize = true;
            this.label_Table.Location = new System.Drawing.Point(12, 47);
            this.label_Table.Name = "label_Table";
            this.label_Table.Size = new System.Drawing.Size(90, 13);
            this.label_Table.TabIndex = 5;
            this.label_Table.Text = "NAV source table";
            // 
            // Form_TableColumnsLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 303);
            this.Controls.Add(this.label_Table);
            this.Controls.Add(this.comboBox_Table);
            this.Controls.Add(this.label_Columns);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.listBox_Columns);
            this.Name = "Form_TableColumnsLoad";
            this.Text = "Form_TableColumnsLoad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Columns;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_Columns;
        private System.Windows.Forms.ComboBox comboBox_Table;
        private System.Windows.Forms.Label label_Table;
    }
}