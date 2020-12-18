using System;
using Windows.UI.Xaml.Data;

namespace MVVMSample.Converter
{
    public class GenderConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int genderCode = (int)value;
            if (genderCode == 0)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
