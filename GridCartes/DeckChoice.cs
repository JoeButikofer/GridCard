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
    public partial class DeckChoice : Form
    {
        private Player player;
        private DatabaseHelper db;

        public DeckChoice(string name)
        {
            InitializeComponent();
            player = new Player(name);
            db = DatabaseHelper.Instance;

            initListBox();
        }

        private void initListBox()
        {
            string sql = "select Nom from Decks where ID_Joueurs = '" + player.Id + "' ;";
            SQLiteDataReader reader = db.execCommandeReader(sql);

            while (reader.Read())
            {
                listBoxDeckChoice.Items.Add("" + reader["Nom"]);
            }

        }
        private void DeckChoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Ferme tout le programme
            System.Windows.Forms.Application.Exit();
        }

        private void listBoxDeckChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Deck deck = new Deck(player.Id, listBoxDeckChoice.SelectedItem.ToString());
            player.CurrentDeck = deck;
            (new GameBoard(player)).Show();
            this.Hide();
        }

    }
}
