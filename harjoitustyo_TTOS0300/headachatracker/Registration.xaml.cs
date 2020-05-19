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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txbUsername.Text;
            string pwd1 = txbPass1.Text;
            string pwd2 = txbPass2.Text;

            // tarkistetaan onko salasanakenttä tyhjä
            if (pwd1.Length <= 5)
            {
                MessageBox.Show($"Salasanan pitää olla pitempi kuin 5 merkkiä");
                txbPass1.Text = "";
                txbPass2.Text = "";
                return;
            }

            // tarkistetaan onko käyttäjänimi vapaana
            bool res = DatabaseAccess.CheckIfUserExistInSQLite(username);
            if (res == true)
            {
                MessageBox.Show($"User '{username}' is already in use.", "Information", MessageBoxButton.OK);
                txbUsername.Text = "";
                txbPass1.Text = "";
                txbPass2.Text = "";
                return;
            }
            // tarkistetaan täsmääkö salasanat
            if (pwd1 != pwd2)
            {
                MessageBox.Show("Password doesn't match!", "Error", MessageBoxButton.OK);
                txbPass1.Text = "";
                txbPass2.Text = "";
                return;
            }
            // luodaan käyttäjälle salt
            string salt = Security.ComputeSaltString();
            // saltataan ja hashataan salasana
            string pwdHashSalted = Security.ComputeSha256Hash(pwd1 + salt);
            // tallennetaan tiedot tietokantaan
            bool res2 = DatabaseAccess.SaveUserToSQL(username, salt, pwdHashSalted);
            if (res2 == true)
            {
                MessageBox.Show($"User '{username}' saved succesfully.", "Information", MessageBoxButton.OK);
                Login loginWindow = new Login();
                loginWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show($"User '{username}' can not be saved.", "Error", MessageBoxButton.OK);
                txbUsername.Text = "";
                txbPass1.Text = "";
                txbPass2.Text = "";
            }
                


        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            // poistetaan tekstilaatikoiden sisältö, jos käyttäjä painaa reset-nappulaa
            txbUsername.Text = "";
            txbPass1.Text = "";
            txbPass2.Text = "";
        }
    }
}
