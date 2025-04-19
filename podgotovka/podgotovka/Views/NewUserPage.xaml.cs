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

namespace podgotovka.Views
{
    /// <summary>
    /// Логика взаимодействия для NewUserPage.xaml
    /// </summary>
    public partial class NewUserPage : Page
    {
        public NewUserPage()
        {
            InitializeComponent();
            
            CmbRole.ItemsSource = AppData.db.Roles.ToList();
        }

        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            Users people = new Users();

            people.LoginUser = LoginTbx.Text;
            people.PasswordUser = PasswordTbx.Text;

            var CurrentRole = CmbRole.SelectedItem as Roles;   
            people.IDRole = CurrentRole.IDRole;

            AppData.db.Users.Add(people);
            AppData.db.SaveChanges(); 
            MessageBox.Show("Okey");
            NavigationService.GoBack();
        }
    }
}
