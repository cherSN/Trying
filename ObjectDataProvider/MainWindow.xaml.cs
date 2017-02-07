using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObjectDataProvider
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public DomainObject myDomainObjectMethod { set; get; }
        //public DomainObject myDomainObject { set; get; }
        //public BalanceQuarterColorConverter myBalanceQuarterColorConverter { set; get; }
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class DomainObject
    {
        public Color ConvertQuarterAndBalanceToColor(string month, decimal balance)
        {
            int quarter = ConvertMonthNameToQuarter(month);
            Color outputColor = Colors.Magenta;
            if (balance == decimal.Zero)
            {
                outputColor = Colors.Black;
            }
            else if (balance > decimal.Zero)
            {
                outputColor = Colors.Green;
            }
            else
            {
                switch (quarter)
                {
                    case 1:
                        outputColor = Colors.Yellow;
                        break;
                    case 2:
                        outputColor = Colors.DarkOrange;
                        break;
                    case 3:
                        outputColor = Colors.OrangeRed;
                        break;
                    case 4:
                        outputColor = Colors.Red;
                        break;
                    default:
                        outputColor = Colors.Magenta;
                        break;
                }
            }
            
        return outputColor;
        }
        private int ConvertMonthNameToQuarter(string month)
        {
            DateTime monthDateTime = DateTime.MinValue;
            DateTime.TryParseExact(month, "MMMM", CultureInfo.CurrentCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal, out monthDateTime);
            return (monthDateTime.Month + 2) / 3;
        }
    }

    public class BalanceQuarterColorConverter : IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            object convertedValue = null;
            if (values.Count() == 2)
            {
                string month = null;
                decimal balance = decimal.MinValue;
                foreach (object value in values)
                {
                    if (value is string)
                    {
                        month = value as string;
                    }
                    else if (value is decimal)
                    {
                        balance = (decimal)value;
                    }
                }
                DateTime monthDateTime = DateTime.MinValue;
                if (DateTime.TryParseExact(month, "MMMM", culture.DateTimeFormat, DateTimeStyles.AssumeUniversal, out monthDateTime))
                {
                    int quarter = (monthDateTime.Month + 2) / 3;
                    convertedValue = ConvertQuarterAndBalanceToColor(quarter, balance);
                }
            }
            return convertedValue;
        }

        private Color ConvertQuarterAndBalanceToColor(int quarter, decimal balance)
        {
            Color outputColor = Colors.Magenta;
            if (balance == decimal.Zero)
            {
                outputColor = Colors.Black;
            }
            else if (balance > decimal.Zero)
            {
                outputColor = Colors.Green;
            }
            else
            {
                switch (quarter)
                {
                    case 1:
                        outputColor = Colors.Yellow;
                        break;
                    case 2:
                        outputColor = Colors.DarkOrange;
                        break;
                    case 3:
                        outputColor = Colors.OrangeRed;
                        break;
                    case 4:
                        outputColor = Colors.Red;
                        break;
                    default:
                        outputColor = Colors.Magenta;
                        break;
                }
            }
            return outputColor;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
