using BudgetHelper.Models;
using BudgetHelper.Services;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BudgetHelper.ViewModels
{
    class MainPageModel : FreshBasePageModel
    {
        private IProductService _productService;
        public Command<ProductItem> DeleteItemCommand { get; set; }
        public Command NavigateToAddViewCommand { get; set; }
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
        public MainPageModel(IProductService productService)
        {
            InitializeCommands();
            _productService = productService;
            Task.Run(async () => await InitializeMainList());
        }
        private void InitializeCommands()
        {
            DeleteItemCommand = new Command<ProductItem>(DeleteItem);
            NavigateToAddViewCommand = new Command(NavigateToAddViev);
        }
        private async Task InitializeMainList()
        {
            ///Mock data, delete later
            var productList = await _productService.GetProducts();
            ProductItems = new ObservableCollection<ProductItem>((IEnumerable<ProductItem>)productList);
        }
        public async void TestFrame()
        {
            await CoreMethods.PopToRoot(false);
        }
        public async void DeleteItem(ProductItem productItem)
        {
            ProductItems.Remove(productItem);
        }
        public async void NavigateToAddViev()
        {
            await CoreMethods.PushPageModel<AddProductPageModel>(false);
        }
    }
}
