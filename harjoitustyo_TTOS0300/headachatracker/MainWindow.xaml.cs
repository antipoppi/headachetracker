using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace headachatracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // Ikkuna ladattaessa haetaan tiedot DatabaseAccess-luokasta

            try
            {
                dataHeadache.DataContext = headachatracker.DatabaseAccess.ReadFromSQLite();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); // Jos tulee virhe, näytetään messagebox
            }
        }


        private void btnTesti_Click(object sender, RoutedEventArgs e)
        {
            // Avataan merkintöjen lisäämistä varten uusi ikkuna
            AddEntriesUI window = new AddEntriesUI();
            window.Show();
            this.Hide();        // Piilotetaan tämä MainWindow ikkuna
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // poistetaan valittu tapahtuma id:n perusteella
            var dt = (DataTable)dataHeadache.DataContext;
            if (dataHeadache.SelectedIndex == 0)
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
                    dataHeadache.DataContext = headachatracker.DatabaseAccess.ReadFromSQLite();
                }
            }
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult quit = MessageBox.Show("Do you really want to exit the application?", "Exit confirmation", MessageBoxButton.YesNo);
            
            switch(quit)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Application closing.", "Closing", MessageBoxButton.OK);
                    Environment.Exit(0);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // closing the applicaiton when this window is closed
            Environment.Exit(0);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var dt = (DataTable)dataHeadache.DataContext;
            Int32.TryParse(dt.Rows[dataHeadache.SelectedIndex][0].ToString(), out int entryID);
            EditEntry editEntry = new EditEntry(entryID);
            editEntry.Show();
            this.Hide();

        }
    }
}
