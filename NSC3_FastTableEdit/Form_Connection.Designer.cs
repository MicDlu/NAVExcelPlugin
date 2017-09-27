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
            this.button_Test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Server
            // 
            this.textBox_Server.Location = new System.Drawing.Point(12, 25);
            this.textBox_Server.Name = "textBox_Server";
            this.textBox_Server.Size = new System.Drawing.Size(396, 20);
            this.textBox_Server.TabIndex = 0;
            // 
            // label_Server
            // 
            this.label_Server.AutoSize = true;
            this.label_Server.Location = new System.Drawing.Point(12, 9);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(38, 13);
            this.label_Server.TabIndex = 2;
            this.label_Server.Text = "Server";
            // 
            // label_Firm
            // 
            this.label_Firm.AutoSize = true;
            this.label_Firm.Location = new System.Drawing.Point(12, 48);
            this.label_Firm.Name = "label_Firm";
            this.label_Firm.Size = new System.Drawing.Size(26, 13);
            this.label_Firm.TabIndex = 4;
            this.label_Firm.Text = "Firm";
            // 
            // textBox_Firm
            // 
            this.textBox_Firm.Location = new System.Drawing.Point(12, 64);
            this.textBox_Firm.Name = "textBox_Firm";
            this.textBox_Firm.Size = new System.Drawing.Size(396, 20);
            this.textBox_Firm.TabIndex = 3;
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(12, 126);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(26, 13);
            this.label_Port.TabIndex = 8;
            this.label_Port.Text = "Port";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(12, 142);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(396, 20);
            this.textBox_Port.TabIndex = 7;
            // 
            // label_Instance
            // 
            this.label_Instance.AutoSize = true;
            this.label_Instance.Location = new System.Drawing.Point(12, 87);
            this.label_Instance.Name = "label_Instance";
            this.label_Instance.Size = new System.Drawing.Size(82, 13);
            this.label_Instance.TabIndex = 6;
            this.label_Instance.Text = "Server Instance";
            // 
            // textBox_Instance
            // 
            this.textBox_Instance.Location = new System.Drawing.Point(12, 103);
            this.textBox_Instance.Name = "textBox_Instance";
            this.textBox_Instance.Size = new System.Drawing.Size(396, 20);
            this.textBox_Instance.TabIndex = 5;
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_OK.Location = new System.Drawing.Point(252, 226);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 9;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(333, 226);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 10;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // button_Test
            // 
            this.button_Test.Location = new System.Drawing.Point(12, 226);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(156, 23);
            this.button_Test.TabIndex = 11;
            this.button_Test.Text = "Test connection";
            this.button_Test.UseVisualStyleBackColor = true;
            // 
            // Form_Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 261);
            this.Controls.Add(this.button_Test);
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
            this.Name = "Form_Connection";
            this.Text = "Form_Connection";
            this.Load += new System.EventHandler(this.Form_Connection_Load);
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
        private System.Windows.Forms.Button button_Test;
    }
}