using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridCartes
{
    public partial class DeckManagement : Form
    {
        private DatabaseHelper db;
        private Player player;
        public DeckManagement(string name)
        {
            InitializeComponent();
            player = new Player(name);
            db = DatabaseHelper.Instance;

            updateListBox();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (textFields_Deck.Text != "" && textFields_Deck.Text.All(char.IsLetterOrDigit))
            {
                string sql = "insert into Decks (ID_Joueurs, Nom) values (\'" + player.Id + "\',\'" + textFields_Deck.Text + "\')";
                db.execCommand(sql);
                MessageBox.Show("Deck ajouté");
                updateListBox();
            }
            else
            {
                MessageBox.Show("Entrer un nom correct");
            }
        }

        private void updateListBox()
        {
            listBoxDeck.Items.Clear();
            string sql = "select Nom from Decks where ID_Joueurs = '" + player.Id + "' and Nom !='AVAILABLE' and Nom !='DEFAULT';";

            SQLiteDataReader reader = db.execCommandeReader(sql);

            while (reader.Read())
            {
                listBoxDeck.Items.Add("" + reader["Nom"]);
            }
        }

        private void listBoxDeck_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxDeck.SelectedItem != null)
            {
                Deck selectedDeck = new Deck(player.Id, listBoxDeck.SelectedItem.ToString());
                player.CurrentDeck = selectedDeck;
                (new DeckCustomization(player)).Show();
                this.Hide();
            }
        }

        private void DeckManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Ferme tout le programme
            System.Windows.Forms.Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            (new MainMenu(player.Pseudo)).Show();
            this.Hide();
        }
    }
}
