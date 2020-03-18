using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

namespace DM_Main
{


    public partial class userMainScreen : Form
    {

        public StatusBar mainStatusBar = new StatusBar();
        //public StatusBarPanel statusPanel = new StatusBarPanel();
        DataTable dtTicketService = new DataTable();
        DataTable dtTokenTable = new DataTable();
        DataTable dtServiceTable = new DataTable();
        public SqlCommand cmdSQL = new SqlCommand();

        //public SqlConnection sqlCon1 = new SqlConnection(@"Data Source=ABC-PC\SQL2005;Initial Catalog=testSQL;Integrated Security=True;");
        public SqlConnection sqlCon1;
        public SqlDataReader ResultSQL = null;
        public SqlDataAdapter adapter = new SqlDataAdapter();
        string sqlQuery = null;
        static string rxDI = null, rxRI = null, rxCountTemp = null, rxCount = null;
        static char rxPrefix;
        int lastRowID = 0, lastTokenID = 0, lastServId = 0;
        int numOfServices = 0;
        public bool serviceType = false, portConnectStatus = false;

        //private static int tokenCount = 0;
        int[] ticketCount = new int[10];
        List<string> availServices = new List<string>();
        List<string> uniqueServices = new List<string>();
        List<string> uniquePrefix = new List<string>();
        List<string> uniqueTicketStart = new List<string>();
        List<string> uniqueTicketEnd = new List<string>();
        List<int> tokenCount = new List<int>();
        string ackMessage = "Select Desired Service,\nA Token Number Will Generate From Here";
        static int tickCountForMessageClear = 0;
        public GroupBox serviceButtonGroup = new GroupBox();
        public userMainScreen()
        {
            string sqlName = null;
            //DataGridView dataGridTemp = new DataGridView();

            InitializeComponent();
            int _ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int _ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            // set form width and height as per screen width and height
            this.Width = 600;
            this.Height = _ScreenHeight;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#B3E5FC");
            //dataGridTemp.Location = new Point(1200, 10);
            //this.Controls.Add(dataGridTemp);
            serviceButtonGroup.Text = "Choose Services From Here";
            serviceButtonGroup.Location = new Point(10, 230);
            serviceButtonGroup.Width = 500;
            serviceButtonGroup.Height = 250;
            serviceButtonGroup.Font = new Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serviceButtonGroup.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000");
            serviceButtonGroup.Padding = new System.Windows.Forms.Padding(12);
            pbTitlePicture.Width = 900;
            pbTitlePicture.BackgroundImageLayout = ImageLayout.Center;
            pbTitlePicture.BackColor = System.Drawing.ColorTranslator.FromHtml("#B3E5FC");
            pbTitlePicture.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //            pbTitlePicture.Padding = new System.Windows.Forms.Padding((_ScreenWidth - pbTitlePicture.Image.Width)/2);

            lCurrentTime.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            GenerateTokenSuccMessage.Margin = new System.Windows.Forms.Padding(12);
            GenerateTokenSuccMessage.Width = 650;
            GenerateTokenSuccMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFF");
            GenerateTokenSuccMessage.BackColor = System.Drawing.ColorTranslator.FromHtml("#43A047");
            //MessageBox.Show("Width = "+_ScreenWidth.ToString()+"\n height = "+_ScreenHeight.ToString());
            this.Controls.Add(serviceButtonGroup);

            //portConnectStatus = serialConnectObj.checkPortConnectionStatus();
            try
            {
                ConfigurationManager.RefreshSection("connectionStrings");
                sqlCon1 = new SqlConnection(sqlName);
                sqlCon1.ConnectionString = ConfigurationManager.ConnectionStrings["con"].ToString();

                dtServiceTable.Columns.Add("ServID", typeof(int));
                dtServiceTable.Columns.Add("Num Of Active Services", typeof(int));
                dtServiceTable.Columns.Add("ServiceType", typeof(int));
                sqlQuery = @"SELECT count(*) as count From ServiceTable WHERE ([is_delete] = 0 AND [in_use] = '1')"; // select rows that are in use only
                adapter = new SqlDataAdapter(sqlQuery, sqlCon1);
                adapter.Fill(dtServiceTable);

                lastServId = Convert.ToInt16(dtServiceTable.Rows[0]["count"].ToString());
                dtServiceTable.Clear();
                sqlQuery = @"SELECT [ServID],[Num Of Active Services],[ServiceType] From ServiceTable WHERE ([is_delete] = 0 AND [in_use] ='1') GROUP BY [ServID],[Num Of Active Services],[ServiceType]";
                adapter = new SqlDataAdapter(sqlQuery, sqlCon1);
                adapter.Fill(dtServiceTable);
                //dataGridTemp.Visible = true;
                //dataGridTemp.DataSource = dtServiceTable;
                //MessageBox.Show("Rows: " + lastServId.ToString());
                if (lastServId > 0)
                {

                    string temp = dtServiceTable.Rows[0]["ServiceType"].ToString();
                    serviceType = Convert.ToBoolean(Convert.ToInt16(temp));
                    temp = dtServiceTable.Rows[0]["Num Of Active Services"].ToString();
                    numOfServices = Convert.ToInt16(temp);
                    //MessageBox.Show("data got: "+temp+" num: "+numOfServices.ToString());
                }
                else
                {

                    MessageBox.Show("Please Select Service Type from Adminstrator");
                }

                /* 
                 * this table contains details about ticket start and end value and its other attributes
                 * 
                 */
                dtTicketService.Columns.Add("Op ID", typeof(int));
                dtTicketService.Columns.Add("In Use", typeof(bool));
                dtTicketService.Columns.Add("Queue Name", typeof(string));
                dtTicketService.Columns.Add("Queue Prefix", typeof(string));
                dtTicketService.Columns.Add("ServiceType", typeof(bool));
                dtTicketService.Columns.Add("Ticket Start", typeof(string));
                dtTicketService.Columns.Add("Ticket End", typeof(string));
                if (serviceType)
                {
                    sqlQuery = @"declare @serviceType int select @serviceType = [testSQL].[dbo].[ServiceTable].[ServiceType] From [testSQL].[dbo].[ServiceTable] where [ServiceType] = '1'
                    SELECT count(*) as count 
                    From [testSQL].[dbo].OperationsTable
                    inner join [testSQL].[dbo].[ServiceTable] ON [testSQL].[dbo].[OperationsTable].[ServiceType] = [testSQL].[dbo].[ServiceTable].[ServiceType]
                    WHERE ([testSQL].[dbo].[OperationsTable].[is_delete] = 0  AND [testSQL].[dbo].[OperationsTable].[In Use] = 'True' AND [testSQL].[dbo].[ServiceTable].[ServiceType] = '1')";
                }
                else if (serviceType == false)// single service
                {
                    sqlQuery = @"declare @serviceType int select @serviceType = [testSQL].[dbo].[ServiceTable].[ServiceType] From [testSQL].[dbo].[ServiceTable] where [ServiceType] = '0'
                    SELECT count(*) as count 
                    From [testSQL].[dbo].OperationsTable
                    inner join [testSQL].[dbo].[ServiceTable] ON [testSQL].[dbo].[OperationsTable].[ServiceType] = [testSQL].[dbo].[ServiceTable].[ServiceType]
                    WHERE ([testSQL].[dbo].[OperationsTable].[is_delete] = 0  AND [testSQL].[dbo].[OperationsTable].[In Use] = 'True' AND [testSQL].[dbo].[ServiceTable].[ServiceType] = '0')";
                }
                adapter = new SqlDataAdapter(sqlQuery, sqlCon1);
                adapter.Fill(dtTicketService);
                lastRowID = Convert.ToInt16(dtTicketService.Rows[0][7].ToString());
                dtTicketService.Clear();
                //MessageBox.Show("Row Id:" + lastRowID.ToString());
                if (lastRowID > 0)
                {
                    if (serviceType)
                    {
                        sqlQuery = @"SELECT [OpID] as [Op ID],[testSQL].[dbo].[OperationsTable].[In Use],
                                    [testSQL].[dbo].[QueueTable].[Queue Name],
                                    [testSQL].[dbo].[QueueTable].[Queue Prefix],
                                    [testSQL].[dbo].[QueueTable].[Token_Start] as [Ticket Start],
                                    [testSQL].[dbo].[QueueTable].[Token_End] as [Ticket End]
                                    From [testSQL].[dbo].OperationsTable 
                                    inner join [testSQL].[dbo].[QueueTable] ON 
                                    ([testSQL].[dbo].[OperationsTable].[Queue Name]  
                                        = [testSQL].[dbo].[QueueTable].[Queue Name]
                                    AND [testSQL].[dbo].[OperationsTable].[Queue prefix]  
                                        = [testSQL].[dbo].[QueueTable].[Queue Prefix])
                                    WHERE ([testSQL].[dbo].[OperationsTable].[is_delete] = 0  
                                    AND [testSQL].[dbo].[OperationsTable].[In Use] = 'True' 
                                    AND [testSQL].[dbo].[QueueTable].[Queue Prefix] != '0')
                                    ORDER BY [testSQL].[dbo].[QueueTable].[Queue Prefix]";
                    }
                    else if (!serviceType) // single service
                    {
                        sqlQuery = @"SELECT [OpID] as [Op ID],[testSQL].[dbo].[OperationsTable].[In Use],
                                    [testSQL].[dbo].[QueueTable].[Queue Name],
                                    [testSQL].[dbo].[QueueTable].[Queue Prefix],
                                    [testSQL].[dbo].[QueueTable].[Token_Start] as [Ticket Start],
                                    [testSQL].[dbo].[QueueTable].[Token_End] as [Ticket End]
                                    From [testSQL].[dbo].OperationsTable 
                                    inner join [testSQL].[dbo].[QueueTable] ON 
                                    ([testSQL].[dbo].[OperationsTable].[Queue Name]  
	                                    = [testSQL].[dbo].[QueueTable].[Queue Name]
                                    AND [testSQL].[dbo].[OperationsTable].[Queue Prefix]  
	                                    = [testSQL].[dbo].[QueueTable].[Queue Prefix])
                                    WHERE ([testSQL].[dbo].[OperationsTable].[is_delete] = 0  
                                    AND [testSQL].[dbo].[OperationsTable].[In Use] = 'True' 
                                    AND [testSQL].[dbo].[QueueTable].[Queue Prefix] = '0')
                                    ORDER BY [testSQL].[dbo].[QueueTable].[Queue Prefix]";
                    }
                    adapter = new SqlDataAdapter(sqlQuery, sqlCon1);
                    adapter.Fill(dtTicketService);
                }

                //dataGridTemp.DataSource = dtTicketService;
                lCurrentTime.Text = DateTime.Now.ToString("ddd, MMM-dd-yyyy \nHH:mm:ss");

                // uniqueServices = availServices.Distinct().ToList();// get unique name of services offered.
                uniqueServices = getUniqueList("Queue Name");
                //uniqueTicketStart = getUniqueList("Ticket Start");
                //uniqueTicketEnd = getUniqueList("Ticket End");
                //uniquePrefix = getUniqueList("Queue Prefix");

                /**
                 * Method 2 to get complete list of prefix, token start and token end as ealier it 
                 * was throwing exception when 2 queues had same token start and stop values
                 */

                List<string> tokenStart = makeTokenNumList("Queue Prefix", "Ticket Start");
                List<string> tokenEnd = makeTokenNumList("Queue Prefix", "Ticket End");
                //MessageBox.Show("Line 190: tokenStart: "+tokenStart[0].ToString());
                setValues(tokenStart, tokenEnd);
                //MessageBox.Show("Line 191: " + uniqueTicketStart.Count.ToString());
                for (int i = 0; i < uniqueTicketStart.Count; i++)
                {
                    tokenCount.Add(Convert.ToInt16(uniqueTicketStart[i].ToString()) - 1);
                    //MessageBox.Show("Start ser: " + tokenCount[i]);
                }

                //MessageBox.Show("serv.count= " + uniqueServices.Count);

                //-------------------------------------------------- Get list of Services ---------------------------------------------------------
                int btnlocationX = 30, btnLocationY = 270;
                for (int i = 0; i < uniqueServices.Count(); i++)
                {
                    //MessageBox.Show("unique[" + Convert.ToString(i) + "] = " + uniqueServices[i]);
                    //cbChooseService.Items.Add(uniqueServices[i].ToString()); // select option for user on display screen
                    createServiceButton(btnlocationX, btnLocationY, uniqueServices[i].ToString(), uniqueServices[i].ToString());
                    btnLocationY += 52;
                    if (i == (Math.Round((double)(uniqueServices.Count() / 2))) + 1) // when 5 out of 10 buttons are added in single row, jump to new row
                    {
                        btnlocationX += 200;
                        btnLocationY = 270;
                        
                    }
                    

                }
                GenerateTokenSuccMessage.Location = new Point(10, btnLocationY + 235);// change position of message box as per no of service 
                //serviceButtonGroup.Height = (uniqueServices.Count()*65)+5;
                //MessageBox.Show("Height: "+((uniqueServices.Count()*65)+5).ToString());
                if (uniqueServices.Count < 5)
                {
                    serviceButtonGroup.Width = 300;
                }
                else
                {
                    serviceButtonGroup.Width = 385;
                }
                dtTokenTable.Columns.Add("Token ID", typeof(int));
                dtTokenTable.Columns.Add("Display ID", typeof(string));
                dtTokenTable.Columns.Add("Keypad ID", typeof(string));
                dtTokenTable.Columns.Add("Queue Name", typeof(string));
                dtTokenTable.Columns.Add("Queue Prefix", typeof(char));
                dtTokenTable.Columns.Add("Token Num", typeof(int));
                dtTokenTable.Columns.Add("Token Status", typeof(string));
                sqlQuery = "SELECT count(*) as count From TokenTable ";
                adapter = new SqlDataAdapter(sqlQuery, sqlCon1);
                adapter.Fill(dtTokenTable);
                lastTokenID = Convert.ToInt16(dtTokenTable.Rows[0][7].ToString());
                if (lastTokenID > 0)
                {
                    getLastTokenValues(); // get last served tokens
                }
                //MessageBox.Show("Token table count: " + lastTokenID.ToString());
                //dtTokenTable.Clear();
                GenerateTokenSuccMessage.Text = ackMessage;
            }
            catch (Exception except)
            {
                logError(except);
            }
            //(userFirstScreen) (this.MdiParent)
        }
        /* on page load, use timer class to update time on screen
         */
        private void userMainScreen_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 100; // tick interval ever 100 msec
            timer.Tick += new EventHandler(timerTickEvent);
            timer.Start(); // enable timer



        }
        /* Interrupt to be called every sec to update on screen time
         */
        private void timerTickEvent(object sender, EventArgs e)
        {
            bool rxFlag = false;
            string rxMessage = null;
            SerialConnect scObj = new SerialConnect();
            lCurrentTime.Text = DateTime.Now.ToString("ddd, MMM-dd-yyyy \nHH:mm:ss");
            rxFlag = scObj.getIntrFlag();

            if (rxFlag)
            {
                rxFlag = false;
                scObj.setrxFlag(rxFlag);
                rxMessage = scObj.getRxMessage();
                getDataFromMessage(rxMessage); // decode received message
                getCount_Prefix(rxCountTemp);
                updateTokenTable();
                //MessageBox.Show("Prefix: " + rxPrefix.ToString() + ", Count: " + rxCount);
                // MessageBox.Show("Message Received: " + rxMessage.Length.ToString());
            }
            if (++tickCountForMessageClear > 200)
            {
                tickCountForMessageClear = 0;
                GenerateTokenSuccMessage.Text = ackMessage;
            }
        }
        /* This funtion is called on button click to generate new token number
         * It insert new token generated in Token table 
         */
        private void btnGenrateTicket_Click(object sender, EventArgs e)
        {
            string temp_token ;
            Button getServiceBtn = sender as Button;
            //String serviceSel = sender.ToString();
            String serviceSel = getServiceBtn.Text;
            //MessageBox.Show("Btn: " + serviceSel);
            //            string serviceSel = cbChooseService.SelectedItem.ToString();
            string serviceId = null;
            string strToken = null;
            int ticketStart = 0, ticketEnd = 0, tokenLocal, numOfServices = 0;
            SerialConnect serialConnectObj = new SerialConnect();
            portConnectStatus = serialConnectObj.checkPortConnectionStatus();
            numOfServices = uniqueServices.Count;
            //serviceId = "* 02 01 B001 #";
            //getDataFromMessage(serviceId); // for testing purpose line 31. and 309 was used
            //MessageBox.Show("Line 314: " + uniqueServices.Count.ToString());
            if (serviceType)
            {



                numOfServices = uniqueServices.Count;
                //MessageBox.Show("Line 314: "+uniqueServices.Count.ToString());
                for (int i = 0; i < numOfServices; i++)
                {
                    // Get Service id and ticket start and ticket end


                    if (serviceSel == uniqueServices[i].ToString())
                    {
                        //MessageBox.Show("Serve: " + serviceSel);
                        //serviceId   = dtTicketService.Rows[i]["Queue Prefix"].ToString();
                        //ticketStart = Convert.ToInt16(dtTicketService.Rows[i]["Ticket Start"].ToString());
                        //ticketEnd   = Convert.ToInt16(dtTicketService.Rows[i]["Ticket End"].ToString());
                        serviceId = uniqueServices[i].ToString();
                        ticketStart = Convert.ToInt16(uniqueTicketStart[i].ToString());
                        ticketEnd = Convert.ToInt16(uniqueTicketEnd[i].ToString());
                        //   MessageBox.Show("Service = " + serviceId.ToString() + "Tic Start = " + ticketStart.ToString()
                        //       + "Ticend = " + ticketEnd.ToString());
                        tokenLocal = Convert.ToInt16(tokenCount[i].ToString());
                        if (tokenLocal > ticketEnd || tokenLocal < ticketStart) tokenLocal = ticketStart;
                        else
                        {
                            ++tokenLocal;

                        }
                        tokenCount[i] = tokenLocal;
                        temp_token = tokenCount[i].ToString();

                        int temp_len = temp_token.Length;// get number of digits in count value 
                        if (temp_len < 3)
                        {
                            strToken = tokenDigitAdjust(tokenCount[i], temp_len, uniquePrefix[i].ToString()); // return count along with prefix and adjusted digits of token number
                            //MessageBox.Show("Line349: " + strToken+" len "+temp_len.ToString());
                            putTokenInTable(tokenCount[i].ToString(), uniquePrefix[i].ToString(), uniqueServices[i].ToString());
                        }
                        else
                        {
                            strToken = uniquePrefix[i].ToString() + tokenCount[i].ToString();
                            //MessageBox.Show("Line355: " + strToken + " len " + temp_len.ToString());
                            putTokenInTable(tokenCount[i].ToString(), uniquePrefix[i].ToString(), uniqueServices[i].ToString());
                        }

                        //MessageBox.Show("Token " + strToken); //test to show token number in alert box
                        //tempText = "Thank You for choosing Services\nYour token number is " + strToken;
                        //tempText += " Your Token Status is Waiting ";
                        //GenerateTokenSuccMessage.Text = tempText;
                        //Ticket_Design tdObj = new Ticket_Design();
                        //tdObj.setOperationName(serviceSel);
                        //tdObj.setTokenValue(strToken);
                        //tdObj.print();


                    }
                }
            }// Multiple services token genrate ends here
            else if (!serviceType) // Single service mode
            {
                uniquePrefix[0] = "0";
                ticketStart = Convert.ToInt16(uniqueTicketStart[0].ToString());
                ticketEnd = Convert.ToInt16(uniqueTicketEnd[0].ToString());
                tokenLocal = Convert.ToInt16(tokenCount[0].ToString());
                if (tokenLocal > ticketEnd || tokenLocal < ticketStart) tokenLocal = ticketStart;
                else
                {
                    ++tokenLocal;

                }
                tokenCount[0] = tokenLocal;
                temp_token = tokenCount[0].ToString();
                for (int i = 0; i < numOfServices; i++)
                {
                    // Get Service id and ticket start and ticket end


                    if (serviceSel == uniqueServices[i].ToString())
                    {
                        int temp_len = temp_token.Length;// get number of digits in count value 
                        if (temp_len < 3)
                        {
                            strToken = tokenDigitAdjust(tokenCount[0], temp_len, uniquePrefix[0].ToString()); // return count along with prefix and adjusted digits of token number
                            putTokenInTable(strToken, uniquePrefix[0].ToString(), uniqueServices[i].ToString());
                        }
                        else
                        {
                            strToken = uniquePrefix[0].ToString() + tokenCount[0].ToString();
                            putTokenInTable(tokenCount[0].ToString(), uniquePrefix[0].ToString(), uniqueServices[i].ToString());
                        }
                    }
                }
            }
            PrintToken(strToken, serviceSel); //prints thanks message on screen 

            // along with token number. and prints ticket  
        }
        /* This function creates a command string 
         * this string should be send to MCU 
         * when using multiple services to save start
         * and stop values at MCU-Master Display
         * Return: string for comport
         * @param: null
         * 
         */
        public string sendServiceSetupToMaster()
        {
            int servCount = uniqueServices.Count;
            //MessageBox.Show("UniquePrefix = " + uniquePrefix.Count+" unique start: "+uniqueTicketStart.Count+"\nunique end= "+uniqueTicketEnd.Count);
            string serviceStr = "$ ";
            //string start,end;
            try
            {
                if (serviceType) // for multiple service only
                {
                    serviceStr += prefixZeroToService(servCount);
                    for (int i = 0; i < servCount; i++)
                    {
                        serviceStr += uniquePrefix[i].ToString();
                        if (Convert.ToInt32(uniqueTicketStart[i].ToString()) < 100)
                            uniqueTicketStart[i] = prefixZeroToToken(Convert.ToInt32(uniqueTicketStart[i].ToString()));
                        serviceStr += uniqueTicketStart[i].ToString();
                        serviceStr += " ";
                        if (Convert.ToInt32(uniqueTicketEnd[i].ToString()) < 100)
                            uniqueTicketEnd[i] = prefixZeroToToken(Convert.ToInt32(uniqueTicketEnd[i].ToString()));
                        serviceStr += uniquePrefix[i].ToString();
                        serviceStr += uniqueTicketEnd[i].ToString();
                        serviceStr += " ";
                        //MessageBox.Show("Line 445: " + serviceStr);
                    }
                    serviceStr += "#"; // end of comand
                }
                //MessageBox.Show("Line 445: " + serviceStr);
            }
            catch (Exception execept)
            {
                logError(execept);
            }
            return serviceStr;

        }
        // get list of items from table like list of 
        private List<string> getUniqueList(string colName)
        {
            List<string> temp = new List<string>();
            try
            {

                for (int i = 0; i < lastRowID; i++)
                {
                    temp.Add(dtTicketService.Rows[i][colName].ToString());
                }

            }
            catch (Exception except)
            {
                logError(except);
            }
            return temp.Distinct().ToList();// get unique name of services offered.
            // return temp;// temperory use a normal list instead of distinct list.
        }

