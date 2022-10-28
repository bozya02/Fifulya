using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fifulya.DB
{
    public partial class Sale
    {
        public double Cost => ProductSales.Sum(x => x.Cost);
        public bool IsDraft => State != null && State.Name.ToLower().Contains("черновик");
    }
}
