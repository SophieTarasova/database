using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        const string FileName = "database.txt";
        public MainPage()
        {
            InitializeComponent();
            LoadData();
        }
        private void RefreshListBox()
        {
            listBoxComics.ItemsSource = null;
            listBoxComics.ItemsSource = ((MainWindow)Application.Current.MainWindow)._comics;
        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewComicsWindow();
            if (window.ShowDialog().Value)
            {
                ((MainWindow)Application.Current.MainWindow)._comics.Add(window.NewComics);
                SaveData();
                RefreshListBox();
            }

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxComics.SelectedIndex != -1)
            {
                ((MainWindow)Application.Current.MainWindow)._comics.RemoveAt(listBoxComics.SelectedIndex);
                SaveData();
                RefreshListBox();
            }
        }

        private void listBoxComics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected index = -1, we set IsEnabled to false
            buttonDelete.IsEnabled = listBoxComics.SelectedIndex != -1;
        }
        private void SaveData()
        {
            using (var sw = new StreamWriter(FileName))
            {
                foreach (var c in ((MainWindow)Application.Current.MainWindow)._comics)
                {
                    sw.WriteLine($"{c.Name}:{c.Publisher.Name}:{c.Publisher.Site}:{c.Author}:{c.Year}");
                }
            }
        }

       private void LoadData()
        {
            try
            {
                // _comics = new List<Comics>();
                //_publishers = new List<Publisher>();

                using (var sr = new StreamReader(FileName))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var parts = line.Split(':');
                        if (parts.Length == 5)
                        {

                            int i = 0;
                            while (i < ((MainWindow)Application.Current.MainWindow)._publishers.Count && ((MainWindow)Application.Current.MainWindow)._publishers[i].Name != parts[1])
                                i++;
                            Publisher p;
                            if (i < ((MainWindow)Application.Current.MainWindow)._publishers.Count)
                                p = ((MainWindow)Application.Current.MainWindow)._publishers[i];  // Use existing faculty
                            else
                            {
                                // Create a new faculty and add it to the list
                                p = new Publisher(parts[1], parts[2]);
                                ((MainWindow)Application.Current.MainWindow)._publishers.Add(p);
                            }

                            var comics = new Comics(parts[0], parts[3], int.Parse(parts[4]));
                            comics.Publisher = p;
                            ((MainWindow)Application.Current.MainWindow)._comics.Add(comics);
                        }
                    }


                }
            }
            catch (FileNotFoundException)
            {
                // Файла с данными нет, создаем один факультет по умолчанию, чтобы можно было
                // выбирать его при добавлении преподавателей
                ((MainWindow)Application.Current.MainWindow)._publishers.Add(new Publisher("DC", "www.dccomics.com"));
            }
            catch
            {
                MessageBox.Show("Ошибка чтения из файла");
            }
            RefreshListBox();
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            var window = new SearchWindow();
            if (window.ShowDialog().Value)
            {
                listBoxComics.ItemsSource = null;
                listBoxComics.ItemsSource = window.SearchComics;
                //SearchPage p = new SearchPage();
                //NavigationService.Navigate(p);
            }
        }
    }
}

