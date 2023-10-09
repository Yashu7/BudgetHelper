using BudgetHelper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetHelper.Services
{
    public interface IProductService
    {
        Task<List<ProductItem>> GetProducts();
        Task<int> PostProducts(List<ProductItem> products);
        Task<int> PutProduct(ProductItem item);
        Task<int> DeleteProduct(int itemId);
    }
}
