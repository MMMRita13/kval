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

namespace bl1.Views
{
    /// <summary>
    /// Логика взаимодействия для NewRequestPage.xaml
    /// </summary>
    public partial class NewRequestPage : Page
    {
        public NewRequestPage()
        {
            InitializeComponent();

            CmbClient.ItemsSource = AppData.db.Clients.ToList();
            CmbTech.ItemsSource  = AppData.db.Tech.ToList();
            CmbWorker.ItemsSource = AppData.db.Workers.ToList();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            Requests req = new Requests();

            int maxReqID = AppData.db.Requests.Max(r => r.ReqID);
            req.ReqID = maxReqID + 1; // Генерируем новый ID

            IdReqTbx.Text = req.ReqID.ToString(); 

            req.ReqName = ReqNameTbx.Text;
            if (int.TryParse(ReqNumberTbx.Text, out int reqNumber))
            {
                req.ReqNumber = reqNumber;
            }
            else
            {
                MessageBox.Show("Некорректный номер заявки");
                return; 
            }

            var CurrentTech = CmbTech.SelectedItem as Tech;
            req.TechID = CurrentTech.TechID;

            var CurrentClient = CmbClient.SelectedItem as Clients;
            req.ClientID = CurrentClient.ClientID;

            var CurrentWorker = CmbWorker.SelectedItem as Workers;
            req.WorkerID = CurrentWorker.WorkerID;

            AppData.db.Requests.Add(req);
            AppData.db.SaveChanges();
            MessageBox.Show("Save");
            NavigationService.GoBack();
        }
    }
}
