using System;
using System.Globalization;
using System.Windows;

namespace PesonalFilesOfStudents
{
    /// <summary>
    /// A converter that takes in the core horizontal aligment enum and converts it to WPF aligment
    /// </summary>
    public class HorizontalAligmentConverter : BaseValueConverter<HorizontalAligmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (HorizontalAlignment) value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
