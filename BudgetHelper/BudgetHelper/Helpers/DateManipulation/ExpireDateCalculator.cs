using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetHelper.Helpers.DateManipulation
{
    public static class ExpireDateCalculator
    {
        public static double CalculateDaysToExpire(DateTime expireDate)
        {
            return (expireDate - DateTime.Now).TotalDays;
        }
    }
}
