using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prac1.SampleDatabaseDataSetTableAdapters;

namespace Prac1
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        OrderDetailsTableAdapter OrderDetails = new OrderDetailsTableAdapter();

        public Page1()
        {
            InitializeComponent();
            OrderDetailsDataGrid.ItemsSource = OrderDetails.GetData();
            ProductFilter.ItemsSource = OrderDetails.GetData();
            ProductFilter.DisplayMemberPath = "ProductName";
        }
        private void ProductSearch_Click(object sender, RoutedEventArgs e)
        {
            OrderDetailsDataGrid.ItemsSource = OrderDetails.SearchByProductName(ProductSearch.Text);
        }
        private void ProductFilterSearch_Click(object sender, RoutedEventArgs e)
        {
            if (ProductFilter.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)ProductFilter.SelectedItem;
                string selectedProduct = selectedRow["ProductName"].ToString();
                var filteredData = OrderDetails.FilterByProduct(selectedProduct);
                OrderDetailsDataGrid.ItemsSource = filteredData;
            }
        }

        private void ProductFilter_Click(object sender, RoutedEventArgs e)
        {
            OrderDetailsDataGrid.ItemsSource = OrderDetails.GetData();
        }
    }
}
