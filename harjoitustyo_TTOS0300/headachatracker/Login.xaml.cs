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
            try
            {
                Registration registrationWindow = new Registration();
                registrationWindow.Show();
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK); // Jos tulee virhe, näytetään messagebox
            }

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
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

        private void pwbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
