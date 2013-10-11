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
            this.PotLengthSetButton = new ArdupilotMega.Controls.MyButton();
            this.LYValue = new System.Windows.Forms.NumericUpDown();
            this.Ext1Value = new System.Windows.Forms.NumericUpDown();
            this.LBCValue = new System.Windows.Forms.NumericUpDown();
            this.LABValue = new System.Windows.Forms.NumericUpDown();
            this.Ext2Value = new System.Windows.Forms.NumericUpDown();
            this.LZValue = new System.Windows.Forms.NumericUpDown();
            this.LXValue = new System.Windows.Forms.NumericUpDown();
            this.LODValue = new System.Windows.Forms.NumericUpDown();
            this.myLabel10 = new ArdupilotMega.Controls.MyLabel();
            this.myLabel8 = new ArdupilotMega.Controls.MyLabel();
            this.myLabel9 = new ArdupilotMega.Controls.MyLabel();
            this.myLabel7 = new ArdupilotMega.Controls.MyLabel();
            this.myLabel6 = new ArdupilotMega.Controls.MyLabel();
            this.myLabel5 = new ArdupilotMega.Controls.MyLabel();
            this.myLabel4 = new ArdupilotMega.Controls.MyLabel();
            this.myLabel3 = new ArdupilotMega.Controls.MyLabel();
            this.CaliFileButton = new ArdupilotMega.Controls.MyButton();
            this.RightRudderButton = new ArdupilotMega.Controls.MyButton();
            this.GraphButton = new ArdupilotMega.Controls.MyButton();
            this.LeftRudderButton = new ArdupilotMega.Controls.MyButton();
            this.ManoeuvreTextBox = new System.Windows.Forms.TextBox();
            this.RUButton = new ArdupilotMega.Controls.MyButton();
            this.ManoeuvreButton = new ArdupilotMega.Controls.MyButton();
            this.LUButton = new ArdupilotMega.Controls.MyButton();
            this.RecordButton = new ArdupilotMega.Controls.MyButton();
            this.RDButton = new ArdupilotMega.Controls.MyButton();
            this.LDButton = new ArdupilotMega.Controls.MyButton();
            this.myLabel2 = new ArdupilotMega.Controls.MyLabel();
            this.cmb_arduIMUConnect = new System.Windows.Forms.ComboBox();
            this.cmb_arduIMUBaud = new System.Windows.Forms.ComboBox();
            this.ArduIMUConnectButton = new ArdupilotMega.Controls.MyButton();
            this.myLabel1 = new ArdupilotMega.Controls.MyLabel();
            this.cmb_Connection = new System.Windows.Forms.ComboBox();
            this.cmb_Baud = new System.Windows.Forms.ComboBox();
            this.CrossbowConnectButton = new ArdupilotMega.Controls.MyButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStringPots = new System.Windows.Forms.TabPage();
            this.zg4 = new ZedGraph.ZedGraphControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabDataView = new System.Windows.Forms.TabPage();
            this.quickViewYaw = new ArdupilotMega.Widgets.QuickView();
            this.quickViewPitch = new ArdupilotMega.Widgets.QuickView();
            this.quickViewZ = new ArdupilotMega.Widgets.QuickView();
            this.quickViewY = new ArdupilotMega.Widgets.QuickView();
            this.quickView2 = new ArdupilotMega.Widgets.QuickView();
            this.quickView12 = new ArdupilotMega.Widgets.QuickView();
            this.quickViewTheta = new ArdupilotMega.Widgets.QuickView();
            this.quickViewBeta = new ArdupilotMega.Widgets.QuickView();
            this.quickViewX = new ArdupilotMega.Widgets.QuickView();
            this.quickViewRoll = new ArdupilotMega.Widgets.QuickView();
            this.quickViewRP = new ArdupilotMega.Widgets.QuickView();
            this.quickViewSP2 = new ArdupilotMega.Widgets.QuickView();
            this.quickViewSP1 = new ArdupilotMega.Widgets.QuickView();
            this.tabStickIMU = new System.Windows.Forms.TabPage();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.tabRudderIMU = new System.Windows.Forms.TabPage();
            this.zg2 = new ZedGraph.ZedGraphControl();
            this.tabCrossBow = new System.Windows.Forms.TabPage();
            this.zg3 = new ZedGraph.ZedGraphControl();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.zgStatus = new ZedGraph.ZedGraphControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.currentStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timer2serial = new System.Windows.Forms.Timer(this.components);
            this.errorTimer = new System.Windows.Forms.Timer(this.components);
            this.quickView1 = new ArdupilotMega.Widgets.QuickView();
            this.ActionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LYValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ext1Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LBCValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LABValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ext2Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LZValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LXValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LODValue)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabStringPots.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabDataView.SuspendLayout();
            this.tabStickIMU.SuspendLayout();
            this.tabRudderIMU.SuspendLayout();
            this.tabCrossBow.SuspendLayout();
            this.tabStatus.SuspendLayout();
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
            this.ActionPanel.Controls.Add(this.PotLengthSetButton);
            this.ActionPanel.Controls.Add(this.LYValue);
            this.ActionPanel.Controls.Add(this.Ext1Value);
            this.ActionPanel.Controls.Add(this.LBCValue);
            this.ActionPanel.Controls.Add(this.LABValue);
            this.ActionPanel.Controls.Add(this.Ext2Value);
            this.ActionPanel.Controls.Add(this.LZValue);
            this.ActionPanel.Controls.Add(this.LXValue);
            this.ActionPanel.Controls.Add(this.LODValue);
            this.ActionPanel.Controls.Add(this.myLabel10);
            this.ActionPanel.Controls.Add(this.myLabel8);
            this.ActionPanel.Controls.Add(this.myLabel9);
            this.ActionPanel.Controls.Add(this.myLabel7);
            this.ActionPanel.Controls.Add(this.myLabel6);
            this.ActionPanel.Controls.Add(this.myLabel5);
            this.ActionPanel.Controls.Add(this.myLabel4);
            this.ActionPanel.Controls.Add(this.myLabel3);
            this.ActionPanel.Controls.Add(this.CaliFileButton);
            this.ActionPanel.Controls.Add(this.RightRudderButton);
            this.ActionPanel.Controls.Add(this.GraphButton);
            this.ActionPanel.Controls.Add(this.LeftRudderButton);
            this.ActionPanel.Controls.Add(this.ManoeuvreTextBox);
            this.ActionPanel.Controls.Add(this.RUButton);
            this.ActionPanel.Controls.Add(this.ManoeuvreButton);
            this.ActionPanel.Controls.Add(this.LUButton);
            this.ActionPanel.Controls.Add(this.RecordButton);
            this.ActionPanel.Controls.Add(this.RDButton);
            this.ActionPanel.Controls.Add(this.LDButton);
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
            // PotLengthSetButton
            // 
            resources.ApplyResources(this.PotLengthSetButton, "PotLengthSetButton");
            this.PotLengthSetButton.Name = "PotLengthSetButton";
            this.PotLengthSetButton.UseVisualStyleBackColor = true;
            this.PotLengthSetButton.Click += new System.EventHandler(this.PotLengthSetButton_Click);
            // 
            // LYValue
            // 
            this.LYValue.DecimalPlaces = 3;
            this.LYValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.LYValue, "LYValue");
            this.LYValue.Name = "LYValue";
            this.LYValue.Value = new decimal(new int[] {
            925,
            0,
            0,
            131072});
            // 
            // Ext1Value
            // 
            this.Ext1Value.DecimalPlaces = 3;
            this.Ext1Value.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.Ext1Value, "Ext1Value");
            this.Ext1Value.Name = "Ext1Value";
            this.Ext1Value.Value = new decimal(new int[] {
            5125,
            0,
            0,
            196608});
            // 
            // LBCValue
            // 
            this.LBCValue.DecimalPlaces = 3;
            this.LBCValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.LBCValue, "LBCValue");
            this.LBCValue.Name = "LBCValue";
            this.LBCValue.Value = new decimal(new int[] {
            75,
            0,
            0,
            65536});
            // 
            // LABValue
            // 
            this.LABValue.DecimalPlaces = 3;
            this.LABValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.LABValue, "LABValue");
            this.LABValue.Name = "LABValue";
            this.LABValue.Value = new decimal(new int[] {
            300,
            0,
            0,
            131072});
            // 
            // Ext2Value
            // 
            this.Ext2Value.DecimalPlaces = 3;
            this.Ext2Value.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.Ext2Value, "Ext2Value");
            this.Ext2Value.Name = "Ext2Value";
            this.Ext2Value.Value = new decimal(new int[] {
            61875,
            0,
            0,
            262144});
            // 
            // LZValue
            // 
            this.LZValue.DecimalPlaces = 3;
            this.LZValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.LZValue, "LZValue");
            this.LZValue.Name = "LZValue";
            this.LZValue.Value = new decimal(new int[] {
            925,
            0,
            0,
            131072});
            // 
            // LXValue
            // 
            this.LXValue.DecimalPlaces = 3;
            this.LXValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.LXValue, "LXValue");
            this.LXValue.Name = "LXValue";
            this.LXValue.Value = new decimal(new int[] {
            3875,
            0,
            0,
            196608});
            // 
            // LODValue
            // 
            this.LODValue.DecimalPlaces = 3;
            this.LODValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.LODValue, "LODValue");
            this.LODValue.Name = "LODValue";
            this.LODValue.Value = new decimal(new int[] {
            95,
            0,
            0,
            65536});
            // 
            // myLabel10
            // 
            resources.ApplyResources(this.myLabel10, "myLabel10");
            this.myLabel10.Name = "myLabel10";
            this.myLabel10.resize = false;
            // 
            // myLabel8
            // 
            resources.ApplyResources(this.myLabel8, "myLabel8");
            this.myLabel8.Name = "myLabel8";
            this.myLabel8.resize = false;
            // 
            // myLabel9
            // 
            resources.ApplyResources(this.myLabel9, "myLabel9");
            this.myLabel9.Name = "myLabel9";
            this.myLabel9.resize = false;
            // 
            // myLabel7
            // 
            resources.ApplyResources(this.myLabel7, "myLabel7");
            this.myLabel7.Name = "myLabel7";
            this.myLabel7.resize = false;
            // 
            // myLabel6
            // 
            resources.ApplyResources(this.myLabel6, "myLabel6");
            this.myLabel6.Name = "myLabel6";
            this.myLabel6.resize = false;
            // 
            // myLabel5
            // 
            resources.ApplyResources(this.myLabel5, "myLabel5");
            this.myLabel5.Name = "myLabel5";
            this.myLabel5.resize = false;
            // 
            // myLabel4
            // 
            resources.ApplyResources(this.myLabel4, "myLabel4");
            this.myLabel4.Name = "myLabel4";
            this.myLabel4.resize = false;
            // 
            // myLabel3
            // 
            resources.ApplyResources(this.myLabel3, "myLabel3");
            this.myLabel3.Name = "myLabel3";
            this.myLabel3.resize = false;
            // 
            // CaliFileButton
            // 
            resources.ApplyResources(this.CaliFileButton, "CaliFileButton");
            this.CaliFileButton.Name = "CaliFileButton";
            this.CaliFileButton.UseVisualStyleBackColor = true;
            this.CaliFileButton.Click += new System.EventHandler(this.CalibrateButton_Click);
            // 
            // RightRudderButton
            // 
            resources.ApplyResources(this.RightRudderButton, "RightRudderButton");
            this.RightRudderButton.Name = "RightRudderButton";
            this.RightRudderButton.UseVisualStyleBackColor = true;
            this.RightRudderButton.Click += new System.EventHandler(this.RightRudderButton_Click);
            // 
            // GraphButton
            // 
            resources.ApplyResources(this.GraphButton, "GraphButton");
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.UseVisualStyleBackColor = true;
            this.GraphButton.Click += new System.EventHandler(this.GraphButton_Click);
            // 
            // LeftRudderButton
            // 
            resources.ApplyResources(this.LeftRudderButton, "LeftRudderButton");
            this.LeftRudderButton.Name = "LeftRudderButton";
            this.LeftRudderButton.UseVisualStyleBackColor = true;
            this.LeftRudderButton.Click += new System.EventHandler(this.LeftRudderButton_Click);
            // 
            // ManoeuvreTextBox
            // 
            resources.ApplyResources(this.ManoeuvreTextBox, "ManoeuvreTextBox");
            this.ManoeuvreTextBox.Name = "ManoeuvreTextBox";
            this.ManoeuvreTextBox.ReadOnly = true;
            // 
            // RUButton
            // 
            resources.ApplyResources(this.RUButton, "RUButton");
            this.RUButton.Name = "RUButton";
            this.RUButton.UseVisualStyleBackColor = true;
            this.RUButton.Click += new System.EventHandler(this.RUButton_Click);
            // 
            // ManoeuvreButton
            // 
            resources.ApplyResources(this.ManoeuvreButton, "ManoeuvreButton");
            this.ManoeuvreButton.Name = "ManoeuvreButton";
            this.ManoeuvreButton.UseVisualStyleBackColor = true;
            this.ManoeuvreButton.Click += new System.EventHandler(this.ManoeuvreButton_Click);
            // 
            // LUButton
            // 
            resources.ApplyResources(this.LUButton, "LUButton");
            this.LUButton.Name = "LUButton";
            this.LUButton.UseVisualStyleBackColor = true;
            this.LUButton.Click += new System.EventHandler(this.LUButton_Click);
            // 
            // RecordButton
            // 
            resources.ApplyResources(this.RecordButton, "RecordButton");
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // RDButton
            // 
            resources.ApplyResources(this.RDButton, "RDButton");
            this.RDButton.Name = "RDButton";
            this.RDButton.UseVisualStyleBackColor = true;
            this.RDButton.Click += new System.EventHandler(this.RDButton_Click);
            // 
            // LDButton
            // 
            resources.ApplyResources(this.LDButton, "LDButton");
            this.LDButton.Name = "LDButton";
            this.LDButton.UseVisualStyleBackColor = true;
            this.LDButton.Click += new System.EventHandler(this.LDButton_Click);
            // 
            // myLabel2
            // 
            resources.ApplyResources(this.myLabel2, "myLabel2");
            this.myLabel2.Name = "myLabel2";
            this.myLabel2.resize = false;
            // 
            // cmb_arduIMUConnect
            // 
            this.cmb_arduIMUConnect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_arduIMUConnect.DropDownWidth = 200;
            resources.ApplyResources(this.cmb_arduIMUConnect, "cmb_arduIMUConnect");
            this.cmb_arduIMUConnect.FormattingEnabled = true;
            this.cmb_arduIMUConnect.Name = "cmb_arduIMUConnect";
            this.cmb_arduIMUConnect.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_Connection_DrawItem);
            // 
            // cmb_arduIMUBaud
            // 
            resources.ApplyResources(this.cmb_arduIMUBaud, "cmb_arduIMUBaud");
            this.cmb_arduIMUBaud.FormattingEnabled = true;
            this.cmb_arduIMUBaud.Items.AddRange(new object[] {
            resources.GetString("cmb_arduIMUBaud.Items"),
            resources.GetString("cmb_arduIMUBaud.Items1"),
            resources.GetString("cmb_arduIMUBaud.Items2"),
            resources.GetString("cmb_arduIMUBaud.Items3"),
            resources.GetString("cmb_arduIMUBaud.Items4"),
            resources.GetString("cmb_arduIMUBaud.Items5"),
            resources.GetString("cmb_arduIMUBaud.Items6"),
            resources.GetString("cmb_arduIMUBaud.Items7"),
            resources.GetString("cmb_arduIMUBaud.Items8")});
            this.cmb_arduIMUBaud.Name = "cmb_arduIMUBaud";
            // 
            // ArduIMUConnectButton
            // 
            resources.ApplyResources(this.ArduIMUConnectButton, "ArduIMUConnectButton");
            this.ArduIMUConnectButton.Name = "ArduIMUConnectButton";
            this.ArduIMUConnectButton.UseVisualStyleBackColor = true;
            this.ArduIMUConnectButton.Click += new System.EventHandler(this.ArduIMUConnectButton_Click);
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
            resources.ApplyResources(this.cmb_Connection, "cmb_Connection");
            this.cmb_Connection.FormattingEnabled = true;
            this.cmb_Connection.Name = "cmb_Connection";
            this.cmb_Connection.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_Connection_DrawItem);
            // 
            // cmb_Baud
            // 
            resources.ApplyResources(this.cmb_Baud, "cmb_Baud");
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
            this.tabControl1.Controls.Add(this.tabStringPots);
            this.tabControl1.Controls.Add(this.tabDataView);
            this.tabControl1.Controls.Add(this.tabStickIMU);
            this.tabControl1.Controls.Add(this.tabRudderIMU);
            this.tabControl1.Controls.Add(this.tabCrossBow);
            this.tabControl1.Controls.Add(this.tabStatus);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Katana_KeyPress);
            // 
            // tabStringPots
            // 
            this.tabStringPots.Controls.Add(this.zg4);
            this.tabStringPots.Controls.Add(this.panel1);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.myLabel2);
            this.panel1.Controls.Add(this.myLabel1);
            this.panel1.Controls.Add(this.cmb_arduIMUConnect);
            this.panel1.Controls.Add(this.CrossbowConnectButton);
            this.panel1.Controls.Add(this.cmb_arduIMUBaud);
            this.panel1.Controls.Add(this.cmb_Baud);
            this.panel1.Controls.Add(this.ArduIMUConnectButton);
            this.panel1.Controls.Add(this.cmb_Connection);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // tabDataView
            // 
            this.tabDataView.Controls.Add(this.quickViewYaw);
            this.tabDataView.Controls.Add(this.quickViewPitch);
            this.tabDataView.Controls.Add(this.quickViewZ);
            this.tabDataView.Controls.Add(this.quickViewY);
            this.tabDataView.Controls.Add(this.quickView1);
            this.tabDataView.Controls.Add(this.quickView2);
            this.tabDataView.Controls.Add(this.quickView12);
            this.tabDataView.Controls.Add(this.quickViewTheta);
            this.tabDataView.Controls.Add(this.quickViewBeta);
            this.tabDataView.Controls.Add(this.quickViewX);
            this.tabDataView.Controls.Add(this.quickViewRoll);
            this.tabDataView.Controls.Add(this.quickViewRP);
            this.tabDataView.Controls.Add(this.quickViewSP2);
            this.tabDataView.Controls.Add(this.quickViewSP1);
            resources.ApplyResources(this.tabDataView, "tabDataView");
            this.tabDataView.Name = "tabDataView";
            this.tabDataView.UseVisualStyleBackColor = true;
            // 
            // quickViewYaw
            // 
            this.quickViewYaw.desc = "Yaw Ratio";
            resources.ApplyResources(this.quickViewYaw, "quickViewYaw");
            this.quickViewYaw.Name = "quickViewYaw";
            this.quickViewYaw.number = 0D;
            this.quickViewYaw.numberColor = System.Drawing.SystemColors.ControlText;
            // 
            // quickViewPitch
            // 
            this.quickViewPitch.desc = "Pitch Ratio";
            resources.ApplyResources(this.quickViewPitch, "quickViewPitch");
            this.quickViewPitch.Name = "quickViewPitch";
            this.quickViewPitch.number = 0D;
            this.quickViewPitch.numberColor = System.Drawing.SystemColors.ControlText;
            // 
            // quickViewZ
            // 
            this.quickViewZ.desc = "Stick Pos Z";
            resources.ApplyResources(this.quickViewZ, "quickViewZ");
            this.quickViewZ.Name = "quickViewZ";
            this.quickViewZ.number = 0D;
            this.quickViewZ.numberColor = System.Drawing.SystemColors.ControlText;
            // 
            // quickViewY
            // 
            this.quickViewY.desc = "Stick Pos Y";
            resources.ApplyResources(this.quickViewY, "quickViewY");
            this.quickViewY.Name = "quickViewY";
            this.quickViewY.number = 0D;
            this.quickViewY.numberColor = System.Drawing.SystemColors.ControlText;
            // 
            // quickView2
            // 
            this.quickView2.desc = "Extra2";
            resources.ApplyResources(this.quickView2, "quickView2");
            this.quickView2.Name = "quickView2";
            this.quickView2.number = 0D;
            this.quickView2.numberColor = System.Drawing.SystemColors.ControlText;
            // 
            // quickView12
            // 
            this.quickView12.desc = "Extra1";
            resources.ApplyResources(this.quickView12, "quickView12");
            this.quickView12.Name = "quickView12";
            this.quickView12.number = 0D;
            this.quickView12.numberColor = System.Drawing.SystemColors.ControlText;
            // 
            // quickViewTheta
            // 
            this.quickViewTheta.desc = "Theta";
            resources.ApplyResources(this.quickViewTheta, "quickViewTheta");
            this.quickViewTheta.Name = "quickViewTheta";
            this.quickViewTheta.number = 0D;
            this.quickViewTheta.numberColor = System.Drawing.SystemColors.ControlText;
            // 
            // quickViewBeta
            // 
            this.quickViewBeta.desc = "Beta";
            resources.ApplyResources(this.quickViewBeta, "quickViewBeta");
            this.quickViewBeta.Name = "quickViewBeta";
            this.quickViewBeta.number = 0D;
            this.quickViewBeta.numberColor = System.Drawing.SystemColors.ControlText;
            // 
            // quickViewX
            // 
            this.quickViewX.desc = "Stick Pos X";
            resources.ApplyResources(this.quickViewX, "quickViewX");
            this.quickViewX.Name = "quickViewX";
            this.quickViewX.number = 0D;
            this.quickViewX.numberColor = System.Drawing.SystemColors.ControlText;
            // 
            // quickViewRoll
            // 
            this.quickViewRoll.desc = "Roll Ratio";
            resources.ApplyResources(this.quickViewRoll, "quickViewRoll");
            this.quickViewRoll.Name = "quickViewRoll";
            this.quickViewRoll.number = 0D;
            this.quickViewRoll.numberColor = System.Drawing.SystemColors.ControlText;
            // 
            // quickViewRP
            // 
            this.quickViewRP.desc = "String Pot 3";
            resources.ApplyResources(this.quickViewRP, "quickViewRP");
            this.quickViewRP.Name = "quickViewRP";
            this.quickViewRP.number = 0D;
            this.quickViewRP.numberColor = System.Drawing.SystemColors.ControlText;
            // 
            // quickViewSP2
            // 
            this.quickViewSP2.desc = "String Pot 2";
            resources.ApplyResources(this.quickViewSP2, "quickViewSP2");
            this.quickViewSP2.Name = "quickViewSP2";
            this.quickViewSP2.number = 0D;
            this.quickViewSP2.numberColor = System.Drawing.SystemColors.ControlText;
            // 
            // quickViewSP1
            // 
            this.quickViewSP1.desc = "String Pot 1";
            resources.ApplyResources(this.quickViewSP1, "quickViewSP1");
            this.quickViewSP1.Name = "quickViewSP1";
            this.quickViewSP1.number = 0D;
            this.quickViewSP1.numberColor = System.Drawing.SystemColors.ControlText;
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
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.zgStatus);
            resources.ApplyResources(this.tabStatus, "tabStatus");
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.UseVisualStyleBackColor = true;
            // 
            // zgStatus
            // 
            this.zgStatus.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.zgStatus, "zgStatus");
            this.zgStatus.Name = "zgStatus";
            this.zgStatus.ScrollGrace = 0D;
            this.zgStatus.ScrollMaxX = 0D;
            this.zgStatus.ScrollMaxY = 0D;
            this.zgStatus.ScrollMaxY2 = 0D;
            this.zgStatus.ScrollMinX = 0D;
            this.zgStatus.ScrollMinY = 0D;
            this.zgStatus.ScrollMinY2 = 0D;
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
            // errorTimer
            // 
            this.errorTimer.Interval = 10000;
            this.errorTimer.Tick += new System.EventHandler(this.errorTimer_Tick);
            // 
            // quickView1
            // 
            this.quickView1.desc = "Extra3";
            resources.ApplyResources(this.quickView1, "quickView1");
            this.quickView1.Name = "quickView1";
            this.quickView1.number = 0D;
            this.quickView1.numberColor = System.Drawing.SystemColors.ControlText;
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
            ((System.ComponentModel.ISupportInitialize)(this.LYValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ext1Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LBCValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LABValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ext2Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LZValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LXValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LODValue)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabStringPots.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabDataView.ResumeLayout(false);
            this.tabStickIMU.ResumeLayout(false);
            this.tabRudderIMU.ResumeLayout(false);
            this.tabCrossBow.ResumeLayout(false);
            this.tabStatus.ResumeLayout(false);
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
        private Controls.MyButton RightRudderButton;
        private Controls.MyButton LeftRudderButton;
        private Controls.MyButton RUButton;
        private Controls.MyButton LUButton;
        private Controls.MyButton RDButton;
        private Controls.MyButton LDButton;
        private Controls.MyButton CaliFileButton;
        private Controls.MyLabel myLabel2;
        private System.Windows.Forms.ComboBox cmb_arduIMUConnect;
        private System.Windows.Forms.ComboBox cmb_arduIMUBaud;
        private Controls.MyButton ArduIMUConnectButton;
        private System.Windows.Forms.TabPage tabStatus;
        private ZedGraph.ZedGraphControl zgStatus;
        private System.Windows.Forms.Timer errorTimer;
        private Controls.MyLabel myLabel8;
        private Controls.MyLabel myLabel7;
        private Controls.MyLabel myLabel6;
        private Controls.MyLabel myLabel5;
        private Controls.MyLabel myLabel4;
        private Controls.MyLabel myLabel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown LODValue;
        private Controls.MyButton PotLengthSetButton;
        private System.Windows.Forms.NumericUpDown LYValue;
        private System.Windows.Forms.NumericUpDown LBCValue;
        private System.Windows.Forms.NumericUpDown LABValue;
        private System.Windows.Forms.NumericUpDown LZValue;
        private System.Windows.Forms.NumericUpDown LXValue;
        private System.Windows.Forms.NumericUpDown Ext1Value;
        private System.Windows.Forms.NumericUpDown Ext2Value;
        private Controls.MyLabel myLabel10;
        private Controls.MyLabel myLabel9;
        private System.Windows.Forms.TabPage tabDataView;
        private Widgets.QuickView quickViewYaw;
        private Widgets.QuickView quickViewPitch;
        private Widgets.QuickView quickViewZ;
        private Widgets.QuickView quickViewY;
        private Widgets.QuickView quickView2;
        private Widgets.QuickView quickView12;
        private Widgets.QuickView quickViewTheta;
        private Widgets.QuickView quickViewBeta;
        private Widgets.QuickView quickViewX;
        private Widgets.QuickView quickViewRoll;
        private Widgets.QuickView quickViewRP;
        private Widgets.QuickView quickViewSP2;
        private Widgets.QuickView quickViewSP1;
        private Widgets.QuickView quickView1;


    }
}
