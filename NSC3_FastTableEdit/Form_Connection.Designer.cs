namespace NSC3_FastTableEdit
{
    partial class Form_Connection
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
            this.textBox_Server = new System.Windows.Forms.TextBox();
            this.label_Server = new System.Windows.Forms.Label();
            this.label_Firm = new System.Windows.Forms.Label();
            this.textBox_Firm = new System.Windows.Forms.TextBox();
            this.label_Port = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label_Instance = new System.Windows.Forms.Label();
            this.textBox_Instance = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.comboBox_Templates = new System.Windows.Forms.ComboBox();
            this.groupBox_Templates = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox_Templates.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Server
            // 
            this.textBox_Server.Location = new System.Drawing.Point(12, 99);
            this.textBox_Server.Name = "textBox_Server";
            this.textBox_Server.Size = new System.Drawing.Size(346, 20);
            this.textBox_Server.TabIndex = 1;
            // 
            // label_Server
            // 
            this.label_Server.AutoSize = true;
            this.label_Server.Location = new System.Drawing.Point(12, 83);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(38, 13);
            this.label_Server.TabIndex = 2;
            this.label_Server.Text = "Server";
            // 
            // label_Firm
            // 
            this.label_Firm.AutoSize = true;
            this.label_Firm.Location = new System.Drawing.Point(12, 161);
            this.label_Firm.Name = "label_Firm";
            this.label_Firm.Size = new System.Drawing.Size(51, 13);
            this.label_Firm.TabIndex = 4;
            this.label_Firm.Text = "Company";
            this.label_Firm.Click += new System.EventHandler(this.label_Firm_Click);
            // 
            // textBox_Firm
            // 
            this.textBox_Firm.Location = new System.Drawing.Point(12, 177);
            this.textBox_Firm.Name = "textBox_Firm";
            this.textBox_Firm.Size = new System.Drawing.Size(346, 20);
            this.textBox_Firm.TabIndex = 3;
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(12, 200);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(26, 13);
            this.label_Port.TabIndex = 8;
            this.label_Port.Text = "Port";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(12, 216);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(345, 20);
            this.textBox_Port.TabIndex = 4;
            // 
            // label_Instance
            // 
            this.label_Instance.AutoSize = true;
            this.label_Instance.Location = new System.Drawing.Point(12, 122);
            this.label_Instance.Name = "label_Instance";
            this.label_Instance.Size = new System.Drawing.Size(82, 13);
            this.label_Instance.TabIndex = 6;
            this.label_Instance.Text = "Server Instance";
            // 
            // textBox_Instance
            // 
            this.textBox_Instance.Location = new System.Drawing.Point(12, 138);
            this.textBox_Instance.Name = "textBox_Instance";
            this.textBox_Instance.Size = new System.Drawing.Size(345, 20);
            this.textBox_Instance.TabIndex = 2;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(202, 242);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 5;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(283, 242);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 6;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(276, 19);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(69, 23);
            this.button_Save.TabIndex = 11;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // comboBox_Templates
            // 
            this.comboBox_Templates.FormattingEnabled = true;
            this.comboBox_Templates.Location = new System.Drawing.Point(6, 19);
            this.comboBox_Templates.Name = "comboBox_Templates";
            this.comboBox_Templates.Size = new System.Drawing.Size(189, 21);
            this.comboBox_Templates.TabIndex = 0;
            this.comboBox_Templates.DropDown += new System.EventHandler(this.comboBox_Templates_DropDown);
            this.comboBox_Templates.SelectedValueChanged += new System.EventHandler(this.comboBox_Templates_SelectedValueChanged);
            // 
            // groupBox_Templates
            // 
            this.groupBox_Templates.Controls.Add(this.button1);
            this.groupBox_Templates.Controls.Add(this.comboBox_Templates);
            this.groupBox_Templates.Controls.Add(this.button_Save);
            this.groupBox_Templates.Location = new System.Drawing.Point(12, 12);
            this.groupBox_Templates.Name = "groupBox_Templates";
            this.groupBox_Templates.Size = new System.Drawing.Size(353, 55);
            this.groupBox_Templates.TabIndex = 14;
            this.groupBox_Templates.TabStop = false;
            this.groupBox_Templates.Text = "Templates";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save to file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_SaveToFile_Click);
            // 
            // Form_Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 274);
            this.Controls.Add(this.groupBox_Templates);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_Instance);
            this.Controls.Add(this.textBox_Firm);
            this.Controls.Add(this.textBox_Server);
            this.Controls.Add(this.label_Server);
            this.Controls.Add(this.label_Firm);
            this.Controls.Add(this.label_Instance);
            this.Controls.Add(this.label_Port);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Connection";
            this.Text = "Connection";
            this.Load += new System.EventHandler(this.Form_Connection_Load);
            this.groupBox_Templates.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Server;
        private System.Windows.Forms.Label label_Server;
        private System.Windows.Forms.Label label_Firm;
        private System.Windows.Forms.TextBox textBox_Firm;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label_Instance;
        private System.Windows.Forms.TextBox textBox_Instance;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.ComboBox comboBox_Templates;
        private System.Windows.Forms.GroupBox groupBox_Templates;
        private System.Windows.Forms.Button button1;
    }
}