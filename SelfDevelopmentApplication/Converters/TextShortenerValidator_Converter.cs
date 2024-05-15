using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace SelfDevelopmentApplication.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    class TextShortenerValidator_Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;
            if (val == null || val.Length == 0)
                return "[Empty]";
            
            if(!int.TryParse((string)parameter, out int charLimit))
            {
                charLimit = 10;
            }

            if (charLimit <= 4 && val.Length > charLimit)
                return new StringBuilder()
                .Append(val[0])
                .Append("...").ToString();

            string convertedText = new(val);

            if (val.Length > charLimit)
            {
                convertedText = new StringBuilder()
                .Append(convertedText.Substring(0, charLimit - 3))
                .Append("...").ToString();
            }
            
            return convertedText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
