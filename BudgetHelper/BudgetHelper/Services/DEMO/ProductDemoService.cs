﻿using BudgetHelper.Models;
using BudgetHelper.Singletons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetHelper.Services.DEMO
{
    public class ProductDemoService : IProductService
    {
        public async Task<int> DeleteProduct(int itemId)
        {
            if (ApplicationSession.GetInstance().ProductItems == null)
                return 0;

            ApplicationSession.GetInstance().ProductItems.RemoveAll(x => x.Id == itemId);
            return 1;
        }

        public async Task<List<ProductItem>> GetProducts()
        {
            if (ApplicationSession.GetInstance().ProductItems == null)
                InitializeDemoProducts();

            return ApplicationSession.GetInstance().ProductItems;
        }

        public async Task<int> PostProducts(List<ProductItem> products)
        {
            if (ApplicationSession.GetInstance().ProductItems == null)
                ApplicationSession.GetInstance().ProductItems = new List<ProductItem>();

            ApplicationSession.GetInstance().ProductItems.AddRange(products);
            return 1;
        }

        public async Task<int> PutProduct(ProductItem item)
        {
            if (ApplicationSession.GetInstance().ProductItems == null)
                ApplicationSession.GetInstance().ProductItems = new List<ProductItem>();

            ApplicationSession.GetInstance().ProductItems.Add(item);
            return 1;
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
