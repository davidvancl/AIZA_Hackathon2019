using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Form1 : Form
    {
        private TcpClient clientSocket = new TcpClient();
        public Form1()
        {
            InitializeComponent();
            try {
                myConsole.Text += "Client: Application has been started !\r\n";
                clientSocket.Connect("192.168.2.10", 6666);
                myConsole.Text += "Client: Server connected !\r\n";
            } catch {

            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                NetworkStream serverStream = clientSocket.GetStream();
                byte[] outStream = Encoding.ASCII.GetBytes(inputData.Text + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                byte[] inStream = new byte[(int)clientSocket.ReceiveBufferSize];
                serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
                string returndata = Encoding.ASCII.GetString(inStream);
                myConsole.Text += "Server: " + returndata + "\r\n";
            }
            catch {
                myConsole.Text += "Somebody is still connected to server: \r\n";
            }
        }
    }
}
