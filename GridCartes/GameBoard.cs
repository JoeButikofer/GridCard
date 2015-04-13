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
    public partial class GameBoard : Form
    {
        private Player player;
        private Deck currentDeck;
        private Card selectedCard;

        public GameBoard(Player p)
        {
            InitializeComponent();
            player = p;
            currentDeck = player.CurrentDeck;

            /*TextBox text = new TextBox();
            text.Text = "test1";

            Panel panel = new Panel();
            panel.BackColor = Color.Yellow;

            tableLayoutPanel1.Controls.Add(panel, 0, 1);
            tableLayoutPanel1.Controls.Add(text, 1, 0);*/

            fillHandCards();
        }


        private void fillHandCards()
        {
            listViewHandCards.Clear();
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(50, 80);
            foreach (Card card in currentDeck.ListCard)
            {
                imageList.Images.Add(card.Name, card.Image);
                var listViewItem = listViewHandCards.Items.Add(card.Name);
                listViewItem.ImageKey = card.Name;
            }
            listViewHandCards.LargeImageList = imageList;
        }

        private void listViewHandCards_ItemActivate(object sender, EventArgs e)
        {
            int i = listViewHandCards.SelectedIndices[0];
            string s = listViewHandCards.Items[i].Text;

            selectedCard = currentDeck.ListCard.ElementAt(i);

        }

        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            if(selectedCard!=null)
            {
                int width = (int)(tableLayoutPanel1.Size.Width / 4);
                int height = (int)(tableLayoutPanel1.Size.Height / 4);


                int resteX = e.X % width;
                int resteY = e.Y % height;

                int x = (e.X - resteX) / width;
                int y = (e.Y - resteY) / height;

                Panel p = new Panel();
                p.BackColor = Color.Red;

                Image img = (Image)(new Bitmap(selectedCard.Image, new Size(width-4, height-4)));


                p.BackgroundImage = img;
                p.Visible = false;

                tableLayoutPanel1.Controls.Add(p, x, y);

                p.Visible = true;

                currentDeck.removeCard(selectedCard);
                fillHandCards();
                selectedCard = null;
            }
            Console.WriteLine("qidhipozahdazhdipazgdfazodpigavdb");
          

        }

        private void GameBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

    }
}
