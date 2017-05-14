using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            FileSystemWatcher watcher = new FileSystemWatcher();

            int index = Assembly.GetExecutingAssembly().Location.LastIndexOf("\\");
            string _path = Assembly.GetExecutingAssembly().Location.Substring(0, index);
            watcher.Path = _path;
            watcher.EnableRaisingEvents = true;
            watcher.Created += new FileSystemEventHandler(watcher_Created);
            watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);
            watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            watcher.Renamed += new RenamedEventHandler(watcher_Renamed);

            FrameMain.Navigate(new LoginPage());
        }

        static void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            File.AppendAllText(Environment.CurrentDirectory+ "\\watcher"+"\\watcher.txt", e.OldName + " has been renamed" +"\t");
        }
        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            File.AppendAllText(Environment.CurrentDirectory + "\\watcher" + "\\watcher.txt", e.Name + " has been changed" + "\t");
        }
        static void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            File.AppendAllText(Environment.CurrentDirectory + "\\watcher" + "\\watcher.txt", e.Name + " has been deleted" + "\t");
        }
        static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            File.AppendAllText(Environment.CurrentDirectory + "\\watcher" + "\\watcher.txt", e.Name + " has been created" + "\t");
        }



    }
}

