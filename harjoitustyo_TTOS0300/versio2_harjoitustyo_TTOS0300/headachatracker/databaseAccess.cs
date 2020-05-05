using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace headachatracker
{
    public static class DatabaseAccess
    {
        #region Fields
        private static string filePath;
        #endregion

        #region Constructors
        static DatabaseAccess()
        {
            filePath = headachatracker.Properties.Settings.Default.databasePath;  // Etsitään tietokannan sijainti Propertiesseistä
        }
        #endregion

        #region Methods
        public static DataTable ReadFromSQLite() // Lukumetodi
        {
            if (System.IO.File.Exists(filePath))    // Tarkistetaan, onko tiedosto olemassa
            {
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                SQLiteCommand cmd = new SQLiteCommand("SELECT * from Headache", connection); // SQL-komento

                // Tiedon luku:
                SQLiteDataReader rdr = cmd.ExecuteReader();

                // Tiedot dataTableen:
                DataTable dt = new DataTable();
                dt.Load(rdr);

                // Suljetaan lukija + yhteys
                rdr.Close();
                connection.Close();

                // Palautetaan datatable-muuttuja
                return dt;

            }

            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }

        }

        public static bool AddToSQLite(Headache headache) // Lisäysmetodi
        {
            try
            {
                if (System.IO.File.Exists(filePath))    // Tarkistetaan, onko tiedosto olemassa
                {
                    SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                    connection.Open(); // Avataan yhteys

                    // Suoritetaan SQL-komento lisäämään tietoa
                    SQLiteCommand cmd = new SQLiteCommand($"INSERT INTO Headache (UserID, AcheType, PainLevel, Symptoms, Triggers, Reliefs, Notes) values ('{headache.UserID}', '{headache.AcheType}', '{headache.PainLevel}', '{headache.Symptoms}', '{headache.Triggers}','{headache.Reliefs}', '{headache.Notes}')", connection);

                    cmd.ExecuteNonQuery();

                    // Suljetaan yhteys
                    connection.Close();

                    return true;

                }

                else // Jos tiedostoa ei löydy, heitetään poikkeus
                {
                    throw new System.IO.FileNotFoundException("File not found");
                }
            }

            catch
            {
                throw;
            }

        }

  

        #endregion
    }
}
