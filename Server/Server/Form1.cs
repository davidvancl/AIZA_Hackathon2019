using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;

namespace Server
{
    public partial class Form1 : Form
    {
        private TcpClient clinetSocket;
        private TcpListener serverSockets;
        private Thread vlakno;
        public Form1()
        {
            InitializeComponent();
            this.myConsole.Text += "Server has been started !\r\n";
            vlakno = new Thread(looping);
            vlakno.IsBackground = true;
            vlakno.Start();
        }

        private void looping()
        {
            serverSockets = new TcpListener(6666);
            int requestCount = 0;
            clinetSocket = default(TcpClient);
            serverSockets.Start();
            clinetSocket = serverSockets.AcceptTcpClient();
            MethodInvoker connectionDetect = delegate
            {
                this.myConsole.Text += "Connection has been detected !\r\n";
            };
            this.Invoke(connectionDetect);
            requestCount = 0;
            while ((true))
            {              
                try
                {
                    requestCount++;
                    NetworkStream networkStream = clinetSocket.GetStream();
                    byte[] bytesFrom = new byte[(int)clinetSocket.ReceiveBufferSize];
                    networkStream.Read(bytesFrom, 0, (int)clinetSocket.ReceiveBufferSize);
                    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    MethodInvoker incommingMessage = delegate
                    {
                        this.myConsole.Text += dataFromClient + "\r\n";
                    };
                    this.Invoke(incommingMessage);
                    string serverResponse = "I recieved data: " + dataFromClient + "\r\n";
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                }
                catch (Exception ex)
                {
                    try
                    {
                        MethodInvoker connectionLost = delegate
                        {
                            this.myConsole.Text += "Connection has been lost !\r\n";
                        };
                        this.Invoke(connectionLost);
                    }
                    catch {

                    }
                    break;
                }               
            }
            clinetSocket.Close();
            serverSockets.Stop();
            clinetSocket = null;
            serverSockets = null;
            looping();
        }

        private void listenButton_Click(object sender, EventArgs e)
        {
            this.myConsole.Text = "";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Close();
            }
            Application.Exit();
        }
    }
}
