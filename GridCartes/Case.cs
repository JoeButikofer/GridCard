using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridCartes
{
    class Case : Panel
    {
        private int x;
        public int X
        {
            get { return X; }
        }

        private int y;
        public int Y
        {
            get { return Y; }
        }

        private Card card;
        public Card Card
        {
            get { return card; }
            set { card = value; }
        }

        //Player who owns the case : 
        // 0 : none
        // 1 : the local player
        // 2 : the remote player
        private int player;
        public int Player
        {
            get { return player; }
            set { player = value; }
        }

        public Case(int _x, int _y) : base()
        {
            x = _x;
            y = _y;
            card = null;
            player = 0;
            updateImage();
        }

        public void placeCard(Card _card, int _player)
        {
            this.card = _card;
            this.player = _player;
            updateImage();
        }

        public void fight(Card opponentCard, Direction attackDirection)
        {
            int myValue = 0;
            int opponentValue = 0;
            switch(attackDirection)
            {
                case Direction.UP:
                    myValue = card.ValueBottom;
                    opponentValue = opponentCard.ValueTop;
                    break;
                case Direction.DOWN:
                    myValue = card.ValueTop;
                    opponentValue = opponentCard.ValueBottom;
                    break;
                case Direction.LEFT:
                     myValue = card.ValueRight;
                    opponentValue = opponentCard.ValueLeft;
                    break;
                case Direction.RIGHT:
                     myValue = card.ValueLeft;
                    opponentValue = opponentCard.ValueRight;
                    break;
            }

            if(myValue < opponentValue)
            {
                if (player == 1)
                    player = 2;
                else
                    player = 1;
                updateImage();
            }
        }

        public bool isEmpty()
        {
            return card == null;
        }

        private void updateImage()
        {
            if (player != 0)
            {
                //we need to create a non indexed image so we can modify it
                Bitmap newBitmap = new Bitmap(card.Image.Width, card.Image.Height);
                Graphics graphics = Graphics.FromImage(newBitmap);
                graphics.DrawImage(card.Image, 0, 0);

                // Create Brush.
                Color color = Color.FromArgb(50, 0, 0, 255);
                if (player == 2) color = Color.FromArgb(50, 255, 0, 0);
                SolidBrush brush = new SolidBrush(color);

                // Create rectangle.
                Rectangle rect = new Rectangle(0, 0, newBitmap.Width, newBitmap.Height);

                // Draw rectangle to Image.
                graphics.FillRectangle(brush, rect);

                this.BackgroundImage = newBitmap;
            }
            else
            {
                this.BackgroundImage = null;
            }
        }

    }
}
