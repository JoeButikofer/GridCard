using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GridCartes
{
    class DatabaseHelper
    {
        private SQLiteConnection con;
        public SQLiteConnection Con
        {
            get { return con; }
        }

        private static DatabaseHelper instance;
        public static DatabaseHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseHelper();
                }
                return instance;
            }
        }

        private DatabaseHelper() //Constructeur privé car Singleton
        {

            String connexionString = @"Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + "/BDD_Cartes; Version = 3";

            con = new SQLiteConnection(connexionString);

        }

        public SQLiteDataReader execCommandeReader(String sql) 
        {
            SQLiteCommand command = new SQLiteCommand(sql, con);
            return command.ExecuteReader();
        }

        public void execCommand(String sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, con);
            command.ExecuteNonQuery();
        }
       
    }
}
