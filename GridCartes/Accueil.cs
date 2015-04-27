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
            if (listBox_Joueurs.SelectedItem != null)
            {
                (new MainMenu(listBox_Joueurs.SelectedItem.ToString())).Show();
                this.Hide();
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (textFields_Pseudo.Text != "" && textFields_Pseudo.Text.All(char.IsLetterOrDigit))
            {
                createNewPlayer();
            }
            else
            {
                MessageBox.Show("Entrer un Pseudo correct");
            }

        }

        private void createNewPlayer()
        {
            //Create the player
            string sql = "insert into Joueurs (Pseudo) values (\'" + textFields_Pseudo.Text + "\')";
            Console.WriteLine(sql);
            db.execCommand(sql);

            //Retrieve the id for the newly created player
            SQLiteDataReader reader = db.execCommandeReader("select * from Joueurs where Pseudo = '" + textFields_Pseudo.Text +"';");
            reader.Read();
            int id = int.Parse(""+reader["ID"]);

            //Set the default available cards for the player

            sql = "insert into Decks (ID_Joueurs, Nom) values (\'" + id + "\','AVAILABLE');";
            db.execCommand(sql);

            //Retrieve the id for the newly created deck
            reader = db.execCommandeReader("select * from Decks where Nom = 'AVAILABLE' and ID_Joueurs = '" + id + "';");
            reader.Read();
            int availableCardsId = int.Parse("" + reader["ID"]);

            //TODO prendre les decks depuis un fichier (XML ou autre)
            for (int i = 4; i <= 13;i++)
            {
                sql = "insert into CartesDecks (ID_Decks, ID_Cartes) values (\'"+availableCardsId+"\',\'" + i + "\');";
                db.execCommand(sql);
            }

            //Create default deck for the player

            sql = "insert into Decks (ID_Joueurs, Nom) values (\'" + id + "\','DEFAULT');";
            db.execCommand(sql);

            //Retrieve the id for the newly created deck
            reader = db.execCommandeReader("select * from Decks where Nom = 'DEFAULT' and ID_Joueurs = '" + id + "';");
            reader.Read();
            int defaultId = int.Parse("" + reader["ID"]);

            //TODO prendre les decks depuis un fichier (XML ou autre)
            for (int i = 4; i <= 13; i++)
            {
                sql = "insert into CartesDecks (ID_Decks, ID_Cartes) values (\'"+defaultId+"\',\'" + i + "\');";
                db.execCommand(sql);
            }

            MessageBox.Show("Joueur ajouté");
            updateListBox();
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
