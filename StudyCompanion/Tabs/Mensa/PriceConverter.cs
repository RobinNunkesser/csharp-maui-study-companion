using System;
using System.Globalization;
using Italbytz.Ports.Meal;

namespace StudyCompanion
{
    public class PriceConverter : IValueConverter
    {
        public PriceConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var price = Settings.Status switch
            {
                0 => (double)((IPrice)value).Students,
                1 => (double)((IPrice)value).Employees,
                2 => (double)((IPrice)value).Others,
                _ => 0.0,
            };
            var cultureInfo = CultureInfo.GetCultureInfo("de-DE");
            return String.Format(cultureInfo, "{0:C}", price);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
