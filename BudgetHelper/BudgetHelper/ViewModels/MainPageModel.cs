using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BudgetHelper.ViewModels
{
    class MainPageModel : FreshBasePageModel
    {
        public Command TappedMainFrame { get; set; }
        public MainPageModel()
        {
            TappedMainFrame = new Command(TestFrame);
        }
        public async void TestFrame()
        {
            await CoreMethods.PopToRoot(false);
        }
    }
}
