using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace SelfDevelopmentApplication.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    class TimeTextInputValidator_Converter : IValueConverter
    {
        private string previousValue;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            previousValue = (string)value;

            return ConvertBack(value, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string inputValue = (string)value;
            if (inputValue == "")
            {
                return "00";
            }
            int inputNumber;
            if (!int.TryParse(inputValue, out inputNumber))
            {
                return previousValue;
            }

            if (inputNumber < 0)
            {
                return previousValue;
            }

            if (inputValue.Length == 1)
            {
                return new StringBuilder().Append('0').Append(inputValue).ToString();
            }

            if (((string)value).Length == 3)
            {
                if (inputValue[1..] == "00")
                {
                    inputValue = inputValue.Substring(0, 2);
                }
                else if (inputValue[0] == '0')
                {
                    inputValue = inputValue[1..];
                }
                else
                {
                    inputValue = inputValue.Substring(0, 2);
                    inputNumber = int.Parse(inputValue);
                }
            }

            if ((string)parameter == "Minute" && inputNumber > 59)
            {
                return previousValue;
            }
            else if ((string)parameter == "Hour" && inputNumber > 23)
            {
                return previousValue;
            }

            return inputValue;
        }
    }
}
