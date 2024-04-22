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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        UsersTableAdapter Users = new UsersTableAdapter();
        public Page3()
        {
            InitializeComponent();
            UsersDataGrid.ItemsSource = Users.GetData();
            UserNameFilter.ItemsSource = Users.GetData();
            UserNameFilter.DisplayMemberPath = "UserName";
        }
        private void UserNameSearch_Click(object sender, RoutedEventArgs e)
        {
            UsersDataGrid.ItemsSource = Users.SearchByUserName(UserNameSearch.Text);
        }
        private void UserNameFilterSearch_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameFilter.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)UserNameFilter.SelectedItem;
                string selectedUserName = selectedRow["UserName"].ToString();
                var filteredData = Users.FilterByUserName(selectedUserName);
                UsersDataGrid.ItemsSource = filteredData;
            }
        }

        private void UserNameFilter_Click(object sender, RoutedEventArgs e)
        {
            UsersDataGrid.ItemsSource = Users.GetData();
        }
    }
}
