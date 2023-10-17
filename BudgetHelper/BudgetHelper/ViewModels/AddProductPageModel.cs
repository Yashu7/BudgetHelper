using BudgetHelper.Helpers.Messaging;
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

        private readonly IMessageService _messageService;
        public AddProductPageModel(IProductService productServicec, IMessageService messageService)
        {
            _productService = productServicec;
            _messageService = messageService;
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            SaveProductCommand = new Command(AddProduct);
        }
        private async void AddProduct()
        {
            if (String.IsNullOrEmpty(NewProduct.Name))
            {
                await _messageService.ShowMessageAsync("Wypełnij brakujące dane: ","Nazwa produktu");
                return;
            }
            await _productService.PutProduct(NewProduct);
        }
    }
}
