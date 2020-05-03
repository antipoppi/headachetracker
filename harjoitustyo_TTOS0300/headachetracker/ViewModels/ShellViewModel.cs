using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Sql;
using System.Data.SqlClient;
using headachetracker.Models;
using System.Configuration;
using System.Data;
using Dapper;

namespace headachetracker.ViewModels
{
    public class ShellViewModel : Screen
    {
        public static List<HeadacheModel> LoadEntries()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HeadacheModel>("Select * from Headache", new DynamicParameters());
                return output.ToList();
            }
        }

		public static void SaveEntry(HeadacheModel headache)
		{
            // Tää ei oo valmis

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("Insert into Headache (PainLevel) values (@PainLevel)", headache);
            }

        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString; // Etsii connection stringin app.configista
        }
    }
}
