using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace headachatracker
{
    /// <summary>
    /// Interaction logic for EditEntry.xaml
    /// </summary>
    public partial class EditEntry : Window
    {
        public EditEntry(int id)
        {
            InitializeComponent();

            txbAcheType.Text = DatabaseAccess.GetAcheTypeFromSQLite(id);
            txbPainLevel.Text = DatabaseAccess.GetPainLevelFromSQLite(id);
            txbMedications.Text = DatabaseAccess.GetMedicationsFromSQLite(id);
            txbSymptoms.Text = DatabaseAccess.GetSymptomsFromSQLite(id);
            txbTriggers.Text = DatabaseAccess.GetTriggersFromSQLite(id);
            txbReliefs.Text = DatabaseAccess.GetReliefsFromSQLite(id);
            txbNotes.Text = DatabaseAccess.GetNotesFromSQLite(id);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
