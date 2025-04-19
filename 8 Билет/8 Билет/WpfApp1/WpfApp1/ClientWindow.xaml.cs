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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        RepairMMEntities db;
        public ClientWindow()
        {
            InitializeComponent();
            db = new RepairMMEntities();
        }

        private void Button_LoadData_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(textBoxStartDate.Text, out DateTime startDate) &&
                DateTime.TryParse(textBoxEndDate.Text, out DateTime endDate))
            {
                LoadClientsNotPickedUp(startDate, endDate);
                LoadRepairDelayCauses(startDate, endDate);
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные даты.");
            }
        }

        private void LoadRepairDelayCauses(DateTime startDate, DateTime endDate)
        {
            using (var db = new RepairMMEntities())
            {
                var delayCauses = from receipt in db.Receipt
                                  where receipt.Receipt_Date >= startDate && receipt.Receipt_Date <= endDate
                                  group receipt by receipt.RepeirCause_Id into g
                                  join cause in db.RepeirCause on g.Key equals cause.RepeirCause_Id
                                  select new
                                  {
                                      CauseName = cause.RepeirCause_Name,
                                      Count = g.Count()
                                  };

                dataGridRepairDelays.ItemsSource = delayCauses.ToList();
            }
        }

        private void LoadClientsNotPickedUp(DateTime startDate, DateTime endDate)
        {
            using (var db = new RepairMMEntities())
            {
                var clientsNotPickedUp = from receipt in db.Receipt
                                         where receipt.Receipt_Date >= startDate && receipt.Receipt_Date <= endDate
                                         select new
                                         {
                                             ClientName = receipt.CompanyUsers.CompanyUsers_Name,
                                             ReceiptDate = receipt.Receipt_Date
                                         };

                dataGridClientsNotPickedUp.ItemsSource = clientsNotPickedUp.ToList();
            }
            
        }
    }
}
    

