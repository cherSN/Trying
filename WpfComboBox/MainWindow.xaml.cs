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

using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace WpfApplication1
{

    public class MyString : INotifyPropertyChanged
    {
        private string name;
        public MyString() { Name1 ="No_Name"; }

        public MyString(string name) { Name1 = name; }

        public string Name1 {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged("Name1");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }

    public partial class MainWindow : Window //, INotifyPropertyChanged
    {
        public List<MyString> MyList { set; get; }

        public MainWindow()
        {
            InitializeComponent();
            
            MyList = new List<MyString>();
            MyList.Add(new MyString("str001"));
            MyList.Add(new MyString("str002"));
            MyList.Add(new MyString("str003"));
            MyList.Add(new MyString("str004"));
            MyList.Add(new MyString("str005"));
            MyList.Add(new MyString("str006"));
            MyList.Add(new MyString("str007"));
            MyList.Add(new MyString("str008"));
            MyList.Add(new MyString("str009"));
            MyList.Add(new MyString("str010"));
            MyList.Add(new MyString("str011"));
            MyList.Add(new MyString("str012"));
            MyList.Add(new MyString("str001"));
            MyList.Add(new MyString("str002"));
            MyList.Add(new MyString("str003"));
            MyList.Add(new MyString("str004"));
            MyList.Add(new MyString("str005"));
            MyList.Add(new MyString("str006"));
            MyList.Add(new MyString("str007"));
            MyList.Add(new MyString("str008"));
            MyList.Add(new MyString("str009"));
            MyList.Add(new MyString("str010"));
            MyList.Add(new MyString("str011"));
            MyList.Add(new MyString("str012"));
            MyList.Add(new MyString("str001"));
            MyList.Add(new MyString("str002"));
            MyList.Add(new MyString("str003"));
            MyList.Add(new MyString("str004"));
            MyList.Add(new MyString("str005"));
            MyList.Add(new MyString("str006"));
            MyList.Add(new MyString("str007"));
            MyList.Add(new MyString("str008"));
            MyList.Add(new MyString("str009"));
            MyList.Add(new MyString("str010"));
            MyList.Add(new MyString("str011"));
            MyList.Add(new MyString("str012"));
            MyList.Add(new MyString("str001"));
            MyList.Add(new MyString("str002"));
            MyList.Add(new MyString("str003"));
            MyList.Add(new MyString("str004"));
            MyList.Add(new MyString("str005"));
            MyList.Add(new MyString("str006"));
            MyList.Add(new MyString("str007"));
            MyList.Add(new MyString("str008"));
            MyList.Add(new MyString("str009"));
            MyList.Add(new MyString("str010"));
            MyList.Add(new MyString("str011"));
            MyList.Add(new MyString("str012"));
            MyList.Add(new MyString("str001"));
            MyList.Add(new MyString("str002"));
            MyList.Add(new MyString("str003"));
            MyList.Add(new MyString("str004"));
            MyList.Add(new MyString("str005"));
            MyList.Add(new MyString("str006"));
            MyList.Add(new MyString("str007"));
            MyList.Add(new MyString("str008"));
            MyList.Add(new MyString("str009"));
            MyList.Add(new MyString("str010"));
            MyList.Add(new MyString("str011"));
            MyList.Add(new MyString("str012"));
            MyList.Add(new MyString("str001"));
            MyList.Add(new MyString("str002"));
            MyList.Add(new MyString("str003"));
            MyList.Add(new MyString("str004"));
            MyList.Add(new MyString("str005"));
            MyList.Add(new MyString("str006"));
            MyList.Add(new MyString("str007"));
            MyList.Add(new MyString("str008"));
            MyList.Add(new MyString("str009"));
            MyList.Add(new MyString("str010"));
            MyList.Add(new MyString("str011"));
            MyList.Add(new MyString("str012"));
            DataContext = this;
            
            //            Mycb.ItemsSource = MyList;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int f = 0;
        }
    }
}
