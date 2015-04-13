﻿using System;
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
    enum DeckStatus {OK, DeckTooLong, DeckTooShort, TooMuchCardUsed, DeckLevelTooHigh};

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
            currentDeck = player.CurrentDeck;
            availableCards = player.getAvailableCards();
            textBoxDeckName.Size = TextRenderer.MeasureText(currentDeck.Name, textBoxDeckName.Font);
            textBoxDeckName.Text = currentDeck.Name;

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
                default:
                    MessageBox.Show("Erreur inconnue");
                    break;
            }
        }

        private DeckStatus checkCardToDeckValidity(Card card)
        {
            //TODO check niveau du deck, nombre de cartes, ....
            return DeckStatus.OK;
        }

        private DeckStatus checkDeckValidity()
        {
            //TODO check niveau du deck, nombre de cartes, ....

            if (currentDeck.ListCard.Count < 10)
            {
                return DeckStatus.DeckTooShort;
            }
            if(currentDeck.ListCard.Count > 20)
            {
                return DeckStatus.DeckTooLong;
            }
            return DeckStatus.OK;
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
