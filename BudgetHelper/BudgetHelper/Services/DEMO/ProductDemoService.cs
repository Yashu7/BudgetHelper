using BudgetHelper.Models;
using BudgetHelper.Singletons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetHelper.Services.DEMO
{
    public class ProductDemoService : IProductService
    {
        public Task<int> DeleteProduct(int itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductItem>> GetProducts()
        {
            if (ApplicationSession.GetInstance().ProductItems == null)
                InitializeDemoProducts();

            return ApplicationSession.GetInstance().ProductItems;
        }

        public Task<ProductItem> PostProducts(List<ProductItem> products)
        {
            throw new NotImplementedException();
        }

        public Task<int> PutProduct(ProductItem item)
        {
            throw new NotImplementedException();
        }
        private void InitializeDemoProducts()
        {
            ApplicationSession.GetInstance().ProductItems = new List<ProductItem>()
            {
                new ProductItem("Bread", 3, DateTime.Now, DateTime.Now.AddDays(7)),
                new ProductItem("Cola", 1, DateTime.Now, DateTime.Now.AddMonths(3), true)
            };
        }
    }
}
