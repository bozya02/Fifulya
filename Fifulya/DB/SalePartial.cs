using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifulya.DB
{
    public partial class Sale
    {
        public double Cost => ProductSales.Sum(x => x.Count * (double)x.Product.MinPrice);
    }
}
