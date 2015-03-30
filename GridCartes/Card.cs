using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

            image = Image.FromFile(_imagePath);
        }

    }
}
