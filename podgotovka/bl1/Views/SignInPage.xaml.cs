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
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void ButtonClickSignIn(object sender, RoutedEventArgs e)
        {
           var CurrentUser = AppData.db.Users.FirstOrDefault(u => u.USerLog == TbxLogin.Text 
           && u.UserPass == TbxPassword.Text);
            if (CurrentUser != null)
            {
                NavigationService.Navigate(new RequestPageInfo());
            }
            else MessageBox.Show("NO");
        }
    }
}
