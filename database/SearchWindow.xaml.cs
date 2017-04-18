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

namespace database
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public  SearchWindow()
        {
            InitializeComponent();
        }
        public List<Comics> _searchComics = new List<Comics>();
        public List<Comics> SearchComics
        {
            get
            {
                return _searchComics;
            }
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem ComboItem = (ComboBoxItem)comboxSearch.SelectedItem;
            string s = ComboItem.Name;
            foreach (var p in ((MainWindow)Application.Current.MainWindow)._comics)
            {

                 if(s=="Publisher")
                   {
                       if (p.Publisher.Name==textBoxSearch.Text.ToString())
                           _searchComics.Add(p);
                   }
                if (s == "Name")
                {
                    if (p.Name == textBoxSearch.Text.ToString())
                        _searchComics.Add(p);
                }
                if (s == "Year")
                {
                    if (p.Year == Int32.Parse(textBoxSearch.Text))
                        _searchComics.Add(p);
                }
                if (s == "Author")
                {
                    if (p.Author == textBoxSearch.Text.ToString())
                        _searchComics.Add(p);
                }


            }
            DialogResult = true;
        }
    }
}
