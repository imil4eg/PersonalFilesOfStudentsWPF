using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesonalFilesOfStudents.TextConverter
{
    class TextVerticalConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
                return value;

            var convertered = "";

            foreach(var character in (string)value)
            {
                //if character is a space,add another line
                if(character == ' ')
                {
                    convertered += '\n';
                    continue;
                }

                //if there's a character before this one , add a newline before out current
                if (!string.IsNullOrEmpty(convertered))
                    convertered += "\n";

                convertered += character;
            }

            return convertered;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
