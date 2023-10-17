using BudgetHelper.Helpers.Messaging;
using BudgetHelper.Services;
using BudgetHelper.Services.DEMO;
using BudgetHelper.ViewModels;
using FreshMvvm;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetHelper
{
    public partial class App : Application
    {
        public App()
        {
            //Changing to english for testing resource file purposes
            CultureInfo.CurrentUICulture = new CultureInfo("pl-PL", false);
            InitializeComponent();
            var page = FreshPageModelResolver.ResolvePageModel<StartPageModel>();
            MainPage = new FreshNavigationContainer(page);
            FreshIOC.Container.Register<IProductService, ProductDemoService>();
            FreshIOC.Container.Register<IMessageService, MessageService>();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
