using BudgetHelper.Models;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace BudgetHelper.ViewModels
{
    class MainPageModel : FreshBasePageModel
    {
        public Command<ProductItem> DeleteItemCommand { get; set; }
        public ObservableCollection<ProductItem> ProductItems { get; set; }
        private ProductItem _selectedProduct;
        public ProductItem SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
            }
        }
        public MainPageModel()
        {
            DeleteItemCommand = new Command<ProductItem>(DeleteItem);
            ProductItems = new ObservableCollection<ProductItem>()
            {
                new ProductItem("Bread",3,DateTime.Now,DateTime.Now.AddDays(7)),
                new ProductItem("Bread",3,DateTime.Now,DateTime.Now.AddDays(7)),
                new ProductItem("Bread",3,DateTime.Now,DateTime.Now.AddDays(7)),
                new ProductItem("Bread",3,DateTime.Now,DateTime.Now.AddDays(7)),
                new ProductItem("Bread",3,DateTime.Now,DateTime.Now.AddDays(7)),
                new ProductItem("Bread",3,DateTime.Now,DateTime.Now.AddDays(7)),
                new ProductItem("Bread",3,DateTime.Now,DateTime.Now.AddDays(7)),
                new ProductItem("Cola",1,DateTime.Now,DateTime.Now.AddMonths(3),true)
            };
        }
        public async void TestFrame()
        {
            await CoreMethods.PopToRoot(false);
        }
        public async void DeleteItem(ProductItem productItem)
        {
            ProductItems.Remove(productItem);
        }
    }
}
