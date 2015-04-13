using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCartes
{
    class Case
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

        public Case(int _x, int _y)
        {
            x = _x;
            y = _y;
            card = null;
            player = 0;
        }

        public Image draw()
        {
            //we need to create a non indexed image so we can modify it
            Bitmap newBitmap = new Bitmap(card.Image.Width, card.Image.Height);
            Graphics graphics = Graphics.FromImage(newBitmap);
            graphics.DrawImage(card.Image, 0, 0);

            // Create Brush.
            Color color = Color.FromArgb(50,0,0,255);
            if (player == 2) color = Color.FromArgb(50,255,0,0);
            SolidBrush brush = new SolidBrush(color);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, newBitmap.Width, newBitmap.Height);

            // Draw rectangle to Image.
            graphics.FillRectangle(brush, rect);

            return newBitmap;
        }

        public bool isEmpty()
        {
            return card == null;
        }
    }
}
