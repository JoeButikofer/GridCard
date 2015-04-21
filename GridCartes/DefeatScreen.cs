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
    public partial class DefeatScreen : Form
    {
        private Player player;

        public DefeatScreen(Player _player)
        {
            this.player = _player;
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            (new MainMenu(player.Pseudo)).Show();
            this.Hide();
        }

        private void DefeatScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Ferme tout le programme
            System.Windows.Forms.Application.Exit();
        }
    }
}
