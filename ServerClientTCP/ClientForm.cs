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

namespace ServerClientTCP
{
    public partial class ClientForm : Form
    {
        private Socket clientSocket;
        private bool connected = false;
        private IPAddress initIP;
        private int initPort;
        private Thread receiveThread;
        private static byte[] message = new byte[1024];

        public ClientForm()
        {
            InitializeComponent();
        }

        private void InitNetWork()
        {
            IPEndPoint remoteEP = new IPEndPoint(initIP, initPort);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            while (!connected)
            {
                try
                {
                    L_Information.Text = "Connecting...";
                    clientSocket.Connect(remoteEP);
                    L_Information.Text = "Success connected...";
                    connected = true;
                }
                catch (Exception)
                {
                    L_Information.Text = "Try to connect again.";
                }
                Thread.Sleep(1000);
            }
            Control.CheckForIllegalCrossThreadCalls = false;
            receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }
        /// <summary>【发送】按钮的Click事件</summary>
        private void B_SendMessage_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                SendMessage();
            }
            else
            {  
                MessageBox.Show("Has not deteive server to connect...", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>从服务器端接收信息</summary>
        private void ReceiveMessage()
        {
            bool flag = true;
            while (flag)
            {
                try
                {
                    int count = clientSocket.Receive(message);
                    R_ReceiveMessage.Text = R_ReceiveMessage.Text + Encoding.UTF8.GetString(message, 0, count);
                    R_ReceiveMessage.Text = R_ReceiveMessage.Text + "\n";
                    R_ReceiveMessage.SelectionStart = R_ReceiveMessage.TextLength;//让垂直滚动条一直位于底部
                }
                catch (Exception)
                {
                    R_ReceiveMessage.Text = R_ReceiveMessage.Text + "The server is closed.\nTry to connect ...";
                    R_ReceiveMessage.Text = R_ReceiveMessage.Text + "\n";
                    R_ReceiveMessage.SelectionStart = R_ReceiveMessage.TextLength;//让垂直滚动条一直位于底部
                    clientSocket.Shutdown(SocketShutdown.Both);
                    flag = false;
                    connected = false;
                    InitNetWork();
                }
            }
        }
        /// <summary>向服务器端发送信息</summary>
        private void SendMessage()
        {
            try
            {
                string s = R_SendMessage.Text.ToString();
                clientSocket.Send(Encoding.UTF8.GetBytes(s));
            }
            catch (Exception)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
        /// <summary>加载窗口时触发的事件</summary>
        private void ClientForm_Load(object sender, EventArgs e)
        {
            initIP = IPAddress.Parse(T_IPAddress.Text.ToString().Trim());
            initPort = Convert.ToInt32(T_Port.Text.ToString().Trim());
            Control.CheckForIllegalCrossThreadCalls = false;
            new Thread(new ThreadStart(InitNetWork)).Start();
        }
        /// <summary>回车发送消息的事件</summary>
        //private void R_SendMessage_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if ((int)e.KeyChar == 13)
        //    {
        //        if (connected)
        //        {
        //            SendMessage();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Has not deteive server to connect...", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }
        //    }
        //}
    }
}
