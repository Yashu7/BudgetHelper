using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetHelper.Models
{
    public class ProductItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public int DaysToExpireAfterOpening { get; set; }
        public DateTime BroughtDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime ExpireDateAfterOpen
        {
            get
            {
                return BroughtDate.AddDays(DaysToExpireAfterOpening);
            }
        }
        public ProductItem()
        {

        }
        public ProductItem(string name, int daysToExpire, DateTime broughtDate, DateTime expireDate, bool isOpen = false)
        {
            Name = name;
            DaysToExpireAfterOpening = daysToExpire;
            BroughtDate = broughtDate;
            ExpireDate = expireDate;
            IsOpen = isOpen;
        }

    }
}
