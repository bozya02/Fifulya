using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifulya.DB
{
    public partial class FifulyaEntities
    {
        private static FifulyaEntities _entities;

        public static FifulyaEntities GetContext()
        {
            if (_entities == null)
                _entities = new FifulyaEntities();
            return _entities;
        }

        public static void RefreshContext()
        {
            _entities = new FifulyaEntities();
        }
    }
}
