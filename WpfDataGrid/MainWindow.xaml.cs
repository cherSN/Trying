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

namespace WpfDataGrid
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataView DView { set; get; }

        public MainWindow()
        {
            InitializeComponent();
            DView = new DataView();
            DView.TicketsList.Add(new TicketInfo("IE Not Working", "Open", "User 1"));
            DView.TicketsList.Add(new TicketInfo("TFS Not Working", "Assigned", "User 3"));
            DView.TicketsList.Add(new TicketInfo("VS 2008 Not Working", "Open", "User 5"));
            DView.TicketsList.Add(new TicketInfo("SQL SERVER Not Working", "Closed", "User 2"));
            DataContext = DView;

        }
    }

    public class DataView
    {


        public List<TicketInfo> TicketsList
        {
            get { return ticketsList; }

            set {
                ticketsList = value;
            }
        }

        private List<TicketInfo> ticketsList;
        public DataView()
        {
            ticketsList = new List<TicketInfo>();
        }
    }

    public class TicketInfo
    {
        public string Subject { get; set; }
        public string Status { get; set; }
        public string RaisedBy { get; set; }
        public TicketInfo(string subject, string status, string raiseby)
        {
            Subject = subject;
            Status = status;
            RaisedBy = raiseby;
        }
        
    }

}
