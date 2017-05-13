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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Comics> _comics = new List<Comics>();
        public List<Publisher> _publishers = new List<Publisher>();
        const string FileName = "database.txt";
        public MainWindow()
        {
            InitializeComponent();
            FrameMain.Navigate(new LoginPage());
        }

       
    }
}

