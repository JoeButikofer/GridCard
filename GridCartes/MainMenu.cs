using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridCartes
{
    public partial class MainMenu : Form
    {
        private string namePlayer;

        public MainMenu(string name)
        {
            InitializeComponent();
            namePlayer = name;
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Ferme tout le programme
            System.Windows.Forms.Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            (new DeckChoice(namePlayer)).Show();
            this.Hide();
        }

        private void btnDeck_Click(object sender, EventArgs e)
        {
            (new DeckManagement(namePlayer)).Show();
            this.Hide();
        }

    }
}
