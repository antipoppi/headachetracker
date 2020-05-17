using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
    /// Interaction logic for EditEntry.xaml
    /// </summary>
    public partial class EditEntry : Window
    {
        private Headache headacheObj;
        public EditEntry(int id)
        {
            InitializeComponent();

            headacheObj = new Headache();

            headacheObj.AcheID = id;
            DatabaseAccess.GetHeadacheObjPFromSQLite(headacheObj, id);

            txbAcheType.Text = headacheObj.AcheType;
            txbPainLevel.Text = headacheObj.PainLevel.ToString();
            txbMedications.Text = headacheObj.Medications;
            txbSymptoms.Text = headacheObj.Symptoms;
            txbTriggers.Text = headacheObj.Triggers;
            txbReliefs.Text = headacheObj.Reliefs;
            txbNotes.Text = headacheObj.Notes;
        }

        private void txbAcheType_TextChanged(object sender, TextChangedEventArgs e)
        {
            string hold = txbAcheType.Text;
            headacheObj.AcheType = hold;
        }

        private void txbPainLevel_TextChanged(object sender, TextChangedEventArgs e)
        {
            // tämä metodi tarkistaa että syötetty on integer ja pitää olla 1-10 väliltä
            string hold = txbPainLevel.Text;
            if (Int32.TryParse(hold, out int hold2))
            {
                if (hold2 >= 1 && hold2 <= 10)
                    headacheObj.PainLevel = hold2;
                else
                {
                    MessageBox.Show("PainLevel can only be 1-10!", "Error", MessageBoxButton.OK);
                    txbPainLevel.Text = "";
                }
            }
            else if (hold == null || hold == "")
                return;
            else
            {
                MessageBox.Show("PainLevel can only be 1-10!", "Error", MessageBoxButton.OK);
                txbPainLevel.Text = "";
            }
                
        }

        private void txbMedications_TextChanged(object sender, TextChangedEventArgs e)
        {
            string hold = txbMedications.Text;
            headacheObj.Medications = hold;
        }

        private void txbSymptoms_TextChanged(object sender, TextChangedEventArgs e)
        {
            string hold = txbSymptoms.Text;
            headacheObj.Symptoms = hold;
        }

        private void txbTriggers_TextChanged(object sender, TextChangedEventArgs e)
        {
            string hold = txbTriggers.Text;
            headacheObj.Triggers = hold;
        }

        private void txbReliefs_TextChanged(object sender, TextChangedEventArgs e)
        {
            string hold = txbReliefs.Text;
            headacheObj.Reliefs = hold;
        }
        private void txbNotes_TextChanged(object sender, TextChangedEventArgs e)
        {
            string hold = txbNotes.Text;
            headacheObj.Notes = hold;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void btnAddEdit_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
