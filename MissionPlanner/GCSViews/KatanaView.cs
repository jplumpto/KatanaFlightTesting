using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ZedGraph;

using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace ArdupilotMega.GCSViews
{
    #region SerialStatus
    enum SerialStatus
    {
        CONNECTION_FAILURE = -1,
        PING_RESPONSE_FAILURE = -2,
        PACKET_SIZE_MISSMATCH = -3,
        BAUD_RATE_CHANGE_FAIL = -4,
        SUCCESS = 1
    }
    #endregion

    #region DataPacket
    struct AHRSDataPacket
    {
        public string time;
        public double roll;
        public double pitch;
        public double yaw;
        public double v_roll;
        public double v_pitch;
        public double v_yaw;
        public double a_x;
        public double a_y;
        public double a_z;
        public double mag_x;
        public double mag_y;
        public double mag_z;
        public double temp_sensor;
        public UInt16 ahrs_time;

        public string getline()
        {
            string outputLine = roll.ToString() + ", " + pitch.ToString() + ", " + yaw.ToString()
                + ", " + v_roll.ToString() + ", " + v_pitch.ToString() + ", " + v_yaw.ToString() + ", " +
                a_x.ToString() + ", " + a_y.ToString() + ", " + a_z.ToString() + ", " + mag_x.ToString()
                + ", " + mag_y.ToString() + ", " + mag_z.ToString() + ", " + temp_sensor.ToString()
                + ", " + ahrs_time.ToString();
            return outputLine;
        }

        public string getlineRads()
        {
            const double GRAVITY = 9.80;
            const double Deg2Rad = Math.PI / 180.0;
            string outputLine = (roll * Deg2Rad).ToString() + ", " + (pitch * Deg2Rad).ToString() + ", " + (yaw * Deg2Rad).ToString()
                + ", " + (v_roll * Deg2Rad).ToString() + ", " + (v_pitch * Deg2Rad).ToString() + ", " + (v_yaw * Deg2Rad).ToString() + ", " +
                (a_x * GRAVITY).ToString() + ", " + (a_y * GRAVITY).ToString() + ", " + (a_z * GRAVITY).ToString() + ", " + mag_x.ToString()
                + ", " + mag_y.ToString() + ", " + mag_z.ToString() + ", " + temp_sensor.ToString()
                + ", " + ahrs_time.ToString();
            return outputLine;
        }

        public string getDebug()
        {
            string outputLine = time + ", " + String.Format("{0:0.000}", roll) + ", " + String.Format("{0:0.000}", pitch) + ", " + String.Format("{0:0.000}", yaw);
            return outputLine;
        }

        public string getFormat()
        {
            string AHRSFormat = "Roll (deg) ,  Pitch (deg) ,  Yaw (deg) ,  RollRate (deg/s),  PitchRate (deg/s) ,  YawRate (deg/s) ,  XAccel (Gs) ,  YAccel (Gs) ,  ZAccel (Gs) ,  XMag (gauss),  YMag (gauss) ,  ZMag (gauss) ,  InTemp (C) ,  AHRSTicks";
            return AHRSFormat;
        }

        public string getFormatRad()
        {
            string AHRSFormat = "Roll (rad) ,  Pitch (rad) ,  Yaw (rad) ,  RollRate (rad/s) ,  PitchRate (rad/s) ,  YawRate (rad/s) ,  XAccel (m/s/s) ,  YAccel (m/s/s) ,  ZAccel (m/s/s) ,  XMag (gauss),  YMag (gauss) ,  ZMag (gauss) ,  InTemp (C) ,  AHRSTicks";
            return AHRSFormat;
        }
    }
    #endregion
    
    #region KatanaViewClass
    public partial class Katana : MyUserControl
    {
        #region Graph
        RollingPointPairList list1 = new RollingPointPairList(10 * 50);
        RollingPointPairList list2 = new RollingPointPairList(10 * 50);
        RollingPointPairList list3 = new RollingPointPairList(10 * 50);
        RollingPointPairList list4 = new RollingPointPairList(10 * 50);
        RollingPointPairList list5 = new RollingPointPairList(10 * 50);
        RollingPointPairList list6 = new RollingPointPairList(10 * 50);

        RollingPointPairList[] stickIMUList = new RollingPointPairList[6] {
            new RollingPointPairList(10 * 50), new RollingPointPairList(10 * 50),
            new RollingPointPairList(10 * 50), new RollingPointPairList(10 * 50),
            new RollingPointPairList(10 * 50), new RollingPointPairList(10 * 50) };

        RollingPointPairList[] rudderIMUList = new RollingPointPairList[6] {
            new RollingPointPairList(10 * 50), new RollingPointPairList(10 * 50),
            new RollingPointPairList(10 * 50), new RollingPointPairList(10 * 50),
            new RollingPointPairList(10 * 50), new RollingPointPairList(10 * 50) };
        RollingPointPairList[] CrossbowIMUList = new RollingPointPairList[6] {
            new RollingPointPairList(10 * 50), new RollingPointPairList(10 * 50),
            new RollingPointPairList(10 * 50), new RollingPointPairList(10 * 50),
            new RollingPointPairList(10 * 50), new RollingPointPairList(10 * 50) };
        RollingPointPairList[] StringPotList = new RollingPointPairList[3] {
            new RollingPointPairList(10 * 50), new RollingPointPairList(10 * 50),
            new RollingPointPairList(10 * 50)};
        RollingPointPairList[] StatusList = new RollingPointPairList[3] {
            new RollingPointPairList(10 * 50), new RollingPointPairList(10 * 50),
            new RollingPointPairList(10 * 50)};
        object thisLock = new object();

        private int tickStart = 0;
        private ZedGraph.ZedGraphControl[] _graphList;
        private ZedGraph.ZedGraphControl _zgPointer = null;
        private int _currentGraphNumber = 1;
        private bool _updateGraph = false;
        #endregion

        #region Variables
        const double Deg2Rad = Math.PI / 180.0;
        const double Rad2Deg = 1 / Deg2Rad;
        private AhrsSerialData _crossbowConnection;
        private ArduIMUSerialData _arduIMUConnection;
        private ControlInputsClass _controlInputs;
        private Mutex _AHRSMutex = new Mutex();
        private Mutex _ArduIMUMutex = new Mutex();
        private Mutex _ManoeuvreMutex = new Mutex();
        private Thread _AHRSThread = null;
        private Thread _ArduIMUThread = null;
        private Thread _RecordingThread = null;
        private bool _isRecording = false;
        private int _manoeuvreNumber = 0;
        private bool _isCalibrating = false;
        private bool ArduIMUConnected = false;
        private bool CrossbowConnected = false;
        #endregion

        #region Constructor
        public Katana()
        {
            InitializeComponent();

            _zgPointer = zg1;
            _graphList = new ZedGraph.ZedGraphControl[5] { zg1, zg2, zg3, zg4, zgStatus };

            CreateIMUChart(zg1, "Stick IMU Raw Sensors", "Time", "Raw Data", stickIMUList);
            CreateIMUChart(zg2, "Rudder IMU Raw Sensors", "Time", "Raw Data", rudderIMUList);
            CreateIMUChart(zg3, "Crossbow IMU Raw Sensors", "Time", "Raw Data", CrossbowIMUList);
            //string[] var_names = {"String Pot 1", "String Pot 2", "Rudder Pot"};
            //CreateStringPotChart(zg4, "String Pot Raw Sensors", "Time", "Raw Data", StringPotList);
            string[] var_names = { "Roll", "Pitch", "Yaw" };
            CreateStringPotChart(zg4, "Control Input Values", "Time", "Input Ratio [-1,1]", StringPotList,var_names);
            CreateStatusChart(zgStatus, "Uno Board Status", "Time", "Status", StatusList);
        }

        public struct plot
        {
            public string Name;
            public RollingPointPairList PointList;
            public Color color;
        }

        private void Katana_Load(object sender, EventArgs e)
        {
            cmb_Connection.Items.AddRange(ArdupilotMega.Comms.SerialPort.GetPortNames());
            cmb_arduIMUConnect.Items.AddRange(ArdupilotMega.Comms.SerialPort.GetPortNames());
            _crossbowConnection = new AhrsSerialData(_AHRSMutex);
            _arduIMUConnection = new ArduIMUSerialData(_ArduIMUMutex);
            _controlInputs = new ControlInputsClass();
            CalibrationButtonStates(false);

            tickStart = Environment.TickCount;
            errorTimer.Enabled = true;
            errorTimer.Start();
        }
        #endregion

        #region FaultCheck
        private void errorTimer_Tick(object sender, EventArgs e)
        {
            if (ArduIMUConnected && ( _arduIMUConnection == null || !_arduIMUConnection.IsOpen() || !_arduIMUConnection.Monitoring) )
            {
                CustomMessageBox.Show("ArduIMUs failed: " + _arduIMUConnection.GetErrorMessage());
                //disconnect
                _arduIMUConnection.DisconnectSerial();
                ArduIMUIsConnected(false);
            }

            if (CrossbowConnected && (_crossbowConnection == null || !_crossbowConnection.IsOpen() || !_crossbowConnection.Monitoring) )
            {
                CustomMessageBox.Show("Crossbow failed: " + _crossbowConnection.GetErrorMessage());
                //disconnect
                _crossbowConnection.DisconnectSerial();
                CrossbowIsConnected(false);
            }
        }
        #endregion

        #region Crossbow
        private void CrossbowConnectButton_Click(object sender, EventArgs e)
        {
            if (!_crossbowConnection.IsOpen())
            {
                //Connect to Crossbow
                string port = cmb_Connection.Text;
                string baudrate = cmb_Baud.Text;

                SerialStatus stat = _crossbowConnection.ConnectSerial(port, int.Parse(baudrate));

                switch (stat)
                {
                    case SerialStatus.SUCCESS:
                        //Console.WriteLine("Successfully connected to AHRS.");
                        break;
                    case SerialStatus.BAUD_RATE_CHANGE_FAIL:
                        CustomMessageBox.Show("Failed to switch from default baud rate: " + _crossbowConnection.GetErrorMessage());
                        break;
                    case SerialStatus.PING_RESPONSE_FAILURE:
                    case SerialStatus.CONNECTION_FAILURE:
                    case SerialStatus.PACKET_SIZE_MISSMATCH:
                        //Console.WriteLine(_crossbowConnection.GetErrorMessage());
                        CustomMessageBox.Show("Failed to connect: " + _crossbowConnection.GetErrorMessage());
                        return;
                }

                CrossbowIsConnected(true);
                _AHRSThread = new Thread(new ThreadStart(_crossbowConnection.MonitorSerial));
                _AHRSThread.Start();
            }
            else
            {
                //disconnect
                _crossbowConnection.DisconnectSerial();
                CrossbowIsConnected(false);
            }
        }
        #endregion

        #region ArduIMU
        private void ArduIMUConnectButton_Click(object sender, EventArgs e)
        {
            if (!_arduIMUConnection.IsOpen())
            {
                //Connect to Crossbow
                string port = cmb_arduIMUConnect.Text;
                string baudrate = cmb_arduIMUBaud.Text;

                SerialStatus stat = _arduIMUConnection.ConnectSerial(port, int.Parse(baudrate));

                switch (stat)
                {
                    case SerialStatus.SUCCESS:
                        break;
                    case SerialStatus.BAUD_RATE_CHANGE_FAIL:
                        CustomMessageBox.Show("Failed to switch from default baud rate: " + _arduIMUConnection.GetErrorMessage());
                        break;
                    case SerialStatus.PING_RESPONSE_FAILURE:
                    case SerialStatus.CONNECTION_FAILURE:
                    case SerialStatus.PACKET_SIZE_MISSMATCH:
                        CustomMessageBox.Show("Failed to connect: " + _arduIMUConnection.GetErrorMessage());
                        return;
                }

                ArduIMUIsConnected(true);
                _ArduIMUThread = new Thread(new ThreadStart(_arduIMUConnection.MonitorSerial));
                _ArduIMUThread.Start();
            }
            else
            {
                //disconnect
                _arduIMUConnection.DisconnectSerial();
                ArduIMUIsConnected(false);
            }
        }
        #endregion

        #region AuxTab
        //Auxiliary
        public ComboBox CMB_baudrate { get { return this.cmb_Baud; } }
        public ComboBox CMB_serialport { get { return this.cmb_Connection; } }

        /// <summary>
        /// Called from the main form - set whether we are connected or not currently.
        /// UI will be updated accordingly
        /// </summary>
        /// <param name="isConnected">Whether we are connected</param>
        public void CrossbowIsConnected(bool isConnected)
        {
            cmb_Baud.Enabled = !isConnected;
            cmb_Connection.Enabled = !isConnected;
            CrossbowConnectButton.Text = isConnected ? "Disconnect" : "Connect";
            CrossbowConnected = isConnected;
        }

        /// <summary>
        /// Called from the main form - set whether we are connected or not currently.
        /// UI will be updated accordingly
        /// </summary>
        /// <param name="isConnected">Whether we are connected</param>
        public void ArduIMUIsConnected(bool isConnected)
        {
            cmb_arduIMUBaud.Enabled = !isConnected;
            cmb_arduIMUConnect.Enabled = !isConnected;
            ArduIMUConnectButton.Text = isConnected ? "Disconnect" : "Connect";
            ArduIMUConnected = isConnected;
        }

        private void cmb_Connection_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;

            ComboBox combo = sender as ComboBox;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight),
                                         e.Bounds);
            else
                e.Graphics.FillRectangle(new SolidBrush(combo.BackColor),
                                         e.Bounds);

            string text = combo.Items[e.Index].ToString();
            if (!MainV2.MONO)
            {
                text = text + " " + ArdupilotMega.Comms.SerialPort.GetNiceName(text);
            }

            e.Graphics.DrawString(text, e.Font,
                                  new SolidBrush(combo.ForeColor),
                                  new Point(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }
        #endregion

        #region RecordButton
        private void RecordButton_Click(object sender, EventArgs e)
        {
            RecordButton.Enabled = false; //Prevent multiple clicks
            if (_isRecording)
            {
                //Kills Recording Thread
                _isRecording = false;
                RecordButton.Text = "Record Data";
                Thread.Sleep(10);
                RecordButton.Enabled = true;
                CrossbowConnectButton.Enabled = true;
            } //if
            else
            {
                //Kill all streams
                MainV2.comPort.stopall(true);

                //Request High Frequency
                MainV2.comPort.requestDatastream(ArdupilotMega.MAVLink.MAV_DATA_STREAM.RAW_SENSORS, (byte)50); // request raw sensor
                MainV2.comPort.requestDatastream(ArdupilotMega.MAVLink.MAV_DATA_STREAM.POSITION, (byte)25);
                BeginRecording();
            }
        }

        System.IO.StreamWriter sw = null;
        private void BeginRecording()
        {
            //Disable Crossbow Button so user can't change status while recording
            CrossbowConnectButton.Enabled = false;

            //Two Cases - Crossbow vs no Crossbow
            if (_crossbowConnection.IsOpen()) // Crossbow is connected
            {
                //Create thread to read from both sources
                _RecordingThread = new Thread(new ThreadStart(RecordingWCrossbow));
            } //if
            else
            {
                //Create thread to save
                _RecordingThread = new Thread(new ThreadStart(RecordingWOutCrossbow));
            } //else

            //Start Thread
            _isRecording = true;
            _RecordingThread.Start();


            //Re-enable Button
            RecordButton.Enabled = true;
            RecordButton.Text = "Stop Recording";
        }
        #endregion

        #region RecordThreads
        private void RecordingWCrossbow()
        {
            //Create StreamWriter
            DateTime currenttime = DateTime.Now;
            string filename = "KatanaFlightData_" + currenttime.Year.ToString("0000") + currenttime.Month.ToString("00") + 
                currenttime.Day.ToString("00") + "_" + currenttime.Hour.ToString("00") + currenttime.Minute.ToString("00") + 
                currenttime.Second.ToString("00") + ".csv";
            sw = new System.IO.StreamWriter(filename);

            string format = _crossbowConnection.GetLineFormat() + ", " + MainV2.comPort.MAV.cs.KatanaFlightTestFormat();

            if (_arduIMUConnection.IsOpen())
            {
                format += "," + _arduIMUConnection.GetLineFormat();
            }
            format += ", Manoeuvre Number";
            sw.WriteLine(format);

            while (_isRecording)
            {
                Thread.Sleep(20);
                
                string data = _crossbowConnection.GetCurrentData() + ", " + MainV2.comPort.MAV.cs.KatanaFlightTestData();
                if (_arduIMUConnection.IsOpen())
                {
                    data += "," + _arduIMUConnection.GetCurrentData();
                }

                _ManoeuvreMutex.WaitOne();
                data += ", " + _manoeuvreNumber.ToString();
                _ManoeuvreMutex.ReleaseMutex();
                sw.WriteLine(data);
            }
            sw.Close();

            //Give user back access to button
            _isRecording = false;
        }

        private void RecordingWOutCrossbow()
        {
            //Create StreamWriter
            DateTime currenttime = DateTime.Now;
            string filename = "KatanaFlightData_" + currenttime.Year.ToString("0000") + currenttime.Month.ToString("00") +
                currenttime.Day.ToString("00") + "_" + currenttime.Hour.ToString("00") + currenttime.Minute.ToString("00") +
                currenttime.Second.ToString("00") + ".csv";
            sw = new System.IO.StreamWriter(filename);

            string format = "Time (hh:mm:ss.mmm), " + MainV2.comPort.MAV.cs.KatanaFlightTestFormat();

            if (_arduIMUConnection.IsOpen())
            {
                format += "," + _arduIMUConnection.GetLineFormat();
            }
            format += ", Manoeuvre Number";
            sw.WriteLine(format);

            while (_isRecording)
            {
                Thread.Sleep(20);
                currenttime = DateTime.Now;
                string time = currenttime.Hour.ToString() + ":" + currenttime.Minute.ToString("00") + ":" + currenttime.Second.ToString("00")
                    + "." + currenttime.Millisecond.ToString("000");
                
                string data = time + ", " + MainV2.comPort.MAV.cs.KatanaFlightTestData();
                if (_arduIMUConnection.IsOpen())
                {
                    data += "," + _arduIMUConnection.GetCurrentData();
                }

                _ManoeuvreMutex.WaitOne();
                data += ", " + _manoeuvreNumber.ToString();
                _ManoeuvreMutex.ReleaseMutex();
                sw.WriteLine(data);
            }
            sw.Close();

            //Give user back access to button
            _isRecording = false;
        }
        #endregion

        #region Manoeuvre
        private void ManoeuvreButton_Click(object sender, EventArgs e)
        {
            _ManoeuvreMutex.WaitOne();
            _manoeuvreNumber++;
            _ManoeuvreMutex.ReleaseMutex();

            ManoeuvreTextBox.Text = _manoeuvreNumber.ToString();
        }

        void Manoeuvre_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _ManoeuvreMutex.WaitOne();
                _manoeuvreNumber++;
                _ManoeuvreMutex.ReleaseMutex();

                ManoeuvreTextBox.Text = _manoeuvreNumber.ToString();
            }
        }

        #endregion

        #region Graph
        #region Create
        public void CreateStringPotChart(ZedGraphControl zgc, string Title, string XAxis, string YAxis, RollingPointPairList[] list, string[] var_names)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = Title;
            myPane.XAxis.Title.Text = XAxis;
            myPane.YAxis.Title.Text = YAxis;

            LineItem myCurve;

            myCurve = myPane.AddCurve(var_names[0], list[0], Color.Red, SymbolType.None);
            myCurve = myPane.AddCurve(var_names[1], list[1], Color.Green, SymbolType.None);
            myCurve = myPane.AddCurve(var_names[2], list[2], Color.SandyBrown, SymbolType.None);
            

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 5;

            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = true;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            //myPane.YAxis.Scale.Min = -1;
            //myPane.YAxis.Scale.Max = 1;

            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

        }

        public void CreateIMUChart(ZedGraphControl zgc, string Title, string XAxis, string YAxis, RollingPointPairList[] list)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = Title;
            myPane.XAxis.Title.Text = XAxis;
            myPane.YAxis.Title.Text = YAxis;

            LineItem myCurve;

            myCurve = myPane.AddCurve("Accel X", list[0], Color.Red, SymbolType.None);
            myCurve = myPane.AddCurve("Accel Y", list[1], Color.Green, SymbolType.None);
            myCurve = myPane.AddCurve("Accel Z", list[2], Color.SandyBrown, SymbolType.None);
            myCurve = myPane.AddCurve("Gyro X", list[3], Color.Blue, SymbolType.None);
            myCurve = myPane.AddCurve("Gyro Y", list[4], Color.Black, SymbolType.None);
            myCurve = myPane.AddCurve("Gyro Z", list[5], Color.Violet, SymbolType.None);


            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 5;

            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = true;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            //myPane.YAxis.Scale.Min = -1;
            //myPane.YAxis.Scale.Max = 1;

            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

        }

        public void CreateStatusChart(ZedGraphControl zgc, string Title, string XAxis, string YAxis, RollingPointPairList[] list)
        {
            GraphPane myPane = zgc.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = Title;
            myPane.XAxis.Title.Text = XAxis;
            myPane.YAxis.Title.Text = YAxis;

            LineItem myCurve;

            myCurve = myPane.AddCurve("Uno Update Freq", list[0], Color.Red, SymbolType.None);
            myCurve = myPane.AddCurve("CS Bytes Read", list[1], Color.Green, SymbolType.None);
            myCurve = myPane.AddCurve("RP Bytes Read", list[2], Color.SandyBrown, SymbolType.None);
            //myCurve = myPane.AddCurve("Gyro X", list[3], Color.Blue, SymbolType.None);
            //myCurve = myPane.AddCurve("Gyro Y", list[4], Color.Black, SymbolType.None);
            //myCurve = myPane.AddCurve("Gyro Z", list[5], Color.Violet, SymbolType.None);


            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 5;

            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = true;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            //myPane.YAxis.Scale.Min = -1;
            //myPane.YAxis.Scale.Max = 1;

            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();

        }
        #endregion

        #region TimerTicks
        private void timer1_Tick(object sender, EventArgs e)
        {
            double time = (Environment.TickCount - tickStart) / 1000.0;

            foreach (ZedGraph.ZedGraphControl zgPointer in _graphList)
            {
                // Make sure that the curvelist has at least one curve
                if (zgPointer.GraphPane == null || zgPointer.GraphPane.CurveList.Count <= 0)
                    continue;

                // Get the first CurveItem in the graph
                LineItem curve = zgPointer.GraphPane.CurveList[0] as LineItem;
                if (curve == null)
                    continue;

                // Get the PointPairList
                IPointListEdit list = curve.Points as IPointListEdit;
                // If this is null, it means the reference at curve.Points does not
                // support IPointListEdit, so we won't be able to modify it
                if (list == null)
                    continue;

                // Time is measured in seconds
                //double time = (Environment.TickCount - tickStart) / 1000.0;

                // Keep the X scale at a rolling 30 second interval, with one
                // major step between the max X value and the end of the axis
                Scale xScale = zgPointer.GraphPane.XAxis.Scale;
                if (time > xScale.Max - xScale.MajorStep)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 10.0;
                }

                // Make sure the Y axis is rescaled to accommodate actual data
                try
                {
                    zgPointer.AxisChange();
                }
                catch { }
                // Force a redraw
                zgPointer.Invalidate();
            }

            #region Single
            //// Make sure that the curvelist has at least one curve
            //if (_zgPointer.GraphPane == null || _zgPointer.GraphPane.CurveList.Count <= 0)
            //    return;

            //// Get the first CurveItem in the graph
            //LineItem curve = _zgPointer.GraphPane.CurveList[0] as LineItem;
            //if (curve == null)
            //    return;

            //// Get the PointPairList
            //IPointListEdit list = curve.Points as IPointListEdit;
            //// If this is null, it means the reference at curve.Points does not
            //// support IPointListEdit, so we won't be able to modify it
            //if (list == null)
            //    return;

            //// Time is measured in seconds
            ////double time = (Environment.TickCount - tickStart) / 1000.0;

            //// Keep the X scale at a rolling 30 second interval, with one
            //// major step between the max X value and the end of the axis
            //Scale xScale = _zgPointer.GraphPane.XAxis.Scale;
            //if (time > xScale.Max - xScale.MajorStep)
            //{
            //    xScale.Max = time + xScale.MajorStep;
            //    xScale.Min = xScale.Max - 10.0;
            //}

            //// Make sure the Y axis is rescaled to accommodate actual data
            //try
            //{
            //    _zgPointer.AxisChange();
            //}
            //catch { }
            //// Force a redraw
            //_zgPointer.Invalidate();
            #endregion
        }

        private void timer2serial_Tick(object sender, EventArgs e)
        {

            double time = (Environment.TickCount - tickStart) / 1000.0;

            #region OldStuff
            if (_arduIMUConnection != null && _arduIMUConnection.IsOpen())
            {
                _ArduIMUMutex.WaitOne();
                //Update Stick IMU
                stickIMUList[0].Add(time, _arduIMUConnection.stick_ax);
                stickIMUList[1].Add(time, _arduIMUConnection.stick_ay);
                stickIMUList[2].Add(time, _arduIMUConnection.stick_az);
                stickIMUList[3].Add(time, _arduIMUConnection.stick_gx);
                stickIMUList[4].Add(time, _arduIMUConnection.stick_gy);
                stickIMUList[5].Add(time, _arduIMUConnection.stick_gz);
                //Update Rudder IMU
                rudderIMUList[0].Add(time, _arduIMUConnection.rudder_ax);
                rudderIMUList[1].Add(time, _arduIMUConnection.rudder_ay);
                rudderIMUList[2].Add(time, _arduIMUConnection.rudder_az);
                rudderIMUList[3].Add(time, _arduIMUConnection.rudder_gx);
                rudderIMUList[4].Add(time, _arduIMUConnection.rudder_gy);
                rudderIMUList[5].Add(time, _arduIMUConnection.rudder_gz);

                //Update Status
                StatusList[0].Add(time, _arduIMUConnection.frequency);
                StatusList[1].Add(time, _arduIMUConnection.stick_bytes);
                StatusList[2].Add(time, _arduIMUConnection.rudder_bytes);
                _ArduIMUMutex.ReleaseMutex();

            }
            //Update Crossbow IMU
                if (_crossbowConnection != null && _crossbowConnection.IsOpen())
                {
                    AHRSDataPacket tmpData = _crossbowConnection.GetData();
                    CrossbowIMUList[0].Add(time, tmpData.a_x);
                    CrossbowIMUList[1].Add(time, tmpData.a_y);
                    CrossbowIMUList[2].Add(time, tmpData.a_z);
                    CrossbowIMUList[3].Add(time, tmpData.v_roll);
                    CrossbowIMUList[4].Add(time, tmpData.v_pitch);
                    CrossbowIMUList[5].Add(time, tmpData.v_yaw);
                }
            //Update String Pots
            //StringPotList[0].Add(time, ArdupilotMega.MainV2.comPort.MAV.cs.stick_pot1);
            //StringPotList[1].Add(time, ArdupilotMega.MainV2.comPort.MAV.cs.stick_pot2);
                //StringPotList[2].Add(time, ArdupilotMega.MainV2.comPort.MAV.cs.rudder_pot);
            #endregion

            float[] controlInputValues = _controlInputs.RollPitchYaw((int)ArdupilotMega.MainV2.comPort.MAV.cs.stick_pot1,
                                                                     (int)ArdupilotMega.MainV2.comPort.MAV.cs.stick_pot2,
                                                                     (int)ArdupilotMega.MainV2.comPort.MAV.cs.rudder_pot);
            StringPotList[0].Add(time, controlInputValues[0]);
            StringPotList[1].Add(time, controlInputValues[1]);
            StringPotList[2].Add(time, controlInputValues[2]);

            quickViewSP1.number = ArdupilotMega.MainV2.comPort.MAV.cs.stick_pot1;
            quickViewSP2.number = ArdupilotMega.MainV2.comPort.MAV.cs.stick_pot2;
            quickViewRP.number = ArdupilotMega.MainV2.comPort.MAV.cs.rudder_pot;

            quickViewRoll.number = controlInputValues[0];
            quickViewPitch.number = controlInputValues[1];
            quickViewYaw.number = controlInputValues[2];

            quickViewX.number = controlInputValues[3];
            quickViewY.number = controlInputValues[4];
            quickViewZ.number = controlInputValues[5];

            quickViewBeta.number = controlInputValues[6] * Rad2Deg;
            quickViewTheta.number = controlInputValues[7] * Rad2Deg;

        }
        #endregion

        #region Clear
        private void ClearAllGraphs()
        {
            for (int i = 0; i < _graphList.Length; i++)
            {
                ClearGraph(i);
            }
        }

        private void ClearGraph(int graph)
        {
            if (graph == 0) //Stick
            {
                foreach (RollingPointPairList list in stickIMUList)
                {
                    list.Clear();
                }
            }
            else if (graph == 1)
            {
                foreach (RollingPointPairList list in rudderIMUList)
                {
                    list.Clear();
                }
            }
            else if (graph == 2)
            {
                foreach (RollingPointPairList list in CrossbowIMUList)
                {
                    list.Clear();
                }
            }
            else if (graph == 3)
            {
                foreach (RollingPointPairList list in StringPotList)
                {
                    list.Clear();
                }
            }
            else if (graph == 4)
            {
                foreach (RollingPointPairList list in StatusList)
                {
                    list.Clear();
                }
            }
        }
        #endregion

        #region TabChange
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_updateGraph)
            {
                //Change graph
                _currentGraphNumber = tabControl1.SelectedIndex;
                _zgPointer = _graphList[_currentGraphNumber];

                // Sample at 20ms intervals
                timer1.Interval = 50;
                timer1.Enabled = true;
                timer1.Start();

                timer2serial.Interval = 20;
                timer2serial.Enabled = true;
                timer2serial.Start();
            }
            
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            _updateGraph = !_updateGraph;

            if (_updateGraph)
            {
                ClearAllGraphs();
                tabControl1.Enabled = true;
                tabControl1_SelectedIndexChanged(sender, e);
                GraphButton.Text = "Stop Graphs";
                //Request High Frequency
                MainV2.comPort.requestDatastream(ArdupilotMega.MAVLink.MAV_DATA_STREAM.RAW_SENSORS, (byte)50); // request raw sensor
                MainV2.comPort.requestDatastream(ArdupilotMega.MAVLink.MAV_DATA_STREAM.POSITION, (byte)25);
            }
            else
            {
                //tabControl1.Enabled = false;
                timer1.Enabled = false;
                timer2serial.Enabled = false;
                GraphButton.Text = "Start Graphs";
            }
        }

        private void Katana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32) //Spacebar
            {
                _ManoeuvreMutex.WaitOne();
                _manoeuvreNumber++;
                _ManoeuvreMutex.ReleaseMutex();

                ManoeuvreTextBox.Text = _manoeuvreNumber.ToString();
            }
        }
        #endregion
        #endregion

        #region StringPotCalibration
        private void CalibrateButton_Click(object sender, EventArgs e)
        {

            if (_isCalibrating)
            {
                if (sw != null)
                {
                    sw.Close();
                }

                RecordButton.Enabled = true;
                _isCalibrating = false;
                CaliFileButton.Text = "Start Calibrate";
                CalibrationButtonStates(false);
            } //if
            else
            {
                RecordButton.Enabled = false;

                //Create StreamWriter
                DateTime currenttime = DateTime.Now;
                string filename = "KatanaFlightData_" + currenttime.Year.ToString("0000") + currenttime.Month.ToString("00") +
                    currenttime.Day.ToString("00") + "_" + currenttime.Hour.ToString("00") + currenttime.Minute.ToString("00") +
                    currenttime.Second.ToString("00") + "_calibrationfile.csv";
                sw = new System.IO.StreamWriter(filename);

                sw.WriteLine("CS String Pot 1 (raw), CS String Pot 2 (raw), RP String Pot (raw), Position, x (inch) , y (inch) , z (inch)");

                _isCalibrating = true;
                CaliFileButton.Text = "End Calibrate";
                CalibrationButtonStates(true);
            } //else
        }

        private void CalibrationButtonStates(bool enabled)
        {
            LUButton.Enabled = enabled;
            LDButton.Enabled = enabled;
            RUButton.Enabled = enabled;
            RDButton.Enabled = enabled;
            RightRudderButton.Enabled = enabled;
            LeftRudderButton.Enabled = enabled;
        }

        private void LUButton_Click(object sender, EventArgs e)
        {
            if (_isCalibrating)
            {
                string entry = MainV2.comPort.MAV.cs.KatanaStringPots() + ", Left Up";
                float[] values = _controlInputs.SetLUExtreme((int)MainV2.comPort.MAV.cs.stick_pot1,
                    (int)MainV2.comPort.MAV.cs.stick_pot2,
                    (int)MainV2.comPort.MAV.cs.rudder_pot);
                entry += ", " + (values[0]).ToString() + ", " + (values[1]).ToString() + ", " + (values[2]).ToString();
                sw.WriteLine(entry);
           } //if
        }

        private void RUButton_Click(object sender, EventArgs e)
        {
            if (_isCalibrating)
            {
                string entry = MainV2.comPort.MAV.cs.KatanaStringPots() + ", Right Up";
                float[] values = _controlInputs.SetRUExtreme((int)MainV2.comPort.MAV.cs.stick_pot1,
                    (int)MainV2.comPort.MAV.cs.stick_pot2,
                    (int)MainV2.comPort.MAV.cs.rudder_pot);
                entry += ", " + (values[0]).ToString() + ", " + (values[1]).ToString() + ", " + (values[2]).ToString();
                sw.WriteLine(entry);
            } //if
        }

        private void RDButton_Click(object sender, EventArgs e)
        {
            if (_isCalibrating)
            {
                string entry = MainV2.comPort.MAV.cs.KatanaStringPots() + ", Right Down";
                float[] values = _controlInputs.SetRDExtreme((int)MainV2.comPort.MAV.cs.stick_pot1,
                    (int)MainV2.comPort.MAV.cs.stick_pot2,
                    (int)MainV2.comPort.MAV.cs.rudder_pot);
                entry += ", " + (values[0]).ToString() + ", " + (values[1]).ToString() + ", " + (values[2]).ToString();
                sw.WriteLine(entry);
            } //if
        }

        private void LeftRudderButton_Click(object sender, EventArgs e)
        {
            if (_isCalibrating)
            {
                string entry = MainV2.comPort.MAV.cs.KatanaStringPots() + ", Full Left Rudder ";
                sw.WriteLine(entry);
                _controlInputs.SetLRExtreme((int)MainV2.comPort.MAV.cs.rudder_pot);

            } //if
        }

        private void RightRudderButton_Click(object sender, EventArgs e)
        {
            if (_isCalibrating)
            {
                string entry = MainV2.comPort.MAV.cs.KatanaStringPots() + ", Full Right Rudder";
                sw.WriteLine(entry);
                _controlInputs.SetRRExtreme((int)MainV2.comPort.MAV.cs.rudder_pot);
            } //if
        }
        
        private void LDButton_Click(object sender, EventArgs e)
        {
            if (_isCalibrating)
            {
                string entry = MainV2.comPort.MAV.cs.KatanaStringPots() + ", Left Down";
                float[] values = _controlInputs.SetLDExtreme((int)MainV2.comPort.MAV.cs.stick_pot1,
                    (int)MainV2.comPort.MAV.cs.stick_pot2,
                    (int)MainV2.comPort.MAV.cs.rudder_pot);
                entry += ", " + (values[0]).ToString() + ", " + (values[1]).ToString() + ", " + (values[2]).ToString();
                sw.WriteLine(entry);
            } //if
        }

        #endregion

        private void PotLengthSetButton_Click(object sender, EventArgs e)
        {
            _controlInputs.L_OD = (float)LODValue.Value;
            _controlInputs.L_AB = (float)LABValue.Value;
            _controlInputs.L_BC = (float)LBCValue.Value;
            _controlInputs.L_x = (float)LXValue.Value;
            _controlInputs.L_y = (float)LYValue.Value;
            _controlInputs.L_z = (float)LZValue.Value;
            _controlInputs.SP1_ext = (float)Ext1Value.Value;
            _controlInputs.SP2_ext = (float)Ext2Value.Value;
        }


    }
    #endregion

    #region AHRS Class
    class AhrsSerialData
    {
        #region Variables
        public bool Monitoring { get { return isMonitoring; } }

        private SerialPort h_AhrsSerialPort = null;
        private Mutex AHRSMutex;
        private Mutex LocalMonitorMutex;
        private Mutex LocalDataMutex;
        private bool isMonitoring;

        private List<byte> m_buffer;
        private int m_dataCount = 0;
        private int m_packetLength = 0;
        private Stopwatch m_freqTimer;
        private bool m_lowFrequency = false;
        private AHRSDataPacket m_data;
        private string m_msg;
        private bool m_receiving = false;

        private const int SENSOR_TIMEOUT_IN_MSECS = 5000;
        private const int MIN_FREQUENCY = 40; //Hz

        enum AHRSconstants
        {
            VG_MODE_PACKET_SIZE = 30,
            SCALED_MODE_PACKET_SIZE = 24,
            VOLTAGE_MODE_PACKET_SIZE = 24,
            PACKET_HEADER = 0xFF
        }
        #endregion

        #region Constructor
        //constructor
        public AhrsSerialData(Mutex _globalMutex)
        {
            //Mutex needed so many class doesn't access data as it is being written to
            AHRSMutex = _globalMutex;
            LocalMonitorMutex = new Mutex();
            LocalDataMutex = new Mutex();

            m_buffer = new List<byte>();
            m_freqTimer = new Stopwatch();
            m_data = new AHRSDataPacket();
            m_msg = "No errors";
        }

        //Destructor
        ~AhrsSerialData()
        {
            if (isMonitoring)
            {
                KillThread();
            }
        }
        #endregion

        #region End
        // Tells AHRS thread to end
        public void KillThread()
        {
            LocalMonitorMutex.WaitOne();
            isMonitoring = false;
            LocalMonitorMutex.ReleaseMutex();

            Thread.Sleep(10);
        }

        public void DisconnectSerial()
        {
            if (isMonitoring)
            {
                KillThread();
            }

            //Close connection correctly
            if (h_AhrsSerialPort != null && h_AhrsSerialPort.IsOpen)
            {
                //Clear buffer
                h_AhrsSerialPort.DiscardInBuffer();
                h_AhrsSerialPort.Close();
            }
        }
        #endregion //End

        #region Connection
        //Connect
        public SerialStatus ConnectSerial(string portName, int baudrate)
        {
            SerialStatus stat = SerialStatus.SUCCESS;
            h_AhrsSerialPort = new SerialPort(portName, 38400, Parity.None, 8, StopBits.One);
            h_AhrsSerialPort.Handshake = Handshake.None;
            h_AhrsSerialPort.ReadTimeout = SENSOR_TIMEOUT_IN_MSECS;
            h_AhrsSerialPort.WriteTimeout = SENSOR_TIMEOUT_IN_MSECS;

            try
            {
                h_AhrsSerialPort.Open();
            }
            catch (System.Exception ex)
            {
                m_msg = ex.Message;
                return SerialStatus.CONNECTION_FAILURE;
            }


            //Check connection is open
            if (!h_AhrsSerialPort.IsOpen)
            {
                m_msg = "AHRS connection failed to open.";
                return SerialStatus.CONNECTION_FAILURE;
            }

            Thread.Sleep(100);
            h_AhrsSerialPort.DiscardOutBuffer();

            // Changes to polled mode
            h_AhrsSerialPort.Write(new char[1] { 'P' }, 0, 1);

            Thread.Sleep(100);

            if (!pingSerial(5000))
            {
                h_AhrsSerialPort.Close();
                return SerialStatus.PING_RESPONSE_FAILURE;
            }
            else
            {
                m_packetLength = determinePacketLength();
                if (m_packetLength < 30)
                {
                    m_msg = "AHRS packet size too small.";
                    m_receiving = false;
                    return SerialStatus.PACKET_SIZE_MISSMATCH;
                }
                m_msg = "AHRS packet size found.";
            }

            //Check Baud Rate
            if (baudrate != 38400)
            {
                //Request baud rate change
                if (getChar(1000, 'b', 'B'))
                {
                    if (!changeBaud(baudrate))
                    {
                        stat = SerialStatus.BAUD_RATE_CHANGE_FAIL;
                    }
                }
                else
                {
                    stat = SerialStatus.BAUD_RATE_CHANGE_FAIL;
                }

            }


            //Change to Angle (VG) Mode
            h_AhrsSerialPort.Write(new char[1] { 'a' }, 0, 1);
            m_freqTimer.Start();

            //Change to Normal Mode
            h_AhrsSerialPort.Write(new char[2] { 'T', 'C' }, 0, 2);

            return stat;
        }

        // Change baudrate
        private bool changeBaud(int newBaudrate)
        {
            if (!h_AhrsSerialPort.IsOpen)
            {
                return false;
            }

            h_AhrsSerialPort.BaudRate = newBaudrate;

            return getChar(1000, 'a', 'A');
        }

        // Wait for single char response
        private bool getChar(long timeoutInMilliSeconds, char outChar, char reqChar)
        {
            if (!h_AhrsSerialPort.IsOpen) return false;

            char[] data = new char[100];
            int bytesRead = 0;
            Stopwatch stopWatch = new Stopwatch();

            h_AhrsSerialPort.DiscardInBuffer();
            h_AhrsSerialPort.Write(new char[1] { outChar }, 0, 1);

            stopWatch.Start();

            while (bytesRead < 1)
            {
                try
                {
                    if (h_AhrsSerialPort.BytesToRead > 0)
                    {
                        bytesRead = h_AhrsSerialPort.Read(data, 0, 1);
                    }
                }
                catch (System.TimeoutException ex)
                {
                    m_msg = ex.Message;
                    return false;
                }

                if (bytesRead > 0)  //Received response, then good
                {
                    if (data[0] == reqChar)
                    {
                        return true;
                    }
                    m_msg = "Baudrate change failed.";
                    return false;
                }

                //Has timeout expired?
                if (stopWatch.ElapsedMilliseconds > timeoutInMilliSeconds)
                {
                    m_msg = "Baudrate change has timed out.";
                    return false;
                }
            }

            return false;
        }

        // Ping AHRS 
        private bool pingSerial(long timeoutInMilliSeconds)
        {
            if (!h_AhrsSerialPort.IsOpen) return false;

            char[] data = new char[100];
            int bytesRead = 0;
            char[] pingChar = new char[1] { 'R' };
            Stopwatch stopWatch = new Stopwatch();

            h_AhrsSerialPort.DiscardInBuffer();
            h_AhrsSerialPort.Write(pingChar, 0, 1);

            stopWatch.Start();

            while (bytesRead < 1)
            {
                try
                {
                    if (h_AhrsSerialPort.BytesToRead > 0)
                    {
                        bytesRead = h_AhrsSerialPort.Read(data, 0, 1);
                    }
                }
                catch (System.TimeoutException ex)
                {
                    m_msg = ex.Message;
                    return false;
                }

                if (bytesRead > 0)  //Received response, then good
                {
                    m_msg = "AHRS ping response received.";
                    return true;
                }

                //Has timeout expired?
                if (stopWatch.ElapsedMilliseconds > timeoutInMilliSeconds)
                {
                    m_msg = "AHRS ping has timed out.";
                    return false;
                }
            }

            return false;
        }


        #endregion //Connection

        #region Strings
        public AHRSDataPacket GetData()
        {
            return m_data;
        }

        public string GetCurrentData()
        {
            AHRSMutex.WaitOne();
            string line = m_data.getline();
            //string line = m_data.getDebug();
            AHRSMutex.ReleaseMutex();
            return line;
        }
        public string GetCurrentDataRads()
        {
            AHRSMutex.WaitOne();
            string line = m_data.getlineRads();
            //string line = m_data.getDebug();
            AHRSMutex.ReleaseMutex();
            return line;
        }

        public string GetLineFormat()
        {
            return m_data.getFormat();
        }

        public string GetLineFormatRads()
        {
            return m_data.getFormatRad();
        }

        public string GetErrorMessage()
        {
            return m_msg;
        }

        public bool ReceivingData()
        {
            return m_receiving;
        }

        public bool IsOpen()
        {
            bool status = (h_AhrsSerialPort != null && h_AhrsSerialPort.IsOpen);

            return status;
        }

        #endregion

        #region Thread
        //Thread to continuously read data
        public void MonitorSerial()
        {
            if (!h_AhrsSerialPort.IsOpen)
            {
                return;
            }

            Stopwatch timeoutTimer = new Stopwatch();
            long maxTimeout = 5000; //ms
            byte[] data = new byte[100];
            int bytesRead = 0;
            bool monitor = true;

            m_dataCount = 0;

            LocalMonitorMutex.WaitOne();
            isMonitoring = monitor;
            LocalMonitorMutex.ReleaseMutex();

            //Switch to continuous mode
            h_AhrsSerialPort.Write(new char[1] { 'C' }, 0, 1);
            timeoutTimer.Start();
            m_receiving = true;

            while (monitor)
            {
                //Check serial port open
                if (!h_AhrsSerialPort.IsOpen)
                {
                    m_receiving = false;
                    m_msg = "Port has closed.";
                    break;
                }

                //Check for timeout
                if (timeoutTimer.ElapsedMilliseconds > maxTimeout)
                {
                    //ATTEMPT RECONNECT????
                    m_receiving = false;
                    m_msg = "Port has timed out.";
                    break;
                }

                //Something about frequency...
                if (m_lowFrequency)
                {
                    //Create notification
                    bytesRead = -1;
                }

                //Read data
                bytesRead = h_AhrsSerialPort.Read(data, 0, m_packetLength);

                if (bytesRead > 0)
                {
                    timeoutTimer.Reset();
                    timeoutTimer.Start();
                    //PROCESS DATA
                    processPacket(data, bytesRead, m_packetLength);
                }


                LocalMonitorMutex.WaitOne();
                monitor = isMonitoring;
                LocalMonitorMutex.ReleaseMutex();
            }

            if (h_AhrsSerialPort.IsOpen)
            {
                //Tell AHRS to stop sending data
                h_AhrsSerialPort.Write("P");
            }
        }
        #endregion

        #region ProcessPacket
        private void processPacket(byte[] data, int bytesRead, int packetLength)
        {
            int n = 0;

            while (n < bytesRead)
            {
                if (m_buffer.Count == 0) //buffer is empty
                {
                    //find index of potential first byte which could be header
                    for (; n < bytesRead; n++)
                    {
                        if (data[n] == 0xFF)
                        {
                            break;
                        }//if
                    } //for
                } //if

                //Add data to buffer
                for (; n < bytesRead; n++)
                {
                    //Add data
                    m_buffer.Add(data[n]);

                    //If buffer now holds sufficient points
                    if (m_buffer.Count == packetLength)
                    {
                        int sum = 0;
                        for (int k = 1; k < m_buffer.Count - 1; k++)
                        {
                            sum += m_buffer[k];
                        } //for

                        int checksum = sum % 256;
                        //Check Data is in Sync
                        if (m_buffer[0] == 0xFF && m_buffer[packetLength - 1] == checksum)
                        {
                            m_dataCount++;

                            #region Frequency
                            if (m_freqTimer.ElapsedMilliseconds > 5000)
                            {
                                double currentFreq = 1000.0 * m_dataCount / (m_freqTimer.ElapsedMilliseconds);

                                //Require Minimum Frequency
                                if (currentFreq < MIN_FREQUENCY)
                                {
                                    m_lowFrequency = true;
                                }
                                else
                                {
                                    m_lowFrequency = false;
                                } //if

                                m_freqTimer.Reset();
                                m_freqTimer.Start();
                                m_dataCount = 0;
                            } //if
                            #endregion

                            //Data ready for writing
                            processData();
                            m_buffer.RemoveRange(0, packetLength);
                            //m_buffer.Clear();
                            //h_AhrsSerialPort.DiscardInBuffer();
                            m_receiving = true;
                            m_msg = "Processed data.";

                        } //if data in sync
                        else  //Otherwise data out of sync
                        {
                            m_buffer.RemoveAt(0);
                            while (m_buffer[0] != 0xFF)
                            {
                                m_buffer.RemoveAt(0);
                                if (m_buffer.Count == 0)
                                { //Buffer cleared
                                    break;
                                }
                            }
                        } //else not in sync
                    } //if
                } //for

                n++;

            } //while
        } //processPacketLength

        // function to take m_buffer and convert to data
        private void processData()
        {
            //convert data from array of bytes to proper data format
            DateTime currentTime = DateTime.Now;

            short[] data = new short[12];
            int n = 0;

            // Combine MSB and LSB
            for (n = 0; n < 12; n++)
            {
                data[n] = BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 2], m_buffer[2 * n + 1] }, 0);
            }
            UInt16 tempSensor = BitConverter.ToUInt16(new byte[2] { m_buffer[2 * n + 2], m_buffer[2 * n + 1] }, 0);
            n++;
            UInt16 timeTicks = BitConverter.ToUInt16(new byte[2] { m_buffer[2 * n + 2], m_buffer[2 * n + 1] }, 0);

            AHRSMutex.WaitOne();
            m_data.time = currentTime.Hour.ToString() + ":" + currentTime.Minute.ToString("00") + ":" + currentTime.Second.ToString("00")
                + "." + currentTime.Millisecond.ToString("000");

            //Angle = data * (scale) / 2^15
            m_data.roll = 1.0 * data[0] * (180) / (1 << 15);
            m_data.pitch = 1.0 * data[1] * (180) / (1 << 15);
            m_data.yaw = 1.0 * data[2] * (180) / (1 << 15);

            //Angular rate = data * (AR * 1.5) / 2^15
            m_data.v_roll = 1.0 * data[3] * (200 * 1.5) / (1 << 15);
            m_data.v_pitch = 1.0 * data[4] * (200 * 1.5) / (1 << 15);
            m_data.v_yaw = 1.0 * data[5] * (200 * 1.5) / (1 << 15);

            //Accel = data * (GR * 1.5) / 2^15
            m_data.a_x = 1.0 * data[6] * (4 * 1.5) / (1 << 15);
            m_data.a_y = 1.0 * data[7] * (4 * 1.5) / (1 << 15);
            m_data.a_z = 1.0 * data[8] * (4 * 1.5) / (1 << 15);

            //mag = data * (MR * 1.5) / 2^15 .... Magnetic field
            m_data.mag_x = 1.0 * data[9] * (4 * 1.5) / (1 << 15);
            m_data.mag_y = 1.0 * data[10] * (4 * 1.5) / (1 << 15);
            m_data.mag_z = 1.0 * data[11] * (4 * 1.5) / (1 << 15);

            //temp = 44.44 * ( data * 5 / 4096 - 1.375 ) 
            m_data.temp_sensor = 44.44 * (tempSensor * 5 / 4096 - 1.375);

            m_data.ahrs_time = timeTicks;

            AHRSMutex.ReleaseMutex();
        }
        #endregion

        #region PacketLength
        private int determinePacketLength()
        {
            if (!h_AhrsSerialPort.IsOpen) return -1;

            byte[] data = new byte[100];
            List<byte> datalist = new List<byte>();

            int bytesRead = 1;
            Stopwatch stopWatch = new Stopwatch();

            h_AhrsSerialPort.DiscardInBuffer(); //Clear buffer
            h_AhrsSerialPort.Write(new char[1] { 'G' }, 0, 1); //Request three packets
            h_AhrsSerialPort.Write(new char[1] { 'G' }, 0, 1);
            h_AhrsSerialPort.Write(new char[1] { 'G' }, 0, 1);
            stopWatch.Start();

            while (datalist.Count < 90)
            {
                bytesRead = h_AhrsSerialPort.Read(data, 0, data.Length);

                for (int i = 0; i < bytesRead; i++)
                {
                    datalist.Add(data[i]);
                }

                if (stopWatch.ElapsedMilliseconds > 3000)
                {
                    //Serial timeout
                    h_AhrsSerialPort.Close();
                    return 0;
                }
            }

            int verifiedCount = 0;
            int measuredLength = 0;

            for (int n = 0; n < datalist.Count; n++)
            {
                if ((byte)datalist[n] == 0xFF)
                {
                    int lengthCount = 1;
                    int sum = 0;
                    for (n++; n < datalist.Count; n++)
                    {
                        lengthCount++;
                        int checksum = sum % 256;
                        if (checksum == datalist[n] && (n + 1 == datalist.Count || datalist[n + 1] == 0xFF))
                        {
                            if (measuredLength == lengthCount)
                            {
                                verifiedCount++;
                            }
                            else
                            {
                                measuredLength = lengthCount;
                            } //if
                            break;
                        } //if
                        sum += datalist[n];
                    } //for
                } //if
            } //for

            return measuredLength;
        } //determinePacketLength()
        #endregion

        #region Convert
        private double convertAhrs(short _raw, int index)
        {
            double raw = (double)_raw;
            if (raw > 0xffff / 2.0) raw = raw - 0xffff;
            if (index <= 3)
            {
                return raw * (180.0 * 1.0) / 32767.0 + 0;
            }
            else if (index <= 6)
            {
                return raw * (200.0 * 1.5) / 32767.0 + 0;
            }
            else if (index <= 9)
            {
                return raw * (4.0 * 1.5) / 32767.0 + 0;
            }
            return 0;
        }
        #endregion
    }
    #endregion

    #region ArduIMUSerialData
    class ArduIMUSerialData
    {
        #region ArduIMUStruct
        public float stick_ax { get; set; }
        public float stick_ay { get; set; }
        public float stick_az { get; set; }
        public float stick_gx { get; set; }
        public float stick_gy { get; set; }
        public float stick_gz { get; set; }
        public short stick_mx { get; set; }
        public short stick_my { get; set; }
        public short stick_mz { get; set; }
        public float rudder_ax { get; set; }
        public float rudder_ay { get; set; }
        public float rudder_az { get; set; }
        public float rudder_gx { get; set; }
        public float rudder_gy { get; set; }
        public float rudder_gz { get; set; }
        public short rudder_mx { get; set; }
        public short rudder_my { get; set; }
        public short rudder_mz { get; set; }
        public byte stick_bytes { get; set; }
        public byte rudder_bytes { get; set; }
        public bool Monitoring { get { return isMonitoring; } }
        public double frequency
        {
            get
            {
                return m_recvFrequency;
            }
        }
        #endregion

        #region Variables
        private SerialPort h_ArduIMUSerialPort = null;
        private Mutex ArduIMUMutex;
        private Mutex LocalMonitorMutex;
        private Mutex LocalDataMutex;
        private bool isMonitoring;

        private List<byte> m_buffer;
        private int m_dataCount = 0;
        private int m_packetLength = 0;
        private Stopwatch m_freqTimer;
        private bool m_lowFrequency = false;
        private double m_recvFrequency = 0;
        private string m_msg;
        private bool m_receiving = false;

        private const int SENSOR_TIMEOUT_IN_MSECS = 5000;
        private const int MIN_FREQUENCY = 40; //Hz

        enum AHRSconstants
        {
            VG_MODE_PACKET_SIZE = 30,
            SCALED_MODE_PACKET_SIZE = 24,
            VOLTAGE_MODE_PACKET_SIZE = 24,
            PACKET_HEADER = 0xFF
        }
        #endregion

        #region Constructor
        //constructor
        public ArduIMUSerialData(Mutex _globalMutex)
        {
            //Mutex needed so many class doesn't access data as it is being written to
            ArduIMUMutex = _globalMutex;
            LocalMonitorMutex = new Mutex();
            LocalDataMutex = new Mutex();

            m_buffer = new List<byte>();
            m_freqTimer = new Stopwatch();
            m_msg = "No errors";
        }

        //Destructor
        ~ArduIMUSerialData()
        {
            if (isMonitoring)
            {
                KillThread();
            }
        }
        #endregion

        #region End
        // Tells AHRS thread to end
        public void KillThread()
        {
            LocalMonitorMutex.WaitOne();
            isMonitoring = false;
            LocalMonitorMutex.ReleaseMutex();

            Thread.Sleep(10);
        }

        public void DisconnectSerial()
        {
            if (isMonitoring)
            {
                KillThread();
            }

            //Close connection correctly
            if (h_ArduIMUSerialPort != null && h_ArduIMUSerialPort.IsOpen)
            {
                //Clear buffer
                h_ArduIMUSerialPort.DiscardInBuffer();
                h_ArduIMUSerialPort.Close();
            }
        }
        #endregion //End

        #region Connection
        //Connect
        public SerialStatus ConnectSerial(string portName, int baudrate)
        {
            h_ArduIMUSerialPort = new SerialPort(portName, baudrate, Parity.None, 8, StopBits.One);
            h_ArduIMUSerialPort.Handshake = Handshake.None;
            h_ArduIMUSerialPort.ReadTimeout = SENSOR_TIMEOUT_IN_MSECS;
            h_ArduIMUSerialPort.WriteTimeout = SENSOR_TIMEOUT_IN_MSECS;

            try
            {
                h_ArduIMUSerialPort.Open();
            }
            catch (System.Exception ex)
            {
                m_msg = ex.Message;
                return SerialStatus.CONNECTION_FAILURE;
            }


            //Check connection is open
            if (!h_ArduIMUSerialPort.IsOpen)
            {
                m_msg = "ArduIMU connection failed to open.";
                return SerialStatus.CONNECTION_FAILURE;
            }

            Thread.Sleep(2000);
            h_ArduIMUSerialPort.DiscardOutBuffer();

            // Changes to polled mode
            h_ArduIMUSerialPort.Write(new char[1] { 'P' }, 0, 1);

            Thread.Sleep(100);

            if (!pingSerial(5000))
            {
                h_ArduIMUSerialPort.Close();
                return SerialStatus.PING_RESPONSE_FAILURE;
            }
            else
            {
                m_packetLength = determinePacketLength();
                if (m_packetLength < 30)
                {
                    m_msg = "ArduIMU packet size too small.";
                    m_receiving = false;
                    h_ArduIMUSerialPort.Close();
                    return SerialStatus.PACKET_SIZE_MISSMATCH;
                }
                m_msg = "ArduIMU packet size found.";
            }

            m_freqTimer.Start();

            return SerialStatus.SUCCESS;
        }

        // Ping AHRS 
        private bool pingSerial(long timeoutInMilliSeconds)
        {
            if (!h_ArduIMUSerialPort.IsOpen) return false;

            char[] data = new char[100];
            int bytesRead = 0;
            char[] pingChar = new char[1] { 'R' };
            Stopwatch stopWatch = new Stopwatch();

            h_ArduIMUSerialPort.DiscardInBuffer();
            h_ArduIMUSerialPort.Write(pingChar, 0, 1);

            stopWatch.Start();

            while (bytesRead < 1)
            {
                try
                {
                    if (h_ArduIMUSerialPort.BytesToRead > 0)
                    {
                        bytesRead = h_ArduIMUSerialPort.Read(data, 0, 1);
                    }
                }
                catch (System.TimeoutException ex)
                {
                    m_msg = ex.Message;
                    return false;
                }

                if (bytesRead > 0)  //Received response, then good
                {
                    m_msg = "ArduIMU ping response received.";
                    return true;
                }

                //Has timeout expired?
                if (stopWatch.ElapsedMilliseconds > timeoutInMilliSeconds)
                {
                    m_msg = "ArduIMU ping has timed out.";
                    return false;
                }
            }

            return false;
        }


        #endregion //Connection

        #region Strings
        public string GetCurrentData()
        {
            ArduIMUMutex.WaitOne();
            string line = stick_ax.ToString() + ", " + stick_ay.ToString() + ", " + stick_az.ToString() + ", "
                + stick_gx.ToString() + ", " + stick_gy.ToString() + ", " + stick_gz.ToString() + ", "
                + stick_mx.ToString() + ", " + stick_my.ToString() + ", " + stick_mz.ToString() + ", "
                + rudder_ax.ToString() + ", " + rudder_ay.ToString() + ", " + rudder_az.ToString() + ", "
                + rudder_gx.ToString() + ", " + rudder_gy.ToString() + ", " + rudder_gz.ToString() + ", "
                + rudder_mx.ToString() + ", " + rudder_my.ToString() + ", " + rudder_mz.ToString();
            ArduIMUMutex.ReleaseMutex();
            return line;
        }

        public string GetLineFormat()
        {
            string format = "Stick Accel X (m/s/s), Stick Accel Y (m/s/s), Stick Accel Z (m/s/s),"
                            + "Stick Gyro X (rad/s), Stick Gyro Y (rad/s), Stick Gyro Z (rad/s),"
                            + "Stick Mag X, Stick Mag Y, Stick Mag Z,"
                            + "Rudder Accel X (m/s/s), Rudder Accel Y (m/s/s), Rudder Accel Z (m/s/s),"
                            + "Rudder Gyro X (rad/s), Rudder Gyro Y (rad/s), Rudder Gyro Z (rad/s),"
                            + "Rudder Mag X, Rudder Mag Y, Rudder Mag Z";
            return format;
        }

        public string GetErrorMessage()
        {
            return m_msg;
        }

        public bool ReceivingData()
        {
            return m_receiving;
        }

        public bool IsOpen()
        {
            bool status = (h_ArduIMUSerialPort != null && h_ArduIMUSerialPort.IsOpen);

            return status;
        }

        #endregion

        #region Thread
        //Thread to continuously read data
        public void MonitorSerial()
        {
            if (!h_ArduIMUSerialPort.IsOpen)
            {
                isMonitoring = false;
                return;
            }

            Stopwatch timeoutTimer = new Stopwatch();
            long maxTimeout = 5000; //ms
            byte[] data = new byte[100];
            int bytesRead = 0;
            bool monitor = true;

            m_dataCount = 0;

            LocalMonitorMutex.WaitOne();
            isMonitoring = monitor;
            LocalMonitorMutex.ReleaseMutex();

            //Switch to continuous mode
            h_ArduIMUSerialPort.Write(new char[1] { 'C' }, 0, 1);
            timeoutTimer.Start();
            m_receiving = true;

            while (monitor)
            {
                //Check serial port open
                if (!h_ArduIMUSerialPort.IsOpen)
                {
                    m_receiving = false;
                    m_msg = "Port has closed.";
                    isMonitoring = false;
                    break;
                }

                //Check for timeout
                if (timeoutTimer.ElapsedMilliseconds > maxTimeout)
                {
                    //ATTEMPT RECONNECT????
                    m_receiving = false;
                    m_msg = "Port has timed out.";
                    isMonitoring = false;
                    break;
                }

                //Something about frequency...
                if (m_lowFrequency)
                {
                    //Create notification
                    bytesRead = -1;
                }

                //Read data
                try
                {
                    bytesRead = h_ArduIMUSerialPort.Read(data, 0, m_packetLength);
                }
                catch (System.Exception ex)
                {
                    bytesRead = 0;
                    m_msg = "ArduIMU Error: " + ex.Message;
                }

                if (bytesRead > 0)
                {
                    timeoutTimer.Reset();
                    timeoutTimer.Start();
                    //PROCESS DATA
                    processPacket(data, bytesRead, m_packetLength);
                }


                LocalMonitorMutex.WaitOne();
                monitor = isMonitoring;
                LocalMonitorMutex.ReleaseMutex();
            }

            if (h_ArduIMUSerialPort.IsOpen)
            {
                //Tell AHRS to stop sending data
                h_ArduIMUSerialPort.Write("P");
            }
        }
        #endregion

        #region ProcessPacket
        private void processPacket(byte[] data, int bytesRead, int packetLength)
        {
            int n = 0;

            while (n < bytesRead)
            {
                if (m_buffer.Count == 0) //buffer is empty
                {
                    //find index of potential first byte which could be header
                    for (; n < bytesRead; n++)
                    {
                        if (data[n] == 0xFF)
                        {
                            break;
                        }//if
                    } //for
                } //if

                //Add data to buffer
                for (; n < bytesRead; n++)
                {
                    //Add data
                    m_buffer.Add(data[n]);

                    //If buffer now holds sufficient points
                    if (m_buffer.Count == packetLength)
                    {
                        int sum = 0;
                        for (int k = 1; k < m_buffer.Count - 1; k++)
                        {
                            sum += m_buffer[k];
                        } //for

                        int checksum = ( sum % 256 ) + 54;
                        //Check Data is in Sync
                        if (m_buffer[0] == 0xFF && m_buffer[packetLength - 1] == checksum)
                        {
                            m_dataCount++;

                            #region Frequency
                            if (m_freqTimer.ElapsedMilliseconds > 5000)
                            {
                                m_recvFrequency = 1000.0 * m_dataCount / (m_freqTimer.ElapsedMilliseconds);

                                //Require Minimum Frequency
                                if (m_recvFrequency < MIN_FREQUENCY)
                                {
                                    m_lowFrequency = true;
                                }
                                else
                                {
                                    m_lowFrequency = false;
                                } //if

                                m_freqTimer.Reset();
                                m_freqTimer.Start();
                                m_dataCount = 0;
                            } //if
                            #endregion

                            //Data ready for writing
                            processData();
                            //m_buffer.RemoveRange(0, m_packetLength);
                            m_buffer.Clear();
                            h_ArduIMUSerialPort.DiscardInBuffer();
                            m_receiving = true;
                            m_msg = "Processed data.";

                        } //if data in sync
                        else  //Otherwise data out of sync
                        {
                            m_buffer.RemoveAt(0);
                            while (m_buffer[0] != 0xFF)
                            {
                                m_buffer.RemoveAt(0);
                                if (m_buffer.Count == 0)
                                { //Buffer cleared
                                    break;
                                }
                            }
                        } //else not in sync
                    } //if
                } //for

                n++;

            } //while
        } //processPacketLength

        // function to take m_buffer and convert to data
        private void processData()
        {
            int n = 0;

            ArduIMUMutex.WaitOne();
            stick_gx = KatanaIMUGyro(BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0) );
            n++;
            stick_gy = KatanaIMUGyro(BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0) );
            n++;
            stick_gz = KatanaIMUGyro(BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0) );
            n++;
            stick_ax = KatanaIMUAccel(BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0));
            n++;
            stick_ay = KatanaIMUAccel(BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0));
            n++;
            stick_az = KatanaIMUAccel(BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0));
            n++;
            stick_mx = BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0);
            n++;
            stick_my = BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0);
            n++;
            stick_mz = BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0);
            n++;
            rudder_gx = KatanaIMUGyro(BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0) );
            n++;
            rudder_gy = KatanaIMUGyro(BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0) );
            n++;
            rudder_gz = KatanaIMUGyro(BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0));
            n++;
            rudder_ax = KatanaIMUAccel(BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0));
            n++;
            rudder_ay = KatanaIMUAccel(BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0));
            n++;
            rudder_az = KatanaIMUAccel(BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0));
            n++;
            rudder_mx = BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0);
            n++;
            rudder_my = BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0);
            n++;
            rudder_mz = BitConverter.ToInt16(new byte[2] { m_buffer[2 * n + 1], m_buffer[2 * n + 2] }, 0);
            n++;
            stick_bytes = m_buffer[2 * n + 1];
            rudder_bytes = m_buffer[2 * n + 2];
            ArduIMUMutex.ReleaseMutex();
        }
        #endregion

        #region PacketLength
        private int determinePacketLength()
        {
            if (!h_ArduIMUSerialPort.IsOpen) return -1;

            h_ArduIMUSerialPort.Write(new char[1] { 'P' }, 0, 1); //Ensure in polled mode

            byte[] data = new byte[150];
            List<byte> datalist = new List<byte>();

            int bytesRead = 1;
            Stopwatch stopWatch = new Stopwatch();

            h_ArduIMUSerialPort.DiscardInBuffer(); //Clear buffer
            h_ArduIMUSerialPort.Write(new char[1] { 'G' }, 0, 1); //Request three packets
            h_ArduIMUSerialPort.Write(new char[1] { 'G' }, 0, 1);
            h_ArduIMUSerialPort.Write(new char[1] { 'G' }, 0, 1);
            stopWatch.Start();

            while (datalist.Count < 120)
            {
                bytesRead = h_ArduIMUSerialPort.Read(data, 0, data.Length);

                for (int i = 0; i < bytesRead; i++)
                {
                    datalist.Add(data[i]);
                }

                if (stopWatch.ElapsedMilliseconds > 3000)
                {
                    //Serial timeout
                    h_ArduIMUSerialPort.Close();
                    return 0;
                }
            }

            int verifiedCount = 0;
            int measuredLength = 0;

            for (int n = 0; n < datalist.Count; n++)
            {
                if ((byte)datalist[n] == 0xFF)
                {
                    int lengthCount = 1;
                    int sum = 0;
                    for (n++; n < datalist.Count; n++)
                    {
                        lengthCount++;
                        int checksum = (sum % 256) + 54;
                        if (checksum == datalist[n] && (n + 1 == datalist.Count || datalist[n + 1] == 0xFF))
                        {
                            if (measuredLength == lengthCount)
                            {
                                verifiedCount++;
                            }
                            else
                            {
                                measuredLength = lengthCount;
                            } //if
                            break;
                        } //if
                        sum += datalist[n];
                    } //for
                } //if
            } //for

            return measuredLength;
        } //determinePacketLength()
        #endregion

        #region Convert
        const float rad2deg = (float)(180 / Math.PI);
        const float deg2rad = (float)(1.0 / rad2deg);
        private const int IMU_GRAVITY = 4096;
        private float KatanaIMUAccel(short value)
        {
            return value * 9.80665f / IMU_GRAVITY;
        }

        private const float IMU_GYRO_GAIN = 0.0609f; // ( 0.0609 => 1/16.4LSB/deg/s at 2000deg/s)
        private float KatanaIMUGyro(short value)
        {
            return IMU_GYRO_GAIN * deg2rad * value;
        }
        #endregion
    }
    #endregion

    #region InputCalc
    public class ControlInputsClass
    {
        #region Variables
        private const float MaxAnalog = 1024.0f;

        #region Lengths
        private const float SP_Length = 12.5f; //inches
        private float l_OD = 9.5f; //inches
        private float l_x = 3.875f; //inches
        private float l_y = 9.25f; //inches
        private float l_z = 9.25f; //inches
        private float l_AB = 3.0f; //inches
        private float l_BC = 7.5f; //inches
        private float sp1_ext = 5.125f; //inches
        private float sp2_ext = 6.1875f; //inches

        public float L_OD
        {
            get { return l_OD; }
            set { l_OD = value; }
        }
        public float L_AB
        {
            get { return l_AB; }
            set { l_AB = value; }
        }
        public float L_BC
        {
            get { return l_BC; }
            set { l_BC = value; }
        }

        public float L_x
        {
            get { return l_x; }
            set { l_x = value; }
        }
        public float L_y
        {
            get { return l_y; }
            set { l_y = value; }
        }
        public float L_z
        {
            get { return l_z; }
            set { l_z = value; }
        }
        public float SP1_ext
        {
            get { return sp1_ext; }
            set { sp1_ext = value; }
        }
        public float SP2_ext
        {
            get { return sp2_ext; }
            set { sp2_ext = value; }
        }
        #endregion

        #region ComputedExtremes
        private float x_min = 100;
        private float x_max = -100;

        private float y_min = 100;
        private float y_max = -100;

        private float z_min = 100;
        private float z_max = -100;

        private int rudder_min = 1024;
        private int rudder_max = 0;
        #endregion

        #region NewtonRaphson
        private float theta_prev = 0.0f;
        #endregion
        #endregion

        public ControlInputsClass()
        {

        }

        public float[] SetLDExtreme(int SP1, int SP2, int RP)
        {
            float[] nrResults = NewtonRaphsonMethod(SP1, SP2, RP);
            x_min = nrResults[0];
            y_min = nrResults[1];
            return nrResults;
        }

        public float[] SetLUExtreme(int SP1, int SP2, int RP)
        {
            float[] nrResults = NewtonRaphsonMethod(SP1, SP2, RP);
            x_min = nrResults[0];
            y_max = nrResults[1];
            return nrResults;
        }

        public float[] SetRDExtreme(int SP1, int SP2, int RP)
        {
            float[] nrResults = NewtonRaphsonMethod(SP1, SP2, RP);
            x_max = nrResults[0];
            y_min = nrResults[1];
            return nrResults;
        }

        public float[] SetRUExtreme(int SP1, int SP2, int RP)
        {
            float[] nrResults = NewtonRaphsonMethod(SP1, SP2, RP);
            x_max = nrResults[0];
            y_max = nrResults[1];
            return nrResults;
        }

        public void SetLRExtreme(int RP)
        {
            rudder_min = RP;
        }

        public void SetRRExtreme(int RP)
        {
            rudder_max = RP;
        }

        public float[] RollPitchYaw(int SP1, int SP2, int RP)
        {
            float x = 0;
            float y = 0;
            float z = 0;
            float[] nrResults = NewtonRaphsonMethod(SP1, SP2, RP);

            x = nrResults[0];
            y = nrResults[1];
            z = nrResults[2];

            float[] position = { 0.0f, 0.0f, 0.0f, x, y, z, nrResults[3], nrResults[4] };

            //Calculate input ratio
            //Roll Input
            //if (x < x_min)
            //    x_min = x;
            //else if (x_max < x)
            //    x_max = x;

            position[0] = 2.0f * (x - x_min) / (x_max - x_min) - 1.0f;

            //Pitch Input
            //if (y < y_min)
            //    y_min = y;
            //else if (y_max < y)
            //    y_max = y;

            position[1] = 2.0f * (y - y_min) / (y_max - y_min) - 1.0f;

            //Yaw Input
            //if (RP < rudder_min)
            //    rudder_min = RP;
            //else if (rudder_max < RP)
            //    rudder_max = RP;

            position[2] = 2.0f * (RP - rudder_min) / (rudder_max - rudder_min) - 1.0f;

            return position;
        }

        private float[] NewtonRaphsonMethod(int SP1, int SP2, int RP)
        {
            float x = 0;
            float y = 0;
            float z = 0;
            float beta = 0;
            float fxx = 0;
            float dfxx = 0;
            float theta = theta_prev;

            //Calculate Length of each potentiometer ranges
            float R_O = SP_Length * SP1 / MaxAnalog + sp1_ext;
            float R_D = SP_Length * SP2 / MaxAnalog + sp2_ext;

            x = (R_O * R_O - R_D * R_D + l_OD * l_OD) / (2 * l_OD);
            beta = (float)Math.Sin((l_x - x) / l_AB);

            //Next, find y and z
            for (int i = 0; i < 1000; i++)
            {
                y = l_AB * ((float)Math.Sin(theta)) + l_BC * (float)(Math.Sin(theta) * Math.Cos(beta)) + l_y;
                z = -1.0f * l_AB * ((float)Math.Cos(theta)) - l_BC * (float)(Math.Cos(theta) * Math.Cos(beta)) + l_z;

                fxx = R_O * R_O - x * x - y * y - z * z;
                dfxx = -2.0f * l_AB * l_y * (float)Math.Cos(theta)
                    - 2.0f * l_AB * l_z * (float)Math.Sin(theta)
                    - 2.0f * l_BC * l_y * (float)(Math.Cos(beta) * Math.Cos(theta))
                    - 2.0f * l_BC * l_z * (float)(Math.Cos(beta) * Math.Sin(theta));

                theta = theta - fxx / dfxx;
                y = l_AB * ((float)Math.Sin(theta)) + l_BC * (float)(Math.Sin(theta) * Math.Cos(beta)) + l_y;
                z = -1.0f * l_AB * ((float)Math.Cos(theta)) - l_BC * (float)(Math.Cos(theta) * Math.Cos(beta)) + l_z;

                fxx = R_O * R_O - x * x - y * y - z * z;

                if (Math.Abs(fxx) < 0.0001f)
                {
                    theta_prev = theta;
                    break; //Sufficient result to exit loop
                }

            } //for

            float[] value = { x, y, z, beta, theta };
            return value;
        }

    }
    #endregion
}
