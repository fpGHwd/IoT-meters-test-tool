using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace MeterForm
{
    /// <summary>
    /// 一个小的类（其实可以用一个字典或者三个列表类似的东西来重写。
    /// </summary>
    class SktMsgDt
    {
        public Socket socket;
        public string message;
        public byte[] data;

        public SktMsgDt(Socket socket, string message, byte[] data)
        {
            this.socket = socket;
            this.message = message;
            this.data = data;
        }
    }


    /// <summary>
    /// 创建serversocket，获取clientsocket，并获得数据datareceived相关的类
    /// </summary>
    class EstablishConnect
    {
        public List<Socket> clientsocketList = new List<Socket>();
        public readonly byte[] datareceived = new byte[1024];
        /*
        public readonly Socket socket;
        public readonly string message;
        */
        public int port = 8885;
        public IPAddress ip = IPAddress.Parse("127.0.0.1");
        public Socket serverSocket;

        public Thread myThread,dataReceivedThread;

        public delegate void ClientChangedEventHandler(List<Socket> clientsocketList);
        public event ClientChangedEventHandler clientChanged;

        public delegate void dataReceivedEventHandler(SktMsgDt cm);
        public event dataReceivedEventHandler dataReceived;

        SktMsgDt cm;

        /// <summary>
        /// EstablishConnect的构造方法。
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public EstablishConnect(IPAddress ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }


        /// <summary>
        /// 打开socket需要端口，IP和三个构造参数；运行在主线程。监听进程。1
        /// 创建socket，更新socketlist，监听并启动clientsock获取进程。2
        /// </summary>
        public void socketstart()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            serverSocket.Bind(new IPEndPoint(ip, port));
            serverSocket.Listen(10);
            Console.WriteLine("启动监听，监听数量10");
            myThread = new Thread(clientsocket);//名字就是指向另一个方法的地址；
            myThread.Start();
        }

        
        /// <summary>
        /// 获取clientsocket，更新clientsocketlist列表，并委托改变Form1的属性（clentsocket的combobox），并产生新的进程MessageReceived来获取信息
        /// </summary>
        public void clientsocket()
        {
            while (true)
            {
                if(serverSocket == null)
                {
                    break;
                }
                if(serverSocket != null)
                {
                    try
                    {
                        Socket ClientSocket = serverSocket.Accept();

                        clientsocketList.Add(ClientSocket);
                        clientChanged(clientsocketList);

                        if (clientChanged != null)
                        {
                            clientChanged(clientsocketList);
                        }
                        dataReceivedThread = new Thread(MessageReceived);//MessageReceived方法需要新接收到的ClientSocket作为参数。系统Socket类实例。
                        dataReceivedThread.Start(ClientSocket);


                    }
                    catch (Exception)
                    {
                        Console.WriteLine("客户端socket获取和建立实例失败。");
                    }
                }
                
            }

        }


        /// <summary>
        /// 利用clientsocket获取信息，创建并更新SktMsgDt的实例（其实就是产生一个SktMsgDt的实例并返回给主控域）
        /// </summary>
        /// <param name="ClientSocket"></param>
        public void MessageReceived(object ClientSocket)
        {
            Socket myClientSocket = (Socket)ClientSocket;
            while (true)
            {
                if(serverSocket == null)
                {
                    break;
                }
                if(ClientSocket == null)
                {
                    break;
                }
                try
                {
                    //通过clientSocket接收数据  
                    int receiveNumber = myClientSocket.Receive(datareceived);
                    //收到空数组表示客户端已断开
                    if (receiveNumber == 0)
                    {
                        myClientSocket.Shutdown(SocketShutdown.Both);
                        clientsocketList.Remove(myClientSocket);
                        if (clientChanged != null)
                        {
                            clientChanged(clientsocketList);
                        }
                        myClientSocket.Close();
                        break;
                    }
                    //
                    if (receiveNumber <= 0) continue;
                    Console.WriteLine("接收客户端{0}消息{1}", myClientSocket.RemoteEndPoint.ToString(), Encoding.ASCII.GetString(datareceived, 0, receiveNumber));
                    //获得data的原始数据
                    byte[] data = new byte[receiveNumber];
                    for (int i = 0 ; i < data.Length ; i++)
                    {
                        data[i] = datareceived[i];
                    }

                    cm = new SktMsgDt(myClientSocket, Encoding.ASCII.GetString(data, 0, receiveNumber), data);
                    if (dataReceived != null)
                    { dataReceived(cm); }
                }
                catch (Exception ex)
                {
                    if (myClientSocket == null) return;
                    Console.WriteLine(ex.Message);
                    //myClientSocket.Shutdown(SocketShutdown.Both);
                    clientsocketList.Remove(myClientSocket);
                    if (clientChanged != null)
                    {
                        clientChanged(clientsocketList);
                    }
                    myClientSocket.Close();
                    break;
                }
            }
        }


        /// <summary>
        /// 先关闭clientsocket，更新clientsocketlist，关闭serversocket，更新serversocketlist（不过并没有serversocketlist）
        /// </summary>
        public void stopServer()
        {
            try
            {

                for (int i = 0 ; i < clientsocketList.Count ; i++)
                {
                    clientsocketList[i].Shutdown(SocketShutdown.Both);
                    //clientsocketList[i].Disconnect(true);
                    //clientsocketList[i].Close();
                }
                clientsocketList.Clear();
                clientChanged(clientsocketList);
                serverSocket.Close();
                serverSocket = null;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
    // 同步调用，回调，异步调用


}

