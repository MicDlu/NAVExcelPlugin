namespace NSC3_FastTableEdit
{
    partial class NSC3_Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public NSC3_Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group_NSC3 = this.Factory.CreateRibbonGroup();
            this.buttonSetConnection = this.Factory.CreateRibbonButton();
            this.button_LoadTableHeader = this.Factory.CreateRibbonButton();
            this.button_SendToNAV = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group_NSC3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group_NSC3);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // group_NSC3
            // 
            this.group_NSC3.Items.Add(this.buttonSetConnection);
            this.group_NSC3.Items.Add(this.button_LoadTableHeader);
            this.group_NSC3.Items.Add(this.button_SendToNAV);
            this.group_NSC3.Label = "NAV table edit";
            this.group_NSC3.Name = "group_NSC3";
            // 
            // buttonSetConnection
            // 
            this.buttonSetConnection.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonSetConnection.Image = global::NSC3_FastTableEdit.Properties.Resources.server;
            this.buttonSetConnection.Label = "Edit Connection";
            this.buttonSetConnection.Name = "buttonSetConnection";
            this.buttonSetConnection.ShowImage = true;
            this.buttonSetConnection.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonSetConnection_Click);
            // 
            // button_LoadTableHeader
            // 
            this.button_LoadTableHeader.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button_LoadTableHeader.Image = global::NSC3_FastTableEdit.Properties.Resources.browser;
            this.button_LoadTableHeader.Label = "Load table header";
            this.button_LoadTableHeader.Name = "button_LoadTableHeader";
            this.button_LoadTableHeader.ShowImage = true;
            this.button_LoadTableHeader.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_LoadTableHeader_Click);
            // 
            // button_SendToNAV
            // 
            this.button_SendToNAV.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button_SendToNAV.Image = global::NSC3_FastTableEdit.Properties.Resources.startup;
            this.button_SendToNAV.Label = "Send To NAV";
            this.button_SendToNAV.Name = "button_SendToNAV";
            this.button_SendToNAV.ShowImage = true;
            this.button_SendToNAV.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button_SendToNAV_Click);
            // 
            // NSC3_Ribbon
            // 
            this.Name = "NSC3_Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.NSC3_Ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group_NSC3.ResumeLayout(false);
            this.group_NSC3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group_NSC3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_LoadTableHeader;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button_SendToNAV;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonSetConnection;
    }

    partial class ThisRibbonCollection
    {
        internal NSC3_Ribbon NSC3_Ribbon
        {
            get { return this.GetRibbon<NSC3_Ribbon>(); }
        }
    }
}
