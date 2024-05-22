using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace FiberPullStrain
{
    public class SerialCommunication
    {
        public event EventHandler<string> DataReceived; 
        public SerialPort myPort;

        public bool handshakesucceed = false;

        public SerialCommunication()
        {
            myPort = new SerialPort();
            myPort.DataReceived += MyPort_DataReceived;
            //InitializeSerialPort();
            //SearchAllCOMports();
        }
        //private void InitializeSerialPort()
        //{
        //    myPort = new SerialPort("COM3", 115200); // Adjust the port name and baud rate as necessary
        //    myPort.DataReceived += MyPort_DataReceived;
        //    try
        //    {
        //        myPort.Open();
        //    }
        //    catch (Exception ex)
        //    {
        //        DataReceived?.Invoke(this, $"Error opening serial port: {ex.Message}");
        //    }
        //}

        public async Task SearchAllCOMports()
        {
            var ports = new List<string>();
            ports.AddRange(SerialPort.GetPortNames());
            foreach (string port in ports)
            {
                if (myPort.IsOpen)
                {
                    try
                    {
                        myPort.Close();
                        myPort.DataReceived -= MyPort_DataReceived;
                        myPort.PortName = port;
                        myPort.BaudRate = 115200;
                        myPort.Open();
                    }
                    catch (Exception err)
                    {
                        DataReceived?.Invoke(this, err.Message);
                    }
                }
                else
                {
                    try
                    {
                        myPort.PortName = port;
                        myPort.BaudRate = 115200;
                        myPort.DataReceived -= MyPort_DataReceived;
                        myPort.Open();
                    }
                    catch (Exception err)
                    {
                       DataReceived?.Invoke(this,err.Message);
                    }

                }

                if (myPort.IsOpen)
                {
                    try
                    {
                        int i = 0;
                        while (!handshakesucceed && i < 10)
                        {
                            if (myPort.BytesToRead > 0)
                            {
                                string ss = myPort.ReadLine().TrimEnd();
                                if (ss.Contains("FiberPull"))
                                {
                                    handshakesucceed = true;
                                    DataReceived?.Invoke(this, $"Handshaking Succeed with {myPort.PortName}");
                                    myPort.DataReceived += MyPort_DataReceived;
                                    return;
                                }
                                else
                                {
                                    myPort.DiscardInBuffer();
                                    myPort.DiscardOutBuffer();
                                    
                                    DataReceived?.Invoke(this,$"Hand shaking with {myPort.PortName} failed...");
                                }

                            }
                            
                            myPort.DiscardOutBuffer();
                            myPort.WriteLine("h");
                            await Task.Delay(200);
                            i++;
                        }
                        if (!handshakesucceed)
                        {
                            myPort.Close();
                            DataReceived?.Invoke(this, "No instrument found."); 
                        }

                    }
                    catch (Exception err)
                    {
                        DataReceived?.Invoke(this, err.Message);
                    }
                }
            }
        }
        public void MyPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            string data = myPort.ReadLine().TrimEnd();
            DataReceived?.Invoke(this, $"Data incoming...{data}");
            if (data.Length > 0)
            {
                if (!handshakesucceed)
                {
                    if (data.Contains("FiberPull")) // invoke UI information update function
                    {
                        DataReceived?.Invoke(this, $"{myPort.PortName} -- Hand Shaking succeed.");
                        handshakesucceed = true;
                    }
                    else
                    {
                        handshakesucceed = false;
                        myPort.Close();
                        DataReceived?.Invoke(this, $"{myPort.PortName} -- Hand Shaking failed.");
                    }
                }

                else
                {
                    DataReceived?.Invoke(this, data);//????????????????????????????????
                }
            }
        }
        public void SimulateDataReceived(string data)
        {
            DataReceived?.Invoke(this, data);
        }
    }

}
