using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace LanguageLearner
{
    public static class Converters
    {
        public static BoolToHiddenConverter BoolToHidden = new BoolToHiddenConverter();
    }

    public class BoolToHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isVisible)
            {
                return isVisible ? Visibility.Visible : Visibility.Hidden;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
