using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace DM_Main
{
    public partial class SerialConnect : Form
    {
        //StatusBar childStatusBar = new StatusBar();
       
        private static bool rxIntrFlag = false;
        private static string dataRX = null; // shows recieved string on main screen
        public char[] rxData = new char[25];
        //var rxData;
        public bool rxStartFlag = false;
        public bool rxStopFlag = false;
        userMainScreen umsObj = new userMainScreen();
        //userFirstScreen ufsObj = new userFirstScreen();
        StatusBar childStatusBar = new StatusBar();
        StatusBarPanel statusPanel = new StatusBarPanel();
        delegate void SetTextCallback(string text);
        public bool checkPortConnectionStatus()
        {
            return ComPort.IsOpen;
        }
        public string getRxMessage()
        {
            return dataRX;
        }

        public void setrxFlag(bool flag)
        {
            rxIntrFlag = flag;

        }
        public bool getIntrFlag()
        {
            return rxIntrFlag;
        }
        public SerialConnect()
        {
            InitializeComponent();
            cbSelectBaud.Items.Add(2400);
            cbSelectBaud.Items.Add(4800);
            cbSelectBaud.Items.Add(9600);
            cbSelectBaud.Items.Add(14400);
            cbSelectBaud.Items.Add(19200);
            cbSelectBaud.Items.Add(38400);
            cbSelectBaud.Items.Add(57600);
            cbSelectBaud.Items.Add(115200);
            
            string[] ArrayComPortsNames = null;
            int index = -1;
            string ComPortName = null;
            ArrayComPortsNames = SerialPort.GetPortNames();
            do
            {
                index += 1;
                cbSelectPort.Items.Add(ArrayComPortsNames[index]);

            }

            while (!((ArrayComPortsNames[index] == ComPortName) ||
                                (index == ArrayComPortsNames.GetUpperBound(0))));
            ComPort.DataReceived +=
              new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived);

            childStatusBar.Panels.Add(statusPanel);
            //childStatusBar.Show();
            statusPanel.Text = "Not Connected";

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect Port AND Test COMPORT")
            {
                if (!(ComPort.IsOpen)) // if comport is not already open
                {

                    
                    try
                    {
                        ComPort.PortName = Convert.ToString(cbSelectPort.Text);
                        ComPort.BaudRate = Convert.ToInt32(cbSelectBaud.Text);
                        ComPort.Open();
                        btnConnect.Text = "Open";
                        ((userFirstScreen)(this.MdiParent)).statusPanel.Text = ComPort.PortName.ToString() + " Connected";
                        
                    }
                    catch (FormatException)
                    {
                        if (cbSelectBaud.SelectedItem == null)
                        {
                            ComPort.BaudRate = 19200; // default baud rate of 19200 will be selected
                            MessageBox.Show("Please Select Baud rate");


                        }
                        else if (cbSelectPort.SelectedItem == null)
                        {
                            MessageBox.Show("Please Select COM Port");
                        }
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("Select Com port");
                    }
                    catch (UnauthorizedAccessException) 
                    { 
                        MessageBox.Show("Reconnect COM Port Once");
                    }
                } // isopen loop ends here
            } // Connect port loop ends here
            else if (btnConnect.Text == "Open")
            { // close comport if open
                btnConnect.Text = "Closed";
                ComPort.Close();
                ((userFirstScreen)(this.MdiParent)).statusPanel.Text = "Disconnected";
            } // open loop ends here
            else if (btnConnect.Text == "Closed")
            {

                if (!ComPort.IsOpen)
                {

                    ComPort.Open();
                    btnConnect.Text = "Open";
                    ((userFirstScreen)(this.MdiParent)).statusPanel.Text = "Connected";
                }
            } // closed loop ends here

            if (ComPort.IsOpen ) // send test string to Master board to check if comm setup is working fine
            {
                if (umsObj.serviceType == true)
                {
                    String testString = "@ Test from PC#";
                    //umsObj.getServiceList("Queue Prefix", "Ticket Start");
                    testString = umsObj.sendServiceSetupToMaster();
                    ComPort.Write(testString);
                    rtSerialTx.Text = testString;
                    MessageBox.Show(testString);
                }
                ((userFirstScreen)(this.MdiParent)).statusPanel.Text = "Connected";
            }
           
        }

        private void SerialConnect_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

       
        /*
         * Handler attached to comport to receive bytes
         * Received data on Interrupt serial RX interrupt
         * if false command is receiced, send one # then send new actual command 
         * else one actual command will get discarded
         */
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            
            //InputData = ComPort.ReadExisting();
            //rxInData = ComPort.ReadChar();

            string data  = null; //= sp.ReadExisting();

            //data = sp.ReadExisting(); // not suitable for our application
            data = sp.ReadTo("#");
            rxData = data.ToCharArray();
            if (rxData[0] == '*') // check if fisrt char of string received is '*'
            {
                SetText(data);
                dataRX = data;
                setrxFlag(true);
                sp.DiscardInBuffer();
            }
            else
            {
                data = null;
                sp.DiscardInBuffer();
            }
           // MessageBox.Show("Bytes to read: " + data);
            //SetText(data);

            //}
            /* convert int to ASCII ================ sample test*/
          /*  if (rxInData > 0 && rxInData < 128)
            {
                rxData[rxIndex] = (char)rxInData;
                if (rxInData == 35)
                { // if # is received
                    rxStopFlag = true;
                    rxStartFlag = false;

                }
                else if (rxInData == 42 && rxIndex == 0)
                { // mark start flag when '*' is received as first char 

                    rxStartFlag = true;
                   
                }
                //MessageBox.Show(rxData[rxIndex].ToString());
                
                rxIndex++;
                if (rxStopFlag == true && rxStartFlag == false && rxIndex > 0)
                {
                    rxStopFlag = false;
                    rxIndex = 0;
                    //MessageBox.Show(rxData.ToString());
                    rtSerialRx.Text = rxData.ToString();
                   /* for (int i = 0; i < rxIndex; i++)
                    {
                        MessageBox.Show(rxData.ToString());

                    }*/
              //  }

           // }
        }
        private void SetText(string text)
        {
            
            if (this.rtSerialRx.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
                

            }
            
            else
            {
                
                rtSerialRx.Focus();
                this.rtSerialRx.Text += text;
                
            }
            
        }

        private void rtSerialTx_Enter(object sender, EventArgs e)
        {
            if(rtSerialTx.Text == "Transmited text will appear here.")
            {
                rtSerialTx.Clear();
                rtSerialTx.Focus();

            }
        }

        private void rtSerialRx_Enter(object sender, EventArgs e)
        {
            if (rtSerialRx.Text == "You will recieve Text Here")
            {
                rtSerialRx.Clear();
               // rtSerialRx.Focus();

            }
           // MessageBox.Show("RX focus received");
        }
        private bool parseResponse(string str)
        {
            
            if (str.Contains('*'))
                return true;
            else return false;
        }

        private void btnSendServiceToMaster_Click(object sender, EventArgs e)
        {
            string testString = umsObj.sendServiceSetupToMaster();
            try
            {
                if (ComPort.IsOpen)
                {
                    if (umsObj.serviceType == true)
                    {
                        ComPort.Write(testString);
                        rtSerialTx.Text = testString;
                        ((userFirstScreen)(this.MdiParent)).statusPanel.Text = "Services list sent to Master Board";
                    }
                    else
                    {
                        ((userFirstScreen)(this.MdiParent)).statusPanel.Text = "Single Service Mode, No Master list required";
                    }
                    //MessageBox.Show(testString);
                }
                else
                {
                    MessageBox.Show("COM Port Is Not Open");
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Select Com port");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Reconnect COM Port Once");
            }
        }

    }
    
}
