using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BudgetHelper.Helpers
{
    public interface IFreshNavigationService
    {
        Task PopToRoot(bool animate = true);

        Task PushPage(Page page, FreshBasePageModel model, bool modal = false, bool animate = true);

        Task PopPage(bool modal = false, bool animate = true);
    }
}
