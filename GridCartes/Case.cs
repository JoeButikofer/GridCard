﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridCartes
{
    //Arguments send when the panel is clicked
    public class CaseClickEventArgs : EventArgs
    {
        public int x { get; set; }
        public int y { get; set; }
    }

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

        private bool isBlocked;
        public bool IsBlocked
        {
            get { return isBlocked; }
            set { isBlocked = value; updateImage(); }
        }

        private event EventHandler<CaseClickEventArgs> caseClicked;

        public Case(int _x, int _y, int _width, int _height, EventHandler<CaseClickEventArgs> clickCallback) : base()
        {
            x = _x;
            y = _y;
            card = null;
            player = 0;
            isBlocked = false;
            this.Size = new Size(_width, _height);
            updateImage();
            caseClicked += clickCallback; // add the Gameboard method to the event caseClicked
        }

        //When a panel is clicked
        protected override void OnClick(EventArgs e)
        {
            EventHandler<CaseClickEventArgs> handler = caseClicked;
            if (handler != null)
            {
                //We call the Gameboard method with corresponding arguments
                CaseClickEventArgs args = new CaseClickEventArgs();
                args.x = this.x;
                args.y = this.y;
                handler(this, args);
            }
            base.OnClick(e);
        }

        public void placeCard(Card _card, int _player)
        {
            if (!isBlocked)
            {
                this.card = _card;
                this.player = _player;
                updateImage();
            }
        }

        public void fight(Card opponentCard, Direction attackDirection, int opponent)
        {
            if(!isEmpty() && player != opponent && !isBlocked)
            {
                int myValue = 0;
                int opponentValue = 0;
                switch (attackDirection)
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
                if (myValue < opponentValue)
                {
                    player = opponent;
                    updateImage();
                }
            }
        }

        public bool isEmpty()
        {
            return card == null;
        }

        public void destroy()
        {
            card = null;
            isBlocked = false;
            player = 0;
            updateImage();
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

                if(isBlocked)
                {
                    Pen pen = new Pen(color, 9);
                    graphics.DrawRectangle(pen, 0, 0, newBitmap.Width, newBitmap.Height);
                }

                this.BackgroundImage = new Bitmap(newBitmap, this.Size);
            }
            else
            {
                if (isBlocked)
                {
                    Bitmap newBitmap = new Bitmap(this.Width, this.Height);
                    Graphics graphics = Graphics.FromImage(newBitmap);
                    SolidBrush brush = new SolidBrush(Color.Gray);

                    // Create rectangle.
                    Rectangle rect = new Rectangle(0, 0, newBitmap.Width, newBitmap.Height);

                    // Draw rectangle to Image.
                    graphics.FillRectangle(brush, rect);
                    this.BackgroundImage = new Bitmap(newBitmap, this.Size);
                }
                else
                {
                    this.BackgroundImage = null;
                }
            }
            this.Refresh();
        }

    }

}