        private List<string> makeTokenNumList(string colName, string tokenValue)
        {
            List<string> temp = new List<string>();
            try
            {

                for (int i = 0; i < lastRowID; i++)
                {
                    temp.Add(dtTicketService.Rows[i][colName].ToString() + dtTicketService.Rows[i][tokenValue].ToString());
                }

            }
            catch (Exception except)
            {
                logError(except);
            }
            return temp.Distinct().ToList();// get unique name of services offered.
            // return temp;// temperory use a normal list instead of distinct list.
        }
        /* convert number of services from int to string
         * add prefix of 0 to int value
         * say if num of services = 3,
         * it will return string as 03
         */
        private string prefixZeroToService(int num)
        {
            string prefixZero = null;
            if (num > 1 && num <= 9)
            {
                prefixZero = "0";
                prefixZero += num.ToString();
                prefixZero += " ";
                return prefixZero;

            }
            else
            {
                prefixZero = num.ToString();
                prefixZero += " ";
                return prefixZero;
            }


        }

        private string prefixZeroToToken(int num)
        {
            string prefixZero = null;
            if (num >= 1 && num < 10) // add 2 '00' if it is between 1 to 10
            {
                prefixZero = "00";
                prefixZero += num.ToString();
                //prefixZero += " ";
                return prefixZero;

            }
            else if(num > 9 && num < 100)
            {
                prefixZero = "0"; // add single prefix zero when num is between 10 to 100
                prefixZero += num.ToString();
                return prefixZero;
            }
            return prefixZero = num.ToString();

        }
        private void getDataFromMessage(string str)
        {
            int i = 0;
            string[] decodeStrings = new string[3];
            decodeStrings = str.Split('\x20');
            foreach (string decodeString in decodeStrings)
            {
                if (i == 1) rxDI = decodeString;
                else if (i == 2) rxRI = decodeString;
                else if (i == 3) rxCountTemp = decodeString;
                else if (i > 4) break;
                i++;

            }
            //MessageBox.Show("Line549: rxCountTemp " + rxCountTemp+" rxRI: "+rxRI+" rxDI: "+rxDI);

        }
        private void getCount_Prefix(string str)
        {
            char[] temp = new char[4];
            try
            {
                temp = str.ToCharArray();
                //MessageBox.Show("str len of count: " + str.Length.ToString());
                rxPrefix = temp[0];
                rxCount = str.Substring(1);

            }
            catch (Exception excep)
            {
                logError(excep);
            }
        }
        /* This Function adds 00 or 0 for single digit or 2 digit token values
         * so as to make it 3 digit value and make a complete Token number 
         * with its service ID say service ID = A
         * token number = 5
         * it will result in A005 as a string
         * @param1: int token value
         * @param2: int no of digits in current token value
         * @param3: sting prefix
         * @return: string format of token along with its prefix
         */
        private string tokenDigitAdjust(int tok, int len, string strPre)
        {
            string resToken = null;
            if (len == 1)
            {
                resToken = strPre;
                resToken += "00";
                resToken += tok.ToString();
                return resToken;
            }
            else if (len == 2)
            {
                resToken = strPre;
                resToken += "0";
                resToken += tok.ToString();
                return resToken;
            }
            else
                return resToken;
        }


