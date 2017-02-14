using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfDataGridGrouping
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            var data = new ObservableCollection<Person>
        {
            new Person(true, 233, "Max", "New York"),
            new Person(true, 233, "Max", "Los Angeles"),
            new Person(true, 314, "John", "Paris"),
            new Person(true, 578, "Mary", "Vienna"),
            new Person(true, 782, "Susan", "Rome"),
            new Person(true, 782, "Susan", "Prague"),
            new Person(true, 782, "Susan", "San Francisco"),
            new Person(false, 151, "Henry", "Chicago")
        };

            DataSource = new ListCollectionView(data);
        }

        private ListCollectionView _dataSource;

        public ListCollectionView DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
                _dataSource.GroupDescriptions.Add(new PropertyGroupDescription("Active"));
                _dataSource.GroupDescriptions.Add(new PropertyGroupDescription("ID"));
            }
        }
    }

    public class Person
    {
        public Person(bool active, int id, string name, string city)
        {
            Active = active;
            ID = id;
            Name = name;
            City = city;
        }

        public bool Active { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}
