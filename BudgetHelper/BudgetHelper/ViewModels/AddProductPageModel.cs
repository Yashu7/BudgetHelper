using BudgetHelper.Models;
using BudgetHelper.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BudgetHelper.ViewModels
{
    class AddProductPageModel : FreshBasePageModel
    {
        public Command SaveProductCommand { get; set; }
        private ProductItem _newProduct = new ProductItem();
        public ProductItem NewProduct
        {
            get
            {
                return _newProduct;
            }
            set
            {
                _newProduct = value;
                RaisePropertyChanged("NewProduct");
            }
        }
        private readonly IProductService _productService;
        public AddProductPageModel(IProductService productServicec)
        {
            _productService = productServicec;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            SaveProductCommand = new Command(AddProduct);
        }
        private async void AddProduct()
        {
            await _productService.PutProduct(null);
        }
    }
}
