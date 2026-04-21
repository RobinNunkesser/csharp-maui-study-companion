using System;
using System.Globalization;
using System.Linq;
using Italbytz.Ports.Meal;

namespace StudyCompanion
{
    public class BadgesTextConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not Badge[] badges || badges.Length == 0)
                return string.Empty;

            var labels = badges.Select(b => b switch
            {
                Badge.Vegan => "🌱 Vegan",
                Badge.Vegetarian => "🌿 Vegetarisch",
                Badge.LactoseFree => "🥛 Laktosefrei",
                Badge.GlutenFree => "🌾 Glutenfrei",
                Badge.LowCalorie => "⚡ Kalorienarm",
                Badge.Nonfat => "✨ Fettarm",
                _ => (string?)null
            }).Where(s => s != null);

            return string.Join("  ", labels);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }

    public class BadgesVisibleConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
            => value is Badge[] badges && badges.Length > 0;

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
