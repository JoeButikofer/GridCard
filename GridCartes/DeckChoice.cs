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
    public partial class DeckChoice : Form
    {
        private string namePlayer;

        public DeckChoice(string name)
        {
            InitializeComponent();
            namePlayer = name;


        }

    }
}
