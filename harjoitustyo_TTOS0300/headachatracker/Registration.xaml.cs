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
    /// Interaction logic for Registration_2.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

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
