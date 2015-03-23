using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace GridCartes
{
    public partial class Accueil : Form
    {
        private DatabaseHelper db;
        public Accueil()
        {
            InitializeComponent();

            db = DatabaseHelper.Instance;
         
            updateListBox();
        }

        private void listBox_Joueurs_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine(listBox_Joueurs.SelectedItem.ToString());

            (new MainMenu(listBox_Joueurs.SelectedItem.ToString())).Show();
            this.Hide();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (textFields_Pseudo.Text != "" && textFields_Pseudo.Text.All(char.IsLetterOrDigit))
            {
                string sql = "insert into Joueurs (Pseudo) values (\'" + textFields_Pseudo.Text + "\')";
                Console.WriteLine(sql);
                db.execCommand(sql);
                MessageBox.Show("Joueur ajouté");
                updateListBox();
            }
            else
            {
                MessageBox.Show("Entrer un Pseudo correct");
            }

        }

        private void updateListBox()
        {
            listBox_Joueurs.Items.Clear();
            string sql = "select Pseudo from Joueurs";
            
            SQLiteDataReader reader = db.execCommandeReader(sql);

            while (reader.Read())
            {
                listBox_Joueurs.Items.Add("" + reader["Pseudo"]);
            }
        }
    }
}
