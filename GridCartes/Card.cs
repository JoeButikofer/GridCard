using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Data.SQLite;

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

        public Card(int _id)
        {
            id = _id;

            DatabaseHelper db = DatabaseHelper.Instance;
            SQLiteDataReader reader = db.execCommandeReader("select * from Cartes where ID = '" + id + "';");

            reader.Read();

            this.id = int.Parse("" + reader["ID"]);
            name = "" + reader["Nom"];
            valueTop = int.Parse("" + reader["Value_Haut"]);
            valueLeft = int.Parse("" + reader["Value_Gauche"]);
            valueRight = int.Parse("" + reader["Value_Droite"]);
            valueBottom = int.Parse("" + reader["Value_Bas"]);
            level = 0;//int.Parse("" + reader["Level"]);
            String imagePath = "" + reader["Path_Img"];

            String path = Path.Combine(
        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), imagePath);

            Image baseImage = Image.FromFile(path);

            image = addValuesToImage(baseImage);
        }

        public static List<Card> getAllCards()
        {
            List<Card> listCards = new List<Card>();

            DatabaseHelper db = DatabaseHelper.Instance;
            SQLiteDataReader reader = db.execCommandeReader("select * from Cartes;");

            while (reader.Read())
            {
                listCards.Add(new Card(int.Parse(""+reader["ID"])));
            }

            return listCards;
        }

        //Add damage value to the base image of the card, so we don't have to modify the image every time we chnage the values
        private Image addValuesToImage(Image img)
        {
            Image imgSmall = img.GetThumbnailImage(70, 100, null, IntPtr.Zero);
            //we need to create a non indexed image so we can modify it
            Bitmap newBitmap = new Bitmap(imgSmall.Width, imgSmall.Height);
            Graphics graphics = Graphics.FromImage(newBitmap);
            graphics.DrawImage(imgSmall, 0, 0);
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;

            //Default String for the text size
            String text = "12";
            //Since we have numbers, the text size will not change too much
            SizeF textSize = graphics.MeasureString(text, font);

            text = "" + this.valueTop;
            graphics.DrawString(text, font, brush, imgSmall.Width/2 - textSize.Width/2, 0);

            text = "" + this.valueLeft;
            graphics.DrawString("" + this.valueLeft, font, brush, 0, imgSmall.Height / 2-textSize.Height/2);

            text = "" + this.valueRight;
            graphics.DrawString("" + this.valueRight, font, brush, imgSmall.Width - textSize.Width, imgSmall.Height / 2 - textSize.Height / 2);

            text = "" + this.valueBottom;
            graphics.DrawString("" + this.valueBottom, font, brush, imgSmall.Width / 2 - textSize.Width / 2, imgSmall.Height - textSize.Height);

            return newBitmap;
        }

    }
}
