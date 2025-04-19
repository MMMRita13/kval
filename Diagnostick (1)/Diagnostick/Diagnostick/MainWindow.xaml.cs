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

namespace Diagnostick
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenEquipmentPerSite_Click(object sender, RoutedEventArgs e)
        {
            new EquipmentPerSiteWindow().ShowDialog();
        }

        private void OpenDiagnosticsOrganizations_Click(object sender, RoutedEventArgs e)
        {
            new DiagnosticsOrganizationsWindow().ShowDialog();
        }

        private void OpenManageEquipment_Click(object sender, RoutedEventArgs e)
        {
            new ManageEquipmentWindow().ShowDialog();
        }
    }
}
