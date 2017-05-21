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
    /// Логика взаимодействия для NewComicsPage.xaml
    /// </summary>
    public partial class NewComicsPage : Page
    {
        public NewComicsPage(List<Publisher> publishers)
        {
            InitializeComponent();
            comboBoxPublisher.ItemsSource = publishers;
            
        }

        Comics _newComics;
        public Comics NewComics
        {
            get
            {
                return _newComics;
            }
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            int year;
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("You have to  enter the name");
                textBoxName.Focus();
                Logger.Instance.Log("Error occured while adding the new comics");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxAuthor.Text))
            {
                MessageBox.Show("You have to  enter the author");
                Logger.Instance.Log("Error occured while adding the new comics");
                textBoxAuthor.Focus();
                return;
            }
            if (!int.TryParse(textBoxYear.Text, out year))
            {
                MessageBox.Show("You have to  enter the year");
                Logger.Instance.Log("Error occured while adding the new comics");
                textBoxYear.Focus();
                return;
            }
            if (comboBoxPublisher.SelectedItem == null)
            {
                MessageBox.Show("You have to  select the publisher");
                Logger.Instance.Log("Error occured while adding the new comics");
                comboBoxPublisher.Focus();
                return;
            }


            _newComics = new Comics(textBoxName.Text, textBoxAuthor.Text, year);
            _newComics.Publisher = comboBoxPublisher.SelectedItem as Publisher;
            Logger.Instance.Log("New comics added");
            MainPage p = new MainPage(NewComics);
            NavigationService.Navigate(p);
        }

        private void comboBoxPublisher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxPublisher.SelectedIndex !=-1)
                textBlock.Visibility = Visibility.Hidden;
        }
    }
}
