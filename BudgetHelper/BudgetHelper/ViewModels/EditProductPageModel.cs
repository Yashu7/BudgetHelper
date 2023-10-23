using BudgetHelper.Helpers.Messaging;
using BudgetHelper.Models;
using BudgetHelper.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BudgetHelper.ViewModels
{
    class EditProductPageModel : FreshBasePageModel
    {
        public Command SaveProductCommand { get; set; }
        private ProductItem _existingProduct = new ProductItem();
        public ProductItem ExistingProduct
        {
            get
            {
                return _existingProduct;
            }
            set
            {
                _existingProduct = value;
                RaisePropertyChanged("ExistingProduct");
            }
        }
        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }
        private readonly IProductService _productService;

        private readonly IMessageService _messageService;
        public EditProductPageModel(IProductService productServicec, IMessageService messageService)
        {
            _productService = productServicec;
            _messageService = messageService;
            InitializeCommands();
        }
        public override void Init(object exisitngProduct) 
        {
            ExistingProduct = (ProductItem)exisitngProduct;
        }
        private void InitializeCommands()
        {
            SaveProductCommand = new Command(EditProduct);
        }

        private async void EditProduct()
        {
            if (String.IsNullOrEmpty(ExistingProduct.Name))
            {
                await _messageService.ShowMessageAsync("Wypełnij brakujące dane: ", "Nazwa produktu");
                return;
            }
            if (ExistingProduct.ExpireDate < DateTime.Now.AddSeconds(-60))
            {
                await _messageService.ShowMessageAsync("Zmień datę przedawnienia", "Data przedawnienia produktu nie może być wcześniejsza niż data teraźniejsza.");
                return;
            }
            if (ExistingProduct.ExpireDate < ExistingProduct.BroughtDate)
            {
                await _messageService.ShowMessageAsync("Nie poprawne daty", "Data przedawnienia produktu nie może być wcześniejsza niż data zakupu.");
                return;
            }
            IsLoading = true;
            await _productService.UpdateProduct(ExistingProduct);
            CoreMethods.RemoveFromNavigation();
            IsLoading = false;
        }
    }
}
