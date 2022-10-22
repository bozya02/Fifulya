using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Fifulya.DB
{
    public static class DataAccess
    {
        public delegate void NewItemAddedDeledate();
        public static event NewItemAddedDeledate NewItemAddedEvent;

        public static List<Product> GetProducts() => FifulyaEntities.GetContext().Products.ToList();
        public static List<ProductType> GetProductTypes() => FifulyaEntities.GetContext().ProductTypes.ToList();
        public static List<Material> GetMaterials() => FifulyaEntities.GetContext().Materials.ToList();
        public static List<MaterialType> GetMaterialTypes() => FifulyaEntities.GetContext().MaterialTypes.ToList();
        public static List<Workshop> GetWorkshops() => FifulyaEntities.GetContext().Workshops.ToList();

        public static void SaveProduct(Product product)
        {
            if (!GetProducts().Any(x => x == product))
                FifulyaEntities.GetContext().Products.Add(product);

            NewItemAddedEvent?.Invoke();
            FifulyaEntities.GetContext().SaveChanges();
        }

        public static void DeleteProduct(Product product)
        {
            FifulyaEntities.GetContext().Products.Remove(product);

            NewItemAddedEvent?.Invoke();
            FifulyaEntities.GetContext().SaveChanges();
        }
    }
}
