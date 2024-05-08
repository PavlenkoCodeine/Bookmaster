using Bookmaster.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для BookAuthorsDetailsWindow.xaml
    /// </summary>
    public partial class BookAuthorsDetailsWindow : Window
    {
        public BookAuthorsDetailsWindow()
        {
            InitializeComponent();

            // Заполняем ComboBox данными из таблицы Direction
        }
        // Реализовываем конструктор, который может принять
        // выбранную книгу из списка
        public BookAuthorsDetailsWindow(BookAuthor bookAuthor)
        {
            InitializeComponent();
            AuthorCmb.ItemsSource = App.context.BookAuthor.Where(ba => ba.BookId == bookAuthor.BookId).ToList();
            DataContext = AuthorCmb.SelectedItem = bookAuthor;

        }

        private void AuthorCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = AuthorCmb.SelectedItem as BookAuthor;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
            // Открываем браузер по абсолютной ссылке и "разрешаем открытие" веб-страницы
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
            }
            catch
            {
                MessageBox.Show("Невозможно открыть сайт.");
            }
        }
    }
}
