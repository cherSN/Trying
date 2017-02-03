using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using Microsoft.Windows.Controls;

namespace DataGridAddButtonAndImageColumns
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        #region Member Variables
        #endregion

        #region Contructor
        public Window1()
        {
            InitializeComponent();
            DataViewModel model = new DataViewModel(new Data());

            // It is ok to pass either the DataTable or the DataView
            // so both lines below work, however I am only using one:
            //
            // mDataGrid.DataContext = model.View;
            // mDataGrid.DataContext = model.Table;
            
            mDataGrid.DataContext = model.Table;
            CreateActionButtonColumn();
            CreateStatusColumnWithImages();
        }
        #endregion

        #region Functions
        private void ButtonFixThis_Click(object sender, RoutedEventArgs e)
        {
            // Do something here
        }

        public void CreateActionButtonColumn()
        {
            DataGridTemplateColumn actionColumn = new DataGridTemplateColumn { CanUserReorder = false, Width = 85, CanUserSort = true };
            actionColumn.Header = "Action";
            actionColumn.CellTemplateSelector = new ActionDataTemplateSelector();
            mDataGrid.Columns.Add(actionColumn);
        }

        public void CreateStatusColumnWithImages()
        {
            DataGridTemplateColumn statusImageColumn = new DataGridTemplateColumn { CanUserReorder = false, Width = 85, CanUserSort = false };;
            statusImageColumn.Header = "Image"; 
            statusImageColumn.CellTemplateSelector = new StatusImageDataTemplateSelector();
            mDataGrid.Columns.Insert(0, statusImageColumn);
        }
        #endregion

        #region Properties
        #endregion
    }
}
