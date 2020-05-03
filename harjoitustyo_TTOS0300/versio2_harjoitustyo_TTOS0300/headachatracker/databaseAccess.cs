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
        private static string filePath;

        static DatabaseAccess()
        {
            filePath = headachatracker.Properties.Settings.Default.databasePath;
        }

        public static DataTable ReadFromSQLite()
        {
            if (System.IO.File.Exists(filePath))
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

            else
            {
                throw new System.IO.FileNotFoundException("File not found");
            }

        }

    }
}
