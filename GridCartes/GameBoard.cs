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
        private const bool DEBUGMESSAGE = false; //for display tcp message in chat box
        private Player player;
        private Deck currentDeck;
        private Card selectedCard;
        private Case[,] tabCase;
        private bool myTurn;
        private int myScore;
        private int hisScore;

        //Power button management
        private bool isBlockPowerSelected;
        private bool isDestroyPowerSelected;
        private bool isPowerUsed;

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
            tcpListener = new TcpListener(IPAddress.Any, 8013);
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
            randomizeDeck();
            isBlockPowerSelected = false;
            isDestroyPowerSelected = false;
            isPowerUsed = false;
            myScore = 0;
            hisScore = 0;

            //Populates the grid with clickable panels
            int width = (int)(tableLayoutPanel1.Size.Width / 4);
            int height = (int)(tableLayoutPanel1.Size.Height / 4);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    tabCase[i, j] = new Case(i,j,width-4,height-4, caseClick);
                    tableLayoutPanel1.Controls.Add(tabCase[i, j], i, j);
                }
            }
            fillHandCards();
        }

        // Reduces the deck to 10 random cards
        private void randomizeDeck()
        {
            Random randomGen = new Random();
            while(currentDeck.ListCard.Count > 10)
            {
                int rand = randomGen.Next(currentDeck.ListCard.Count);
                currentDeck.ListCard.RemoveAt(rand);
            }
        }
        
        //Method call from one of the panel when clicked
        private void caseClick(object sender, CaseClickEventArgs e)
        {
            if (myTurn)
            {
                int x = e.x;
                int y = e.y;

                if (isBlockPowerSelected && !isPowerUsed)
                {
                    changeTurn(false);
                    isPowerUsed = true;
                    isBlockPowerSelected = false;
                    updatePowerButtons();
                    blockCard(x, y);
                    sendMessage("POWER/" + x + "/" + y + "/" + 1 + "/");
                    checkGameOver();
                }
                else if (isDestroyPowerSelected && !isPowerUsed)
                {
                    if (!tabCase[x, y].isEmpty())
                    {
                        changeTurn(false);
                        isPowerUsed = true;
                        isBlockPowerSelected = false;
                        updatePowerButtons();
                        destroyCard(x, y);
                        sendMessage("POWER/" + x + "/" + y + "/" + 2 + "/");
                        checkGameOver();
                    }
                }
                else if (selectedCard != null)
                {
                    if (!tabCase[x, y].IsBlocked)
                    {
                        changeTurn(false);
                        placeCard(x, y, 1, selectedCard);

                        sendMessage("CARD/" + x + "/" + y + "/" + selectedCard.Id + "/");

                        currentDeck.removeCard(selectedCard);
                        fillHandCards();
                        selectedCard = null;
                        checkGameOver();
                    }
                }
            }
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

            //when we create the server we want to hide this form for display a waiting screen
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
                int bytesRead = await ns.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead <= 0)
                    break;
                String message = Encoding.UTF8.GetString(buffer);
                parseMessage(message);
                Console.WriteLine("Receive : " + message);
            }
        }


        private void fillHandCards()
        {
            listViewHandCards.Clear();
            listViewHandCards.Items.Clear();

            int count = 0;
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(50, 80);
            foreach (Card card in currentDeck.ListCard)
            {
                var listViewItem = listViewHandCards.Items.Add(card.Name);
                listViewItem.ImageKey = ""+count;
                imageList.Images.Add(""+count, card.Image);
                count++;
            }
            listViewHandCards.LargeImageList = imageList;
        }

        private void listViewHandCards_ItemActivate(object sender, EventArgs e)
        {
            int i = listViewHandCards.SelectedIndices[0];

            selectedCard = currentDeck.ListCard.ElementAt(i);

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

            tableLayoutPanel1.Refresh();
            updateScore();
        }

        private void destroyCard(int x, int y)
        {
            tabCase[x, y].destroy();
            tableLayoutPanel1.Refresh();
            updateScore();
        }

        private void blockCard(int x, int y)
        {
            tabCase[x, y].IsBlocked = true;
            tableLayoutPanel1.Refresh();
        }

        private void updateScore()
        {
            myScore = 0;
            hisScore = 0;

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

            lblMyScore.Text = "Mon score : " + myScore;
            lblHisScore.Text = "Son score : " + hisScore;
        }

        private void changeTurn(bool isMyTurn)
        {
            myTurn = isMyTurn;
            if (isMyTurn)
            {
                lblTurn.Text = "Mon tour";
                lblTurn.ForeColor = Color.Blue;
            }
            else
            {
                lblTurn.Text = "Son tour";
                lblTurn.ForeColor = Color.Red;
            }
        }

        //Send message to the opponent
        //Format :
        // For game command : 
        //  ACTION/CaseX/CaseY/parameters/
        //  ACTION : CARD (play a card) or POWER (use a power)
        //  CaseX, CaseY : x and y coordinates in grid
        //  parameter : card id for action CARD or power id for action POWER
        // For chat :
        //  CHAT/content/
        //  CHAT : for indicating it's a chat message
        //  content : content of the message
        // NOTE :We need the last '/' because is used for terminating the message and help to prevent error
        // causing by additionnal characters in the end of the message 
        private void sendMessage(String message)
        {
            if (message.Length > 0)
            {
                try
                {
                    Stream stream = tcpClient.GetStream();

                    byte[] byteMessage = Encoding.UTF8.GetBytes(message);
                    Console.WriteLine("Send : " + message);
                    if (DEBUGMESSAGE == true) listBoxChat.Items.Add("Send : " + message);
                    stream.Write(byteMessage, 0, byteMessage.Length);
                }
                catch(Exception e)
                {
                    closeConnections();
                    MessageBox.Show("La connexion à votre adversaire a été perdu. Retour au menu principal");
                    (new MainMenu(player.Pseudo)).Show();
                    this.Hide();
                }
            }
        }

        //Parse the incoming message and execute the corresponding action (see the function above for format of message)
        private void parseMessage(String message)
        {
            String[] elements = message.Split('/');
            String action = elements[0];

            if (DEBUGMESSAGE == true)
            {
                listBoxChat.Items.Add("Received : " + message);
            }

            if (action == "CHAT")
            {
                String content = elements[1];
                listBoxChat.Items.Add("Lui : " + content);
            }
            else
            {
                int caseX = int.Parse(elements[1]);
                int caseY = int.Parse(elements[2]);
                int parameter = int.Parse(elements[3]);


                if (action == "CARD")
                {
                    Card card = new Card(parameter);
                    placeCard(caseX, caseY, 2, card);
                }
                else if (action == "POWER")
                {
                    switch (parameter)
                    {
                        case 1:
                            blockCard(caseX, caseY);
                            break;
                        case 2:
                            destroyCard(caseX, caseY);
                            break;
                    }
                }
                changeTurn(true);
                checkGameOver();
            }
        }

        private void checkGameOver()
        {
            bool isOver = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tabCase[i, j].isEmpty() && !tabCase[i, j].IsBlocked)
                    {
                        isOver = false;
                    }
                }
            }

            if (isOver)
            {
                gameOver();
            }
        }

        private void gameOver()
        {
            closeConnections();

            if(myScore > hisScore)
            {
                //Victory !!!
                (new VictoryScreen(player)).Show();
                this.Hide();
            }
            else if( myScore < hisScore)
            {
                //Defeat...
                (new DefeatScreen(player)).Show();
                this.Hide();
            }
            else
            {
                //Draw
                (new DrawScreen(player)).Show();
                this.Hide();
            }
            
        }


        private void closeConnections()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
            if (tcpListener != null)
            {
                tcpListener.Stop();
            }
        }

        private void GameBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Finish the application
            closeConnections();
            System.Windows.Forms.Application.Exit();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (textBoxChat.Text.Length > 0)
            {
                listBoxChat.Items.Add("Moi : " + textBoxChat.Text);
                sendMessage("CHAT/" + textBoxChat.Text + "/");
                textBoxChat.Clear();
            }
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            isDestroyPowerSelected = false;
            isBlockPowerSelected = !isBlockPowerSelected;
            updatePowerButtons();
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            isBlockPowerSelected = false;
            isDestroyPowerSelected = !isDestroyPowerSelected;
            updatePowerButtons();
        }

        private void updatePowerButtons()
        {
            if (!isPowerUsed)
            {
                if (isDestroyPowerSelected)
                {
                    btnDestroy.Text = "Sélectionnez une carte...";
                }
                else
                {
                    btnDestroy.Text = "Détruire une carte";
                }

                if (isBlockPowerSelected)
                {
                    btnBlock.Text = "Sélectionnez une case...";
                }
                else
                {
                    btnBlock.Text = "Bloque une case";
                }
            }
            else
            {
                btnBlock.Text = "Plus de pouvoir disponible";
                btnDestroy.Text = "Plus de pouvoir disponible";
                btnBlock.Enabled = false;
                btnDestroy.Enabled = false;
            }
        }
    }
}
