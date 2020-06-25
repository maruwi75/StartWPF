using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MaruWPFDll.ValueConverters
{
    public class VCFormattedString : IValueConverter
    {

        //
        // 요약:
        //     값을 변환합니다.
        //
        // 매개 변수:
        //   value:
        //     바인딩 소스에서 생성한 값입니다.
        //
        //   targetType:
        //     바인딩 대상 속성의 형식입니다.
        //
        //   parameter:
        //     사용할 변환기 매개 변수입니다.
        //
        //   culture:
        //     변환기에서 사용할 문화권입니다.
        //
        // 반환 값:
        //     변환된 값입니다. 메서드에서 null을 반환하면 유효한 null 값이 사용됩니다.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is IFormattable && parameter is string && !string.IsNullOrEmpty(parameter as string) && targetType == typeof(string))  {
                if (culture == null)
                {
                    return (value as IFormattable).ToString(parameter as string, null);
                }
                return (value as IFormattable).ToString(parameter as string, culture);
            }
            return value;
        }
        //
        // 요약:
        //     값을 변환합니다.
        //
        // 매개 변수:
        //   value:
        //     바인딩 대상에서 생성한 값입니다.
        //
        //   targetType:
        //     변환할 대상 형식입니다.
        //
        //   parameter:
        //     사용할 변환기 매개 변수입니다.
        //
        //   culture:
        //     변환기에서 사용할 문화권입니다.
        //
        // 반환 값:
        //     변환된 값입니다. 메서드에서 null을 반환하면 유효한 null 값이 사용됩니다.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
