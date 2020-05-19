using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows;

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
                    // Luodaan yhteys
                    SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                    

                    // Luodaan komento ja lisätään sille yhteys
                    SQLiteCommand cmd = new SQLiteCommand("INSERT INTO Headache (UserID, AcheType, PainLevel, Medications, Symptoms, Triggers, Reliefs, Notes) Values (@UserID, @AcheType, @PainLevel, @Medications, @Symptoms, @Triggers, @Reliefs, @Notes)", connection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;


                    // Lisätään tieto komentoon muuttujina
                    cmd.Parameters.AddWithValue("@UserID", headache.UserID);
                    cmd.Parameters.AddWithValue("@AcheType", headache.AcheType);
                    cmd.Parameters.AddWithValue("@PainLevel", headache.PainLevel);
                    cmd.Parameters.AddWithValue("@Medications", headache.Medications);
                    cmd.Parameters.AddWithValue("@Symptoms", headache.Symptoms);
                    cmd.Parameters.AddWithValue("@Triggers", headache.Triggers);
                    cmd.Parameters.AddWithValue("@Reliefs", headache.Reliefs);
                    cmd.Parameters.AddWithValue("@Notes", headache.Notes);

                    // Avataan yhteys
                    connection.Open(); 

                    // Suoritetaan komento
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
            if (System.IO.File.Exists(filePath)) // tarkistetaan onko tiedosto olemassa
            {
                // luodaan yhteys ja komento
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                SQLiteCommand cmd = new SQLiteCommand($"DELETE FROM Headache WHERE AcheID LIKE @AcheID", connection);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                // Lisätään merkinnän ID muuttujana komentoon
                cmd.Parameters.AddWithValue("@AcheID", entryID);

                // Avataan yhteys
                connection.Open();
                
                // Suoritetaan komento
                cmd.ExecuteNonQuery();

                // Suljetaan komento
                connection.Close();
                return true;
            }
            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }
        }
        public static void GetHeadacheObjPFromSQLite(Headache headache, int id)
        {
            if (System.IO.File.Exists(filePath))
            {
                headache.UserID = id;
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys

                // asetetaan olion AcheType
                SQLiteCommand cmdAcheType = new SQLiteCommand($"SELECT AcheType FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder1 = cmdAcheType.ExecuteScalar();
                if (holder1 != null)
                    headache.AcheType = holder1.ToString();
                else
                    headache.AcheType = null;

                // aseteaan olion PainLevel
                SQLiteCommand cmdPainLevel = new SQLiteCommand($"SELECT PainLevel FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder2 = cmdPainLevel.ExecuteScalar();
                if (holder2 != null)
                {
                    string painLevelstring = holder2.ToString();
                    Int32.TryParse(painLevelstring, out int painLevelInt);
                    headache.PainLevel = painLevelInt;
                }
                else
                    headache.PainLevel = 0;

                // asetetaan olion Medications
                SQLiteCommand cmdMedications = new SQLiteCommand($"SELECT Medications FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder3 = cmdMedications.ExecuteScalar();
                if (holder3 != null)
                    headache.Medications = holder3.ToString();
                else
                    headache.Medications = null;

                // asetetaan olion Symptoms
                SQLiteCommand cmdSymptoms = new SQLiteCommand($"SELECT Symptoms FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder4 = cmdSymptoms.ExecuteScalar();
                if (holder4 != null)
                    headache.Symptoms = holder4.ToString();
                else
                    headache.Symptoms = null;

                // asetetaan olion Triggers
                SQLiteCommand cmdTriggers = new SQLiteCommand($"SELECT Triggers FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder5 = cmdTriggers.ExecuteScalar();
                if (holder5 != null)
                    headache.Triggers = holder5.ToString();
                else
                    headache.Triggers = null;

                // asetetaan olion Reliefs
                SQLiteCommand cmdReliefs = new SQLiteCommand($"SELECT Reliefs FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder6 = cmdReliefs.ExecuteScalar();
                if (holder6 != null)
                    headache.Reliefs = holder6.ToString();
                else
                    headache.Reliefs = null;

                // asetetaan olion Notes
                SQLiteCommand cmdNotes = new SQLiteCommand($"SELECT Notes FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder7 = cmdNotes.ExecuteScalar();
                if (holder7 != null)
                    headache.Notes = holder7.ToString();
                else
                    headache.Notes = null;

                // Suljetaan yhteys
                connection.Close();
            }
            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }
        }

        public static bool SaveEditedEntryToSQLite(Headache headache)
        {
            if (System.IO.File.Exists(filePath))
            {
                // Luodaan yhteys
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string

                // Luodaan komento ja lisätään sille yhteys
                SQLiteCommand cmd = new SQLiteCommand("UPDATE Headache SET AcheType = @AcheType, PainLevel = @PainLevel, Medications = @Medications, Symptoms = @Symptoms, Triggers = @Triggers, Reliefs = @Reliefs, Notes = @Notes WHERE AcheID = @AcheID;", connection);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                // Lisätään tieto komentoon muuttujina
                cmd.Parameters.AddWithValue("@AcheType", headache.AcheType);
                cmd.Parameters.AddWithValue("@PainLevel", headache.PainLevel);
                cmd.Parameters.AddWithValue("@Medications", headache.Medications);
                cmd.Parameters.AddWithValue("@Symptoms", headache.Symptoms);
                cmd.Parameters.AddWithValue("@Triggers", headache.Triggers);
                cmd.Parameters.AddWithValue("@Reliefs", headache.Reliefs);
                cmd.Parameters.AddWithValue("@Notes", headache.Notes);
                cmd.Parameters.AddWithValue("@AcheID", headache.AcheID);

                // Avataan yhteys
                connection.Open();

                // Suoritetaan komento
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

        /// <summary>
        /// Below are Methods that are used to edit login
        /// </summary>
        public static int LoginToDatabase(string username, string inputPassword)
        {
            // Luodaan yhteys
            SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string

            // Luodaan komento ja lisätään sille yhteys
            SQLiteCommand cmd = new SQLiteCommand($"SELECT Password FROM User WHERE Username = @Username", connection);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            // Lisätään tieto komentoon muuttujina
            cmd.Parameters.AddWithValue("@Username", username);

            // Avataan yhteys
            connection.Open();

            // Suoritetaan komento
            var hold = cmd.ExecuteScalar();

            // Suljetaan yhteys
            connection.Close();

            if (hold != null)
            {
                string validPassword = hold.ToString();
                if (validPassword == inputPassword)
                {
                    // Luodaan komento ja lisätään sille yhteys
                    SQLiteCommand cmd3 = new SQLiteCommand($"SELECT UserID FROM User WHERE Username = @Username", connection);
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Connection = connection;
                    // Lisätään tieto komentoon muuttujina
                    cmd3.Parameters.AddWithValue("@Username", username);
                    // Avataan yhteys
                    connection.Open();
                    // Suoritetaan komento
                    var holdID = cmd3.ExecuteScalar();
                    // Suljetaan yhteys
                    connection.Close();
                    if (holdID != null)
                    {
                        string userIDstr = holdID.ToString();
                        Int32.TryParse(userIDstr, out int userID);
                        return userID;
                    }
                    else
                        return 0;
                }
                else
                    return 0;
            }
            else
                return 0;
        }

        public static string GetUserSaltFromSQLite(string username)
        {
            // Luodaan yhteys
            SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string

            // Luodaan komento ja lisätään sille yhteys
            SQLiteCommand cmd = new SQLiteCommand($"SELECT Salt FROM User WHERE Username = @Username", connection);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;

            // Lisätään tieto komentoon muuttujina
            cmd.Parameters.AddWithValue("@Username", username);

            // Avataan yhteys
            connection.Open();

            // Suoritetaan komento
            var hold = cmd.ExecuteScalar();

            // Suljetaan yhteys
            connection.Close();

            if (hold != null)
            {
                string salt = hold.ToString();
                return salt;
            }
            else
                throw new Exception($"Salt can not be acquired!");
        }

        /// <summary>
        /// Below are Methods that are used to Register user
        /// </summary>

        public static bool SaveUserToSQL(string username,string salt, string hashSaltedPwd)
        {
            if (System.IO.File.Exists(filePath)) // tarkistetaan onko tiedosto olemassa
            {
                // Luodaan yhteys
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string

                // Luodaan komento ja lisätään sille yhteys
                SQLiteCommand cmd = new SQLiteCommand($"INSERT INTO User (UserName, Salt, Password) VALUES (@Username, @Salt, @Password);", connection);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                // Lisätään tieto komentoon muuttujina
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Salt", salt);
                cmd.Parameters.AddWithValue("@Password", hashSaltedPwd);

                // Avataan yhteys
                connection.Open();

                // Suoritetaan komento
                cmd.ExecuteNonQuery();

                // Suljetaan komento
                connection.Close();
                return true; 
            }
            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }

        }

        /*
        // NÄMÄ ON NYT YLIMÄÄRÄISIÄ ???
        /// <summary>
        /// Below are Methods that are used to edit Entry
        /// </summary>
        public static string GetAcheTypeFromSQLite(int id)
        {
            if (System.IO.File.Exists(filePath))
            {
                string hold = null;
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT AcheType FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder = cmd.ExecuteScalar();
                if (holder != null)
                    hold = holder.ToString();
                else
                    return hold;
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
                string hold = null;
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT PainLevel FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder = cmd.ExecuteScalar();
                if (holder != null)
                    hold = holder.ToString();
                else
                    return hold;
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
                string hold = null;
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT Medications FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder = cmd.ExecuteScalar();
                if (holder != null)
                    hold = holder.ToString();
                else
                    return hold;
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
                string hold = null;
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT Symptoms FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder = cmd.ExecuteScalar();
                if (holder != null)
                    hold = holder.ToString();
                else
                    return hold;
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
                string hold = null;
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT Triggers FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder = cmd.ExecuteScalar();
                if (holder != null)
                    hold = holder.ToString();
                else
                    return hold;
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
                string hold = null;
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT Reliefs FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder = cmd.ExecuteScalar();
                if (holder != null)
                    hold = holder.ToString();
                else
                    return hold;
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
                string hold = null;
                SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
                connection.Open(); // Avataan yhteys
                // Suoritetaan SQL-komento hakemaan ja palauttamaan AcheType tietyllä AcheID:llä
                SQLiteCommand cmd = new SQLiteCommand($"SELECT Notes FROM Headache WHERE AcheID LIKE {id}", connection);
                var holder = cmd.ExecuteScalar();
                if (holder != null)
                    hold = holder.ToString();
                else
                    return hold;
                connection.Close();
                return hold;
            }
            else // Jos tiedostoa ei löydy, heitetään poikkeus
            {
                throw new System.IO.FileNotFoundException("File not found");
            }
        }

        public static void UpdateEntryToSQLite(string acheType, string painLevel, string medications, string symptoms, string triggers, string reliefs, string notes, int id)
        {
            SQLiteConnection connection = new SQLiteConnection($"Data Source = {filePath}; Version=3;"); // Yhteys + connection string
            connection.Open(); // Avataan yhteys
            Int32.TryParse(painLevel, out int editedPainLevel);
            SQLiteCommand cmd = new SQLiteCommand($"UPDATE Headache SET AcheType='{acheType}, PainLevel={editedPainLevel}, Medications='{medications}', Symptoms='{symptoms}', Triggers='{triggers}', Reliefs='{reliefs}, Notes='{notes}' WHERE AcheID={id};");
        }
        */
    }

    #endregion
}
