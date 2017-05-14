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
                byte[] password = md5.ComputeHash(Encoding.ASCII.GetBytes("comics"));
              string pass =  Convert.ToBase64String(password);
            if ((textBoxLogin.Text == "sonjechka") && (h == pass))
            {
                Logger.Instance.Log("Выполнен авторизованный вход");
                MainPage p = new MainPage();
                NavigationService.Navigate(p);

            }
            else
            { Logger.Instance.Log("Была произведена попытка войти с неверным паролем/логином");
                MessageBox.Show("Вы ввели неправильный логин/пароль"); }
        }

        private void buttonNonAuthorized_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            Logger.Instance.Log("Выполнен неавторизованный вход");
            MainPage p = new MainPage(s);
            NavigationService.Navigate(p);
        }
    }
}
