using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GridCartes
{
    class Deck
    {
        private int id;
        public int Id
        {
            get { return id; }
        }

        private int playerId;
        public int PlayerId
        {
            get { return playerId; }
        }

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private List<Card> listCard;
        public List<Card> ListCard
        {
            get { return listCard; }
        }

        public Deck(int _playerId, String _name)
        {
            this.playerId = _playerId;
            this.name = _name;

            DatabaseHelper db = DatabaseHelper.Instance;
            SQLiteDataReader reader = db.execCommandeReader("select * from Decks where ID_Joueurs = '" + playerId + "' and nom ='" + name + "';");

            reader.Read();
            
            loadCards((String)reader["ID"]);      

        }

        public Deck()
        {

        }

        public void addCard(Card card)
        {
            listCard.Add(card);
        }

        public void removeCard(Card card)
        {
            listCard.Remove(card);
        }

        public void save()
        {

        }

        private void loadCards(String deckId)
        {
            DatabaseHelper db = DatabaseHelper.Instance;
            SQLiteDataReader reader = db.execCommandeReader("select * from CartesDecks where ID_Decks = '" + deckId +"';");

            while (reader.Read())
            {
                String carteId = (String)reader["ID_Cartes"];
                int nbCartes = int.Parse((String)reader["Nb_Cartes"]);

                SQLiteDataReader readerCard = db.execCommandeReader("select * from Cartes where ID ='" + carteId + "'");

                readerCard.Read();

                for(int i = 0;i<nbCartes;i++)
                {
                    String name = (String)readerCard["Nom"];
                    int valueTop = int.Parse((String)readerCard["Valeur_Haut"]);
                    int valueLeft = int.Parse((String)readerCard["Valeur_Gauche"]);
                    int valueRight = int.Parse((String)readerCard["Valeur_Droite"]);
                    int valueBottom = int.Parse((String)readerCard["Valeur_Bas"]);
                    int level = int.Parse((String)readerCard["Level"]);
                    String imagePath = (String)readerCard["Path_Img"];
                    
                    Card card = new Card(int.Parse(carteId),name,valueTop,valueLeft,valueRight,valueBottom,level,imagePath);
                    addCard(card);
                }

            }
        }

    }
}
