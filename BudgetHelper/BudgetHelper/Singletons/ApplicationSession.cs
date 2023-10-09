using BudgetHelper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetHelper.Singletons
{
    public sealed class ApplicationSession
    {
        private static ApplicationSession _instance;
        public static ApplicationSession GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ApplicationSession();
            }
            return _instance;
        }
        private ApplicationSession()
        {

        }

        private List<ProductItem> _productItems;
        public List<ProductItem> ProductItems
        {
            get
            {
                return _productItems;
            }
            set
            {
                _productItems = value;
            }
        }
        
    }
}
