using BudgetHelper.Helpers.DateManipulation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace BudgetHelper.Helpers.Converters
{
    public class DateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime finalDate = (DateTime)value;
            double daysleft = ExpireDateCalculator.CalculateDaysToExpire(finalDate);
            switch(daysleft)
            {
                case double d when (d > 10):
                    return Color.Transparent;
                case double d when (d <= 10 && d >= 3):
                    return Color.Yellow;
                case double d when (d < 3 && d >= 1):
                    return Color.Orange;
                case double d when (d < 1 && d >= 0):
                    return Color.OrangeRed;
                case double d when (d < 0):
                    return Color.Red;
                default:
                    return Color.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
