﻿using BudgetHelper.Helpers.Messaging;
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
        public AddProductPageModel(IProductService productServicec, IMessageService messageService)
        {
            _productService = productServicec;
            _messageService = messageService;
            InitializeProperties();
            InitializeCommands();
        }
        private void InitializeProperties()
        {
            NewProduct.DaysToExpireAfterOpening = 1;
            IsLoading = false;
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
            if(NewProduct.ExpireDate < DateTime.Now.AddSeconds(-60))
            {
                await _messageService.ShowMessageAsync("Zmień datę przedawnienia", "Data przedawnienia produktu nie może być wcześniejsza niż data teraźniejsza.");
                return;
            }
            if (NewProduct.ExpireDate < NewProduct.BroughtDate)
            {
                await _messageService.ShowMessageAsync("Nie poprawne daty", "Data przedawnienia produktu nie może być wcześniejsza niż data zakupu.");
                return;
            }
            IsLoading = true;
            await _productService.PutProduct(NewProduct);
            CoreMethods.RemoveFromNavigation();
            IsLoading = false;
        }
    }
}
