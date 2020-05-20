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
            // avataan ikkuna keskellä ruutua
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txbUsername.Text;
            string pwd1 = pwbPass1.Password;
            string pwd2 = pwbPass2.Password;

            // tarkistetaan onko salasanakenttä tyhjä
            if (pwd1.Length <= 5)
            {
                MessageBox.Show($"The password needs to be at least 6 characters long.");
                pwbPass1.Password = "";
                pwbPass2.Password = "";
                return;
            }

            // tarkistetaan onko käyttäjänimi vapaana
            bool res = DatabaseAccess.CheckIfUserExistInSQLite(username);
            if (res == true)
            {
                MessageBox.Show($"Username '{username}' is already in use.", "Information", MessageBoxButton.OK);
                txbUsername.Text = "";
                pwbPass1.Password = "";
                pwbPass2.Password = "";
                return;
            }
            // tarkistetaan täsmääkö salasanat
            if (pwd1 != pwd2)
            {
                MessageBox.Show("Password doesn't match!", "Error", MessageBoxButton.OK);
                pwbPass1.Password = "";
                pwbPass2.Password = "";
                return;
            }
            // luodaan käyttäjälle salt
            string salt = Security.ComputeSaltString();
            // saltataan ja hashataan salasana
            string pwdHashSalted = Security.ComputeSha256Hash(pwd1 + salt);
            // tallennetaan tiedot tietokantaan
            bool res2 = DatabaseAccess.SaveUserToSQL(username, salt, pwdHashSalted);
            try
            {   // Näytetään joko onnistumisboksi tai epäonnistumisboksi, kun tallennetaan
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
                    pwbPass1.Password = "";
                    pwbPass2.Password = "";
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Mennään takaisin login-ikkunaan, jos painetaan cancel-nappia
            try
            {
                Login loginWindow = new Login();
                loginWindow.Show();
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            // poistetaan tekstilaatikoiden ja tekstien sisältö, jos käyttäjä painaa reset-nappulaa
            txbUsername.Text = "";
            pwbPass1.Password = "";
            pwbPass2.Password = "";
            txtLengthMessage.Text = "";
            txtMatchMessage.Text = "";
        }

        private void pwbPass1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckPassword();
        }

        private void pwbPass2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            CheckPassword();
        }

        private void CheckPassword()
        {
            string pwd1 = pwbPass1.Password;
            string pwd2 = pwbPass2.Password;

            if (pwd1 != pwd2)
            {
                txtMatchMessage.Text = "Passwords don't match!";
            }

            if (pwd1.Length <= 5 || pwd2.Length <= 5)
            {
                txtLengthMessage.Text = "Password needs to be at least 6 characters long.";
            }



        }

    }
}
