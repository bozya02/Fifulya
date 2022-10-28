using Fifulya.DB;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fifulya.Pages
{
    /// <summary>
    /// Interaction logic for SalesPage.xaml
    /// </summary>
    public partial class SalesPage : Page
    {
        public List<Sale> Sales { get; set; }
        public SalesPage()
        {
            InitializeComponent();

            Sales = DataAccess.IsAdmin(App.Agent.User) ? DataAccess.GetSales() : DataAccess.GetSales(App.Agent);

            this.DataContext = this;
        }

        private void lvSales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new SalePage(lvSales.SelectedItem as Sale));
        }

        private void btnAddSale_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SalePage(new Sale()));
        }
    }
}
