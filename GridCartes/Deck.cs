﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GridCartes
{
    public enum DeckStatus { OK, DeckTooLong, DeckTooShort, TooMuchCardUsed, DeckLevelTooHigh };

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

        private DatabaseHelper db;

        public Deck(int _playerId, String _name)
        {
            this.playerId = _playerId;
            this.name = _name;
            this.listCard = new List<Card>();

            DatabaseHelper db = DatabaseHelper.Instance;
            SQLiteDataReader reader = db.execCommandeReader("select * from Decks where ID_Joueurs = '" + playerId + "' and nom ='" + name + "';");

            reader.Read();

            this.id = int.Parse(""+reader["ID"]);
            loadCards(""+reader["ID"]);      

        }

        public Deck(int _deckId)
        {
            this.id = _deckId;
            this.listCard = new List<Card>();

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
            db = DatabaseHelper.Instance;
            db.execCommand("update Decks set nom = '" + this.name + "' where ID = '" + this.id + "';");

            removeOldCards();

            foreach (Card card in this.listCard)
            {
                db.execCommand("insert into CartesDecks (ID_Decks, ID_Cartes) values ('" + this.id + "', '" + card.Id + "');");
            }
        }

        private void removeOldCards()
        {
            db.execCommand("delete from CartesDecks where ID_Decks = '" + this.id + "';");
        }

        private void loadCards(String deckId)
        {
            db = DatabaseHelper.Instance;
            SQLiteDataReader reader = db.execCommandeReader("select * from CartesDecks where ID_Decks = '" + deckId +"';");

            while (reader.Read())
            {
                String carteId = ""+reader["ID_Cartes"];
                int nbCartes = int.Parse(""+reader["Nb_Cartes"]);

                SQLiteDataReader readerCard = db.execCommandeReader("select * from Cartes where ID ='" + carteId + "'");

                readerCard.Read();

                for(int i = 0;i<nbCartes;i++)
                {
                    Card card = new Card(int.Parse(carteId));
                    addCard(card);
                }

            }
        }

        //Check the validity of the deck (number of cards, number of same cards)
        public DeckStatus isValid()
        {
            if (listCard.Count < 10)
            {
                return DeckStatus.DeckTooShort;
            }
            if (listCard.Count > 20)
            {
                return DeckStatus.DeckTooLong;
            }

            if(!checkNumberOfSameCards())
            {
                return DeckStatus.TooMuchCardUsed;
            }

            return DeckStatus.OK;
        }

        //Check if we have a maximum of 2 same cards
        private bool checkNumberOfSameCards()
        {
            foreach(Card card in listCard)
            {
                int count = listCard.Count(item => item.Name == card.Name);
                if (count > 2) return false;
            }
            return true;
        }

    }
}
