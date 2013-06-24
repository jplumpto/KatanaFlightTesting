namespace ArdupilotMega.GCSViews
{
    partial class Katana
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

            //Kill Thread
            _isRecording = false;
            System.Threading.Thread.Sleep(5);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Katana));
            this.ActionPanel = new BSE.Windows.Forms.Panel();
            this.RecordButton = new ArdupilotMega.Controls.MyButton();
            this.myLabel1 = new ArdupilotMega.Controls.MyLabel();
            this.cmb_Connection = new System.Windows.Forms.ComboBox();
            this.cmb_Baud = new System.Windows.Forms.ComboBox();
            this.CrossbowConnectButton = new ArdupilotMega.Controls.MyButton();
            this.ActionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ActionPanel
            // 
            resources.ApplyResources(this.ActionPanel, "ActionPanel");
            this.ActionPanel.AssociatedSplitter = null;
            this.ActionPanel.BackColor = System.Drawing.Color.Transparent;
            this.ActionPanel.CaptionFont = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.ActionPanel.CaptionHeight = 27;
            this.ActionPanel.Controls.Add(this.RecordButton);
            this.ActionPanel.Controls.Add(this.myLabel1);
            this.ActionPanel.Controls.Add(this.cmb_Connection);
            this.ActionPanel.Controls.Add(this.cmb_Baud);
            this.ActionPanel.Controls.Add(this.CrossbowConnectButton);
            this.ActionPanel.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ActionPanel.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.ActionPanel.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.ActionPanel.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(244)))), ((int)(((byte)(242)))));
            this.ActionPanel.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.ActionPanel.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
            this.ActionPanel.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(189)))), ((int)(((byte)(210)))));
            this.ActionPanel.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(189)))), ((int)(((byte)(210)))));
            this.ActionPanel.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.ActionPanel.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.ActionPanel.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.ActionPanel.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(244)))));
            this.ActionPanel.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.ActionPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ActionPanel.Image = null;
            this.ActionPanel.Name = "ActionPanel";
            this.ActionPanel.ToolTipTextCloseIcon = null;
            this.ActionPanel.ToolTipTextExpandIconPanelCollapsed = null;
            this.ActionPanel.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // RecordButton
            // 
            resources.ApplyResources(this.RecordButton, "RecordButton");
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // myLabel1
            // 
            resources.ApplyResources(this.myLabel1, "myLabel1");
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.resize = false;
            // 
            // cmb_Connection
            // 
            this.cmb_Connection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Connection.DropDownWidth = 200;
            this.cmb_Connection.FormattingEnabled = true;
            resources.ApplyResources(this.cmb_Connection, "cmb_Connection");
            this.cmb_Connection.Name = "cmb_Connection";
            this.cmb_Connection.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_Connection_DrawItem);
            // 
            // cmb_Baud
            // 
            this.cmb_Baud.FormattingEnabled = true;
            this.cmb_Baud.Items.AddRange(new object[] {
            resources.GetString("cmb_Baud.Items"),
            resources.GetString("cmb_Baud.Items1"),
            resources.GetString("cmb_Baud.Items2"),
            resources.GetString("cmb_Baud.Items3"),
            resources.GetString("cmb_Baud.Items4"),
            resources.GetString("cmb_Baud.Items5"),
            resources.GetString("cmb_Baud.Items6"),
            resources.GetString("cmb_Baud.Items7"),
            resources.GetString("cmb_Baud.Items8")});
            resources.ApplyResources(this.cmb_Baud, "cmb_Baud");
            this.cmb_Baud.Name = "cmb_Baud";
            // 
            // CrossbowConnectButton
            // 
            resources.ApplyResources(this.CrossbowConnectButton, "CrossbowConnectButton");
            this.CrossbowConnectButton.Name = "CrossbowConnectButton";
            this.CrossbowConnectButton.UseVisualStyleBackColor = true;
            this.CrossbowConnectButton.Click += new System.EventHandler(this.CrossbowConnectButton_Click);
            // 
            // Katana
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ActionPanel);
            this.Name = "Katana";
            this.Load += new System.EventHandler(this.Katana_Load);
            this.ActionPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BSE.Windows.Forms.Panel ActionPanel;
        private System.Windows.Forms.ComboBox cmb_Connection;
        private System.Windows.Forms.ComboBox cmb_Baud;
        private Controls.MyButton CrossbowConnectButton;
        private Controls.MyLabel myLabel1;
        private Controls.MyButton RecordButton;


    }
}
