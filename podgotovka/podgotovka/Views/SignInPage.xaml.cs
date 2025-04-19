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
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUser = AppData.db.Users.FirstOrDefault(u => u.LoginUser == TbxLogin.Text && u.PasswordUser == TbxPassword.Text);
            if (CurrentUser != null)
            {
                NavigationService.Navigate(new DataPage());
            }
            else
            {
                MessageBox.Show("Данного пользователя не существует");
            }
        }
    }
}
