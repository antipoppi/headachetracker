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
            // Ikkuna ladattaessa haetaan tiedot ShellViewModel-luokasta

            try
            {
                dataHeadache.DataContext = headachatracker.DatabaseAccess.ReadFromSQLite();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTesti_Click(object sender, RoutedEventArgs e)
        {
            AcheTypeWindow window = new AcheTypeWindow();
            window.Show();
        }
    }
}
