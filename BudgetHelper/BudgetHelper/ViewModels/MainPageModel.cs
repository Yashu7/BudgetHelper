using BudgetHelper.Helpers.Messaging;
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
        private readonly IProductService _productService;
        private readonly IMessageService _messageService;
        public Command<ProductItem> DeleteItemCommand { get; set; }
        public Command NavigateToAddViewCommand { get; set; }
        private ObservableCollection<ProductItem> _productItems;
        public ObservableCollection<ProductItem> ProductItems
        {
            get
            {
                return _productItems;
            }
            set
            {
                _productItems = value;
                RaisePropertyChanged("ProductItems");
            }
        }
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
        private DateTime _minDate;
        public DateTime MinDate
        {
            get
            {
                return _minDate;
            }
            set
            {
                _minDate = value;
                RaisePropertyChanged("MinDate");
            }
        }
        private DateTime _maxDate;
        public DateTime MaxDate
        {
            get
            {
                return _maxDate;
            }
            set
            {
                _maxDate = value;
                RaisePropertyChanged("MaxDate");
            }
        }
        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            Task.Run(async () => await InitializeMainList());
        }
        public MainPageModel(IProductService productService, IMessageService messageService)
        {
            InitializeCommands();
            _productService = productService;
            _messageService = messageService;

            MinDate = DateTime.Now;
            MaxDate = DateTime.Now.AddDays(365);
        }
        private void InitializeCommands()
        {
            DeleteItemCommand = new Command<ProductItem>(DeleteItem);
            NavigateToAddViewCommand = new Command(NavigateToAddViev);
        }
        private async Task InitializeMainList()
        {
            ///TODO: Mock data, delete later
            var productList = await _productService.GetProducts();
            ProductItems = new ObservableCollection<ProductItem>((IEnumerable<ProductItem>)productList);
        }
        public async void TestFrame()
        {
            await CoreMethods.PopToRoot(false);
        }
        public async void DeleteItem(ProductItem productItem)
        {
            
            if (productItem is null)
                return;
            bool isDeleting = await _messageService.ShowMessageAskAsync("Delete selected product?");
            if (isDeleting)
                ProductItems.Remove(productItem);
            else
                SelectedProduct = null;
        }
        public async void NavigateToAddViev()
        {
            await CoreMethods.PushPageModel<AddProductPageModel>(false);
        }
    }
}
