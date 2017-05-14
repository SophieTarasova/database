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
using System.Runtime.Serialization.Formatters.Binary;

namespace database
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        //const string FileName = "database.txt";
        public MainPage()
        {
            InitializeComponent();
           
            listBoxComics.ItemsSource = null;
            RefreshListBox();
           // LoadData();
          Deserialization();
        }

        public MainPage(string s)
        {
            InitializeComponent();
            listBoxComics.ItemsSource = null;
           // LoadData();
            Deserialization();
            buttonAdd.Visibility = Visibility.Hidden;
            buttonDelete.Visibility = Visibility.Hidden;
            buttonUpdate.Visibility = Visibility.Hidden;
            buttonSearch.Visibility = Visibility.Hidden;
        }
        public MainPage(Comics _updatedComics, int index)
        {
            InitializeComponent();
           MainWindow._comics[index] = _updatedComics;
            RefreshListBox();
            Serialization();
          //  SaveData();
        }
        public MainPage(Comics NewComics)
        {
            InitializeComponent();
            MainWindow._comics.Add(NewComics);
         //   SaveData();
            Serialization();
            RefreshListBox();
        }
        private void RefreshListBox()
        {
            listBoxComics.ItemsSource = null;
            listBoxComics.ItemsSource = MainWindow._comics;
        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
           NewComicsPage p = new NewComicsPage(MainWindow._publishers);
            NavigationService.Navigate(p);

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxComics.SelectedIndex != -1)
            {
               MainWindow._comics.RemoveAt(listBoxComics.SelectedIndex);
                Logger.Instance.Log("Было произведено удаление комикса");
                Serialization();
           //     SaveData();
                RefreshListBox();
            }
        }

        private void listBoxComics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonDelete.IsEnabled = listBoxComics.SelectedIndex != -1;
            buttonUpdate.IsEnabled= listBoxComics.SelectedIndex != -1;
        }
     /*   private void SaveData()
        {
            using (var sw = new StreamWriter(FileName))
            {
                foreach (var c in ((MainWindow)Application.Current.MainWindow)._comics)
                {
                    sw.WriteLine($"{c.Name}:{c.Publisher.Name}:{c.Publisher.Site}:{c.Author}:{c.Year}");
                }
            }
        }*/

   /*    private void LoadData()
        {
            try
            {

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
                                p = ((MainWindow)Application.Current.MainWindow)._publishers[i];  
                            else
                            {
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
                ((MainWindow)Application.Current.MainWindow)._publishers.Add(new Publisher("DC", "www.dccomics.com"));
            }
            catch
            {
                MessageBox.Show("Ошибка чтения из файла");
            }
            RefreshListBox();
        }*/

        private void Serialization()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("comics.dat", FileMode.OpenOrCreate))
            {
                
                formatter.Serialize(fs, MainWindow._comics);

            }


        }

        private void Deserialization()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream("comics.dat", FileMode.OpenOrCreate))
                {
                    List<Comics> deserilizeComics = (List<Comics>)formatter.Deserialize(fs);
                    foreach (var p in deserilizeComics)
                    {
                        MainWindow._comics.Add(p);
                    }
                    foreach (var p in MainWindow._comics)
                    {
                        MainWindow._publishers.Add(p.Publisher);
                    }
                    listBoxComics.ItemsSource = MainWindow._comics;
                }
            }
            catch
            {
                MainWindow._publishers.Add(new Publisher("DC", "www.dccomics.com"));
                MainWindow._publishers.Add(new Publisher("Parallel Comics", "www.parallelcomic.com"));
                MainWindow._publishers.Add(new Publisher("MARVEL", "www.marvel.com"));
                listBoxComics.ItemsSource = null;
            }
        }


        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {

            SearchPage p = new SearchPage(MainWindow._publishers);
        NavigationService.Navigate(p);


        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdatePage p = new UpdatePage(listBoxComics.SelectedItem as Comics, MainWindow._publishers, listBoxComics.SelectedIndex);
            if (listBoxComics.SelectedIndex !=-1)
            {
                NavigationService.Navigate(p); 

            }
            else MessageBox.Show("Вы не выбрали комикс для редактирования");



        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._comics.Clear();
            Logger.Instance.Log("Был произведен выход на страницу авторизации");
            LoginPage p = new LoginPage();
            NavigationService.Navigate(p);
        }
    }
}

