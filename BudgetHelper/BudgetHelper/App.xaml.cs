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
