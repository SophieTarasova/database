﻿using System;
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
                MessageBox.Show("Необходимо ввести название");
                textBoxName.Focus();
                Logger.Instance.Log("Ошибка добавления комикса");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxAuthor.Text))
            {
                MessageBox.Show("Необходимо ввести имя автора");
                Logger.Instance.Log("Ошибка добавления комикса");
                textBoxAuthor.Focus();
                return;
            }
            if (!int.TryParse(textBoxYear.Text, out year))
            {
                MessageBox.Show("Необходимо ввести год");
                Logger.Instance.Log("Ошибка добавления комикса");
                textBoxYear.Focus();
                return;
            }
            if (comboBoxPublisher.SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать издательство");
                Logger.Instance.Log("Ошибка добавления комикса");
                comboBoxPublisher.Focus();
                return;
            }


            _newComics = new Comics(textBoxName.Text, textBoxAuthor.Text, year);
            _newComics.Publisher = comboBoxPublisher.SelectedItem as Publisher;
            Logger.Instance.Log("Добавлен новый комикс");
            MainPage p = new MainPage(NewComics);
            NavigationService.Navigate(p);
        }
    }
}
