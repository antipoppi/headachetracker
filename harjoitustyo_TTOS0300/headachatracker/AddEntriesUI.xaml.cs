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
        public AddEntriesUI()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            headacheObj = new Headache();
        }

        private void btnAddMedications_Click(object sender, RoutedEventArgs e)
        {
            AddMedication medicationWindow = new AddMedication();
            medicationWindow.Owner = this;
            medicationWindow.Show();

        }
        public void UpdateMedication(string medications) // tällä metodilla voidaan päivittää oliota AddMedication-ikkunassa
        {
            headacheObj.Medications = medications;
        }

        private void btnAddSymptoms_Click(object sender, RoutedEventArgs e)
        {
            AddSymptoms symptomWindow = new AddSymptoms();
            symptomWindow.Owner = this;
            symptomWindow.Show();
        }

        public void UpdateSymptoms(string symptoms) // tällä metodilla voidaan päivittää oliota AddSymptoms-ikkunassa
        {
            headacheObj.Symptoms = symptoms;
        }

        private void btnAddReliefs_Click(object sender, RoutedEventArgs e)
        {
            AddReliefs addReliefsWindow = new AddReliefs();
            addReliefsWindow.Owner = this;
            addReliefsWindow.Show();
        }
        public void UpdateReliefs(string reliefs) // tällä metodilla voidaan päivittää oliota AddReliefs-ikkunassa
        {
            headacheObj.Reliefs = reliefs;
        }

        private void btnAddTriggers_Click(object sender, RoutedEventArgs e)
        {
            AddTriggers addTriggersWindow = new AddTriggers();
            addTriggersWindow.Owner = this;
            addTriggersWindow.Show();
        }
        public void UpdateTriggers(string triggers) // tällä metodilla voidaan päivittää oliota AddTriggers-ikkunassa
        {
            headacheObj.Triggers = triggers;
        }
        private void txbNotes_TextChanged(object sender, TextChangedEventArgs e)
        {
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

                //shows mainwindow and closes this window
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }

            catch (InvalidOperationException ex)
            {
                throw new Exception($"Cannot close the window: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // shows mainwindow and closes this window
            this.Close();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            // shows mainwindow when this window is closed
            MainWindow window = new MainWindow();
            window.Show();

        }

        private void btnPreview_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Headache information:\r\n" + headacheObj.Preview(), "Preview", MessageBoxButton.OK);

        }
    }
}
