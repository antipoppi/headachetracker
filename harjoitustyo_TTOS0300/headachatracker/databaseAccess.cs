﻿using System;
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
                    SQLiteCommand cmd = new SQLiteCommand($"INSERT INTO Headache (UserID, AcheType, PainLevel, Medications, Symptoms, Triggers, Reliefs, Notes) values ('{headache.UserID}', '{headache.AcheType}', '{headache.PainLevel}', '{headache.Medications}', '{headache.Symptoms}', '{headache.Triggers}','{headache.Reliefs}', '{headache.Notes}')", connection);

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
        public static bool DeleteFromSQLite(int entryID) // poistometodi
        {
            if (System.IO.File.Exists(filePath))
            {
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento poistamaan tietoa
                SQLiteCommand cmd = new SQLiteCommand($"DELETE FROM Headache WHERE AcheID LIKE '{entryID}'", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }
       }

        /// <summary>
        /// Below are Methods that are used to edit Entry
        /// </summary>
        public static string GetAcheTypeFromSQLite(int id)
        {
            if (System.IO.File.Exists(filePath))
            {
                string hold = "";
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT AcheType FROM Headache WHERE AcheID LIKE {id}", connection);
                hold = (string)cmd.ExecuteScalar();
                connection.Close();
                return hold;
            }
            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }
        }

        public static string GetPainLevelFromSQLite(int id)
        {
            if (System.IO.File.Exists(filePath))
            {
                string hold = "";
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT PainLevel FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder = cmd.ExecuteScalar();
                if (holder != null)
                    hold = holder.ToString();
                else
                    throw new Exception($"PainLevel could not be retrieved!");
                connection.Close();
                return hold;
            }
            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }
        }

        public static string GetMedicationsFromSQLite(int id)
        {
            if (System.IO.File.Exists(filePath))
            {
                string hold = "";
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT Medications FROM Headache WHERE AcheID LIKE {id}", connection);
                hold = (string)cmd.ExecuteScalar();
                connection.Close();
                return hold;
            }
            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }
        }

        public static string GetSymptomsFromSQLite(int id)
        {
            if (System.IO.File.Exists(filePath))
            {
                string hold = "";
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT Symptoms FROM Headache WHERE AcheID LIKE {id}", connection);
                hold = (string)cmd.ExecuteScalar();
                connection.Close();
                return hold;
            }
            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }
        }

        public static string GetTriggersFromSQLite(int id)
        {
            if (System.IO.File.Exists(filePath))
            {
                string hold = "";
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT Triggers FROM Headache WHERE AcheID LIKE {id}", connection);
                hold = (string)cmd.ExecuteScalar();
                connection.Close();
                return hold;
            }
            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }
        }

        public static string GetReliefsFromSQLite(int id)
        {
            if (System.IO.File.Exists(filePath))
            {
                string hold = "";
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT Reliefs FROM Headache WHERE AcheID LIKE {id}", connection);
                hold = (string)cmd.ExecuteScalar();
                connection.Close();
                return hold;
            }
            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }
        }

        public static string GetNotesFromSQLite(int id)
        {
            if (System.IO.File.Exists(filePath))
            {
                string hold = "";
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT Notes FROM Headache WHERE AcheID LIKE {id}", connection);
                hold = (string)cmd.ExecuteScalar();
                connection.Close();
                return hold;
            }
            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }
        }
        #endregion
    }
}
