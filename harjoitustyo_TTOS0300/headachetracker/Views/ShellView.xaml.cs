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
using System.Windows.Shapes;
using headachetracker.Models;
using headachetracker.ViewModels;

namespace headachetracker.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        List<HeadacheModel> headache = new List<HeadacheModel>();

        public ShellView()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            HeadacheModel h = new HeadacheModel();

            ShellViewModel.SaveEntry(h);
                    }

        private void dataHeadache_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataHeadache_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            // Ikkuna ladattaessa haetaan tiedot ShellViewModel-luokasta

            try
            {
                dataHeadache.DataContext = headachetracker.ViewModels.ShellViewModel.ReadFromSQLite;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error", "Error", MessageBoxButton.OK);
            }

        }
    }
}