        /*
         * Add Recently generated Token into TokenTable
         * @params: tokenNum -string
         * @params: tokenService - string Queue prefix
         * @params: queueName - string 
         */
        private void putTokenInTable(string tokenNum, string tokenService, string queueName)
        {
            string tokenStatus = "WAITING"; // When token is generated, it gets status as waiting
            sqlQuery = @"INSERT into TokenTable ( [Queue Name],[Queue Prefix],
                        [Token Num],[Token Status],[createDate],[updateDate] ) 
                        Values('"+queueName+"','"+tokenService+"','" + tokenNum + "','" + tokenStatus + "',GetDate(),GetDate() )";
            sqlCon1.Open();
            try
            {

                adapter.InsertCommand = new SqlCommand(sqlQuery, sqlCon1);
                adapter.InsertCommand.ExecuteNonQuery();
                //MessageBox.Show("Token inserted !! ");
                //((userFirstScreen)this.MdiParent).statusPanel.Text = "New Token Added to Database ";
                sqlCon1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                sqlCon1.Close();
            }
            //sqlCon1.Open();
        }

        /* As token gets served, this method is called.
         * On serial receive data is extracted and this
         * method is called to updated Token status in
         * Token table.
         */
        private void updateTokenTable()
        {
            string tokenStatus = "SERVED";
            //string newTokenStatus = "SERVED";
            string oldStatus = "WAITING";

            int tokenCount = Convert.ToInt16(rxCount);

            int oldTokenCount = tokenCount - 1;
            try
            {
                sqlCon1.Open();
                /*this query updated token value where queue name is met true else it discard data
                 * this is helpful for multiple service, but creates problem with single srvice
                 * so if condition is applied to use seperate queries for both single and multiple services
                 * this was noticed while testing on 06-01-2019
                 */
//                sqlQuery = @"declare @opID int , @queueName varchar(50)
//                            Select @opID = [testSQL].[dbo].[OperationsTable].[OpID], 
//                                    @queueName = [testSQL].[dbo].[OperationsTable].[Queue Name]  
//                            From [testSQL].[dbo].[OperationsTable] "+
//                            "Where ([testSQL].[dbo].[OperationsTable].[Display ID] = '"+rxDI+"'  "+
//                                "AND [testSQL].[dbo].[OperationsTable].[Keypad ID] = '"+rxRI+"' ) "+
//                            "update [testSQL].[dbo].[TokenTable] "+ 
//                            "set [testSQL].[dbo].[TokenTable].[Display ID] = '"+rxDI+"' ,"+
//                            "[testSQL].[dbo].[TokenTable].[Keypad ID] = '"+rxRI+"', "+
//                            "[testSQL].[dbo].[TokenTable].[OpID] = @opID, "+
//                            "[testSQL].[dbo].[TokenTable].[updateDate] = GetDate(),"+
//                            "[testSQL].[dbo].[TokenTable].[Token Status] = ('"+tokenStatus+"')"+ 
//                            "WHERE [testSQL].[dbo].[TokenTable].[Token Status] = ('"+oldStatus+"') "+
//                                    "AND [testSQL].[dbo].[TokenTable].[Queue Name] = @queueName "+ 
//                                    "AND [testSQL].[dbo].[TokenTable].[Token Num] = '"+tokenCount+"' ";
                if (serviceType)
                {
                    sqlQuery = @"declare @opID int , @queueName varchar(50)
                            Select @opID = [testSQL].[dbo].[OperationsTable].[OpID], 
                                    @queueName = [testSQL].[dbo].[OperationsTable].[Queue Name]  
                            From [testSQL].[dbo].[OperationsTable] " +
                            "Where ([testSQL].[dbo].[OperationsTable].[Display ID] = '" + rxDI + "'  " +
                                "AND [testSQL].[dbo].[OperationsTable].[Keypad ID] = '" + rxRI + "' ) " +
                            "update [testSQL].[dbo].[TokenTable] " +
                            "set [testSQL].[dbo].[TokenTable].[Display ID] = '" + rxDI + "' ," +
                            "[testSQL].[dbo].[TokenTable].[Keypad ID] = '" + rxRI + "', " +
                            "[testSQL].[dbo].[TokenTable].[OpID] = @opID, " +
                            "[testSQL].[dbo].[TokenTable].[updateDate] = GetDate()," +
                            "[testSQL].[dbo].[TokenTable].[Token Status] = ('" + tokenStatus + "')" +
                            "WHERE [testSQL].[dbo].[TokenTable].[Token Status] = ('" + oldStatus + "') " +
                                    "AND [testSQL].[dbo].[TokenTable].[Queue Name] = @queueName " +
                                    "AND [testSQL].[dbo].[TokenTable].[Token Num] = '" + tokenCount + "' ";
                }
                else
                {
                    sqlQuery = @"declare @opID int , @queueName varchar(50)
                            Select @opID = [testSQL].[dbo].[OperationsTable].[OpID]  
                            From [testSQL].[dbo].[OperationsTable] " +
                            "Where ([testSQL].[dbo].[OperationsTable].[Display ID] = '" + rxDI + "'  " +
                                "AND [testSQL].[dbo].[OperationsTable].[Keypad ID] = '" + rxRI + "' ) " +
                            "update [testSQL].[dbo].[TokenTable] " +
                            "set [testSQL].[dbo].[TokenTable].[Display ID] = '" + rxDI + "' ," +
                            "[testSQL].[dbo].[TokenTable].[Keypad ID] = '" + rxRI + "', " +
                            "[testSQL].[dbo].[TokenTable].[OpID] = @opID, " +
                            "[testSQL].[dbo].[TokenTable].[updateDate] = GetDate()," +
                            "[testSQL].[dbo].[TokenTable].[Token Status] = ('" + tokenStatus + "')" +
                            "WHERE [testSQL].[dbo].[TokenTable].[Token Status] = ('" + oldStatus + "') " +
                                    "AND [testSQL].[dbo].[TokenTable].[Token Num] = '" + tokenCount + "' ";
                }
                adapter.UpdateCommand = new SqlCommand(sqlQuery, sqlCon1);
                ResultSQL = adapter.UpdateCommand.ExecuteReader();
                // MessageBox.Show("Result: " + ResultSQL.RecordsAffected.ToString());
                sqlCon1.Close();
            }
            catch (Exception excep)
            {
                sqlCon1.Close();
                logError(excep);
            }
            //try
            //{
            //    if (sqlCon1.State == ConnectionState.Closed)
            //        sqlCon1.Open();
            //    sqlQuery = "update TokenTable Set  [Token Status] = '" + newTokenStatus + "', updateDate = GetDate() WHERE (createDate >= DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))) AND [Token Status] = '" + tokenStatus + "' AND [Token Num] = '" + oldTokenCount + "' AND [Service ID] = '" + rxPrefix + "' ";
            //    adapter.UpdateCommand = new SqlCommand(sqlQuery, sqlCon1);
            //    ResultSQL = adapter.UpdateCommand.ExecuteReader();
            //  //  MessageBox.Show("Result: "+ResultSQL.RecordsAffected.ToString());
            //}
            //catch (Exception e)
            //{
            //    sqlCon1.Close();
            //    logError(e);
            //}
            sqlCon1.Close();

            //MessageBox.Show("Update token table " );

        }
        /*
         * get last served token values for different available services
         */
        void getLastTokenValues()
        {

        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            string temp_token, tempText; ;
            string serviceSel = cbChooseService.SelectedItem.ToString();
            string serviceId = null;
            string strToken = null;
            int ticketStart = 0, ticketEnd = 0;
            for (int i = 0; i < uniqueServices.Count; i++)
            {
                // Get Service id and ticket start and ticket end


                if (serviceSel == uniqueServices[i].ToString())
                {
                    serviceId = uniqueServices[i].ToString();
                    ticketStart = Convert.ToInt16(uniqueTicketStart[i].ToString());
                    ticketEnd = Convert.ToInt16(uniqueTicketEnd[i].ToString());
                    temp_token = tokenCount[i].ToString();
                    int temp_len = temp_token.Length;// get number of digits in count value 
                    if (temp_len < 3)
                    {
                        strToken = tokenDigitAdjust(tokenCount[i], temp_len, uniquePrefix[i].ToString()); // return count along with prefix and adjusted digits of token number
                        putTokenInTable(strToken, uniquePrefix[i].ToString(),uniqueServices[i].ToString());
                    }
                    else
                    {
                        strToken = uniquePrefix[i].ToString() + tokenCount[i].ToString();
                        putTokenInTable(tokenCount[i].ToString(), uniquePrefix[i].ToString(), uniqueServices[i].ToString());
                    }

                    //MessageBox.Show("Token " + strToken); test to show token number in alert box
                    tempText = "Thank You for choosing Services\nYour token number is " + strToken;
                    tempText += " Your Token Status is Waiting ";
                    GenerateTokenSuccMessage.Text = tempText;
                    Ticket_Design tdObj = new Ticket_Design();
                    tdObj.setOperationName(serviceSel);
                    tdObj.setTokenValue(strToken);
                    tdObj.print();
                }
            }
        }
        /* Sets operation name on ticket
         * calls printer to print token receipt
         * Updates display with thanks message and token generated
         * @param1: token string
         * @param2: operation name
         * 
         */
        private void PrintToken(string tokStr, string operaName)
        {
            string tempText = null;
            GenerateTokenSuccMessage.BackColor = Color.Green;

            tempText = "Thank You for choosing Services\nYour token number is " + tokStr;
            tempText += " Your Token Status is Waiting ";
            GenerateTokenSuccMessage.Text = tempText;
            GenerateTokenSuccMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFF");
            GenerateTokenSuccMessage.BackColor = System.Drawing.ColorTranslator.FromHtml("#43A047");

            Ticket_Design tdObj = new Ticket_Design();
            tdObj.setOperationName(operaName);
            tdObj.setTokenValue(tokStr);
            //tdObj.print();
        }
        public void logError(Exception except)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory.ToString();
            filePath += "LogError.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Message :" + except.Message + "\n" + Environment.NewLine + "StackTrace :" + except.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }

        private void createServiceButton(int x, int y, String btnText, String btnName)
        {
            Button btn = new Button();
            serviceButtonGroup.Controls.Add(btn);
            btn.Location = new Point(x, y);
            btn.Text = btnText;
            btn.Width = 150;
            btn.Height = 50;
            btn.Name = btnName;
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.UseVisualStyleBackColor = true;
            btn.Padding = new System.Windows.Forms.Padding(12);
            btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(btn);
            serviceButtonGroup.SendToBack();
            btn.Click += new EventHandler(btnGenrateTicket_Click);


        }
        // get list of items from table like list of 
        private List<string> getTokenNumber(string prefix, string colName)
        {
            List<string> temp = new List<string>();
            try
            {

                for (int i = 0; i < lastRowID; i++)
                {
                    temp.Add(dtTicketService.Rows[i][prefix].ToString() + dtTicketService.Rows[i][colName].ToString());
                }

            }
            catch (Exception except)
            {
                logError(except);
            }
            return temp.Distinct().ToList();// get unique name of services offered.
            // return temp;// temperory use a normal list instead of distinct list.
        }
        private void setValues(List<string> tokenNumStart, List<string> tokenNumEnd)
        {
            var numAlpha = new Regex("(?<Alpha>[a-zA-Z]*)(?<Numeric>[0-9]*)");
            for (int i = 0; i < tokenNumStart.Count; i++)
            {
                var match = numAlpha.Match(tokenNumStart[i].ToString());

                var alpha = match.Groups["Alpha"].Value;
                uniquePrefix.Add(alpha.ToString());
                var num = match.Groups["Numeric"].Value;
                uniqueTicketStart.Add(num.ToString());
                var endResult = numAlpha.Match(tokenNumEnd[i].ToString());
                var numEnd = endResult.Groups["Numeric"].Value;
                uniqueTicketEnd.Add(numEnd.ToString());
                //MessageBox.Show("SetValues: " + uniquePrefix[i]);
                //var alpha = match.Groups["Alpha"].Value;
                //var num = match.Groups["Numeric"].Value;
                //MessageBox.Show("string: " + alpha.ToString() + " nums: " + num.ToString()+ " \n numEnd = "+numEnd.ToString());
            }

        }

        private void userMainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            System.Windows.Forms.Application.ExitThread(); 
        }

        

    } // class ends here

} // namespace ends here
