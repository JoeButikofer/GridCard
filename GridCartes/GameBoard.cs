using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        //Network things
        private string opponentAddress;
        private TcpClient tcpClient;
        private TcpListener tcpListener;
        private Form waitingForm;
        private bool isServer;

        public GameBoard(Player p)
        {
            this.isServer = true;

            baseConstructor(p);

            waitingForm = new WaitingScreen();
            waitingForm.Show();
            tcpListener = new TcpListener(IPAddress.Loopback, 8013);
            tcpListener.Start();
            Task task = ReadAsync();
            waitingForm.Show();
            this.Text = "GridCards - SERVER";
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
            if(selectedCard!=null)
            {
                int width = (int)(tableLayoutPanel1.Size.Width / 4);
                int height = (int)(tableLayoutPanel1.Size.Height / 4);


                int resteX = e.X % width;
                int resteY = e.Y % height;

                int x = (e.X - resteX) / width;
                int y = (e.Y - resteY) / height;


                tabCase[x, y].placeCard(selectedCard, 1);

                if (x != 0)
                {
                    tabCase[x - 1, y].fight(tabCase[x, y].Card, Direction.LEFT, 1);
                }
                else if (x != 3)
                {
                    tabCase[x + 1, y].fight(tabCase[x, y].Card, Direction.RIGHT, 1);
                }
                if (y != 0)
                {
                    tabCase[x, y - 1].fight(tabCase[x, y].Card, Direction.UP, 1);
                }
                else if (y != 3)
                {
                    tabCase[x, y + 1].fight(tabCase[x, y].Card, Direction.DOWN, 1);
                }



                /*Console.WriteLine(width);
                Console.WriteLine(height);*/


                //p.BackColor = Color.Red;

                //Image img = (Image)(new Bitmap(tabCase[x, y].draw(), new Size(width - 4, height - 4)));


               //p.BackgroundImage = img;

                tableLayoutPanel1.Controls.Add(tabCase[x, y], x, y);



                currentDeck.removeCard(selectedCard);
                fillHandCards();
                selectedCard = null;
            }

            this.
          

        }


        private void GameBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

    }
}
