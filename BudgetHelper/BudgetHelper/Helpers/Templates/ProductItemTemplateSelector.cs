using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BudgetHelper.Helpers.Templates
{
    public class ProductItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NewProductItemTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return NewProductItemTemplate;
        }
    }
}
