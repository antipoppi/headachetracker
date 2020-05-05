using System;
using System.Collections.Generic;
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
            Headache headacheObj = new Headache();
            AddEntriesUI window = new AddEntriesUI(headacheObj);
            window.Show();
            this.Hide();        // Piilotetaan tämä MainWindow ikkuna
        }
    }
}
