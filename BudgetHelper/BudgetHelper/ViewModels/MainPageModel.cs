using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace BudgetHelper.ViewModels
{
    class MainPageModel : FreshBasePageModel
    {
        public Command DeleteItemCommand { get; set; }
        public ObservableCollection<string> CreatedItems { get; set; }
        public MainPageModel()
        {
            DeleteItemCommand = new Command(DeleteItem);
            CreatedItems = new ObservableCollection<string>()
            {
                "First",
                "Second",
                "Third",
                "Fourth",
                "Fifth"
            };
        }
        public async void TestFrame()
        {
            await CoreMethods.PopToRoot(false);
        }
        public async void DeleteItem()
        {
            CreatedItems.RemoveAt(CreatedItems.Count-1);
        }
    }
}
