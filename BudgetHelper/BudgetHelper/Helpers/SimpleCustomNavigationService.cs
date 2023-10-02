using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BudgetHelper.Helpers
{
    public class SimpleCustomNavigationService : NavigationPage, IFreshNavigationService
    {
        public SimpleCustomNavigationService(Page page) : base(page)
        {
        }

        public async Task PopToRoot(bool animate = true)
        {
            await Navigation.PopToRootAsync(animate);
        }

        public async Task PushPage(Page page, FreshMvvm.FreshBasePageModel model, bool modal = false, bool animate = true)
        {
            if (modal)
                await Navigation.PushModalAsync(page, animate);
            else
                await Navigation.PushAsync(page, animate);
        }

        public async Task PopPage(bool modal = false, bool animate = true)
        {
            if (modal)
                await Navigation.PopModalAsync(animate);
            else
                await Navigation.PopAsync(animate);
        }
    }
}
