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
        private Headache headacheObj; // yksityinen olio käsittelyä varten
        public EditEntry(int userID, int entryID)
        {
            InitializeComponent();

            // luodaan uusi olio
            headacheObj = new Headache();

            headacheObj.UserID = userID;
            headacheObj.AcheID = entryID;
            DatabaseAccess.GetHeadacheObjPFromSQLite(headacheObj, entryID); // Haetaan tietoa tietokannasta


            // laitetaan tietokannan tiedot olion kautta tekstilaatikkoihin
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
            // tallennetaan tekstilaatikkoon kirjoitettua tietoa
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
            else // virheiden tarkistus
            {
                MessageBox.Show("PainLevel can only be 1-10!", "Error", MessageBoxButton.OK);
                txbPainLevel.Text = "";
            }
                
        }

        private void txbMedications_TextChanged(object sender, TextChangedEventArgs e)
        {
            // tallennetaan tekstilaatikkoon kirjoitettua tietoa
            string hold = txbMedications.Text;
            headacheObj.Medications = hold;
        }

        private void txbSymptoms_TextChanged(object sender, TextChangedEventArgs e)
        {           
            // tallennetaan tekstilaatikkoon kirjoitettua tietoa
            string hold = txbSymptoms.Text;
            headacheObj.Symptoms = hold;
        }

        private void txbTriggers_TextChanged(object sender, TextChangedEventArgs e)
        {  
            // tallennetaan tekstilaatikkoon kirjoitettua tietoa
            string hold = txbTriggers.Text;
            headacheObj.Triggers = hold;
        }

        private void txbReliefs_TextChanged(object sender, TextChangedEventArgs e)
        {          
            // tallennetaan tekstilaatikkoon kirjoitettua tietoa
            string hold = txbReliefs.Text;
            headacheObj.Reliefs = hold;
        }
        private void txbNotes_TextChanged(object sender, TextChangedEventArgs e)
        {            
            // tallennetaan tekstilaatikkoon kirjoitettua tietoa
            string hold = txbNotes.Text;
            headacheObj.Notes = hold;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // suljetaan tämä ikkuna painettaessa cancel-nappia
            this.Close();
        }


        private void btnAddEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // lisätään tiedot tietokantaan
                DatabaseAccess.SaveEditedEntryToSQLite(headacheObj);
                // sulkee tämän ja näyttää pääikkunan
                this.Close();
            }
            catch (InvalidOperationException ex) // Näyttää virheviestin
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }


    }
}
