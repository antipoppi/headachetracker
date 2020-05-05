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
            InitializeComponent();
            headacheObj = new Headache();
        }

        private void btnAddMedications_Click(object sender, RoutedEventArgs e)
        {
            AddMedication medicationWindow = new AddMedication(headacheObj);
            medicationWindow.Show();

        }

        private void btnAddSymptoms_Click(object sender, RoutedEventArgs e)
        {
            AddSymptoms symptomWindow = new AddSymptoms();
            symptomWindow.Show();
        }

        private void btnAddReliefs_Click(object sender, RoutedEventArgs e)
        {
            AddReliefs addReliefsWindow = new AddReliefs();
            addReliefsWindow.Show();
        }

        private void btnAddTriggers_Click(object sender, RoutedEventArgs e)
        {
            AddTriggers addTriggersWindow = new AddTriggers();
            addTriggersWindow.Show();
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

                DatabaseAccess.AddToSQLite(headacheObj);
            }

            catch (Exception ex)
            {

            }
        }
    }
}
