﻿namespace ArdupilotMega
{
    partial class Katana_Sensor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Katana_Sensor));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2serial = new System.Windows.Forms.Timer(this.components);
            this.tabRawSensor = new System.Windows.Forms.TabPage();
            this.BUT_savecsv = new ArdupilotMega.Controls.MyButton();
            this.label3 = new System.Windows.Forms.Label();
            this.CMB_rawupdaterate = new System.Windows.Forms.ComboBox();
            this.aGauge1 = new AGaugeApp.AGauge();
            this.currentStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkax = new System.Windows.Forms.CheckBox();
            this.chkay = new System.Windows.Forms.CheckBox();
            this.chkaz = new System.Windows.Forms.CheckBox();
            this.chkgx = new System.Windows.Forms.CheckBox();
            this.chkgy = new System.Windows.Forms.CheckBox();
            this.chkgz = new System.Windows.Forms.CheckBox();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.Gpitch = new AGaugeApp.AGauge();
            this.Groll = new AGaugeApp.AGauge();
            this.tabOrientation = new System.Windows.Forms.TabPage();
            this.horizontalProgressBar17 = new ArdupilotMega.VerticalProgressBar();
            this.verticalProgressBar7 = new ArdupilotMega.VerticalProgressBar();
            this.verticalProgressBar6 = new ArdupilotMega.VerticalProgressBar();
            this.verticalProgressBar5 = new ArdupilotMega.VerticalProgressBar();
            this.verticalProgressBar4 = new ArdupilotMega.VerticalProgressBar();
            this.progressBar2 = new ArdupilotMega.VerticalProgressBar();
            this.progressBar1 = new ArdupilotMega.VerticalProgressBar();
            this.verticalProgressBar3 = new ArdupilotMega.VerticalProgressBar();
            this.verticalProgressBar2 = new ArdupilotMega.VerticalProgressBar();
            this.verticalProgressBar1 = new ArdupilotMega.VerticalProgressBar();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmb_Connection = new System.Windows.Forms.ComboBox();
            this.cmb_Baud = new System.Windows.Forms.ComboBox();
            this.CrossbowConnectButton = new ArdupilotMega.Controls.MyButton();
            this.tabRawSensor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentStateBindingSource)).BeginInit();
            this.tabOrientation.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2serial
            // 
            this.timer2serial.Enabled = true;
            this.timer2serial.Interval = 10;
            this.timer2serial.Tick += new System.EventHandler(this.timer2serial_Tick);
            // 
            // tabRawSensor
            // 
            this.tabRawSensor.Controls.Add(this.BUT_savecsv);
            this.tabRawSensor.Controls.Add(this.label3);
            this.tabRawSensor.Controls.Add(this.CMB_rawupdaterate);
            this.tabRawSensor.Controls.Add(this.aGauge1);
            this.tabRawSensor.Controls.Add(this.chkax);
            this.tabRawSensor.Controls.Add(this.chkay);
            this.tabRawSensor.Controls.Add(this.chkaz);
            this.tabRawSensor.Controls.Add(this.chkgx);
            this.tabRawSensor.Controls.Add(this.chkgy);
            this.tabRawSensor.Controls.Add(this.chkgz);
            this.tabRawSensor.Controls.Add(this.zg1);
            this.tabRawSensor.Controls.Add(this.Gpitch);
            this.tabRawSensor.Controls.Add(this.Groll);
            resources.ApplyResources(this.tabRawSensor, "tabRawSensor");
            this.tabRawSensor.Name = "tabRawSensor";
            this.tabRawSensor.UseVisualStyleBackColor = true;
            // 
            // BUT_savecsv
            // 
            resources.ApplyResources(this.BUT_savecsv, "BUT_savecsv");
            this.BUT_savecsv.Name = "BUT_savecsv";
            this.BUT_savecsv.UseVisualStyleBackColor = true;
            this.BUT_savecsv.Click += new System.EventHandler(this.BUT_savecsv_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // CMB_rawupdaterate
            // 
            this.CMB_rawupdaterate.FormattingEnabled = true;
            this.CMB_rawupdaterate.Items.AddRange(new object[] {
            resources.GetString("CMB_rawupdaterate.Items"),
            resources.GetString("CMB_rawupdaterate.Items1"),
            resources.GetString("CMB_rawupdaterate.Items2")});
            resources.ApplyResources(this.CMB_rawupdaterate, "CMB_rawupdaterate");
            this.CMB_rawupdaterate.Name = "CMB_rawupdaterate";
            this.CMB_rawupdaterate.SelectedIndexChanged += new System.EventHandler(this.CMB_rawupdaterate_SelectedIndexChanged);
            // 
            // aGauge1
            // 
            this.aGauge1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.aGauge1.BackgroundImage = global::ArdupilotMega.Properties.Resources.Gaugebg;
            resources.ApplyResources(this.aGauge1, "aGauge1");
            this.aGauge1.BaseArcColor = System.Drawing.Color.Gray;
            this.aGauge1.BaseArcRadius = 50;
            this.aGauge1.BaseArcStart = 270;
            this.aGauge1.BaseArcSweep = 360;
            this.aGauge1.BaseArcWidth = 2;
            this.aGauge1.basesize = new System.Drawing.Size(170, 170);
            this.aGauge1.Cap_Idx = ((byte)(2));
            this.aGauge1.CapColor = System.Drawing.Color.White;
            this.aGauge1.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.White,
        System.Drawing.Color.White,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.aGauge1.CapPosition = new System.Drawing.Point(10, 10);
            this.aGauge1.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.aGauge1.CapsText = new string[] {
        "Yaw",
        "",
        "",
        "",
        ""};
            this.aGauge1.CapText = "";
            this.aGauge1.Center = new System.Drawing.Point(85, 85);
            this.aGauge1.DataBindings.Add(new System.Windows.Forms.Binding("Value0", this.currentStateBindingSource, "yaw", true, System.Windows.Forms.DataSourceUpdateMode.Never, "0"));
            this.aGauge1.MaxValue = 359F;
            this.aGauge1.MinValue = 0F;
            this.aGauge1.Name = "aGauge1";
            this.aGauge1.Need_Idx = ((byte)(3));
            this.aGauge1.NeedleColor1 = AGaugeApp.AGauge.NeedleColorEnum.Gray;
            this.aGauge1.NeedleColor2 = System.Drawing.Color.DimGray;
            this.aGauge1.NeedleEnabled = false;
            this.aGauge1.NeedleRadius = 80;
            this.aGauge1.NeedlesColor1 = new AGaugeApp.AGauge.NeedleColorEnum[] {
        AGaugeApp.AGauge.NeedleColorEnum.Gray,
        AGaugeApp.AGauge.NeedleColorEnum.Gray,
        AGaugeApp.AGauge.NeedleColorEnum.Gray,
        AGaugeApp.AGauge.NeedleColorEnum.Gray};
            this.aGauge1.NeedlesColor2 = new System.Drawing.Color[] {
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DimGray};
            this.aGauge1.NeedlesEnabled = new bool[] {
        true,
        false,
        false,
        false};
            this.aGauge1.NeedlesRadius = new int[] {
        50,
        80,
        80,
        80};
            this.aGauge1.NeedlesType = new int[] {
        0,
        0,
        0,
        0};
            this.aGauge1.NeedlesWidth = new int[] {
        2,
        2,
        2,
        2};
            this.aGauge1.NeedleType = 0;
            this.aGauge1.NeedleWidth = 2;
            this.aGauge1.Range_Idx = ((byte)(0));
            this.aGauge1.RangeColor = System.Drawing.Color.LightGreen;
            this.aGauge1.RangeEnabled = true;
            this.aGauge1.RangeEndValue = 360F;
            this.aGauge1.RangeInnerRadius = 50;
            this.aGauge1.RangeOuterRadius = 60;
            this.aGauge1.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.DimGray,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.aGauge1.RangesEnabled = new bool[] {
        true,
        false,
        false,
        false,
        false};
            this.aGauge1.RangesEndValue = new float[] {
        360F,
        180F,
        0F,
        0F,
        0F};
            this.aGauge1.RangesInnerRadius = new int[] {
        50,
        45,
        50,
        70,
        70};
            this.aGauge1.RangesOuterRadius = new int[] {
        60,
        50,
        60,
        80,
        80};
            this.aGauge1.RangesStartValue = new float[] {
        0F,
        -180F,
        0F,
        0F,
        0F};
            this.aGauge1.RangeStartValue = 0F;
            this.aGauge1.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleLinesInterInnerRadius = 60;
            this.aGauge1.ScaleLinesInterOuterRadius = 50;
            this.aGauge1.ScaleLinesInterWidth = 1;
            this.aGauge1.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleLinesMajorInnerRadius = 50;
            this.aGauge1.ScaleLinesMajorOuterRadius = 60;
            this.aGauge1.ScaleLinesMajorStepValue = 45F;
            this.aGauge1.ScaleLinesMajorWidth = 2;
            this.aGauge1.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.aGauge1.ScaleLinesMinorInnerRadius = 50;
            this.aGauge1.ScaleLinesMinorNumOf = 2;
            this.aGauge1.ScaleLinesMinorOuterRadius = 55;
            this.aGauge1.ScaleLinesMinorWidth = 1;
            this.aGauge1.ScaleNumbersColor = System.Drawing.Color.White;
            this.aGauge1.ScaleNumbersFormat = null;
            this.aGauge1.ScaleNumbersRadius = 38;
            this.aGauge1.ScaleNumbersRotation = 0;
            this.aGauge1.ScaleNumbersStartScaleLine = 1;
            this.aGauge1.ScaleNumbersStepScaleLines = 1;
            this.aGauge1.Value = 0F;
            this.aGauge1.Value0 = 0F;
            this.aGauge1.Value1 = 0F;
            this.aGauge1.Value2 = 0F;
            this.aGauge1.Value3 = 0F;
            // 
            // currentStateBindingSource
            // 
            this.currentStateBindingSource.DataSource = typeof(ArdupilotMega.CurrentState);
            // 
            // chkax
            // 
            resources.ApplyResources(this.chkax, "chkax");
            this.chkax.Checked = true;
            this.chkax.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkax.Name = "chkax";
            this.chkax.UseVisualStyleBackColor = true;
            // 
            // chkay
            // 
            resources.ApplyResources(this.chkay, "chkay");
            this.chkay.Checked = true;
            this.chkay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkay.Name = "chkay";
            this.chkay.UseVisualStyleBackColor = true;
            // 
            // chkaz
            // 
            resources.ApplyResources(this.chkaz, "chkaz");
            this.chkaz.Checked = true;
            this.chkaz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkaz.Name = "chkaz";
            this.chkaz.UseVisualStyleBackColor = true;
            // 
            // chkgx
            // 
            resources.ApplyResources(this.chkgx, "chkgx");
            this.chkgx.Checked = true;
            this.chkgx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkgx.Name = "chkgx";
            this.chkgx.UseVisualStyleBackColor = true;
            // 
            // chkgy
            // 
            resources.ApplyResources(this.chkgy, "chkgy");
            this.chkgy.Checked = true;
            this.chkgy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkgy.Name = "chkgy";
            this.chkgy.UseVisualStyleBackColor = true;
            // 
            // chkgz
            // 
            resources.ApplyResources(this.chkgz, "chkgz");
            this.chkgz.Checked = true;
            this.chkgz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkgz.Name = "chkgz";
            this.chkgz.UseVisualStyleBackColor = true;
            // 
            // zg1
            // 
            resources.ApplyResources(this.zg1, "zg1");
            this.zg1.BackColor = System.Drawing.Color.Transparent;
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            // 
            // Gpitch
            // 
            this.Gpitch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Gpitch.BackgroundImage = global::ArdupilotMega.Properties.Resources.Gaugebg;
            resources.ApplyResources(this.Gpitch, "Gpitch");
            this.Gpitch.BaseArcColor = System.Drawing.Color.Gray;
            this.Gpitch.BaseArcRadius = 50;
            this.Gpitch.BaseArcStart = 90;
            this.Gpitch.BaseArcSweep = 360;
            this.Gpitch.BaseArcWidth = 2;
            this.Gpitch.basesize = new System.Drawing.Size(170, 170);
            this.Gpitch.Cap_Idx = ((byte)(2));
            this.Gpitch.CapColor = System.Drawing.Color.White;
            this.Gpitch.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.White,
        System.Drawing.Color.White,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.Gpitch.CapPosition = new System.Drawing.Point(10, 10);
            this.Gpitch.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.Gpitch.CapsText = new string[] {
        "Pitch",
        "",
        "",
        "",
        ""};
            this.Gpitch.CapText = "";
            this.Gpitch.Center = new System.Drawing.Point(85, 85);
            this.Gpitch.DataBindings.Add(new System.Windows.Forms.Binding("Value0", this.currentStateBindingSource, "pitch", true, System.Windows.Forms.DataSourceUpdateMode.Never, "0"));
            this.Gpitch.MaxValue = 89F;
            this.Gpitch.MinValue = -90F;
            this.Gpitch.Name = "Gpitch";
            this.Gpitch.Need_Idx = ((byte)(3));
            this.Gpitch.NeedleColor1 = AGaugeApp.AGauge.NeedleColorEnum.Gray;
            this.Gpitch.NeedleColor2 = System.Drawing.Color.DimGray;
            this.Gpitch.NeedleEnabled = false;
            this.Gpitch.NeedleRadius = 80;
            this.Gpitch.NeedlesColor1 = new AGaugeApp.AGauge.NeedleColorEnum[] {
        AGaugeApp.AGauge.NeedleColorEnum.Gray,
        AGaugeApp.AGauge.NeedleColorEnum.Gray,
        AGaugeApp.AGauge.NeedleColorEnum.Gray,
        AGaugeApp.AGauge.NeedleColorEnum.Gray};
            this.Gpitch.NeedlesColor2 = new System.Drawing.Color[] {
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DimGray};
            this.Gpitch.NeedlesEnabled = new bool[] {
        true,
        false,
        false,
        false};
            this.Gpitch.NeedlesRadius = new int[] {
        50,
        80,
        80,
        80};
            this.Gpitch.NeedlesType = new int[] {
        0,
        0,
        0,
        0};
            this.Gpitch.NeedlesWidth = new int[] {
        2,
        2,
        2,
        2};
            this.Gpitch.NeedleType = 0;
            this.Gpitch.NeedleWidth = 2;
            this.Gpitch.Range_Idx = ((byte)(2));
            this.Gpitch.RangeColor = System.Drawing.Color.LightGreen;
            this.Gpitch.RangeEnabled = true;
            this.Gpitch.RangeEndValue = -90F;
            this.Gpitch.RangeInnerRadius = 50;
            this.Gpitch.RangeOuterRadius = 60;
            this.Gpitch.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightSteelBlue,
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.LightGreen,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.Gpitch.RangesEnabled = new bool[] {
        true,
        true,
        true,
        false,
        false};
            this.Gpitch.RangesEndValue = new float[] {
        90F,
        180F,
        -90F,
        0F,
        0F};
            this.Gpitch.RangesInnerRadius = new int[] {
        50,
        50,
        50,
        70,
        70};
            this.Gpitch.RangesOuterRadius = new int[] {
        60,
        60,
        60,
        80,
        80};
            this.Gpitch.RangesStartValue = new float[] {
        -90F,
        90F,
        -180F,
        0F,
        0F};
            this.Gpitch.RangeStartValue = -180F;
            this.Gpitch.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.Gpitch.ScaleLinesInterInnerRadius = 60;
            this.Gpitch.ScaleLinesInterOuterRadius = 50;
            this.Gpitch.ScaleLinesInterWidth = 1;
            this.Gpitch.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.Gpitch.ScaleLinesMajorInnerRadius = 50;
            this.Gpitch.ScaleLinesMajorOuterRadius = 60;
            this.Gpitch.ScaleLinesMajorStepValue = 20F;
            this.Gpitch.ScaleLinesMajorWidth = 2;
            this.Gpitch.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.Gpitch.ScaleLinesMinorInnerRadius = 50;
            this.Gpitch.ScaleLinesMinorNumOf = 9;
            this.Gpitch.ScaleLinesMinorOuterRadius = 55;
            this.Gpitch.ScaleLinesMinorWidth = 1;
            this.Gpitch.ScaleNumbersColor = System.Drawing.Color.White;
            this.Gpitch.ScaleNumbersFormat = null;
            this.Gpitch.ScaleNumbersRadius = 38;
            this.Gpitch.ScaleNumbersRotation = 0;
            this.Gpitch.ScaleNumbersStartScaleLine = 1;
            this.Gpitch.ScaleNumbersStepScaleLines = 1;
            this.Gpitch.Value = 0F;
            this.Gpitch.Value0 = 0F;
            this.Gpitch.Value1 = 0F;
            this.Gpitch.Value2 = 0F;
            this.Gpitch.Value3 = 0F;
            // 
            // Groll
            // 
            this.Groll.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Groll.BackgroundImage = global::ArdupilotMega.Properties.Resources.Gaugebg;
            resources.ApplyResources(this.Groll, "Groll");
            this.Groll.BaseArcColor = System.Drawing.Color.Gray;
            this.Groll.BaseArcRadius = 50;
            this.Groll.BaseArcStart = 90;
            this.Groll.BaseArcSweep = 360;
            this.Groll.BaseArcWidth = 2;
            this.Groll.basesize = new System.Drawing.Size(170, 170);
            this.Groll.Cap_Idx = ((byte)(2));
            this.Groll.CapColor = System.Drawing.Color.White;
            this.Groll.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.White,
        System.Drawing.Color.White,
        System.Drawing.Color.White,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.Groll.CapPosition = new System.Drawing.Point(10, 10);
            this.Groll.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.Groll.CapsText = new string[] {
        "Roll",
        "",
        "",
        "",
        ""};
            this.Groll.CapText = "";
            this.Groll.Center = new System.Drawing.Point(85, 85);
            this.Groll.DataBindings.Add(new System.Windows.Forms.Binding("Value0", this.currentStateBindingSource, "roll", true, System.Windows.Forms.DataSourceUpdateMode.Never, "0"));
            this.Groll.MaxValue = 179F;
            this.Groll.MinValue = -180F;
            this.Groll.Name = "Groll";
            this.Groll.Need_Idx = ((byte)(3));
            this.Groll.NeedleColor1 = AGaugeApp.AGauge.NeedleColorEnum.Gray;
            this.Groll.NeedleColor2 = System.Drawing.Color.DimGray;
            this.Groll.NeedleEnabled = false;
            this.Groll.NeedleRadius = 80;
            this.Groll.NeedlesColor1 = new AGaugeApp.AGauge.NeedleColorEnum[] {
        AGaugeApp.AGauge.NeedleColorEnum.Gray,
        AGaugeApp.AGauge.NeedleColorEnum.Gray,
        AGaugeApp.AGauge.NeedleColorEnum.Gray,
        AGaugeApp.AGauge.NeedleColorEnum.Gray};
            this.Groll.NeedlesColor2 = new System.Drawing.Color[] {
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DimGray,
        System.Drawing.Color.DimGray};
            this.Groll.NeedlesEnabled = new bool[] {
        true,
        false,
        false,
        false};
            this.Groll.NeedlesRadius = new int[] {
        50,
        80,
        80,
        80};
            this.Groll.NeedlesType = new int[] {
        0,
        0,
        0,
        0};
            this.Groll.NeedlesWidth = new int[] {
        2,
        2,
        2,
        2};
            this.Groll.NeedleType = 0;
            this.Groll.NeedleWidth = 2;
            this.Groll.Range_Idx = ((byte)(2));
            this.Groll.RangeColor = System.Drawing.Color.LightGreen;
            this.Groll.RangeEnabled = true;
            this.Groll.RangeEndValue = -90F;
            this.Groll.RangeInnerRadius = 50;
            this.Groll.RangeOuterRadius = 60;
            this.Groll.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightSteelBlue,
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.LightGreen,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.Groll.RangesEnabled = new bool[] {
        true,
        true,
        true,
        false,
        false};
            this.Groll.RangesEndValue = new float[] {
        90F,
        180F,
        -90F,
        0F,
        0F};
            this.Groll.RangesInnerRadius = new int[] {
        50,
        50,
        50,
        70,
        70};
            this.Groll.RangesOuterRadius = new int[] {
        60,
        60,
        60,
        80,
        80};
            this.Groll.RangesStartValue = new float[] {
        -90F,
        90F,
        -180F,
        0F,
        0F};
            this.Groll.RangeStartValue = -180F;
            this.Groll.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.Groll.ScaleLinesInterInnerRadius = 60;
            this.Groll.ScaleLinesInterOuterRadius = 50;
            this.Groll.ScaleLinesInterWidth = 1;
            this.Groll.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.Groll.ScaleLinesMajorInnerRadius = 50;
            this.Groll.ScaleLinesMajorOuterRadius = 60;
            this.Groll.ScaleLinesMajorStepValue = 30F;
            this.Groll.ScaleLinesMajorWidth = 2;
            this.Groll.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.Groll.ScaleLinesMinorInnerRadius = 50;
            this.Groll.ScaleLinesMinorNumOf = 5;
            this.Groll.ScaleLinesMinorOuterRadius = 55;
            this.Groll.ScaleLinesMinorWidth = 1;
            this.Groll.ScaleNumbersColor = System.Drawing.Color.White;
            this.Groll.ScaleNumbersFormat = null;
            this.Groll.ScaleNumbersRadius = 38;
            this.Groll.ScaleNumbersRotation = 0;
            this.Groll.ScaleNumbersStartScaleLine = 1;
            this.Groll.ScaleNumbersStepScaleLines = 1;
            this.Groll.Value = 0F;
            this.Groll.Value0 = 0F;
            this.Groll.Value1 = 0F;
            this.Groll.Value2 = 0F;
            this.Groll.Value3 = 0F;
            // 
            // tabOrientation
            // 
            this.tabOrientation.Controls.Add(this.horizontalProgressBar17);
            this.tabOrientation.Controls.Add(this.verticalProgressBar7);
            this.tabOrientation.Controls.Add(this.verticalProgressBar6);
            this.tabOrientation.Controls.Add(this.verticalProgressBar5);
            this.tabOrientation.Controls.Add(this.verticalProgressBar4);
            this.tabOrientation.Controls.Add(this.progressBar2);
            this.tabOrientation.Controls.Add(this.progressBar1);
            this.tabOrientation.Controls.Add(this.verticalProgressBar3);
            this.tabOrientation.Controls.Add(this.verticalProgressBar2);
            this.tabOrientation.Controls.Add(this.verticalProgressBar1);
            resources.ApplyResources(this.tabOrientation, "tabOrientation");
            this.tabOrientation.Name = "tabOrientation";
            this.tabOrientation.UseVisualStyleBackColor = true;
            // 
            // horizontalProgressBar17
            // 
            this.horizontalProgressBar17.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.currentStateBindingSource, "gz", true, System.Windows.Forms.DataSourceUpdateMode.Never, "0"));
            resources.ApplyResources(this.horizontalProgressBar17, "horizontalProgressBar17");
            this.horizontalProgressBar17.Label = "Gyro Z";
            this.horizontalProgressBar17.MarqueeAnimationSpeed = 1;
            this.horizontalProgressBar17.Maximum = 4000;
            this.horizontalProgressBar17.maxline = 0;
            this.horizontalProgressBar17.Minimum = -4000;
            this.horizontalProgressBar17.minline = 0;
            this.horizontalProgressBar17.Name = "horizontalProgressBar17";
            this.horizontalProgressBar17.Step = 1;
            this.horizontalProgressBar17.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // verticalProgressBar7
            // 
            this.verticalProgressBar7.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.currentStateBindingSource, "ch4out", true, System.Windows.Forms.DataSourceUpdateMode.Never, "1000"));
            resources.ApplyResources(this.verticalProgressBar7, "verticalProgressBar7");
            this.verticalProgressBar7.Label = "Motor 4";
            this.verticalProgressBar7.MarqueeAnimationSpeed = 1;
            this.verticalProgressBar7.Maximum = 2000;
            this.verticalProgressBar7.maxline = 0;
            this.verticalProgressBar7.Minimum = 1000;
            this.verticalProgressBar7.minline = 0;
            this.verticalProgressBar7.Name = "verticalProgressBar7";
            this.verticalProgressBar7.Step = 1;
            this.verticalProgressBar7.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.verticalProgressBar7.Value = 1500;
            // 
            // verticalProgressBar6
            // 
            this.verticalProgressBar6.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.currentStateBindingSource, "ch3out", true, System.Windows.Forms.DataSourceUpdateMode.Never, "1000"));
            resources.ApplyResources(this.verticalProgressBar6, "verticalProgressBar6");
            this.verticalProgressBar6.Label = "Motor 3";
            this.verticalProgressBar6.MarqueeAnimationSpeed = 1;
            this.verticalProgressBar6.Maximum = 2000;
            this.verticalProgressBar6.maxline = 0;
            this.verticalProgressBar6.Minimum = 1000;
            this.verticalProgressBar6.minline = 0;
            this.verticalProgressBar6.Name = "verticalProgressBar6";
            this.verticalProgressBar6.Step = 1;
            this.verticalProgressBar6.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.verticalProgressBar6.Value = 1500;
            // 
            // verticalProgressBar5
            // 
            this.verticalProgressBar5.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.currentStateBindingSource, "ch2out", true, System.Windows.Forms.DataSourceUpdateMode.Never, "1000"));
            resources.ApplyResources(this.verticalProgressBar5, "verticalProgressBar5");
            this.verticalProgressBar5.Label = "Motor 2";
            this.verticalProgressBar5.MarqueeAnimationSpeed = 1;
            this.verticalProgressBar5.Maximum = 2000;
            this.verticalProgressBar5.maxline = 0;
            this.verticalProgressBar5.Minimum = 1000;
            this.verticalProgressBar5.minline = 0;
            this.verticalProgressBar5.Name = "verticalProgressBar5";
            this.verticalProgressBar5.Step = 1;
            this.verticalProgressBar5.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.verticalProgressBar5.Value = 1500;
            // 
            // verticalProgressBar4
            // 
            this.verticalProgressBar4.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.currentStateBindingSource, "ch1out", true, System.Windows.Forms.DataSourceUpdateMode.Never, "1000"));
            resources.ApplyResources(this.verticalProgressBar4, "verticalProgressBar4");
            this.verticalProgressBar4.Label = "Motor 1";
            this.verticalProgressBar4.MarqueeAnimationSpeed = 1;
            this.verticalProgressBar4.Maximum = 2000;
            this.verticalProgressBar4.maxline = 0;
            this.verticalProgressBar4.Minimum = 1000;
            this.verticalProgressBar4.minline = 0;
            this.verticalProgressBar4.Name = "verticalProgressBar4";
            this.verticalProgressBar4.Step = 1;
            this.verticalProgressBar4.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.verticalProgressBar4.Value = 1500;
            // 
            // progressBar2
            // 
            this.progressBar2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.currentStateBindingSource, "gx", true, System.Windows.Forms.DataSourceUpdateMode.Never, "0"));
            resources.ApplyResources(this.progressBar2, "progressBar2");
            this.progressBar2.Label = "Gyro X";
            this.progressBar2.MarqueeAnimationSpeed = 1;
            this.progressBar2.Maximum = 4000;
            this.progressBar2.maxline = 0;
            this.progressBar2.Minimum = -4000;
            this.progressBar2.minline = 0;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Step = 1;
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // progressBar1
            // 
            this.progressBar1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.currentStateBindingSource, "ax", true, System.Windows.Forms.DataSourceUpdateMode.Never, "0"));
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Label = "Accel X";
            this.progressBar1.MarqueeAnimationSpeed = 1;
            this.progressBar1.Maximum = 1200;
            this.progressBar1.maxline = 0;
            this.progressBar1.Minimum = -1200;
            this.progressBar1.minline = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // verticalProgressBar3
            // 
            this.verticalProgressBar3.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.currentStateBindingSource, "gy", true, System.Windows.Forms.DataSourceUpdateMode.Never, "0"));
            resources.ApplyResources(this.verticalProgressBar3, "verticalProgressBar3");
            this.verticalProgressBar3.Label = "Gyro Y";
            this.verticalProgressBar3.MarqueeAnimationSpeed = 1;
            this.verticalProgressBar3.Maximum = 4000;
            this.verticalProgressBar3.maxline = 0;
            this.verticalProgressBar3.Minimum = -4000;
            this.verticalProgressBar3.minline = 0;
            this.verticalProgressBar3.Name = "verticalProgressBar3";
            this.verticalProgressBar3.Step = 1;
            this.verticalProgressBar3.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // verticalProgressBar2
            // 
            this.verticalProgressBar2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.currentStateBindingSource, "ay", true, System.Windows.Forms.DataSourceUpdateMode.Never, "0"));
            resources.ApplyResources(this.verticalProgressBar2, "verticalProgressBar2");
            this.verticalProgressBar2.Label = "Accel Y";
            this.verticalProgressBar2.MarqueeAnimationSpeed = 1;
            this.verticalProgressBar2.Maximum = 1200;
            this.verticalProgressBar2.maxline = 0;
            this.verticalProgressBar2.Minimum = -1200;
            this.verticalProgressBar2.minline = 0;
            this.verticalProgressBar2.Name = "verticalProgressBar2";
            this.verticalProgressBar2.Step = 1;
            this.verticalProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // verticalProgressBar1
            // 
            this.verticalProgressBar1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.currentStateBindingSource, "az", true, System.Windows.Forms.DataSourceUpdateMode.Never, "0"));
            resources.ApplyResources(this.verticalProgressBar1, "verticalProgressBar1");
            this.verticalProgressBar1.Label = "Accel Z";
            this.verticalProgressBar1.MarqueeAnimationSpeed = 1;
            this.verticalProgressBar1.Maximum = 1200;
            this.verticalProgressBar1.maxline = 0;
            this.verticalProgressBar1.Minimum = -1200;
            this.verticalProgressBar1.minline = 0;
            this.verticalProgressBar1.Name = "verticalProgressBar1";
            this.verticalProgressBar1.Step = 1;
            this.verticalProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tabRawSensor);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmb_Connection);
            this.tabPage1.Controls.Add(this.cmb_Baud);
            this.tabPage1.Controls.Add(this.CrossbowConnectButton);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // 
            // Katana_Sensor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "Katana_Sensor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ACM_Setup_FormClosed);
            this.Load += new System.EventHandler(this.ACM_Setup_Load);
            this.tabRawSensor.ResumeLayout(false);
            this.tabRawSensor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentStateBindingSource)).EndInit();
            this.tabOrientation.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource currentStateBindingSource;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2serial;
        private System.Windows.Forms.TabPage tabRawSensor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CMB_rawupdaterate;
        private AGaugeApp.AGauge aGauge1;
        private System.Windows.Forms.CheckBox chkax;
        private System.Windows.Forms.CheckBox chkay;
        private System.Windows.Forms.CheckBox chkaz;
        private System.Windows.Forms.CheckBox chkgx;
        private System.Windows.Forms.CheckBox chkgy;
        private System.Windows.Forms.CheckBox chkgz;
        private ZedGraph.ZedGraphControl zg1;
        private AGaugeApp.AGauge Gpitch;
        private AGaugeApp.AGauge Groll;
        private System.Windows.Forms.TabPage tabOrientation;
        private VerticalProgressBar horizontalProgressBar17;
        private VerticalProgressBar verticalProgressBar7;
        private VerticalProgressBar verticalProgressBar6;
        private VerticalProgressBar verticalProgressBar5;
        private VerticalProgressBar verticalProgressBar4;
        private VerticalProgressBar progressBar2;
        private VerticalProgressBar progressBar1;
        private VerticalProgressBar verticalProgressBar3;
        private VerticalProgressBar verticalProgressBar2;
        private VerticalProgressBar verticalProgressBar1;
        private System.Windows.Forms.TabControl tabControl;
        private ArdupilotMega.Controls.MyButton BUT_savecsv;
        private System.Windows.Forms.TabPage tabPage1;
        private Controls.MyButton CrossbowConnectButton;
        private System.Windows.Forms.ComboBox cmb_Connection;
        private System.Windows.Forms.ComboBox cmb_Baud;

    }
}