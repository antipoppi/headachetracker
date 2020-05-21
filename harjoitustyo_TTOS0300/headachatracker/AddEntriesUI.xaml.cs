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
    /// Interaction logic for AcheTypeWindow.xaml
    /// </summary>
    public partial class AddEntriesUI : Window
    {
        private Headache headacheObj;
        public AddEntriesUI(int userID)
        {
            // avataan ikkuna keskellä ruutua ja luodaan olio
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            headacheObj = new Headache();
            headacheObj.UserID = userID;
        }

        private void btnAddMedications_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // avataan uusi ikkuna
                AddMedication medicationWindow = new AddMedication();
                medicationWindow.Owner = this;
                medicationWindow.ShowDialog();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); // Jos tulee virhe, näytetään messagebox
            }
        }
        public void UpdateMedication(string medications) // tällä metodilla voidaan päivittää oliota AddMedication-ikkunassa
        {
            headacheObj.Medications = medications;
        }

        private void btnAddSymptoms_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // avataan uusi ikkuna
                AddSymptoms symptomWindow = new AddSymptoms();
                symptomWindow.Owner = this;
                symptomWindow.ShowDialog();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); // Jos tulee virhe, näytetään messagebox
            }
        }

        public void UpdateSymptoms(string symptoms) // tällä metodilla voidaan päivittää oliota AddSymptoms-ikkunassa
        {
            headacheObj.Symptoms = symptoms;
        }

        private void btnAddReliefs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // avataan uusi ikkuna
                AddReliefs addReliefsWindow = new AddReliefs();
                addReliefsWindow.Owner = this;
                addReliefsWindow.ShowDialog();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); // Jos tulee virhe, näytetään messagebox
            }
        }
        public void UpdateReliefs(string reliefs) // tällä metodilla voidaan päivittää oliota AddReliefs-ikkunassa
        {
            headacheObj.Reliefs = reliefs;
        }

        private void btnAddTriggers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // avataan uusi ikkuna
                AddTriggers addTriggersWindow = new AddTriggers();
                addTriggersWindow.Owner = this;
                addTriggersWindow.ShowDialog();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); // Jos tulee virhe, näytetään messagebox
            }
        }
        public void UpdateTriggers(string triggers) // tällä metodilla voidaan päivittää oliota AddTriggers-ikkunassa
        {
            headacheObj.Triggers = triggers;
        }
        private void txbNotes_TextChanged(object sender, TextChangedEventArgs e)
        {
            // tallennetaan tietoa olioon jos tekstiboksin tekstiä muutetaan
            string hold = txbNotes.Text;
            headacheObj.Notes = hold;
        }

        private void btnAddEntry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // sets headache type to headacheObj
                headacheObj.AcheType = comboAcheType.Text;
                // sets pain intensity to headacheObj
                Int32.TryParse(PainLevel.Text.ToString(), out int painLvl);
                headacheObj.PainLevel = painLvl;
                // adds headacheObj in to database
                DatabaseAccess.AddToSQLite(headacheObj);

                // closes this window
                this.Close();
            }

            catch (InvalidOperationException ex) // Näyttää virheviestin
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // closes this window
            this.Close();

        }


        private void btnPreview_Click(object sender, RoutedEventArgs e)
        {
            // näytetään esikatselu-ikkunassa olion tiedot
            MessageBox.Show("Headache information:\r\n" + headacheObj.Preview(), "Preview", MessageBoxButton.OK);

        }

        private void txbNotes_KeyDown(object sender, KeyEventArgs e)
        {
            // jos painetaan entteriä notes-laatikossa, ohjataan addEntry-napin klikkaustapahtumaan
            if (e.Key == Key.Enter)
            {
                btnAddEntry_Click(sender, e);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // jos painetaan entteriä ikkunassa, ohjataan addEntry-napin klikkaustapahtumaan
            if (e.Key == Key.Enter)
            {
                btnAddEntry_Click(sender, e);
            }
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = calendar.SelectedDate.Value.ToString("yyyy-MM-dd");
            headacheObj.Date = selected;
        }
    }
}
