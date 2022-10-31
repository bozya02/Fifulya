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
        public double Cost
        {
            get { return ProductSales.Sum(x => x.Cost); }
            set { }
        }
        public bool IsDraft => State != null && State.Name.ToLower().Contains("черновик");
    }
}
