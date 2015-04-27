using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace GridCartes
{
    public partial class DeckChoice : Form
    {
        private Player player;
        private DatabaseHelper db;
        private IPAddress serverAddress;

        public DeckChoice(string name, IPAddress _serverAddress)
        {
            InitializeComponent();
            player = new Player(name);
            db = DatabaseHelper.Instance;
            serverAddress = _serverAddress;

            initListBox();
        }

        private void initListBox()
        {
            string sql = "select Nom from Decks where ID_Joueurs = '" + player.Id + "' and Nom !='AVAILABLE' ;";
            SQLiteDataReader reader = db.execCommandeReader(sql);

            while (reader.Read())
            {
                listBoxDeckChoice.Items.Add("" + reader["Nom"]);
            }

        }
        private void DeckChoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Ferme tout le programme
            System.Windows.Forms.Application.Exit();
        }

        private void listBoxDeckChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDeckChoice.SelectedItem != null)
            {
                Deck deck = new Deck(player.Id, listBoxDeckChoice.SelectedItem.ToString());
                player.CurrentDeck = deck;
                connectToServer();
            }
        }

        private void connectToServer()
        {
           // try
            //{
                //TODO changer adresse 
                //TcpClient tcpClient = new TcpClient(IPAddress.Loopback.ToString(), 8012);
                TcpClient tcpClient = new TcpClient(serverAddress.ToString(), 8012);
                Stream stream = tcpClient.GetStream();

                ASCIIEncoding encode = new ASCIIEncoding();

                //TODO voir pour la limite de byte peut être, pour l'instant à 100
                byte[] byteReceived = new byte[100];
                int k = stream.Read(byteReceived, 0, 100);

                //Read the message
                String responseFromServer = "";
                for (int i = 0; i < k; i++)
                    responseFromServer += Convert.ToChar(byteReceived[i]);
                Console.WriteLine(responseFromServer);

                //Close all the things
                stream.Close();
                tcpClient.Close();
                IPAddress ipAddress = null;
                //There are 3 possible reponse from the server :
                // - an IP address, it means that this will be the client
                // - "SERVER", it means that this will be the server
                // - other, an invalid response
                if (IPAddress.TryParse(responseFromServer, out ipAddress))
                {
                    (new GameBoard(player, responseFromServer)).Show();
                    this.Hide();
                }
                else if (responseFromServer == "SERVER")
                {
                    (new GameBoard(player)).Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid response from server");
                }
           /* }
            catch (SocketException e)
            {
                MessageBox.Show("Connexion au serveur impossible, vérifier votre connexion internet et réessayer", "Erreur réseau");
            }*/
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            (new MainMenu(player.Pseudo)).Show();
            this.Hide();
        }

    }
}
