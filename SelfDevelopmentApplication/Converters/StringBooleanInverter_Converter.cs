using System;
using System.Globalization;
using System.Windows.Data;

namespace SelfDevelopmentApplication.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    class StringBooleanInverter_Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                
            if ((string)value == "False")
            {
                return "True";
            }

            else
            {
                return "False";
            }
                
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "False")
            {
                return "True";
            }

            else
            {
                return "False";
            }
        }
    }
}
