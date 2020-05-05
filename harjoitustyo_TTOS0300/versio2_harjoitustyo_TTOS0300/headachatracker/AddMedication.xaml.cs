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
    /// Interaction logic for AddMedication.xaml
    /// </summary>
    public partial class AddMedication : Window
    {
        public AddMedication()
        {
            InitializeComponent();
        }

        private void otherCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            txtAddMedication.Visibility = Visibility.Visible;
            txbAddOtherMed.Visibility = Visibility.Visible;
            
        }

        private void otherCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            txtAddMedication.Visibility = Visibility.Hidden;
            txbAddOtherMed.Visibility = Visibility.Hidden;
        }
    }
}
