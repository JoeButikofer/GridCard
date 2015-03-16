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
        private String connexionString;
        private SQLiteConnection con;
        public Accueil()
        {
            InitializeComponent();
            connexionString = @"Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + "/BDD_Cartes; Version = 3";

            con = new SQLiteConnection(connexionString);
            try
            {
                con.Open();
                updateListBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox_Joueurs_DoubleClick(object sender, EventArgs e)
        {
            //TODO Redirection page Menu Joueur
            Console.WriteLine(listBox_Joueurs.SelectedItem.ToString());

            (new MainMenu()).Show();
            this.Hide();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (textFields_Pseudo.Text != "" && textFields_Pseudo.Text.All(char.IsLetterOrDigit))
            {
                string sql = "insert into Joueurs (Pseudo) values (\'" + textFields_Pseudo.Text + "\')";
                Console.WriteLine(sql);
                SQLiteCommand command = new SQLiteCommand(sql, con);
                command.ExecuteNonQuery();
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
            string sql = "select * from Joueurs";
            SQLiteCommand command = new SQLiteCommand(sql, con);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                listBox_Joueurs.Items.Add("" + reader["Pseudo"]);
            }
        }
    }
}
