using podgotovka.Model;
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
using podgotovka.Model;

namespace podgotovka.Views
{
    /// <summary>
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        public DataPage()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UsersGrid.ItemsSource = AppData.db.Users.ToList();
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewUserPage());
        }

        private void Rem_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить пользователя", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentUser = UsersGrid.SelectedItem as Users;
                AppData.db.Users.Remove(CurrentUser);
                AppData.db.SaveChanges();

                UsersGrid.ItemsSource = AppData.db.Users.ToList();
                MessageBox.Show("Done");
            }
        }

        private void Upd_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
