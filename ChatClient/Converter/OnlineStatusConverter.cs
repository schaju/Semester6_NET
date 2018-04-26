using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using Model.Enum;

namespace ChatClient.Converter
{
    public class OnlineStatusConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider) => this;


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is UserAccountStatus status))
            {
                return null;
            }

            switch (status)
            {
                case UserAccountStatus.Inactive:
                    return new SolidColorBrush(Colors.Red);
                case UserAccountStatus.Active:
                    return new SolidColorBrush(Colors.Green);
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
