using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace database
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page

    {

        public LoginPage()
        {
            InitializeComponent();

        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(passwordBox.Password));
            string h = Convert.ToBase64String(hash);
            byte[] password = md5.ComputeHash(Encoding.ASCII.GetBytes("hsepassword"));
            string pass = Convert.ToBase64String(password);
            if ((textBoxLogin.Text == "hseguest") && (h == pass))
            {
                Logger.Instance.Log("Authorized access");
                MainPage p = new MainPage();
                NavigationService.Navigate(p);

            }
            else
            { Logger.Instance.Log("Error at authorization");
                MessageBox.Show("Wrong login/password"); }
        }

        private void buttonNonAuthorized_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            Logger.Instance.Log("Non-authorized access");
            MainPage p = new MainPage(s);
            NavigationService.Navigate(p);
        }

       

       

        private void buttonLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            buttonLogin.FontSize = 30;
        }

        private void buttonLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            buttonLogin.FontSize = 20;
        }

        private void buttonNonAuthorized_MouseEnter(object sender, MouseEventArgs e)
        {
            buttonNonAuthorized.FontSize = 20;
        }

        private void buttonNonAuthorized_MouseLeave(object sender, MouseEventArgs e)
        {
            buttonNonAuthorized.FontSize = 15;
        }
    }
}
