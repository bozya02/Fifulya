using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Fifulya.DB
{
    public static class DataAccess
    {
        public delegate void NewItemAddedDeledate();
        public static event NewItemAddedDeledate NewItemAddedEvent;

        public static List<Product> GetProducts() => FifulyaEntities.GetContext().Products.ToList().FindAll(x => !x.IsDeleted);
        public static List<ProductType> GetProductTypes() => FifulyaEntities.GetContext().ProductTypes.ToList();
        public static List<Material> GetMaterials() => FifulyaEntities.GetContext().Materials.ToList();
        public static List<Workshop> GetWorkshops() => FifulyaEntities.GetContext().Workshops.ToList();
        public static List<Sale> GetSales() => FifulyaEntities.GetContext().Sales.ToList();
        public static List<State> GetStates() => FifulyaEntities.GetContext().States.ToList();
        public static List<Sale> GetSales(Agent agent) => FifulyaEntities.GetContext().Sales.ToList().FindAll(s => s.Agent == agent);
        public static List<User> GetUsers() => FifulyaEntities.GetContext().Users.ToList();
        public static List<Agent> GetAgents() => FifulyaEntities.GetContext().Agents.ToList();

        public static void SaveProduct(Product product)
        {
            if (product.Id == 0)
                FifulyaEntities.GetContext().Products.Add(product);

            FifulyaEntities.GetContext().SaveChanges();
            NewItemAddedEvent?.Invoke();
        }

        public static void DeleteProduct(Product product)
        {
            product.IsDeleted = true;

            SaveProduct(product);
        }

        public static bool IsUniqueLogin(string login) => !GetUsers().Any(x => x.Login == login);

        public static void SaveAgent(Agent agent)
        {
            if (agent.Id == 0)
                FifulyaEntities.GetContext().Agents.Add(agent);

            FifulyaEntities.GetContext().SaveChanges();
            NewItemAddedEvent?.Invoke();
        }

        public static Agent UserLogin(string login, string password) => GetAgents().Find(x => x.User.Login == login && x.User.Password == password);

        public static bool IsAdmin(User user) => user.Login == user.Password && user.Login == "admin";

        public static void SaveSale(Sale sale)
        {
            
            if (sale.Id == 0)
            {
                sale.StateId = 1;
                FifulyaEntities.GetContext().Sales.Add(sale);
            }

            FifulyaEntities.GetContext().SaveChanges();
            NewItemAddedEvent?.Invoke();
        }

        public static void PaySale(Sale sale)
        {
            sale.StateId = 2;
            SaveSale(sale);
        }

        public static void DeleteProductSale(ProductSale productSale)
        {
            FifulyaEntities.GetContext().ProductSales.Remove(productSale);
            FifulyaEntities.GetContext().SaveChanges();
            NewItemAddedEvent?.Invoke();
        }
    }
}
