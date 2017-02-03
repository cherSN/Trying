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

namespace ComboBoxWPFmy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> statut;

        public MainWindow()
        {
            InitializeComponent();
            List<TicketInfo> ticketsList = new List<TicketInfo>
            {
                new TicketInfo{ Subject="IE Not Working", Status="Open", RaisedBy="User 1"},
                new TicketInfo{ Subject="TFS Not Working", Status="Assigned", RaisedBy="User 3"},
                new TicketInfo{ Subject="VS 2008 Not Working", Status="Open", RaisedBy="User 9"},
                new TicketInfo{ Subject="SQL SERVER Not Working", Status="Open", RaisedBy="User 2"},
                new TicketInfo{ Subject="Portal Not Working", Status="Closed", RaisedBy="User 12"},
                new TicketInfo{ Subject="Not able to log in to portal", Status="Open", RaisedBy="User 4"},
                new TicketInfo{ Subject="WIFI not Working", Status="Open", RaisedBy="User 7"}
            };

            Statut = new List<string>();
            Statut.Add("Assigned1");
            Statut.Add("Closed1");
            Statut.Add("In Progress1");
            Statut.Add("Open1");
            Statut.Add("Resolved1");
            dgData.ItemsSource = ticketsList;
        }

        public List<string> Statut
        {
            get
            {
                return statut;
            }

            set
            {
                statut = value;
            }
        }
    }

    public class TicketInfo
    {
        public string Subject { get; set; }
        public string Status { get; set; }
        public string RaisedBy { get; set; }
    }

    public class StatusList : List<string>
    {
        public StatusList()
        {
            this.Add("Assigned");
            this.Add("Closed");
            this.Add("In Progress");
            this.Add("Open");
            this.Add("Resolved");
        }
    }
}
