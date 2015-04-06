using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace GridCartes
{
    public class Card
    {
        private int id;
        public int Id
        {
            get { return id; }
        }

        private String name;
        public String Name
        {
            get { return name; }
        }

        private int valueTop;
        public int ValueTop
        {
            get { return valueTop; }
        }

        private int valueLeft;
        public int ValueLeft
        {
            get { return valueLeft; }
        }

        private int valueRight;
        public int ValueRight
        {
            get { return valueRight; }
        }

        private int valueBottom;
        public int ValueBottom
        {
            get { return valueBottom; }
        }

        private int level;
        public int Level
        {
            get { return level; }
        }

        private Image image;
        public Image Image
        {
            get { return image; }
        }

        public Card(int _id, String _name, int _valueTop, int _valueLeft, int _valueRight, int _valueBottom, int _level, String _imagePath)
        {
            id = _id;
            name = _name;
            valueTop = _valueTop;
            valueLeft = _valueLeft;
            valueRight = _valueRight;
            valueBottom = _valueBottom;
            level = _level;

            String path = Path.Combine(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _imagePath);

            Image baseImage = Image.FromFile(path);

            image = addValuesToImage(baseImage);
        }

        //Add damage value to the base image of the card, so we don't have to modify the image every time we chnage the values
        private Image addValuesToImage(Image img)
        {
            //we need to create a non indexed image so we can modify it
            Bitmap newBitmap = new Bitmap(img.Width, img.Height);
            Graphics graphics = Graphics.FromImage(newBitmap);
            graphics.DrawImage(img, 0, 0);
            Font font = new Font("Arial", 100);
            Brush brush = Brushes.Black;

            String text = ""+this.valueTop;
            //Since we have numbers, the text size will not change too much
            SizeF textSize = graphics.MeasureString(text, font);

            graphics.DrawString(text, font, brush, img.Width/2 - textSize.Width/2, 0);

            text = "" + this.valueLeft;
            graphics.DrawString("" + this.valueLeft, font, brush, 0, img.Height / 2-textSize.Height/2);

            text = "" + this.valueRight;
            graphics.DrawString("" + this.valueRight, font, brush, img.Width - textSize.Width, img.Height / 2 - textSize.Height / 2);

            text = "" + this.valueBottom;
            graphics.DrawString("" + this.valueBottom, font, brush, img.Width / 2 - textSize.Width / 2, img.Height - textSize.Height);

            return newBitmap;
        }

    }
}
