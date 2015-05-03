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
    public partial class InputTextForm : Form
    {
        public InputTextForm(string oldAddress)
        {
            InitializeComponent();
            textBoxIP.Text = oldAddress;
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {

        }

        internal string getAddress()
        {
            return textBoxIP.Text;
        }

        private void btnLocalhost_Click(object sender, EventArgs e)
        {
            textBoxIP.Text = "127.0.0.1";
        }
    }
}
