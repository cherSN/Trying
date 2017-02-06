using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfDataGrid
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DataGrid myGrid;
        public MainWindow()
        {
            InitializeComponent();
            
            
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DataGridTemplateColumn tcol = myCol1;

 
              DataGridRow myRow=  (DataGridRow)(dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.Items.CurrentItem));

            ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myRow);
            // Finding textBlock from the DataTemplate that is set on that ContentPresenter
            //DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
            DataTemplate myDataTemplate = tcol.CellEditingTemplate;
            DependencyObject fe = (DependencyObject)myDataTemplate.LoadContent();

            //TextBlock myTextBlock = (TextBlock)myDataTemplate.FindName("myDataTemplate", myContentPresenter);
            string typeobj = fe.DependencyObjectType.Name;
           DatePicker dpp = FindVisualChild<DatePicker>(fe);


            bool res = IsDatePickerUsed(fe);


            MessageBox.Show("Setting");
        }

        private bool IsDatePickerUsed(DependencyObject obj)
        {

            if(obj.DependencyObjectType.Name.Equals("DatePicker")) {
                return true;
            }
            else
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                    return IsDatePickerUsed(child);
                }


            }
            return false;
        }

        

        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Count == 0) return;
            var cellInfo = e.AddedCells[0];
            //if (cellInfo.Column ==
            //  dataGrid.Columns[3])
            //{
            //    dataGrid.BeginEdit();
            //}

            if (cellInfo.Column.GetType().Equals(typeof(DataGridTemplateColumn)))
            {
                DataGridTemplateColumn column = (DataGridTemplateColumn)cellInfo.Column;
                DataTemplate myDataTemplate = column.CellEditingTemplate;
                DependencyObject obj = (DependencyObject)myDataTemplate.LoadContent();
                if (IsDatePickerUsed(obj))
                {
                    dataGrid.BeginEdit();
                }
            } 



            //


            //string header = (string)cellInfo.Column.Header;

            //var item = cellInfo.Item;


            //int rowIndex = dataGrid.Items.IndexOf(item);
            //int colIndex = cellInfo.Column.DisplayIndex;

            //var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
            //DataGridTemplateColumn tcol = (DataGridTemplateColumn)cellInfo.Column;


            //if (cellContent != null)
            //DataGridCell cell= (DataGridCell)cellContent.Parent;

            //object result = item.GetType().GetProperty("TicketDate").GetValue(item, null);


            //  Binding bind = BindingOperations.GetBinding(tcol.Header, DependencyProperty dp);


            //string columnName = currentCell.Column.SortMemberPath;

            //            DataRowView dataRow = (DataRowView)dataGrid.SelectedItem;
            //cellInfo.Column.GetType().GetProperty("CellEditingTemplate")
            //System.Windows.LocalValueEnumerator lp = cellInfo.Column.GetLocalValueEnumerator();
            //while (lp.MoveNext())
            //{
            //    DependencyProperty dp = lp.Current.Property;
            //}

            //string cellValue = dataRow.Row.ItemArray[index].ToString();

            //var content = currentCell.Column.GetCellContent(currentCell.Item);
            //var row = (DataRowView)content.DataContext;
            //object[] obj = row.Row.ItemArray;


        }
    }

    public class DataView : INotifyPropertyChanged
    {


        public List<TicketInfo> TicketsList
        {
            get { return _TicketsList; }

            set {
                _TicketsList = value;
                OnPropertyChanged("TicketsList");
            }

        }

        public int RowCount
        {
            get
            {
                return rowCount;
            }

            set
            {
                rowCount = value;
                OnPropertyChanged("RowCount");
            }
        }

        private int rowCount;
        public void AddTicketInfo(string subject, string status, string raiseby)
        {
            TicketsList.Add(new TicketInfo(subject, status, raiseby));
            RowCount = TicketsList.Count;

            OnPropertyChanged("TicketsList");
        }

        private List<TicketInfo> _TicketsList;

        public DataView()
        {
            _TicketsList = new List<TicketInfo>();
            AddTicketInfo("IE Not Working", "Open", "User 1");
            AddTicketInfo("TFS Not Working", "Assigned", "User 3");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class TicketInfo
    {
        public string Subject { get; set; }
        public string Status { get; set; }
        public string RaisedBy { get; set; }
        public DateTime TicketDate { get; set; }

        public TicketInfo(string subject, string status, string raiseby)
        {
            Subject = subject;
            Status = status;
            RaisedBy = raiseby;
            TicketDate = DateTime.Now;
        }
        
    }

}
