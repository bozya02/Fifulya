using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifulya.DB
{
    public partial class ProductSale
    {
        public double Cost => (double)(Product.MinPrice * Count);
    }
}
