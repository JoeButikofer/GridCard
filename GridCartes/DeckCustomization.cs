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

namespace GridCartes
{
    public partial class DeckCustomization : Form
    {
        private DatabaseHelper db;
        private Player player;
        private Deck availableCards;
        private Deck currentDeck;


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
            listBoxDeck.Items.Clear();
            currentDeck = player.CurrentDeck;

            foreach (Card card in currentDeck.ListCard)
            {
                listBoxDeck.Items.Add(card);
            }
        }

        private void fillListAvailableCards()
        {
            listBoxCards.Items.Clear();
            availableCards = player.getAvailableCards();
           
            foreach (Card card in availableCards.ListCard)
            {
                listBoxCards.Items.Add(card);
            }
        }

        private void DeckCustomization_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Ferme tout le programme
            System.Windows.Forms.Application.Exit();
        }
    }
}
