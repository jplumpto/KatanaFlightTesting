using System;
//using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace FlightTestConsole
{
    enum SerialStatus
    {
        CONNECTION_FAILURE = -1,
        PING_RESPONSE_FAILURE = -2,
        PACKET_SIZE_MISSMATCH = -3,
        SUCCESS = 1
    }

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
            string outputLine = time + "\t" + roll.ToString() + "\t" + pitch.ToString() + "\t" + yaw.ToString()
                + "\t" + v_roll.ToString() + "\t" + v_pitch.ToString() + "\t" + v_yaw.ToString() + "\t" +
                a_x.ToString() + "\t" + a_y.ToString() + "\t" + a_z.ToString() + "\t" + mag_x.ToString()
                + "\t" + mag_y.ToString() + "\t" + mag_z.ToString() + "\t" + temp_sensor.ToString()
                + "\t" + ahrs_time.ToString();
            return outputLine;
        }

        public string getDebug()
        {
            string outputLine = time + "\t" + String.Format("{0:0.000}", roll) + "\t" + String.Format("{0:0.000}", pitch) + "\t" + String.Format("{0:0.000}", yaw);
            return outputLine;
        }

        public string getFormat()
        {
            string AHRSFormat = "Time(s) \t Roll(deg) \t Pitch(deg) \t Yaw(deg) \t RollRate \t PitchRate \t YawRate \t XAccel \t YAccel \t ZAccel \t XMag \t YMag \t ZMag \t InTemp(C) \t AHRSTicks";
            return AHRSFormat;
        }
    } 
    #endregion

    class AhrsSerialData
    {
        #region Variables
        private SerialPort h_AhrsSerialPort;
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
        #endregion //End

        #region Connection
        //Connect
        public SerialStatus ConnectSerial(string portName)
        {
            h_AhrsSerialPort = new SerialPort(portName,38400,Parity.None,8,StopBits.One);
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

            //Change to Angle (VG) Mode
            h_AhrsSerialPort.Write(new char[1]{'a'},0,1);
            m_freqTimer.Start();

            //Change to Normal Mode
            h_AhrsSerialPort.Write(new char[2] {'T', 'C' }, 0, 2);

            return SerialStatus.SUCCESS;
        }

        // Ping AHRS 
        private bool pingSerial(long timeoutInMilliSeconds)
        {
	        if (!h_AhrsSerialPort.IsOpen ) return false;

	        char[] data = new char[100];
            int bytesRead = 0;
            char[] pingChar = new char[1]{'R'};
            Stopwatch stopWatch = new Stopwatch();

            h_AhrsSerialPort.DiscardInBuffer();
            h_AhrsSerialPort.Write(pingChar,0,1);
            
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
        public string GetCurrentData()
        {
            AHRSMutex.WaitOne();
            string line = m_data.getline();
            //string line = m_data.getDebug();
            AHRSMutex.ReleaseMutex();
            return line;
        }

        public string GetLineFormat()
        {
            return m_data.getFormat();
        }

        public string GetErrorMessage()
        {
            return m_msg;
        }

        public bool ReceivingData()
        {
            return m_receiving;
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

            //Close connection correctly
            if (h_AhrsSerialPort.IsOpen)
            {
                //Tell AHRS to stop sending data
                h_AhrsSerialPort.Write("P");

                //Clear buffer
                h_AhrsSerialPort.DiscardInBuffer();
                h_AhrsSerialPort.Close();
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
                    for (; n < bytesRead;n++ )
                    {
                        if (data[n] == 0xFF)
                        {
                            break;
                        }//if
                    } //for
                } //if

                //Add data to buffer
                for (; n < bytesRead;n++ )
                {
                    //Add data
                    m_buffer.Add(data[n]);

                    //If buffer now holds sufficient points
                    if (m_buffer.Count == packetLength)
                    {
                        int sum = 0;
                        for (int k = 1; k < m_buffer.Count - 1;k++ )
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
                                } else
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
                            m_buffer.Clear();
                            h_AhrsSerialPort.DiscardInBuffer();
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
            for (n = 0; n < 12;n++ )
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
            m_data.roll = 1.0 * data[0] * (180) / (1<<15);
            m_data.pitch = 1.0 * data[1] * (180) / (1 << 15);
            m_data.yaw = 1.0 * data[2] * (180) / (1 << 15);
            
            //Angular rate = data * (AR * 1.5) / 2^15
            m_data.v_roll = 1.0 * data[3] * (100 * 1.5) / (1 << 15);
            m_data.v_pitch = 1.0 * data[4] * (100 * 1.5) / (1 << 15);
            m_data.v_yaw = 1.0 * data[5] * (100 * 1.5) / (1 << 15);

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
                bytesRead = h_AhrsSerialPort.Read(data,0,data.Length);

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

	        for (int n=0;n<datalist.Count;n++) 
            {
		        if ((byte)datalist[n] == 0xFF) 
                {
			        int lengthCount = 1;
			        int sum = 0;
                    for (n++; n < datalist.Count; n++) 
                    {
				        lengthCount++;
				        int checksum = sum % 256;
                        if (checksum == datalist[n] && (n + 1 == datalist.Count || datalist[n+1] == 0xFF)) 
                        {
					        if (measuredLength == lengthCount) 
                            {
						        verifiedCount++;
					        } else {
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
	        if (raw > 0xffff/2.0) raw = raw - 0xffff;
	        if (index <=3) {
		        return raw * (180.0 * 1.0) / 32767.0 + 0;
	        } else if (index <= 6) {
		        return raw * (100.0 * 1.5) / 32767.0 + 0;
	        } else if (index <= 9) {
		        return raw * (4.0 * 1.5) / 32767.0 + 0;
	        }
	        return 0;
        }
        #endregion
    }
}
