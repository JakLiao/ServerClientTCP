using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerTCP
{
    public partial class MainForm : Form
    {
        /// <summary>选择发送消息的所有用户</summary>
        private List<Socket> chooseSocket = new List<Socket>();
        /// <summary>用户列表</summary>
        private List<Socket> listSocket = new List<Socket>();
        private IPAddress initIP;
        private int initPort;
        private Socket serverSocket;
        private Socket clientSocket;
        /// <summary>接收的消息</summary>
        private static byte[] message = new byte[1024];   

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitNetWork()
        {
            IPEndPoint localEP = new IPEndPoint(initIP, initPort);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(localEP);
            L_Information.Text = "Listening...";
            serverSocket.Listen(10);
            L_Information.Text = listSocket.Count + " Connect success.";
            Control.CheckForIllegalCrossThreadCalls = false;//线程安全
            new Thread(new ThreadStart(ListeningClientConnect)) { 
                IsBackground = true
            }.Start();//创建一个线程在后台监听客户端连接请求
        }
        /// <summary>接收客户端连接</summary>
        private void ListeningClientConnect()
        {
            while (true)
            {
                clientSocket = serverSocket.Accept();
                listSocket.Add(clientSocket);
                L_ClientList.Items.Add(Convert.ToString(clientSocket.RemoteEndPoint.ToString()));
                L_Information.Text = listSocket.Count + " Connect success.";
                object text = R_ReceiveMessage.Text;
                R_ReceiveMessage.Text = string.Concat(new object[] { text, listSocket.Count, " Connected from ", clientSocket.RemoteEndPoint.ToString(), " ", DateTime.Now.ToShortTimeString(), "\n" });
                R_ReceiveMessage.SelectionStart = R_ReceiveMessage.TextLength;//让垂直滚动条一直位于底部
                clientSocket.Send(Encoding.UTF8.GetBytes("Hello,I am server....\n"));
                new Thread(new ParameterizedThreadStart(ReceiveMessage)) {
                    IsBackground = true 
                }.Start(clientSocket);//将数据传到线程中
            }
        }
        /// <summary>【发送】按钮的Click事件</summary>
        private void B_SendMessage_Click(object sender, EventArgs e)
        {
            chooseSocket.Clear();
            if (listSocket.Count > 0)
            {
                for (int i = 0; i < L_ClientList.Items.Count; i++)
                {
                    if (L_ClientList.GetSelected(i))
                    {
                        chooseSocket.Add(listSocket[i]);
                    }
                }
                SendMessage();
            }
            else
            {
                MessageBox.Show("No client to connect...", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// 处理接收的客户端数据
        /// </summary>
        /// <param name="clientSocket">客户端信息</param>
        private void ReceiveMessage(object clientSocket)
        {
            Socket item = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    int count = item.Receive(message);
                    R_ReceiveMessage.Text = R_ReceiveMessage.Text + Convert.ToString(item.RemoteEndPoint.ToString());
                    R_ReceiveMessage.Text = R_ReceiveMessage.Text + "  ";
                    R_ReceiveMessage.Text = R_ReceiveMessage.Text + Encoding.UTF8.GetString(message, 0, count);
                    R_ReceiveMessage.Text = R_ReceiveMessage.Text + "\n";
                    R_ReceiveMessage.SelectionStart = R_ReceiveMessage.TextLength;//让垂直滚动条一直位于底部
                    R_ReceiveMessage.Focus();
                }
                catch (Exception)
                {
                    R_ReceiveMessage.Text = R_ReceiveMessage.Text + item.RemoteEndPoint.ToString();
                    R_ReceiveMessage.Text = R_ReceiveMessage.Text + " out of connected...\n";
                    R_ReceiveMessage.SelectionStart = R_ReceiveMessage.TextLength;//让垂直滚动条一直位于底部
                    listSocket.Remove(item);
                    L_ClientList.Items.Remove(Convert.ToString(item.RemoteEndPoint.ToString()));
                    L_Information.Text = listSocket.Count + " Connect success.";
                    item.Shutdown(SocketShutdown.Both);
                    item.Close();
                    return;
                }
            }
        }
        /// <summary>
        /// 发送信息给客户端
        /// </summary>
        private void SendMessage()
        {
            foreach (Socket socket in chooseSocket)
            {
                try
                {
                    string s = Convert.ToString(socket.LocalEndPoint.ToString()) + " " + R_SendMessage.Text.ToString() + "  ";
                    socket.Send(Encoding.UTF8.GetBytes(s));
                    s = string.Empty;
                }
                catch (Exception)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
            }
        }
        /// <summary>关闭窗口时触发的事件</summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        /// <summary>加载窗口时触发的事件</summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            initIP = IPAddress.Parse(T_IPAddress.Text.ToString().Trim());
            initPort = Convert.ToInt32(T_Port.Text.ToString().Trim());
            InitNetWork();
        }
    }
}
