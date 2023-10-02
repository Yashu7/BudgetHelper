using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BudgetHelper.ViewModels
{
    public class StartPageModel : FreshBasePageModel
    {
        public Command NavigateToMainPageCommand { get; set; }
        public StartPageModel()
        {
            NavigateToMainPageCommand = new Command(MoveToMainPage);
        }
        private async void MoveToMainPage()
        {
            await CoreMethods.PushPageModel<MainPageModel>(false);
        }
    }
}
