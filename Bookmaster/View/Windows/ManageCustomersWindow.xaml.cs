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
    /// Логика взаимодействия для ManageCustomersWindow.xaml
    /// </summary>
    public partial class ManageCustomersWindow : Window
    {
        public ManageCustomersWindow()
        {
            InitializeComponent();
            CustomersLv.ItemsSource = App.context.Customers.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(CustomersIdTb.Text);
                if (CustomersIdTb.Text == String.Empty && NameTb.Text != String.Empty)
                {
                    CustomersLv.ItemsSource = App.context.Customers.Where(c => c.Name.Contains(NameTb.Text)).ToList();
                    MessageBox.Show("Сработало if");
                }
                else if (id != 0 && NameTb.Text == String.Empty)
                {
                    CustomersLv.ItemsSource = App.context.Customers.Where(c => c.Id == id).ToList();
                    MessageBox.Show("Сработало else if");
                }
                else 
                {
                    MessageBox.Show("Сработало else");
                }
                
            }
            catch
            {
                Console.WriteLine("Ошибка поиска. Попробуйте позже!");
            }
            
          

        }
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            AddEditCustomerWindow addEditCustomerWindow = new AddEditCustomerWindow();
            addEditCustomerWindow.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomerWindow addEditCustomerWindow = new AddEditCustomerWindow();
            addEditCustomerWindow.ShowDialog();
        }

        private void CustomersLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
