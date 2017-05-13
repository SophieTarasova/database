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
            _searchComics.Clear();

            
        }

        public List<Comics> _searchComics = new List<Comics>();
        public List<Comics> SearchComics
        {
            get
            {
                return _searchComics;
            }
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            _searchComics.Clear();
            MainPage p = new MainPage();
            NavigationService.Navigate(p);
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
           
            ComboBoxItem ComboItem = (ComboBoxItem)comboxSearch.SelectedItem;
            string s = ComboItem.Name;
                foreach (var p in ((MainWindow)Application.Current.MainWindow)._comics)
                {
                
                    if (s == "Publisher")
                    {
                    if (p.Publisher.Name == textBoxSearch.Text.ToString())
                        _searchComics.Add(p);
                    } else
                    if (s == "Name")
                    {
                        if (p.Name == textBoxSearch.Text.ToString())
                        _searchComics.Add(p);
                } else
                    if (s == "Year")
                    {
                        if (p.Year == Int32.Parse(textBoxSearch.Text))
                        _searchComics.Add(p);
                }
                else
                    if (s == "Author")
                    {
                        if (p.Author == textBoxSearch.Text.ToString())
                        _searchComics.Add(p);
                }
              
            } listBoxComics.ItemsSource = _searchComics;
            
             
    
            
        }
    }
}
