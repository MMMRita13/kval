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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RepairMMEntities db;
        public MainWindow()
        {
            InitializeComponent();
            db= new RepairMMEntities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = textBoxUserName.Text;

            var user = db.CompanyUsers.FirstOrDefault(u => u.CompanyUsers_Post == userName);

            if (user.CompanyUsers_Post == "Руководитель Организации")
            {
                ViewWindow viewWindow = new ViewWindow();
                viewWindow.Show();
                this.Close();
            }
            else if (user.CompanyUsers_Post == "Сотрудник")
            {
                Window1 window1 = new Window1();
                window1.Show();
                this.Close();
            }
            else if(user.CompanyUsers_Post == "Руководитель по клиентам")
            {
                ClientWindow window1 = new ClientWindow();
                window1.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден.");
            }
        }
    }
}
