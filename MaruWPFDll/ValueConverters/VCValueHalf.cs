using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MaruWPFDll.ValueConverters
{
    public class VCValueHalf : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double nValue;

           
            if(value is int || value is float || value is double || value is Decimal)
            {
                nValue = System.Convert.ToDouble(value);
                if (nValue != 0)
                {
                    return (nValue / 2);
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return value;
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
