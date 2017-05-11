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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace database
{
    /// <summary>
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            listBoxComics.ItemsSource = null;
            var window = new SearchWindow();
            if (window.ShowDialog().Value)
            {
                listBoxComics.ItemsSource = null;
                listBoxComics.ItemsSource = window.SearchComics;

            }
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            listBoxComics.ItemsSource = null;
            MainPage p = new MainPage();
            NavigationService.Navigate(p);
        }
    }
}
