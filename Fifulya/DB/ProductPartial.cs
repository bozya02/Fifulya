using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Fifulya.DB
{
    public partial class Product
    {
        public string Materials
        {
            get
            {
                return string.Join(", ", Enumerable.Range(0, ProductMaterials.Count).Select(i => ProductMaterials.ElementAt(i).Material.Name));
            }
            set {}
        }

        public SolidColorBrush Color => (ProductSales.Any(x => x.Sale.Date.Value.Month == DateTime.Today.Month) ?
                    new SolidColorBrush(Colors.Transparent) : new SolidColorBrush(Colors.Bisque));
    }
}
