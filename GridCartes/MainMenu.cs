using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridCartes
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Ferme tout le programme
            System.Windows.Forms.Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            (new DeckChoice()).Show();
            this.Hide();
        }

        private void btnDeck_Click(object sender, EventArgs e)
        {
            (new DeckManagement()).Show();
            this.Hide();
        }



    }
}
