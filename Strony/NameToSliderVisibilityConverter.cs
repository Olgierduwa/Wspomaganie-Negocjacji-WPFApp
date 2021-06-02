using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace negocjacja.Strony
{
    public class NameToSliderVisibilityConverter : IValueConverter
    {
        public string NazwaSzukana { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Nazwa = (string)value;
            if (Nazwa != NazwaSzukana && Nazwa != "") return Visibility.Visible;
            else return Visibility.Hidden;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
