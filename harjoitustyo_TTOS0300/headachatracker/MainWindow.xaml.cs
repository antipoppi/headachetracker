using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace headachatracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Headache headacheObj;
        public MainWindow(int userID)
        {
            InitializeComponent();
            // luodaan headache-olio ja asetetaan sen userID:ksi parametri userID
            headacheObj = new Headache();
            headacheObj.UserID = userID;
            // avataan ikkuna keskellä ruutua
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // Ikkunaa ladattaessa haetaan tiedot DatabaseAccess-luokasta ja välitetään haettavaksi käyttäjäID:n merkinnät

            try
            {
                dataHeadache.DataContext = headachatracker.DatabaseAccess.ReadFromSQLite(headacheObj.UserID);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); // Jos tulee virhe, näytetään messagebox
            }
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Avataan merkintöjen lisäämistä varten uusi ikkuna
                AddEntriesUI window = new AddEntriesUI(headacheObj.UserID);
                window.ShowDialog();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); // Jos tulee virhe, näytetään messagebox
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // poistetaan valittu tapahtuma id:n perusteella
            var dt = (DataTable)dataHeadache.DataContext;
            if (dataHeadache.SelectedCells.Count == 0)
            {
                return;
            }
            else
            {
                Int32.TryParse(dt.Rows[dataHeadache.SelectedIndex][0].ToString(), out int entryID);
                // varmistetaan halutaanko poistaa
                var result = MessageBox.Show($"Do you really want to delete selected entry (AcheID{entryID})?", "Entry delete confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    if (headachatracker.DatabaseAccess.DeleteFromSQLite(entryID))
                        MessageBox.Show($"Selected entry deleted successfully", "", MessageBoxButton.OK);
                    else
                        MessageBox.Show($"Selected entry cannot be deleted", "", MessageBoxButton.OK);
                    // päivitetään datagrid tietokannasta
                    dataHeadache.DataContext = headachatracker.DatabaseAccess.ReadFromSQLite(headacheObj.UserID);
                }
            }
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult quit = MessageBox.Show("Do you really want to exit the application?", "Exit confirmation", MessageBoxButton.YesNo);
            
            switch(quit) // tarkistetaan haluaako käyttäjä sulkea ohjelman
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Application closing.", "Closing", MessageBoxButton.OK);
                    Environment.Exit(0);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // kun painetaan edit-nappulaa, avataan uusi ikkuna ja lähetetään sille valittu indeksi. piilotetaan tämä ikkuna
            if (dataHeadache.SelectedCells.Count > 0)
            {
                try
                {
                    var dt = (DataTable)dataHeadache.DataContext;
                    Int32.TryParse(dt.Rows[dataHeadache.SelectedIndex][0].ToString(), out int entryID);
                    EditEntry editEntry = new EditEntry(headacheObj.UserID, entryID);
                    editEntry.ShowDialog();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
                }
            }
            else // jos nappia painetaan, mutta mitään ei ole valittuna, tulee virheviesti
            {
                MessageBox.Show("You haven't selected anything!", "Error", MessageBoxButton.OK);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            // Logout napista avataan login-ikkuna ja suljetaan tämä ikkuna
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }
    }
}
