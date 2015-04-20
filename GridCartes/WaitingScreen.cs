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
    public partial class WaitingScreen : Form
    {
        public WaitingScreen()
        {
            InitializeComponent();
        }

        private void WaitingScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Finish the application
            System.Windows.Forms.Application.Exit();
        }
    }
}
