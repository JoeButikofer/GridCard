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
            listViewDeck.Items.Clear();
            currentDeck = player.CurrentDeck;

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(50, 80);
            foreach (Card card in currentDeck.ListCard)
            {
                imageList.Images.Add(card.Name, card.Image);
                var listViewItem = listViewDeck.Items.Add(card.Name);
                listViewItem.ImageKey = card.Name;

            }
            listViewDeck.LargeImageList = imageList;
        }

        private void fillListAvailableCards()
        {
            listViewCards.Items.Clear();
            availableCards = player.getAvailableCards();

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(50,80);
            foreach (Card card in availableCards.ListCard)
            {
                imageList.Images.Add(card.Name,card.Image);
                var listViewItem = listViewCards.Items.Add(card.Name);
                listViewItem.ImageKey = card.Name;
                
            }
            listViewCards.LargeImageList = imageList;

        }

        private void DeckCustomization_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Ferme tout le programme
            System.Windows.Forms.Application.Exit();
        }

        private void listViewCards_ItemActivate(object sender, EventArgs e)
        {
            int i = listViewCards.SelectedIndices[0];
            string s = listViewCards.Items[i].Text;

            Card selectedCard = availableCards.ListCard.ElementAt(i);

            if (checkCardToDeckValidity(selectedCard))
            {
                currentDeck.addCard(selectedCard);
                fillCurrentDeck();
            }
            else
            {
                MessageBox.Show("TODO message selon erreur");
            }
        }

        private void listViewDeck_ItemActivate(object sender, EventArgs e)
        {
            int i = listViewDeck.SelectedIndices[0];

            currentDeck.ListCard.RemoveAt(i);
            listViewDeck.Items.RemoveAt(i);

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            (new DeckManagement(player.Pseudo)).Show();
            this.Hide();
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (checkDeckValidity())
            {
                currentDeck.save();
                (new DeckManagement(player.Pseudo)).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("TODO message selon erreur");
            }
        }

        private bool checkCardToDeckValidity(Card card)
        {
            //TODO check niveau du deck, nombre de cartes, ....
            return true;
        }

        private bool checkDeckValidity()
        {
            //TODO check niveau du deck, nombre de cartes, ....
            return true;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            currentDeck.ListCard.Clear();
            fillCurrentDeck();
        }


    }
}
