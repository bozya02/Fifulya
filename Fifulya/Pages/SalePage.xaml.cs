using Fifulya.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Fifulya.Pages
{
    /// <summary>
    /// Interaction logic for SalePage.xaml
    /// </summary>
    public partial class SalePage : Page
    {
        public Sale Sale { get; set; }
        public Agent Agent { get; set; }
        public List<Product> Products { get; set; }
        public List<State> States { get; set; }


        public SalePage(Sale sale, bool isNewSale = false)
        {
            InitializeComponent();
            Sale = sale;
            Products = DataAccess.GetProducts();
            States = DataAccess.GetStates();

            try
            {
                btnPay.Visibility = Sale.IsDraft ? Visibility.Visible : Visibility.Hidden;
            }
            catch { }

            
            grid.IsEnabled = isNewSale || Sale.IsDraft;

            Agent = App.Agent;
            this.DataContext = this;
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if ((double)Agent.Balance < Sale.Cost)
            {
                MessageBox.Show("Недостаточно баланса", "Ошибка");
                return;
            }
            Agent.Balance -= (decimal)Sale.Cost;
            DataAccess.PaySale(Sale);
            NavigationService.GoBack();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sale.Agent = Agent;
                DataAccess.SaveSale(Sale);
                NavigationService.GoBack();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }
        }

        private void cbProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = cbProducts.SelectedItem as Product;
            Sale.ProductSales.Add(new ProductSale
            {
                Sale = Sale,
                Product = product
            });

            lvProducts.ItemsSource = Sale.ProductSales;
            lvProducts.Items.Refresh();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var productSale = (sender as Button).DataContext as ProductSale;
            Sale.ProductSales.Remove(productSale);
            try
            {
                DataAccess.DeleteProductSale(productSale);
            }
            catch { }

            lvProducts.ItemsSource = Sale.ProductSales;
            lvProducts.Items.Refresh();
        }

        private void tbCount_LostFocus(object sender, RoutedEventArgs e)
        {
            lvProducts.Items.Refresh();
            runCost.Text = Sale.Cost.ToString();
        }
    }
}
