﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GridCartes
{
    public class Deck
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

            this.id = int.Parse(""+reader["ID"]);
            loadCards(""+reader["ID"]);      

        }

        public Deck(int _deckId)
        {
            this.id = _deckId;
            DatabaseHelper db = DatabaseHelper.Instance;
            SQLiteDataReader reader = db.execCommandeReader("select * from Decks where ID = '" + _deckId + "';");
            reader.Read();
            this.playerId = int.Parse(""+reader["ID_Joueurs"]);
            this.name = "" + reader["Nom"];

            loadCards("" + id);

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
                    String name = ""+readerCard["Nom"];
                    int valueTop = int.Parse(""+readerCard["Valeur_Haut"]);
                    int valueLeft = int.Parse(""+readerCard["Valeur_Gauche"]);
                    int valueRight = int.Parse(""+readerCard["Valeur_Droite"]);
                    int valueBottom = int.Parse(""+readerCard["Valeur_Bas"]);
                    int level = int.Parse(""+readerCard["Level"]);
                    String imagePath = ""+readerCard["Path_Img"];
                    
                    Card card = new Card(int.Parse(carteId),name,valueTop,valueLeft,valueRight,valueBottom,level,imagePath);
                    addCard(card);
                }

            }
        }

    }
}
