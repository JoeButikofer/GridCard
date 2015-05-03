using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridCartes
{
    public partial class MainMenu : Form
    {
        private string namePlayer;
        private IPAddress serverAddress;

        public MainMenu(string name)
        {
            InitializeComponent();
            namePlayer = name;
            if (File.Exists("serverAddress.txt"))
            {
                String text = File.ReadAllText("serverAddress.txt");
                IPAddress ipAddress = null;
                if(IPAddress.TryParse(text, out ipAddress))
                {
                    serverAddress = IPAddress.Parse(text);
                }
                else
                {
                    setDefaultAddress();
                }
               
            }
            else
            {
                setDefaultAddress();
            }
        }

        private void setDefaultAddress()
        {
            serverAddress = IPAddress.Loopback;
            StreamWriter streamFile = File.CreateText("serverAddress.txt");
            streamFile.Write("127.0.0.1");
            streamFile.Close();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Ferme tout le programme
            System.Windows.Forms.Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            (new DeckChoice(namePlayer, serverAddress)).Show();
            this.Hide();
        }

        private void btnDeck_Click(object sender, EventArgs e)
        {
            (new DeckManagement(namePlayer)).Show();
            this.Hide();
        }

        private void btnOption_Click(object sender, EventArgs e)
        {
            InputTextForm textDialog = new InputTextForm(serverAddress.ToString());

           // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (textDialog.ShowDialog(this) == DialogResult.OK)
           {
              // Read the contents of testDialog's TextBox.
              string address = textDialog.getAddress();
              IPAddress ipAddress = null;
              if (IPAddress.TryParse(address, out ipAddress))
              {
                  StreamWriter streamFile = File.CreateText("serverAddress.txt");
                  streamFile.Write(address);
                  serverAddress = IPAddress.Parse(address);
                  streamFile.Close();
              }
              else
              {
                  MessageBox.Show("L'adresse rentré n'est pas correct");
              }
              
           }

            textDialog.Dispose();
        }

    }
}
