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
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
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

        private void btnAddMed_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // haetaan kaikki valitut checkboxit
                var list = (this.Content as Panel).Children.OfType<CheckBox>().Where(x => x.IsChecked == true);
                if (list != null)
                {
                    // lisätään kyseisten checkboxien sisältö hold-stringiin
                    string hold = null;
                    int counter = 0;
                    try
                    {
                        foreach (var item in list)
                        {
                            {
                                counter++;
                                hold += item.Content;
                                if (counter != list.Count())
                                {
                                    hold += ", ";
                                }
                            }
                        }
                        // päivitetään AddEntriesUI:n oliota kyseisillä helpotuksilla
                        ((AddEntriesUI)this.Owner).UpdateReliefs(hold);
                        this.Hide();
                    }
                    catch (OverflowException)
                    {

                        throw;
                    }
                }
                else
                    return;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
