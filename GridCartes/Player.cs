using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCartes
{
    public class Player
    {
        private int id;

        public int Id
        {
            get { return id; }
        }

        private String pseudo;

        public String Pseudo
        {
            get { return pseudo; }
        }

        private int victory;

        public int Victory
        {
            get { return victory; }
        }

        private int defeat;

        public int Defeat
        {
            get { return defeat; }
        }

        private Deck currentDeck;

        public Deck CurrentDeck
        {
            get { return currentDeck; }
            set { currentDeck = value; }
        }

        public Player(String _pseudo)
        {
            DatabaseHelper db = DatabaseHelper.Instance;
            SQLiteDataReader reader = db.execCommandeReader("select * from Joueurs where Pseudo = '" + _pseudo +"';");

            reader.Read();

            this.id = int.Parse(""+reader["ID"]);
            this.pseudo = (String)reader["Pseudo"];
            this.victory = int.Parse(""+reader["Nb_Games_Win"]);
            this.defeat = int.Parse(""+reader["Nb_Games_Loose"]);
            
        }

        public Deck getDefaultDeck()
        {
            //the default deck is a deck created when a player is created, it's the same for everyone and you can't change it
            return new Deck(this.id, "DEFAULT");
        }

        public Deck getAvailableCards()
        {
            //AVAILABLE is a deck containing all the cards the player owns
            return new Deck(this.id, "AVAILABLE");
        }
    }
}
