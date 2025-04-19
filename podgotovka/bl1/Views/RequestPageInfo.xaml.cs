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
    /// Логика взаимодействия для RequestPageInfo.xaml
    /// </summary>
    public partial class RequestPageInfo : Page
    {
        public RequestPageInfo()
        {
            InitializeComponent();
           // DGridRequest.ItemsSource = new TestBaseProbaEntities.GetContext().Requests.ToList();
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RequestGrid.ItemsSource = AppData.db.Requests.ToList();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewRequestPage());
        }

        private void Rem_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить заказ", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentReq = RequestGrid.SelectedItem as Requests;
                AppData.db.Requests.Remove(CurrentReq);
                AppData.db.SaveChanges();

                RequestGrid.ItemsSource = AppData.db.Requests.ToList();
                MessageBox.Show("Done");
            }
        }

        private void Upd_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpdReqPage());
        }
    }
}
