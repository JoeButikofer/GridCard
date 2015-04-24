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
    public partial class VictoryScreen : Form
    {
        private Player player;

        public VictoryScreen(Player _player)
        {
            this.player = _player;
            InitializeComponent();
            giveRandomCardToPlayer();
        }

        private void giveRandomCardToPlayer()
        {
            //Gets all the disponible cards
            List<Card> listAllCards = Card.getAllCards();

            //Gets all the cards that the player owns
            Deck deckPlayerAvailableCards = player.getAvailableCards();

            //Removes the cards that the player already has
            foreach(Card playerCard in deckPlayerAvailableCards.ListCard)
            {
                listAllCards.RemoveAll(card => card.Id == playerCard.Id);
            }

            if(listAllCards.Count > 0)
            {
                Random randomGen = new Random();
                int rand = randomGen.Next(listAllCards.Count);
                Card randomCard = listAllCards.ElementAt(rand);
                deckPlayerAvailableCards.addCard(randomCard);
                deckPlayerAvailableCards.save();
                //TODO afficher la nouvelle carte marche pas
                pictureBoxNewCard.Image = randomCard.Image;
            }
            else
            {
                lblCardMessage.Text= "Vous avez déjà toutes les cartes\nBien joué !!!";
            }
            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            (new MainMenu(player.Pseudo)).Show();
            this.Hide();
        }

        private void VictoryScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Ferme tout le programme
            System.Windows.Forms.Application.Exit();
        }
    }
}
