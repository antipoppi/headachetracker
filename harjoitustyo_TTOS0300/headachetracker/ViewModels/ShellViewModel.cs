using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.Threading.Tasks;
using System.Data.SQLite;
using headachetracker.Models;
using System.Configuration;
using System.Data;
using Dapper;

namespace headachetracker.ViewModels
{
    public class ShellViewModel : Screen
    {
		public static void SaveEntry(HeadacheModel headache)
		{
            /*

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("Insert into Headache (PainLevel) values (@PainLevel)", headache);
            }
            */

        }

        public static DataTable ReadFromSQLite()
        {
            if (System.IO.File.Exists(".\\SQLheadache.db"))
            {
                SQLiteConnection connection = new SQLiteConnection(LoadConnectionString()); // Yhteys + connection string
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

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString; // Etsii connection stringin app.configista
        }
    }
}
