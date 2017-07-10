using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication3;
using ConcentratorTest.Tools;
using System.Net.Sockets;


namespace MeterForm
{
    
    
    public partial class Form1 : Form
    {
        //更新Form1外观相关的类实例属性的属性
        List<Dictionary<string, string>> cmdlist = new List<Dictionary<string, string>>();
        List<Label> s2clabellist = new List<Label>();
        List<TextBox> s2ctextboxlist = new List<TextBox>();
        List<Label> c2slabellist = new List<Label>();
        List<TextBox> c2stextboxlist = new List<TextBox>();
        delegate void changeFormMessageText(string formmessage);
        delegate void changeClientIPComboBoxCallback(List<Socket> clientsocketlist, ComboBox combobox);
        delegate void addLogRichTextBoxCallback(string s);
        delegate void FormMessageTextBoxCallback(string s);
        string meterID;
        string messageID;


        //声明但为使用构造方法的EstablishConnect类，EstablishConnect的入口
        EstablishConnect connect;


        /// <summary>
        /// 更新Form1窗口里各实例化类的属性，来更新外观
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 更新Form1窗口里各实例化类的属性，来更新外观
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form1_Load(object sender, EventArgs e)
        {
            initData();
            initView();
        }


        /// <summary>
        /// 更新Form1窗口里各实例化类的属性，来更新外观
        /// </summary>
        public void initData()
        {
            cmdlist = Const.CmdList();

            s2clabellist.Add(label5);
            s2clabellist.Add(label6);
            s2clabellist.Add(label7);
            s2clabellist.Add(label8);
            s2clabellist.Add(label9);
            s2clabellist.Add(label10);
            s2clabellist.Add(label11);
            s2clabellist.Add(label12);
            s2clabellist.Add(label13);
            s2clabellist.Add(label14);
            s2clabellist.Add(label15);
            s2clabellist.Add(label16);
            s2clabellist.Add(label17);
            s2clabellist.Add(label18);
            s2clabellist.Add(label19);
            s2clabellist.Add(label20);


            

            s2ctextboxlist.Add(textBox3);
            s2ctextboxlist.Add(textBox4);
            s2ctextboxlist.Add(textBox5);
            s2ctextboxlist.Add(textBox6);
            s2ctextboxlist.Add(textBox7);
            s2ctextboxlist.Add(textBox8);
            s2ctextboxlist.Add(textBox9);
            s2ctextboxlist.Add(textBox10);
            s2ctextboxlist.Add(textBox11);
            s2ctextboxlist.Add(textBox12);
            s2ctextboxlist.Add(textBox13);
            s2ctextboxlist.Add(textBox14);
            s2ctextboxlist.Add(textBox15);
            s2ctextboxlist.Add(textBox16);
            s2ctextboxlist.Add(textBox17);
            s2ctextboxlist.Add(textBox18);
           


           
            
            c2slabellist.Add(label21);
            c2slabellist.Add(label22);
            c2slabellist.Add(label23);
            c2slabellist.Add(label24);
            c2slabellist.Add(label25);
            c2slabellist.Add(label26);
            c2slabellist.Add(label27);
            c2slabellist.Add(label28);
            c2slabellist.Add(label29);
            c2slabellist.Add(label30);
            c2slabellist.Add(label31);
            c2slabellist.Add(label32);
            c2slabellist.Add(label33);
            c2slabellist.Add(label34);
            c2slabellist.Add(label35);
            c2slabellist.Add(label36);
            


           
            
            c2stextboxlist.Add(textBox19);
            c2stextboxlist.Add(textBox20);
            c2stextboxlist.Add(textBox21);
            c2stextboxlist.Add(textBox22);
            c2stextboxlist.Add(textBox23);
            c2stextboxlist.Add(textBox24);
            c2stextboxlist.Add(textBox25);
            c2stextboxlist.Add(textBox26);
            c2stextboxlist.Add(textBox27);
            c2stextboxlist.Add(textBox28);
            c2stextboxlist.Add(textBox29);
            c2stextboxlist.Add(textBox30);
            c2stextboxlist.Add(textBox31);
            c2stextboxlist.Add(textBox32);
            c2stextboxlist.Add(textBox33);
            c2stextboxlist.Add(textBox34);

        }


