using Prac1.SampleDatabaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Prac1
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        OrdersTableAdapter Orders = new OrdersTableAdapter();
        public Page2()
        {
            InitializeComponent();
            OrdersDataGrid.ItemsSource = Orders.GetData();
            UserIDFilter.ItemsSource = Orders.GetData();
            UserIDFilter.DisplayMemberPath = "UserID";
        }
        private void UserIDSearch_Click(object sender, RoutedEventArgs e)
        {
            OrdersDataGrid.ItemsSource = Orders.SearchByUserID(UserIDSearch.Text);
        }
        private void UserIDFilterSearch_Click(object sender, RoutedEventArgs e)
        {
            if (UserIDFilter.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)UserIDFilter.SelectedItem;
                string selectedUserID = selectedRow["UserID"].ToString();
                var filteredData = Orders.FilterByUserID(Convert.ToInt32(selectedUserID));
                OrdersDataGrid.ItemsSource = filteredData;
            }
        }

        private void UserIDFilter_Click(object sender, RoutedEventArgs e)
        {
            OrdersDataGrid.ItemsSource = Orders.GetData();
        }
    }
}
