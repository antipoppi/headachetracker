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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            // Avataan ikkuna keskellä näyttöä
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            // kun painetaan rekisteröintinappia, yritetään avata rekisteröinti-ikkuna
            try
            {
                Registration registrationWindow = new Registration();
                registrationWindow.Show();
                this.Close();
            }
            catch (InvalidOperationException ex) // virheviesti
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); // Jos tulee virhe, näytetään messagebox
            }

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txbUsername.Text != "" && pwbPassword.Password != "")
            {
                // Tarkistetaan löytyykö käyttäjää tällä nimellä
                bool userExists = DatabaseAccess.CheckIfUserExistInSQLite(txbUsername.Text);
                if (userExists == true)
                {
                    // Hashataan syötetty salasana
                    string rawPwd = pwbPassword.Password;
                    string salt = DatabaseAccess.GetUserSaltFromSQLite(txbUsername.Text);
                    string rawPwdSalted = rawPwd + salt;
                    string hashedAndSaltedInput = Security.ComputeSha256Hash(rawPwdSalted);

                    // Tarkistetaan onko syötetty salasana oikein (verrataan saltattua ja hashattua salasanaa tietokannassa olevaan salted hashiin kyseisellä käyttäjänimellä)
                    int userID = DatabaseAccess.LoginToDatabase(txbUsername.Text, hashedAndSaltedInput);

                    if (userID != 0)
                    {
                        try
                        {
                            // Välitetään userID pääikkunaan
                            MainWindow mainWindow = new MainWindow(userID);
                            mainWindow.Show();
                            this.Close();
                        }
                        catch (InvalidOperationException ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); // Jos tulee virhe, näytetään messagebox
                        }
                    }
                    else
                    {
                        // jos käyttäjänimi/salasana on väärin ilmoitetaan siitä
                        MessageBox.Show("Login failed! Username or Password is wrong.", "Error login", MessageBoxButton.OK);
                        pwbPassword.Password = "";
                    }
                }
                else
                {
                    // jos käyttäjänimeä ei löydy
                    MessageBox.Show("Login failed! Username not found", "Error login", MessageBoxButton.OK);
                    txbUsername.Text = "";
                    pwbPassword.Password = "";
                }
            }
            else
            {
                MessageBox.Show("No username or password inputted!", "Input username or password", MessageBoxButton.OK);
            }
        }

        private void pwbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // jos painetaan entteriä salasanakohdassa, ohjataan login-napin klikkaustapahtumaan
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
