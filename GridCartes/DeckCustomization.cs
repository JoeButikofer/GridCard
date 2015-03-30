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
    public partial class DeckCustomization : Form
    {
        private DatabaseHelper db;
        private Player player;

        public DeckCustomization(Player _player)
        {
            InitializeComponent();
            player = _player;
            db = DatabaseHelper.Instance;

            fillListAvailableCards();
            fillCurrentDeck();
        }

        private void fillCurrentDeck()
        {
            throw new NotImplementedException();
        }

        private void fillListAvailableCards()
        {
            throw new NotImplementedException();
        }

        private void DeckCustomization_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Ferme tout le programme
            System.Windows.Forms.Application.Exit();
        }
    }
}
