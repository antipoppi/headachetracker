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

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Hashataan syötetty salasana
            string rawPwd = pwbPassword.Password;
            string hashedRawPwd = Security.ComputeSha256Hash(rawPwd);

            // Tarkistetaan onko syötetty salasana oikein (verrataan hashattua salasanaan tietokannassa olevaan hashiin kyseisellä käyttäjänimellä)
            int userID = DatabaseAccess.LoginToDatabase(txbUsername.Text, hashedRawPwd);

            if (userID != 0)
            {
                // Välitetään userID pääikkunaan
                MainWindow mainWindow = new MainWindow(userID);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                // jos käyttäjänimi/salasana on väärin ilmoitetaan siitä
                MessageBox.Show("Login failed! Username or Password is wrong.", "Error login", MessageBoxButton.OK);
                pwbPassword.Password = "";
            }
            

        }

    }
}
