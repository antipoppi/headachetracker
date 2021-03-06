﻿using System;
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
            // avataan ikkuna keskellä ruutua
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void checkOther_Checked(object sender, RoutedEventArgs e)
        {
            // jos tietty ruutu valitaan, näytetään kaksi muuta komponenttia
            txtAddSymptom.Visibility = Visibility.Visible;
            txbAddOtherSymptom.Visibility = Visibility.Visible;
        }

        private void checkOther_Unchecked(object sender, RoutedEventArgs e)
        {           
            // piilotetaan komponentit, jos rasti otetaan pois valinnasta
            txtAddSymptom.Visibility = Visibility.Hidden;
            txbAddOtherSymptom.Visibility = Visibility.Hidden;
        }

        private void btnAddSymptoms_Click(object sender, RoutedEventArgs e)
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
                        if (checkOther.IsChecked == true) // jos Other on valittu, lisätään kyseisen textboxin sisältö
                        {
                            hold += $": {txbAddOtherSymptom.Text}";
                        }
                        // päivitetään AddEntriesUI:n oliota kyseisillä oireilla
                        ((AddEntriesUI)this.Owner).UpdateSymptoms(hold);
                        this.Close();
                    }
                    catch (OverflowException ex) // virheiden tarkistus
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); // Jos tulee virhe, näytetään messagebox
                    }
                }
                else
                    return;
            }
            catch (ArgumentNullException ex) // virheiden tarkistus
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); // Jos tulee virhe, näytetään messagebox
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // suljetaan ikkuna cancel-napista painettaessa
            this.Close();
        }
    }
}
