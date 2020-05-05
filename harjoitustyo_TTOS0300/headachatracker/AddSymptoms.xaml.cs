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
    /// Interaction logic for AddSymptoms.xaml
    /// </summary>
    public partial class AddSymptoms : Window
    {
        public AddSymptoms()
        {
            InitializeComponent();
        }

        private void checkOther_Checked(object sender, RoutedEventArgs e)
        {
            txtAddSymptom.Visibility = Visibility.Visible;
            txbAddOtherSymptom.Visibility = Visibility.Visible;
        }

        private void checkOther_Unchecked(object sender, RoutedEventArgs e)
        {
            txtAddSymptom.Visibility = Visibility.Hidden;
            txbAddOtherSymptom.Visibility = Visibility.Hidden;
        }
    }
}
