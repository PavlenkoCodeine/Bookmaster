using Bookmaster.Models;
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

namespace Bookmaster.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogWindow.xaml
    /// </summary>
    public partial class BrowseCatalogWindow : Window
    {
        public BrowseCatalogWindow()
        {
            InitializeComponent();
            BookAuthorLv.ItemsSource = App.context.BookAuthor.ToList();
            CountOfBooksTbl.DataContext = App.context.Book.ToList();
            // Выбираем первый элемент из списка по его индексу (SelectedIndex)
            BookAuthorLv.SelectedIndex = 0;
        }

        private void BookAuthorLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedBookGrid.DataContext = BookAuthorLv.SelectedItem as BookAuthor;

        }

        private void LoginMi_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно LoginWindow в режиме диалогового окна
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();

            LogoutMi.Visibility = Visibility.Visible;
            LogoutMi.Visibility = Visibility.Collapsed;

            LibraryMi.Visibility = Visibility.Visible;
        }

        private void LogoutMi_Click(object sender, RoutedEventArgs e)
        {
            // пользователь выходит
            LogoutMi.Visibility = Visibility.Collapsed; 
            LogoutMi.Visibility = Visibility.Visible;
            LibraryMi.Visibility = Visibility.Collapsed;

        }

        private void ClosetMi_Click(object sender, RoutedEventArgs e)
        {
            // Закрываем текущее окно
            Close();
        }

        private void ManageCustomersMi_Click(object sender, RoutedEventArgs e)
        {
            ManageCustomersWindow manageCustomersWindow = new ManageCustomersWindow();
            manageCustomersWindow.Show();
        }

        private void LibraryMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CirculationMi_Click(object sender, RoutedEventArgs e)
        {
            CirculationWindow circulationWindow = new CirculationWindow();
            circulationWindow.Show();
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow reportsWindow = new ReportsWindow();
            reportsWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Реализовываем поиск с помощью метода Contains()
            BookAuthorLv.ItemsSource = App.context.BookAuthor.Where(ba => ba.Book.Title.Contains(TitleTb.Text) && ba.Author.Lastname.Contains(AuthorTb.Text)).ToList();

        }

        private void AuthorHl_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно bookAuthorsDetailsWindow в режиме диалогового окна
            BookAuthorsDetailsWindow bookAuthorsDetailsWindow = new BookAuthorsDetailsWindow(BookAuthorLv.SelectedItem as BookAuthor);
            bookAuthorsDetailsWindow.ShowDialog();    
        }
    }
}
