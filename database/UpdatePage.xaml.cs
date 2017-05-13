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
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
    {
        public UpdatePage(Comics comics, List<Publisher> publishers, int index)
        {
            InitializeComponent();
            comboBoxPublisher.ItemsSource = publishers ;
           textBoxName.Text = comics.Name;
            textBoxAuthor.Text = comics.Author;
            textBoxYear.Text = (comics.Year).ToString();
            this.index = index;
        }
        Comics _newComics;
        public Comics NewComics
        {
            get
            {
                return _newComics;
            }
        }
          int index;


        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Необходимо ввести название");
                Logger.Instance.Log("Ошибка редактирования комикса");
                textBoxName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxAuthor.Text))
            {
                MessageBox.Show("Необходимо ввести имя автора");
                Logger.Instance.Log("Ошибка редактирования комикса");
                textBoxAuthor.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace((textBoxYear.Text).ToString()))
            {
                MessageBox.Show("Необходимо ввести год");
                Logger.Instance.Log("Ошибка редактирования комикса");
                textBoxYear.Focus();
                return;
            }
            if (comboBoxPublisher.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать издательство");
                Logger.Instance.Log("Ошибка редактирования комикса");
                comboBoxPublisher.Focus();
                return;
            }
            _newComics = new Comics(textBoxName.Text, textBoxAuthor.Text, int.Parse(textBoxYear.Text));
            _newComics.Publisher = comboBoxPublisher.SelectedItem as Publisher;
            Logger.Instance.Log("Было произведено редактирования комикса");
            MainPage p = new MainPage(NewComics, index);
            NavigationService.Navigate(p);

        }
    }
}
