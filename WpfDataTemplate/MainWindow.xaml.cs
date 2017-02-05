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

namespace WpfDataTemplate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            SelectDataTemplate(lbi.Content);
        }

        private void SelectDataTemplate(object value)
        {
            string numberStr = value as string;

            if (numberStr != null)
            {
                int num;

                try
                {
                    num = Convert.ToInt32(numberStr);
                }
                catch
                {
                    return;
                }

                DataTemplate template;

                // Select one of the DataTemplate objects, based on the 
                // value of the selected item in the ComboBox.
                if (num % 2 != 0)
                {
                    template = rootStackPanel.Resources["oddNumberTemplate"] as DataTemplate;
                }
                else
                {
                    template = rootStackPanel.Resources["evenNumberTemplate"] as DataTemplate;
                }

                selectedItemDisplay.Child = template.LoadContent() as UIElement;
                TextBlock tb = FindVisualChild<TextBlock>(selectedItemDisplay);
                tb.Text = numberStr;
            }
        }

        private childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);

                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

    }
}
