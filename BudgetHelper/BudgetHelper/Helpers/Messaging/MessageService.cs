using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetHelper.Helpers.Messaging
{
    public class MessageService : IMessageService
    {
        public async Task<bool> ShowMessageAskAsync(string title)
        {
            var response = await App.Current.MainPage.DisplayActionSheet(title, "NO", "YES");
            if (String.IsNullOrEmpty(response))
                return false;
            if (response.Contains("YES") || response.Contains("TAK"))
                return true;
            else
                return false;
        }

        public async Task ShowMessageAsync(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "Ok");
        }
    }
}
