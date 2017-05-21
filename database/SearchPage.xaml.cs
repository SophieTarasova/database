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
        public SearchPage(List<Publisher> publishers)
        {
            InitializeComponent();
            comboBoxPublisher.ItemsSource = publishers;
            listBoxComics.ItemsSource = null;
           

        }

        

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._comics.Clear();
            buttonSearch.IsEnabled = true;
            MainPage p = new MainPage();
            NavigationService.Navigate(p);
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {

            listBoxComics.Items.Clear();
            listBoxComics.Visibility = Visibility.Visible;
            foreach (var comics in MainWindow._comics)
            {
                if ((textBoxName.Text == comics.Name || textBoxName.Text == "") && (textBoxAuthor.Text == comics.Author || textBoxAuthor.Text == "") && (textBoxYear.Text == comics.Year.ToString() || textBoxYear.Text == "") && (comboBoxPublisher.Text == comics.Publisher.Name || comboBoxPublisher.Text == ""))
                {
                    listBoxComics.Items.Add(comics);
                   
                }
            }

           MainWindow._comics.Clear();
            buttonSearch.IsEnabled = false;
            //listBoxComics.ItemsSource = _searchComics;
        }

    
        private void comboBoxPublisher_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            if (comboBoxPublisher.SelectedIndex != -1)
                textBlock.Visibility = Visibility.Hidden;
        }
    }
}
            
             
    
            
        
    

