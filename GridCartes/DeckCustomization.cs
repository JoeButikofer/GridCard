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


        public DeckCustomization(Player _player, bool isCancelButtonEnabled)
        {
            InitializeComponent();
            player = _player;
            db = DatabaseHelper.Instance;
            currentDeck = player.CurrentDeck;
            availableCards = player.getAvailableCards();
            textBoxDeckName.Size = TextRenderer.MeasureText(currentDeck.Name, textBoxDeckName.Font);
            textBoxDeckName.Text = currentDeck.Name;
            btn_Cancel.Enabled = isCancelButtonEnabled;

            fillListAvailableCards();
            fillCurrentDeck();
        }

        private void fillCurrentDeck()
        {
            listViewDeck.Items.Clear();

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(50, 80);
            foreach (Card card in currentDeck.ListCard)
            {
                imageList.Images.Add(card.Name, card.Image);
                var listViewItem = listViewDeck.Items.Add(card.Name);
                listViewItem.ImageKey = card.Name;

            }
            listViewDeck.LargeImageList = imageList;

            lbl_NbCards.Text = "Nombre de cartes : "+currentDeck.ListCard.Count;
        }

        private void fillListAvailableCards()
        {
            listViewCards.Items.Clear();

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(70, 100);
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

            Card selectedCard = availableCards.ListCard.ElementAt(i);

            switch(checkCardToDeckValidity(selectedCard))
            {
                case DeckStatus.OK:
                    currentDeck.addCard(selectedCard);
                    fillCurrentDeck();
                    break;
                case DeckStatus.TooMuchCardUsed:
                    MessageBox.Show("Vous avez déjà utilisé le maximum de fois cette carte");
                    break;
                default:
                    MessageBox.Show("Erreur inconnue");
                    break;
            }
        }

        private void listViewDeck_ItemActivate(object sender, EventArgs e)
        {
            int i = listViewDeck.SelectedIndices[0];

            currentDeck.ListCard.RemoveAt(i);
            listViewDeck.Items.RemoveAt(i);
            lbl_NbCards.Text = "Nombre de cartes : " + currentDeck.ListCard.Count;

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            (new DeckManagement(player.Pseudo)).Show();
            this.Hide();
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            DeckStatus deckStatus = checkDeckValidity();
            switch(deckStatus)
            {
                case DeckStatus.OK:
                    currentDeck.Name = this.textBoxDeckName.Text;
                    currentDeck.save();
                    (new DeckManagement(player.Pseudo)).Show();
                    this.Hide();
                    break;
                case DeckStatus.DeckTooLong:
                     MessageBox.Show("Le deck contient trop de cartes, il doit contenir au maximum 20 cartes");
                    break;
                case DeckStatus.DeckTooShort:
                     MessageBox.Show("Le deck ne contient pas assez de cartes, il doit contenir au minimum 10 cartes");
                    break;
                case DeckStatus.TooMuchCardUsed:
                    MessageBox.Show("Le deck contient trop de cartes semblables, le maximum est 2");
                    break;
                default:
                    MessageBox.Show("Erreur inconnue");
                    break;
            }
        }

        private DeckStatus checkCardToDeckValidity(Card card)
        {
            //Check if we have a maximum of 2 same cards
            int count = currentDeck.ListCard.Count(item => item.Name == card.Name);
            if (count > 1) return DeckStatus.TooMuchCardUsed;

            return DeckStatus.OK;
        }

        private DeckStatus checkDeckValidity()
        {
            //TODO check niveau du deck
            return currentDeck.isValid();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            currentDeck.ListCard.Clear();
            fillCurrentDeck();
        }

        private void textBoxDeckName_TextChanged(object sender, EventArgs e)
        {
            textBoxDeckName.Size = TextRenderer.MeasureText(textBoxDeckName.Text, textBoxDeckName.Font);
        }


    }
}