        /// <summary>
        /// 更新Form1窗口里各实例化类的属性，来更新外观
        /// </summary>
        public void initView()
        {
            for(int i =0; i < cmdlist.Count; i++ )
            {
                comboBox1.Items.Add(cmdlist[i]["cmdname"]);
            }
            IPHostEntry host;

            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                Console.WriteLine("ip.AddressFamily == " + ip.AddressFamily);
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    this.IP.Items.Add(ip);
                }
            }
        }

        /*
        /// <summary>
        /// 获取IP
        /// </summary>
        private void GetLocalIp()
        {
            
            
        }
        */


        /// <summary>
        /// 更新Form1窗口里各实例化类的属性，来更新外观
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void initLableandTextBox(object sender, EventArgs e)
        {
            Dictionary<string, string> datadic = cmdlist[this.comboBox1.SelectedIndex];

            string[] s2ctextitemlist = datadic["cmds2cformat"].Split('|');
            string[] s2ccmditemlist = datadic["cmds2c"].Split('|');

            string[] c2stextitemlist = datadic["cmdc2sformat"].Split('|');
            string[] c2scmditemlist = datadic["cmdc2s"].Split('|');

            
            switch(this.comboBox1.SelectedIndex)
            {
                case 0:
                    s2ccmditemlist[5] = meterID;
                    s2ccmditemlist[8] = meterID;
                    s2ccmditemlist[6] = messageID;
                    c2scmditemlist[5] = meterID;
                    c2scmditemlist[9] = meterID;
                    c2scmditemlist[6] = messageID;
                    break;
                case 1:
                    s2ccmditemlist[5] = meterID;
                    s2ccmditemlist[9] = meterID;
                    s2ccmditemlist[6] = messageID;
                    c2scmditemlist[5] = meterID;
                    c2scmditemlist[8] = meterID;
                    c2scmditemlist[6] = messageID;
                    break;
                case 2:
                    s2ccmditemlist[5] = meterID;
                    s2ccmditemlist[9] = meterID;
                    s2ccmditemlist[6] = messageID;
                    s2ccmditemlist[10] = DateTime.Now.ToString("yyyyMMdd");
                    s2ccmditemlist[11] = DateTime.Now.ToString("HHmmss");
                    c2scmditemlist[5] = meterID;
                    c2scmditemlist[8] = meterID;
                    c2scmditemlist[6] = messageID;
                    break;
                case 3:
                    s2ccmditemlist[5] = meterID;
                    s2ccmditemlist[9] = meterID;
                    s2ccmditemlist[6] = messageID;
                    c2scmditemlist[5] = meterID;
                    c2scmditemlist[8] = meterID;
                    c2scmditemlist[6] = messageID;
                    break;
                case 4:
                    s2ccmditemlist[5] = meterID;
                    s2ccmditemlist[8] = meterID;
                    s2ccmditemlist[6] = messageID;
                    c2scmditemlist[5] = meterID;
                    c2scmditemlist[9] = meterID;
                    c2scmditemlist[6] = messageID;
                    break;
                case 5:
                    s2ccmditemlist[5] = meterID;
                    s2ccmditemlist[9] = meterID;
                    s2ccmditemlist[6] = messageID;
                    c2scmditemlist[5] = meterID;
                    c2scmditemlist[8] = meterID;
                    c2scmditemlist[6] = messageID;
                    break;
                case 6:
                    s2ccmditemlist[5] = meterID;
                    s2ccmditemlist[8] = meterID;
                    s2ccmditemlist[6] = messageID;
                    c2scmditemlist[5] = meterID;
                    c2scmditemlist[9] = meterID;
                    c2scmditemlist[6] = messageID;
                    break;
                case 7:
                    s2ccmditemlist[5] = meterID;
                    s2ccmditemlist[8] = meterID;
                    s2ccmditemlist[6] = messageID;
                    c2scmditemlist[5] = meterID;
                    c2scmditemlist[9] = meterID;
                    c2scmditemlist[6] = messageID;
                    break;
                case 8:
                    s2ccmditemlist[5] = meterID;
                    s2ccmditemlist[9] = meterID;
                    s2ccmditemlist[6] = messageID;
                    c2scmditemlist[5] = meterID;
                    c2scmditemlist[8] = meterID;
                    c2scmditemlist[6] = messageID;
                    break;
            }

            for (int i = 0; i < s2clabellist.Count; i++)
            {
                if (i < s2ctextitemlist.Length)
                {
                    this.s2clabellist[i].Visible = true;
                    s2ctextboxlist[i].Visible = true;
                    s2clabellist[i].Text = s2ctextitemlist[i];
                    s2ctextboxlist[i].Text = s2ccmditemlist[i];


                }
                else
                {
                    s2clabellist[i].Visible = false;
                    s2clabellist[i].Text = string.Empty;
                    s2ctextboxlist[i].Visible = false;
                    s2ctextboxlist[i].Text = string.Empty;

                }
                
            }
            if (comboBox1.SelectedIndex == 2)
            {
                string date = DateTime.Now.ToString("yyyyMMdd");
                string time = DateTime.Now.ToString("HHmmss");
                s2ctextboxlist[10].Text = date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6, 2);
                s2ctextboxlist[11].Text = time.Substring(0, 2) + ":" + time.Substring(2, 2) + ":" + time.Substring(4, 2);
            }
            else
            {

            }


                for (int i = 0; i < c2slabellist.Count; i++)
            {

                if (i < c2stextitemlist.Length)
                {
                    c2slabellist[i].Visible = true;
                    c2stextboxlist[i].Visible = true;
                    c2slabellist[i].Text = c2stextitemlist[i];
                    c2stextboxlist[i].Text = c2scmditemlist[i];
                }
                else
                {
                    c2slabellist[i].Visible = false;
                    c2slabellist[i].Text = string.Empty;
                    c2stextboxlist[i].Visible = false;
                    c2stextboxlist[i].Text = string.Empty;
                }
            }

        }


        /// <summary>
        /// 开始服务器的委托方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startServerbtn_Click(object sender, EventArgs e)
        {
            if(IP.Text == string.Empty)
            {
                MessageBox.Show("请输入IP");
                return;
            }
            else
            {
                try
                {
                    if (ServerStartBtn.Text == "开始")
                    {
                        FormMessageTextBox.AppendText(Environment.NewLine + "\r\n准备打开服务器");
                        Connect();
                        FormMessageTextBox.AppendText(Environment.NewLine + "打开服务器");
                        ServerStartBtn.Text = "停止";
                    }
                    else
                    {
                        FormMessageTextBox.AppendText(Environment.NewLine + "准备停止服务器");
                        if(connect.myThread.IsAlive)
                        {
                            Console.WriteLine("slidgsdsjl ");
                        }
                        /*                       
                        connect.myThread.Abort();
                        connect.myThread.Join();
                        connect.dataReceivedThread.Abort();
                        connect.dataReceivedThread.Join();
                        */
                        connect.stopServer();///异常：空的引用异常。
                        FormMessageTextBox.AppendText(Environment.NewLine + "停止服务器");
                        ServerStartBtn.Text = "开始";
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("出现异常：" + ex.StackTrace);
                    Console.WriteLine("出现异常：" + ex.Message);
                    FormMessageTextBox.AppendText("\r\n出现异常：" + ex.Message + "未能打开服务器，并关闭所有连接。");
                    /*
                    connect.myThread.Abort();
                    connect.myThread.Join();
                    connect.dataReceivedThread.Abort();
                    connect.dataReceivedThread.Join();
                    */
                    connect.stopServer();
                }
                
            }
            
        }


        /// <summary>
        /// 主进程连接入口 
        /// 
        /// </summary>
        public void Connect()
        {

            string ipstring = IP.Text;
            string port = Port.Text;

            try
            {
                connect = new EstablishConnect(IPAddress.Parse(ipstring), Convert.ToInt16(port));//connect是一个具有构造方法的EstablishConnect的实例
                connect.socketstart();
                FormMessageTextBox.AppendText("\r\n启动监听");
                connect.clientChanged += connect_clientChanged;
                connect.dataReceived += connect_dataReceived;
            }
            catch (Exception ex)
            {
                Console.WriteLine("出现异常：" + ex.StackTrace);
                Console.WriteLine("出现异常：" + ex.Message);
                FormMessageTextBox.AppendText("\r\n出现异常：" + ex.Message);
            }
            
            
        }



        /// <summary>
        /// 改变FormmessageTextBox实例的属性的委托方法
        /// </summary>
        /// <param name="formmessage"></param>
        public void changeFormMessage(string formmessage)
        {
            this.FormMessageTextBox.AppendText(formmessage);
        }


        /// <summary>
        /// 接收到数据的委托方法，包括更新Form1各实例的属性，来改变外观，以及返回报文的
        /// </summary>
        /// <param name="cm"></param>
        private void connect_dataReceived(SktMsgDt cm)
        {


            //用MESSAGE类的未拆分DATA属性来添加日志内容
            string logdata = Tools.byteToHexStr(cm.data);
            string sourcestr = ((System.Net.IPEndPoint)cm.socket.RemoteEndPoint).Address.ToString() + ":" + ((System.Net.IPEndPoint)cm.socket.RemoteEndPoint).Port.ToString();
            string str = "\r\n\r\n" + "<<<<" + sourcestr + " " + DateTime.Now.ToString() + "\r\n" + logdata;
            if (textBox50.InvokeRequired)
            {

                addLogRichTextBoxCallback callback = new addLogRichTextBoxCallback(addLog);
                Invoke(callback, new object[] { str });

            }
            else
            {
                addLog(str);
            }


            //用MESSAGE类的IP和PORT属性改变客户端IP的combox选项外观
            //string clientstr = ((System.Net.IPEndPoint)cm.socket.RemoteEndPoint).Address.ToString() + ":" + ((IPEndPoint)cm.socket.RemoteEndPoint).Port.ToString();
            for (int i = 0 ; i < ClientIPCombobox.Items.Count ; i++)
            {
                if (ClientIPCombobox.Items[i].ToString() == sourcestr)
                {
                    OpenMainFormControl(delegate ()
                    {
                        ClientIPCombobox.SelectedIndex = i;
                    });
                }
            }


            //拆分MESSAGE类的DATA
            //DATA
            //68 
            //21 00 
            //30 04 
            //01
            //00
            //23 06 15 10 12 12 34
            //00 00 00 00 00 00 02
            //07 00
            //23 06 15 10 12 12 34
            //A5 CO
            //16
            byte[] revdata = Encoding.ASCII.GetBytes(cm.message);
            //string revstr = Tools.byteToHexStr(revdata).Replace(" ","");//和下面一样
            string revstr1 = logdata.Replace(" ", "");//和上面一样
            string crccode1 = revstr1.Substring(revstr1.Length - 6, 4);//校验码
            string crccode2 = crccode1.Substring(2, 2) + crccode1.Substring(0, 2);
            string cmdcode = revstr1.Substring(6, 4);//命令码
            meterID = revstr1.Substring(14, 14);//表ID
            messageID = revstr1.Substring(28, 14);//报文ID


            //用revdata来获得校验码和形成校验码的前面数据，并对照
            //byte[] revcrccodebyte = new byte[2];
            //revcrccodebyte[0] = revdata[revdata.Length - 3];
            //revcrccodebyte[1] = revdata[revdata.Length - 2];
            //string revcrccodestr = Tools.byteToHexStr(revcrccodebyte).Replace(" ", "");
            string calcrccode = Check.getCrcStr(revstr1.Replace(" ", ""));
            string calcrccode1 = calcrccode.Substring(2, 2) + calcrccode.Substring(0, 2);
            if (crccode1 == calcrccode)
            {

                if (FormMessageTextBox.InvokeRequired)
                {
                    string formstr = Environment.NewLine + "\n原校验码为： " + crccode2 + "\r\n计算校验码为： " + calcrccode1 + "\r\n校验码相同\r\n";
                    changeFormMessageText callback = new changeFormMessageText(changeFormMessage);
                    Invoke(callback, new object[] { formstr });
                }
                Console.WriteLine("\r\n校验码校验通过");
            }
            else
            {

                if (FormMessageTextBox.InvokeRequired)
                {
                    string formstr = "\r\n原校验码为： " + crccode2 + "\r\n计算校验码为： " + calcrccode1 + "\r\n校验码不相同\r\n";
                    changeFormMessageText callback = new changeFormMessageText(changeFormMessage);
                    Invoke(callback, new object[] { formstr });
                }
                Console.WriteLine("\r\n校验码校验没通过");
            }


            //改变MessageToAccept的外观和MessageToSend的外观
            for (int j = 0 ; j < cmdlist.Count ; j++)
            {
                if (cmdlist[j]["cmdc2s"].Split('|')[2] == cmdcode)//找到对应的命令码
                {
                    OpenMainFormControl(delegate ()
                    {
                        comboBox1.SelectedIndex = j;
                        /*
                        if (cmdcode == "3002" || cmdcode == "3003" || cmdcode == "3004" || cmdcode == "3043" || cmdcode == "3062")
                        {
                            s2ctextboxlist[5].Text = meterID;
                            s2ctextboxlist[6].Text = messageID;
                            s2ctextboxlist[9].Text = meterID;
                            joinStr();
                            sendData();
                        }
                        */
                    });
                }
            }


            string messagelength, datalength, identifingcode, responsecode;
            string readmetertime, readmeterdate, meterphase, tapstate;
            string occurdate, occurtime, exceptiontype;
            string askforresponsecode;
            messagelength = revstr1.Substring(4, 2) + revstr1.Substring(2, 2);
            askforresponsecode = revstr1.Substring(12, 2);
            datalength = revstr1.Substring(42, 4);
            responsecode = revstr1.Substring(46, 4);
            string crccode = crccode1.Substring(2, 2) + crccode1.Substring(0, 2);


            try
            {
                switch (cmdcode)
                {
                    case "3001":
                        
                        
                        //identifingcode = revstr1.Substring(64, 4);
                        OpenMainFormControl(delegate ()
                        {
                            c2stextboxlist[1].Text = messagelength;
                            c2stextboxlist[5].Text = meterID;
                            c2stextboxlist[6].Text = messageID;
                            //c2stextboxlist[7].Text = datalength;
                            c2stextboxlist[8].Text = responsecode;
                            c2stextboxlist[9].Text = meterID;
                            c2stextboxlist[10].Text = crccode;
                            
                            s2ctextboxlist[5].Text = meterID;
                            s2ctextboxlist[6].Text = messageID;
                            s2ctextboxlist[8].Text = meterID;
                            
                            if (askforresponsecode == "00")
                            {
                                joinStr();
                                Console.WriteLine("\n已响应物联网表");
                                sendData();
                            }
                            else if (askforresponsecode == "01")
                            {

                            }
                            else
                            {
                                Console.WriteLine("响应码有误");
                            }

                        });
                        break;
                    case "3002":
                        OpenMainFormControl(delegate ()
                        {
                            c2stextboxlist[1].Text = messagelength;
                            c2stextboxlist[5].Text = meterID;
                            c2stextboxlist[6].Text = messageID;
                            //c2stextboxlist[7].Text = datalength;
                            c2stextboxlist[8].Text = meterID;
                            c2stextboxlist[9].Text = crccode;
                            
                            s2ctextboxlist[5].Text = meterID;
                            s2ctextboxlist[6].Text = messageID;
                            s2ctextboxlist[9].Text = meterID;
                            
                            if (askforresponsecode == "00")
                            {
                                joinStr();
                                Console.WriteLine("\n已响应物联网表");
                                sendData();
                            }
                            else if (askforresponsecode == "01")
                            {


                            }
                            else
                            {
                                Console.WriteLine("响应码有误");
                            }
                        });
                        break;
                    case "3003":
                        OpenMainFormControl(delegate ()
                        {
                            c2stextboxlist[1].Text = messagelength;
                            c2stextboxlist[5].Text = meterID;
                            c2stextboxlist[6].Text = messageID;
                            //c2stextboxlist[7].Text = datalength;
                            c2stextboxlist[8].Text = meterID;
                            c2stextboxlist[9].Text = crccode;
                            
                            s2ctextboxlist[5].Text = meterID;
                            s2ctextboxlist[6].Text = messageID;
                            s2ctextboxlist[9].Text = meterID;
                            
                            if (askforresponsecode == "00")
                            {
                                joinStr();
                                Console.WriteLine("\n已响应物联网表");
                                sendData();
                            }
                            else if (askforresponsecode == "01")
                            {

                            }
                            else
                            {
                                Console.WriteLine("响应码有误");
                            }
                        });
                        break;
                    case "3004":
                        OpenMainFormControl(delegate ()
                        {
                            c2stextboxlist[1].Text = messagelength;
                            c2stextboxlist[5].Text = meterID;
                            c2stextboxlist[6].Text = messageID;
                            //c2stextboxlist[7].Text = datalength;
                            c2stextboxlist[8].Text = meterID;
                            c2stextboxlist[9].Text = crccode;
                           
                            s2ctextboxlist[5].Text = meterID;
                            s2ctextboxlist[6].Text = messageID;
                            s2ctextboxlist[9].Text = meterID;
                            
                            if (askforresponsecode == "00")
                            {
                                joinStr();
                                Console.WriteLine("\n已响应物联网表");
                                sendData();
                            }
                            else if (askforresponsecode == "01")
                            {

                            }
                            else
                            {
                                Console.WriteLine("响应码有误");
                            }
                        });
                        break;
                    case "3042":
                        readmeterdate = revstr1.Substring(64, 4) + "-" + revstr1.Substring(68, 2) + "-" + revstr1.Substring(70, 2);
                        readmetertime = revstr1.Substring(72, 2)+ ":" + revstr1.Substring(74, 2) + ":" + revstr1.Substring(76, 2); ;
                        string meterphase1 = revstr1.Substring(78, 12);
                        //68 00 15 30 43 01 01 01 12 40 00 00 00 00 00 52 06 51 12 23 20 00 15 01 12 40 00 00 00 00 20 15 10 31 16 29 00 
                        //2C 01 73 00 00 00 01 
                        //46 E5 
                        //16
                        int meterphase2_1 = Convert.ToInt32(Tools.GetHexData(meterphase1).Substring(0, 8), 16);
                        int meterphase2_2 = Convert.ToInt32(Tools.GetHexData(meterphase1).Substring(8, 4), 16);
                        string meterphase3 = Convert.ToString(meterphase2_1) + '.' + Convert.ToString(meterphase2_2);
                        meterphase = meterphase3;
                        tapstate = revstr1.Substring(90, 2);
                        OpenMainFormControl(delegate ()
                        {
                            c2stextboxlist[1].Text = messagelength;
                            c2stextboxlist[5].Text = meterID;
                            c2stextboxlist[6].Text = messageID;
                            //c2stextboxlist[7].Text = datalength;
                            c2stextboxlist[8].Text = responsecode;
                            c2stextboxlist[9].Text = meterID;
                            c2stextboxlist[10].Text = readmeterdate;
                            c2stextboxlist[11].Text = readmetertime;
                            c2stextboxlist[12].Text = meterphase;
                            c2stextboxlist[13].Text = tapstate;
                            c2stextboxlist[14].Text = crccode;
                            
                            s2ctextboxlist[5].Text = meterID;
                            s2ctextboxlist[6].Text = messageID;
                            s2ctextboxlist[8].Text = meterID;
                            
                            if (askforresponsecode == "00")
                            {
                                joinStr();
                                Console.WriteLine("\n已响应物联网表");
                                sendData();
                            }
                            else if (askforresponsecode == "01")
                            {

                            }
                            else
                            {
                                Console.WriteLine("响应码有误");
                            }
                        });
                        break;
                    case "3043":
                        readmeterdate = revstr1.Substring(60, 4) + "-" + revstr1.Substring(64, 2) + "-" + revstr1.Substring(66, 2);
                        readmetertime = revstr1.Substring(68, 2) + ":" + revstr1.Substring(70, 2) + ":" + revstr1.Substring(72, 2);
                        meterphase1 = revstr1.Substring(74, 12);
                        meterphase2_1 = Convert.ToInt32(Tools.GetHexData(meterphase1).Substring(0, 8), 16);
                        meterphase2_2 = Convert.ToInt32(Tools.GetHexData(meterphase1).Substring(8, 4), 16);
                        meterphase3 = Convert.ToString(meterphase2_1) + '.' + Convert.ToString(meterphase2_2);
                        meterphase = meterphase3;
                        tapstate = revstr1.Substring(86, 2);
                        identifingcode = revstr1.Substring(88, 4);
                        OpenMainFormControl(delegate ()
                        {
                            c2stextboxlist[1].Text = messagelength;
                            c2stextboxlist[5].Text = meterID;
                            c2stextboxlist[6].Text = messageID;
                            //c2stextboxlist[7].Text = datalength;
                            c2stextboxlist[8].Text = meterID;
                            c2stextboxlist[9].Text = readmeterdate;
                            c2stextboxlist[10].Text = readmetertime;
                            c2stextboxlist[11].Text = meterphase;
                            c2stextboxlist[12].Text = tapstate;
                            c2stextboxlist[13].Text = crccode;
                            
                            s2ctextboxlist[5].Text = meterID;
                            s2ctextboxlist[6].Text = messageID;
                            s2ctextboxlist[9].Text = meterID;
                            
                            if (askforresponsecode == "00")
                            {
                                joinStr();
                                Console.WriteLine("\n已响应物联网表");
                                sendData();
                            }
                            else if (askforresponsecode == "01")
                            {

                            }
                            else
                            {
                                Console.WriteLine("响应码有误");
                            }
                        });
                        break;
                    case "3051":
                        OpenMainFormControl(delegate ()
                        {
                            c2stextboxlist[1].Text = messagelength;
                            c2stextboxlist[5].Text = meterID;
                            c2stextboxlist[6].Text = messageID;
                            //c2stextboxlist[7].Text = datalength;
                            c2stextboxlist[8].Text = responsecode;
                            c2stextboxlist[9].Text = meterID;
                            c2stextboxlist[10].Text = crccode;
                            
                            s2ctextboxlist[5].Text = meterID;
                            s2ctextboxlist[6].Text = messageID;
                            s2ctextboxlist[8].Text = meterID;
                            
                            if(askforresponsecode == "00")
                            {
                                joinStr();
                                Console.WriteLine("\n已响应物联网表");
                                sendData();
                            }
                            else if (askforresponsecode == "01")
                            {

                            }
                            else
                            {
                                Console.WriteLine("响应码有误");
                            }
                        });
                        break;
                    case "3052":
                        OpenMainFormControl(delegate ()
                        {
                            c2stextboxlist[1].Text = messagelength;
                            c2stextboxlist[5].Text = meterID;
                            c2stextboxlist[6].Text = messageID;
                            //c2stextboxlist[7].Text = datalength;
                            c2stextboxlist[8].Text = responsecode;
                            c2stextboxlist[9].Text = meterID;
                            c2stextboxlist[10].Text = crccode;
                            
                            s2ctextboxlist[5].Text = meterID;
                            s2ctextboxlist[6].Text = messageID;
                            s2ctextboxlist[8].Text = meterID;
                            
                            if (askforresponsecode == "00")
                            {
                                joinStr();
                                Console.WriteLine("\n已响应物联网表");
                                sendData();
                            }
                            else if (askforresponsecode == "01")
                            {

                            }
                            else
                            {
                                Console.WriteLine("响应码有误");
                            }
                        });
                        break;
                    case "3062":
                        occurdate = revstr1.Substring(60, 8);
                        occurtime = revstr1.Substring(68, 6);
                        exceptiontype = revstr1.Substring(74, 4);
                        //identifingcode = revstr1.Substring(78, 4);
                        OpenMainFormControl(delegate ()
                        {
                            c2stextboxlist[1].Text = messagelength;
                            c2stextboxlist[5].Text = meterID;
                            c2stextboxlist[6].Text = messageID;
                            //c2stextboxlist[7].Text = datalength;
                            c2stextboxlist[8].Text = meterID;
                            c2stextboxlist[9].Text = occurdate;
                            c2stextboxlist[10].Text = occurtime;
                            c2stextboxlist[11].Text = exceptiontype;
                            c2stextboxlist[12].Text = crccode;
                            
                            s2ctextboxlist[5].Text = meterID;
                            s2ctextboxlist[6].Text = messageID;
                            s2ctextboxlist[9].Text = meterID;
                            
                            if (askforresponsecode == "00")
                            {
                                joinStr();
                                sendData();
                                Console.WriteLine("\n已响应物联网表");
                            }
                            else if (askforresponsecode == "01")
                            {

                            }
                            else
                            {
                                Console.WriteLine("响应码有误");
                            }
                        });
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("输入数据错误产生了异常，一般是手动测试时的数据长度有误");
                MessageBox.Show("数据异常" + ex);
            }
        }


        /// <summary>
        /// 获取新的客户端后改变Form内类的实例的属性的委托方法
        /// </summary>
        /// <param name="clientsocketList"></param>
        private void connect_clientChanged(List<Socket> clientsocketList) 
        {
            if (ClientIPCombobox.InvokeRequired)
            {
                changeClientIPComboBoxCallback callback = new changeClientIPComboBoxCallback(setComboBoxValues);
                Invoke(callback, new object[] { connect.clientsocketList, ClientIPCombobox });
            }
            else
            {
                setComboBoxValues(clientsocketList, ClientIPCombobox);
            }
        }


        /// <summary>
        /// 委托就必须要有委托方法
        /// </summary>
        /// <param name="clientsocketList"></param>
        /// <param name="combobox"></param>
        private void setComboBoxValues(List<Socket> clientsocketList, ComboBox combobox)
        {
            combobox.Items.Clear();
            for (int i = 0; i < clientsocketList.Count; i++)
            {
                combobox.Items.Add(((System.Net.IPEndPoint)clientsocketList[i].RemoteEndPoint).Address.ToString() + ":" + ((IPEndPoint)clientsocketList[i].RemoteEndPoint).Port.ToString());
           
            }
            combobox.Text = "";
            combobox.SelectedIndex = clientsocketList.Count - 1;
        }


        /// <summary>
        /// 生成字符串的委托事件的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void combinestr(object sender, EventArgs e)
        {
            if(this.comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("请选择命令");
            }
            else
            {
                
            }


            if (comboBox1.SelectedIndex == 2)
            {
                string date = DateTime.Now.ToString("yyyyMMdd");
                string time = DateTime.Now.ToString("HHmmss");
                s2ctextboxlist[10].Text = date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6, 2);
                s2ctextboxlist[11].Text = time.Substring(0, 2) + ":" + time.Substring(2, 2) + ":" + time.Substring(4, 2);
            }
            else
            {

            }
            /*
            if (comboBox1.SelectedIndex == 1)
            {
                s2ccmditemlist[10] = DateTime.Now.ToString("yyyyMMdd");
                s2ccmditemlist[11] = DateTime.Now.ToString("HHmmss");
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                s2ccmditemlist[9] = DateTime.Now.ToString("yyyyMMdd");
                s2ccmditemlist[10] = DateTime.Now.ToString("HHmmss");
            }
            else
            {
                ;
            }
            */

            List<String> rawtextliststr = new List<String>();
            /*
            if (comboBox1.SelectedIndex == 2)
            {
                s2ctextboxlist[10].Text = DateTime.Now.ToString("yyyyMMdd");
                s2ctextboxlist[11].Text = DateTime.Now.ToString("HHmmss");
            }
            else
            {
                ;
            }
            */
            for (int i = 0; i < this.s2ctextboxlist.Count; i++)
            {
                if (s2ctextboxlist[i].Text == string.Empty) break;

                if (comboBox1.SelectedIndex == 2)
                {
                    if (i == 10)
                    {
                        rawtextliststr.Add(DateTime.Now.ToString("yyyyMMdd"));
                    }
                    else if(i == 11)
                    {
                        rawtextliststr.Add(DateTime.Now.ToString("HHmmss"));
                    }
                    else
                    {
                        rawtextliststr.Add(s2ctextboxlist[i].Text);
                    }

                }
                else
                {
                    rawtextliststr.Add(s2ctextboxlist[i].Text); 
                }
                
                //Console.WriteLine("Rawtext{0} in list-string formed.", i);
                
            }
            //Console.WriteLine("Raw text in list-string formed.");


            string datafield = "";
            int datafieldnum = 0;
            
            for (int j = 0; j < rawtextliststr.Count; j++)
            {
                if (j > 7 && j < rawtextliststr.Count - 2)
                {
                    datafield += rawtextliststr[j];
                    datafieldnum++;
                }
            }

            rawtextliststr[7] = (datafield.Length / 2).ToString("X").PadLeft(4, '0');
            s2ctextboxlist[7].Text = rawtextliststr[7];
            rawtextliststr[7] = rawtextliststr[7].Substring(2, 2) + rawtextliststr[7].Substring(0, 2);

            int datalength = 0;
     
            for (int i = 0; i < rawtextliststr.Count; i++)
            {

                datalength += rawtextliststr[i].Length / 2;
                Console.WriteLine("Datalength upto rawtextliststr{0}:{1}", i, rawtextliststr[i]);
       
            }


            rawtextliststr[1] = (datalength).ToString("X").PadLeft(4, '0');//整条数据长度
            s2ctextboxlist[1].Text = rawtextliststr[1];
            rawtextliststr[1] = rawtextliststr[1].Substring(2, 2) + rawtextliststr[1].Substring(0, 2);//低字节在前高字节在后


            string hexdatastr = "";//不带分隔符的hexdatastr
            for (int i = 0; i < rawtextliststr.Count; i++)
            {
                hexdatastr += rawtextliststr[i];
            }



            string crcstr = ConcentratorTest.Tools.Check.getCrcStr(hexdatastr);
            s2ctextboxlist[rawtextliststr.Count - 2].Text = crcstr.Substring(2, 2) + crcstr.Substring(0, 2);
            rawtextliststr[rawtextliststr.Count - 2] = crcstr;//crc16校验字节，低字节在前高字节在后
            //rawtextliststr[rawtextliststr.Count - 2] = crcstr;

            byte[] lastdata = new byte[datalength];
            byte[] head = Tools.strToToHexByte(rawtextliststr[0]);
            head.CopyTo(lastdata, 0);
            int index = head.Length;
            for (int i = 1; i < rawtextliststr.Count; i++)
            {
                byte[] data = Tools.strToToHexByte(rawtextliststr[i]);
                data.CopyTo(lastdata, index);
                index += data.Length;
            }

            textBox50.Text = Tools.byteToHexStr(lastdata);

        }


        /// <summary>
        /// 发送按钮事件的委托事件方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendData(object sender, EventArgs e)
        {
            if (ClientIPCombobox.SelectedIndex == -1)
            {
                ClientIPCombobox.Text = string.Empty;
                MessageBox.Show("请重新选择客户端");
                return;
            }
            Socket socket = connect.clientsocketList[ClientIPCombobox.SelectedIndex];




            try
            {
                byte[] data = Tools.strToToHexByte(textBox50.Text);

                //添加日志
                string sourcestr = ((System.Net.IPEndPoint)socket.RemoteEndPoint).Address.ToString() + ":" + ((System.Net.IPEndPoint)socket.RemoteEndPoint).Port.ToString();
                string strsendlog = "\r\n\n" + ">>>>" + sourcestr + " " + DateTime.Now.ToString() + "\r\n" + textBox50.Text;
                this.FormMessageTextBox.AppendText(strsendlog);
                //addLog(strsendlog);
                //发送数据
                socket.Send(data);
                FormMessageTextBox.AppendText("\r\n发送成功\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("出现异常：" + ex.StackTrace);
                Console.WriteLine("出现异常：" + ex.Message);
                FormMessageTextBox.AppendText("\r\n出现异常：" + ex.Message);
            }


        }


        /// <summary>
        /// 添加日志的委托事件方法
        /// </summary>
        /// <param name="str"></param>
        private void addLog(string str)
        {
            this.FormMessageTextBox.AppendText(str);
        }

        /*
        private void addFormMessage (string str)
        {
            this.FormMessageTextBox.AppendText(str);
        }
        */


        /// <summary>
        /// 在线程中操作窗体的控件的方法
        /// </summary>
        /// <param name="action"></param>
        private void OpenMainFormControl(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action); //返回主线程（创建控件的线程）
            }
            else
            {
                action();
            }
        }


        /// <summary>
        /// 改变FormMessageTextBox实例的属性的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.FormMessageTextBox.Text = String.Empty;
        }


        /// <summary>
        /// 接收信息后生成响应报文的方法，并改变Form1的各类实例的属性
        /// </summary>
        //主动生成要发送给物联网表的字符串
        private void joinStr()
        {

            //形成列表表示的数据
            List<string> strlist = new List<string>();
            strlist.Add(textBox3.Text);
            if (strlist[0] == string.Empty) return;
            for (int i = 1; i < s2ctextboxlist.Count; i++)
            {
                if (s2ctextboxlist[i].Text == string.Empty) break;
                strlist.Add(s2ctextboxlist[i].Text.Replace(":","").Replace("-",""));
            }

            
            //形成字符串表示的数据域长度
            string datafield = "";
            int datafieldnum = 0;
            for (int i = 0; i < strlist.Count; i++)
            {
                if (i > 7 && i < strlist.Count - 2)
                {
                    datafield += strlist[i];
                    datafieldnum++;
                }
            }
            strlist[7] = (datafield.Length / 2).ToString("X").PadLeft(4, '0');//数据域长度
            s2ctextboxlist[7].Text = strlist[7];
            strlist[7] = strlist[7].Substring(2, 2) + strlist[7].Substring(0, 2);


            //形成字符串表示的整条数据长度
            int datalength = 0;
            for (int i = 0; i < strlist.Count; i++)
            {
                datalength += strlist[i].Length / 2;
            }
            strlist[1] = (datalength).ToString("X").PadLeft(4, '0');//整条数据长度
            s2ctextboxlist[1].Text = strlist[1];
            strlist[1] = strlist[1].Substring(2, 2) + strlist[1].Substring(0, 2);//低字节在前高字节在后
            

            //由列表表示的数据形成字符串表示的数据
            string hexdatastr = "";//不带分隔符的hexdatastr
            for (int i = 0; i < strlist.Count; i++)
            {
                hexdatastr += strlist[i];
            }

            //用字符串表示的16进制byte，来获取字符串表示的16进制byte来表示校验码。在字符串列表表示的报文中更新校验码元素。
            string crcstr = Check.getCrcStr(hexdatastr);
            string crcstr2 = crcstr.Substring(2, 2) + crcstr.Substring(0, 2);
            //s2ctextboxlist[strlist.Count - 2].Text = crcstr;
            s2ctextboxlist[strlist.Count - 2].Text = crcstr2;
            //strlist[strlist.Count - 2] = crcstr.Substring(2, 2) + crcstr.Substring(0, 2);//crc16校验字节，低字节在前高字节在后
            //strlist[strlist.Count - 2] = crcstr2;
            strlist[strlist.Count - 2] = crcstr;

            /*
            if (strlist[2] == "2011")
                strlist[strlist.Count - 3] = strlist[strlist.Count - 3].Substring(2, 2) + strlist[strlist.Count - 3].Substring(0, 2);
                */

            byte[] lastdata = new byte[datalength];
            byte[] head = Tools.strToToHexByte(strlist[0]);
            head.CopyTo(lastdata, 0);
            int index = head.Length;
            for (int i = 1; i < strlist.Count; i++)
            {
                byte[] data = Tools.strToToHexByte(strlist[i]);
                data.CopyTo(lastdata, index);
                index += data.Length;
            }

            textBox50.Text = Tools.byteToHexStr(lastdata);
            
        }


        /// <summary>
        /// 接收报文后的响应报文的发送方法，并改变Form1的某些类的实例的外观
        /// </summary>
        private void sendData()
        {
            if (ClientIPCombobox.SelectedIndex == -1)
            {
                ClientIPCombobox.Text = string.Empty;
                MessageBox.Show("请重新选择客户端");
                return;
            }
            Socket socket = connect.clientsocketList[ClientIPCombobox.SelectedIndex];
            try
            {
                byte[] data = Tools.strToToHexByte(textBox50.Text);

                //添加日志
                string sourcestr = ((System.Net.IPEndPoint)socket.RemoteEndPoint).Address.ToString() + ":" + ((System.Net.IPEndPoint)socket.RemoteEndPoint).Port.ToString();
                string strsendlog =  "\r\n\r\n" + ">>>>" + sourcestr + " " + DateTime.Now.ToString() + "\r\n" + textBox50.Text;
                addLog(strsendlog);
                //发送数据
                socket.Send(data);
                FormMessageTextBox.AppendText("\r\n响应信息发送成功");
            }
            catch (Exception)
            {
                Console.WriteLine("sendData出现异常");
            }
        }


        /*
        delegate void FormMessageTextChanged(object sender, EventArgs e);
        private void FormMessageTextChangedScroll(object sender, EventArgs e)
        {
            FormMessageTextBox.SelectionStart = FormMessageTextBox.Text.Length;
            FormMessageTextBox.ScrollToCaret();
        }
        */


        /// <summary>
        /// 关闭Form1的事件发生后的委托的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Form1_Closed(object sender, EventArgs e) {
            Console.Write("");
            try
            {
                connect.stopServer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Environment.Exit(0);
        }


    }
    
   
}
