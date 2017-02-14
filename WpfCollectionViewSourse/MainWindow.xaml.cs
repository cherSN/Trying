using System;
using System.Collections.Generic;
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

namespace WpfCollectionViewSourse
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> lstSource = new List<string>() { "1", "2", "3" };
            viewSource = new CollectionViewSource();
            viewSource.Source = lstSource;
            viewSource.Filter += viewSource_Filter;
            lst.ItemsSource = viewSource.View;
        }

        CollectionViewSource viewSource;
        void viewSource_Filter(object sender, FilterEventArgs e)
        {
            e.Accepted = ((string)e.Item).IndexOf(filter.Text) >= 0;
        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewSource.View.Refresh();
        }
    }
}
