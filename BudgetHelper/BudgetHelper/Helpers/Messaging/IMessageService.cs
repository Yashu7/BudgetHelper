using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetHelper.Helpers.Messaging
{
    public interface IMessageService
    {
        Task ShowMessageAsync(string title, string message);
        Task<bool> ShowMessageAskAsync(string title);
    }
}
