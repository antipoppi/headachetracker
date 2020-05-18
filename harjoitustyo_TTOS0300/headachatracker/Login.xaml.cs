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
        private Headache headacheObj;
        public Login()
        {
            headacheObj = new Headache();
            // Avataan ikkuna keskellä näyttöä
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            int userID = DatabaseAccess.LoginToDatabase(txbUsername.Text, pwbPassword.Password);
            if (userID != 0)
            {
                headacheObj.UserID = userID;
                //shows mainwindow and closes this window
                MainWindow mainWindow = new MainWindow(headacheObj.UserID);
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed! Username or Password is wrong.", "Error login", MessageBoxButton.OK);
                pwbPassword.Password = "";
            }
            

        }
    }
}
