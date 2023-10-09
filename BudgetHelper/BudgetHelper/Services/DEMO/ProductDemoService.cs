using BudgetHelper.Models;
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

        public Task<List<ProductItem>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductItem> PostProducts(List<ProductItem> products)
        {
            throw new NotImplementedException();
        }

        public Task<int> PutProduct(ProductItem item)
        {
            throw new NotImplementedException();
        }
    }
}
