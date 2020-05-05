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

namespace headachatracker
{
    /// <summary>
    /// Interaction logic for AddReliefs.xaml
    /// </summary>
    public partial class AddReliefs : Window
    {
        public AddReliefs()
        {
            InitializeComponent();
        }

        private void checkOther_Unchecked(object sender, RoutedEventArgs e)
        {
            txtAddRelief.Visibility = Visibility.Hidden;
            txbAddOtherRelief.Visibility = Visibility.Hidden;
        }

        private void checkOther_Checked(object sender, RoutedEventArgs e)
        {
            txtAddRelief.Visibility = Visibility.Visible;
            txbAddOtherRelief.Visibility = Visibility.Visible;
        }
    }
}
