using System;
using System.Globalization;

namespace StudyCompanion
{
    public class DateConverter : IValueConverter
    {
        private static readonly string weekdayFormat = "ddd HH:mm";

        public DateConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var startDate = DateTime.ParseExact((string)value, CourseDataService.longFormat, CultureInfo.InvariantCulture);

            return startDate.ToString(weekdayFormat);

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
