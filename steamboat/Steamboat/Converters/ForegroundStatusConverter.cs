using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Steamboat.Converters
{
    public class ForegroundStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = value.ToString();
            Brush background = Brushes.White;
            switch (status)
            {
                case "Running":
                    background = Brushes.ForestGreen;
                    break;

                case "Offline":
                    background = Brushes.Red;
                    break;
            }

            return background;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
