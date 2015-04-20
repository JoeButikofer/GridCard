﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridCartes
{
    enum Direction {UP, DOWN, LEFT, RIGHT };

    public partial class GameBoard : Form
    {
        private Player player;
        private Deck currentDeck;
        private Card selectedCard;
        private Case[,] tabCase;
        private bool myTurn;

        //Network things
        private string opponentAddress;
        private TcpClient tcpClient;
        private TcpListener tcpListener;
        private Form waitingForm;
        private bool isServer;

        public GameBoard(Player p)
        {
            baseConstructor(p);

            this.isServer = true;
            //The server plays fisrt
            changeTurn(true);

            waitingForm = new WaitingScreen();
            waitingForm.Show();
            tcpListener = new TcpListener(IPAddress.Loopback, 8013);
            tcpListener.Start();
            Task task = ReadAsync();
            waitingForm.Show();
            this.Text = "GridCards - SERVER";
        }

        public GameBoard(Player p, string host)
        {
            baseConstructor(p);

            this.isServer = false;
            //The client plays second
            changeTurn(false);

            this.opponentAddress = host;
            this.tcpClient = new TcpClient(host, 8013);

            Task task = ReadAsync();
            this.Text = "GridCards - CLIENT";
        }

        private void baseConstructor(Player p)
        {
            InitializeComponent();
            tabCase = new Case[4,4];
            player = p;
            currentDeck = player.CurrentDeck;

            int width = (int)(tableLayoutPanel1.Size.Width / 4);
            int height = (int)(tableLayoutPanel1.Size.Height / 4);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tabCase[i, j] = new Case(i,j,width-4,height-4);
                }
            }

            fillHandCards();
        }

        //When we are the server, wait for the other player (client)
        private async Task HandleConnectionsAsync()
        {
            Console.WriteLine("Waiting for async connection...");
            Task<TcpClient> acceptClient = this.tcpListener.AcceptTcpClientAsync();
            this.tcpClient = await acceptClient;
            this.opponentAddress = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            Console.WriteLine(this.opponentAddress + " has just connected");
            waitingForm.Hide();
            this.Show();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.tcpClient == null)
            {
                this.Visible = false;
            }
        }

        private async Task ReadAsync()
        {
            if (isServer)
            {
                Console.WriteLine("Waiting for client...");
                Task connectClient = HandleConnectionsAsync();
                await connectClient;
                Console.WriteLine("Client connected...");
            }

            NetworkStream ns = this.tcpClient.GetStream();
            byte[] buffer = new byte[1024];

            while (true)
            {
                Console.WriteLine("Before reading");
                int bytesRead = await ns.ReadAsync(buffer, 0, buffer.Length);
                Console.WriteLine("After reading");
                if (bytesRead <= 0)
                    break;
                String message = Encoding.UTF8.GetString(buffer);
                parseMessage(message);
                //listBox_Messages.Items.Add(this.opponentAddress + " : " + message);
                Console.WriteLine("Receive : " + message);
            }
        }


        private void fillHandCards()
        {
            listViewHandCards.Clear();
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(50, 80);
            foreach (Card card in currentDeck.ListCard)
            {
                imageList.Images.Add(card.Name, card.Image);
                var listViewItem = listViewHandCards.Items.Add(card.Name);
                listViewItem.ImageKey = card.Name;
            }
            listViewHandCards.LargeImageList = imageList;
        }

        private void listViewHandCards_ItemActivate(object sender, EventArgs e)
        {
            int i = listViewHandCards.SelectedIndices[0];
            string s = listViewHandCards.Items[i].Text;

            selectedCard = currentDeck.ListCard.ElementAt(i);

        }

        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            if(selectedCard!=null && myTurn)
            {
                int width = (int)(tableLayoutPanel1.Size.Width / 4);
                int height = (int)(tableLayoutPanel1.Size.Height / 4);


                int resteX = e.X % width;
                int resteY = e.Y % height;

                int x = (e.X - resteX) / width;
                int y = (e.Y - resteY) / height;

                changeTurn(false);
                placeCard(x, y, 1, selectedCard);
                
                sendMessage("CARD/" + x + "/" + y + "/" + selectedCard.Id);

                currentDeck.removeCard(selectedCard);
                fillHandCards();
                selectedCard = null;
            }

        }

        private void placeCard(int x, int y, int player, Card card)
        {

            tabCase[x, y].placeCard(card, player);

            if (x != 0)
            {
                tabCase[x - 1, y].fight(tabCase[x, y].Card, Direction.LEFT, player);
            }
            else
            {
                tabCase[3, y].fight(tabCase[x, y].Card, Direction.LEFT, player);
            }

            if (x != 3)
            {
                tabCase[x + 1, y].fight(tabCase[x, y].Card, Direction.RIGHT, player);
            }
            else
            {
                tabCase[0, y].fight(tabCase[x, y].Card, Direction.RIGHT, player);
            }
            if (y != 0)
            {
                tabCase[x, y - 1].fight(tabCase[x, y].Card, Direction.UP, player);
            }
            else
            {
                tabCase[x, 3].fight(tabCase[x, y].Card, Direction.UP, player);
            }
            if (y != 3)
            {
                tabCase[x, y + 1].fight(tabCase[x, y].Card, Direction.DOWN, player);
            }
            else
            {
                tabCase[x, 0].fight(tabCase[x, y].Card, Direction.DOWN, player);
            }

            tableLayoutPanel1.Controls.Add(tabCase[x, y], x, y);

            updateScore();
        }

        private void updateScore()
        {
            int myScore = 0;
            int hisScore = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(tabCase[i, j].Player == 1)
                    {
                        myScore++;
                    }
                    else if(tabCase[i, j].Player == 2)
                    {
                        hisScore++;
                    }
                }
            }

            lblMyScore.Text = "My score : " + myScore;
            lblHisScore.Text = "His score : " + hisScore;
        }

        private void changeTurn(bool isMyTurn)
        {
            myTurn = isMyTurn;
            if (isMyTurn)
            {
                lblTurn.Text = "My turn";
                lblTurn.ForeColor = Color.Blue;
            }
            else
            {
                lblTurn.Text = "His turn";
                lblTurn.ForeColor = Color.Red;
            }
        }

        //Send message to the opponent
        //Format :
        // ACTION/CaseX/CaseY/parameters
        // ACTION : CARD (play a card) or POWER (use a power)
        // CaseX, CaseY : x and y coordinates in grid
        // parameter : card id for action CARD or power id for action POWER
        private void sendMessage(String message)
        {
            if (message.Length > 0)
            {
                Stream stream = tcpClient.GetStream();

                byte[] byteMessage = Encoding.UTF8.GetBytes(message);
                Console.WriteLine("Send : " + message);
                stream.Write(byteMessage, 0, byteMessage.Length);
            }
        }

        //Parse the incoming message and execute the corresponding action (see the function above for format of message)
        private void parseMessage(String message)
        {
            String[] elements = message.Split('/');
            String action = elements[0];
            int caseX = int.Parse(elements[1]);
            int caseY = int.Parse(elements[2]);
            int parameter = int.Parse(elements[3]);
            
            if(action == "CARD")
            {
                Card card = new Card(parameter);
                placeCard(caseX, caseY, 2, card);
                changeTurn(true);
            }
            else if(action == "POWER")
            {
                //TODO
            }
            else
            {
                //TODO envoi de message, tchat ?
            }
        }

        private void closeConnections()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }

        private void GameBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Finish the application
            closeConnections();
            System.Windows.Forms.Application.Exit();
        }

    }
}
