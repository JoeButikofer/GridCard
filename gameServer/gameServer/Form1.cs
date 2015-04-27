using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gameServer
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener;
        private bool started;
        private Queue<String> listWaitingClient;

        public Form1()
        {
            InitializeComponent();
            this.btn_Stop.Enabled = false;
            this.started = false;
            //FIFO
            this.listWaitingClient = new Queue<String>();
            tcpListener = new TcpListener(IPAddress.Parse("157.26.111.104"), 8012);
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            changeState();
            tcpListener.Start();
            Task task = HandleConnectionsAsync(tcpListener);
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            changeState();
            tcpListener.Stop();
        }

        private void changeState()
        {
            started = !started;
            this.btn_Stop.Enabled = !this.btn_Stop.Enabled;
            this.btn_Start.Enabled = !this.btn_Start.Enabled;
        }

        async Task HandleConnectionsAsync(TcpListener listener)
        {
            while (started)
            {
                Console.Write("Waiting for async connection...");
                Task<TcpClient> acceptClient = listener.AcceptTcpClientAsync();
                TcpClient tcpClient = await acceptClient;
                sendOpponentAddress(tcpClient);
                Console.WriteLine("OK");
                tcpClient.Close();
            }
        }

        private void sendOpponentAddress(TcpClient tcpClient)
        {
            Stream stream = tcpClient.GetStream();

            ASCIIEncoding encode = new ASCIIEncoding();
            String address = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();

            String message = "";
            //If nobody is available for a match, we put the client in the waiting list
            if(listWaitingClient.Count <= 0)
            {
                listWaitingClient.Enqueue(address);
                //and we say that he is the server
                message = "SERVER";
            }
            //else, we take the first client in the list and we send his address
            else
            {
                message = listWaitingClient.Dequeue();
            }
            byte[] byteMessage = encode.GetBytes(message);
            Console.WriteLine("Send : " + message + "To : " + address);
            stream.Write(byteMessage, 0, byteMessage.Length);
            stream.Close();
        }

    }
}
