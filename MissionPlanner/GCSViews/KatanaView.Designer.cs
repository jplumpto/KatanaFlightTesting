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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Katana));
            this.ActionPanel = new BSE.Windows.Forms.Panel();
            this.GraphButton = new ArdupilotMega.Controls.MyButton();
            this.ManoeuvreTextBox = new System.Windows.Forms.TextBox();
            this.ManoeuvreButton = new ArdupilotMega.Controls.MyButton();
            this.RecordButton = new ArdupilotMega.Controls.MyButton();
            this.myLabel1 = new ArdupilotMega.Controls.MyLabel();
            this.cmb_Connection = new System.Windows.Forms.ComboBox();
            this.cmb_Baud = new System.Windows.Forms.ComboBox();
            this.CrossbowConnectButton = new ArdupilotMega.Controls.MyButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStickIMU = new System.Windows.Forms.TabPage();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.tabRudderIMU = new System.Windows.Forms.TabPage();
            this.zg2 = new ZedGraph.ZedGraphControl();
            this.tabCrossBow = new System.Windows.Forms.TabPage();
            this.zg3 = new ZedGraph.ZedGraphControl();
            this.tabStringPots = new System.Windows.Forms.TabPage();
            this.zg4 = new ZedGraph.ZedGraphControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.currentStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timer2serial = new System.Windows.Forms.Timer(this.components);
            this.ActionPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabStickIMU.SuspendLayout();
            this.tabRudderIMU.SuspendLayout();
            this.tabCrossBow.SuspendLayout();
            this.tabStringPots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentStateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ActionPanel
            // 
            resources.ApplyResources(this.ActionPanel, "ActionPanel");
            this.ActionPanel.AssociatedSplitter = null;
            this.ActionPanel.BackColor = System.Drawing.Color.Transparent;
            this.ActionPanel.CaptionFont = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.ActionPanel.CaptionHeight = 27;
            this.ActionPanel.Controls.Add(this.GraphButton);
            this.ActionPanel.Controls.Add(this.ManoeuvreTextBox);
            this.ActionPanel.Controls.Add(this.ManoeuvreButton);
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
            this.ActionPanel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Katana_KeyPress);
            // 
            // GraphButton
            // 
            resources.ApplyResources(this.GraphButton, "GraphButton");
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.UseVisualStyleBackColor = true;
            this.GraphButton.Click += new System.EventHandler(this.GraphButton_Click);
            // 
            // ManoeuvreTextBox
            // 
            resources.ApplyResources(this.ManoeuvreTextBox, "ManoeuvreTextBox");
            this.ManoeuvreTextBox.Name = "ManoeuvreTextBox";
            this.ManoeuvreTextBox.ReadOnly = true;
            // 
            // ManoeuvreButton
            // 
            resources.ApplyResources(this.ManoeuvreButton, "ManoeuvreButton");
            this.ManoeuvreButton.Name = "ManoeuvreButton";
            this.ManoeuvreButton.UseVisualStyleBackColor = true;
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
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabStickIMU);
            this.tabControl1.Controls.Add(this.tabRudderIMU);
            this.tabControl1.Controls.Add(this.tabCrossBow);
            this.tabControl1.Controls.Add(this.tabStringPots);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Katana_KeyPress);
            // 
            // tabStickIMU
            // 
            this.tabStickIMU.Controls.Add(this.zg1);
            resources.ApplyResources(this.tabStickIMU, "tabStickIMU");
            this.tabStickIMU.Name = "tabStickIMU";
            this.tabStickIMU.UseVisualStyleBackColor = true;
            // 
            // zg1
            // 
            this.zg1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.zg1, "zg1");
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            // 
            // tabRudderIMU
            // 
            this.tabRudderIMU.Controls.Add(this.zg2);
            resources.ApplyResources(this.tabRudderIMU, "tabRudderIMU");
            this.tabRudderIMU.Name = "tabRudderIMU";
            this.tabRudderIMU.UseVisualStyleBackColor = true;
            // 
            // zg2
            // 
            this.zg2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.zg2, "zg2");
            this.zg2.Name = "zg2";
            this.zg2.ScrollGrace = 0D;
            this.zg2.ScrollMaxX = 0D;
            this.zg2.ScrollMaxY = 0D;
            this.zg2.ScrollMaxY2 = 0D;
            this.zg2.ScrollMinX = 0D;
            this.zg2.ScrollMinY = 0D;
            this.zg2.ScrollMinY2 = 0D;
            // 
            // tabCrossBow
            // 
            this.tabCrossBow.Controls.Add(this.zg3);
            resources.ApplyResources(this.tabCrossBow, "tabCrossBow");
            this.tabCrossBow.Name = "tabCrossBow";
            this.tabCrossBow.UseVisualStyleBackColor = true;
            // 
            // zg3
            // 
            this.zg3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.zg3, "zg3");
            this.zg3.Name = "zg3";
            this.zg3.ScrollGrace = 0D;
            this.zg3.ScrollMaxX = 0D;
            this.zg3.ScrollMaxY = 0D;
            this.zg3.ScrollMaxY2 = 0D;
            this.zg3.ScrollMinX = 0D;
            this.zg3.ScrollMinY = 0D;
            this.zg3.ScrollMinY2 = 0D;
            // 
            // tabStringPots
            // 
            this.tabStringPots.Controls.Add(this.zg4);
            resources.ApplyResources(this.tabStringPots, "tabStringPots");
            this.tabStringPots.Name = "tabStringPots";
            this.tabStringPots.UseVisualStyleBackColor = true;
            // 
            // zg4
            // 
            this.zg4.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.zg4, "zg4");
            this.zg4.Name = "zg4";
            this.zg4.ScrollGrace = 0D;
            this.zg4.ScrollMaxX = 0D;
            this.zg4.ScrollMaxY = 0D;
            this.zg4.ScrollMaxY2 = 0D;
            this.zg4.ScrollMinX = 0D;
            this.zg4.ScrollMinY = 0D;
            this.zg4.ScrollMinY2 = 0D;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // currentStateBindingSource
            // 
            this.currentStateBindingSource.DataSource = typeof(ArdupilotMega.CurrentState);
            // 
            // timer2serial
            // 
            this.timer2serial.Interval = 20;
            this.timer2serial.Tick += new System.EventHandler(this.timer2serial_Tick);
            // 
            // Katana
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ActionPanel);
            this.Name = "Katana";
            this.Load += new System.EventHandler(this.Katana_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Katana_KeyPress);
            this.ActionPanel.ResumeLayout(false);
            this.ActionPanel.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabStickIMU.ResumeLayout(false);
            this.tabRudderIMU.ResumeLayout(false);
            this.tabCrossBow.ResumeLayout(false);
            this.tabStringPots.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentStateBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BSE.Windows.Forms.Panel ActionPanel;
        private System.Windows.Forms.ComboBox cmb_Connection;
        private System.Windows.Forms.ComboBox cmb_Baud;
        private Controls.MyButton CrossbowConnectButton;
        private Controls.MyLabel myLabel1;
        private Controls.MyButton RecordButton;
        private Controls.MyButton ManoeuvreButton;
        private System.Windows.Forms.TextBox ManoeuvreTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStickIMU;
        private System.Windows.Forms.TabPage tabRudderIMU;
        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.BindingSource currentStateBindingSource;
        private System.Windows.Forms.Timer timer2serial;
        private System.Windows.Forms.TabPage tabStringPots;
        private System.Windows.Forms.TabPage tabCrossBow;
        private ZedGraph.ZedGraphControl zg2;
        private ZedGraph.ZedGraphControl zg4;
        private ZedGraph.ZedGraphControl zg3;
        private Controls.MyButton GraphButton;


    }
}
