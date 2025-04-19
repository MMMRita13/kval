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

namespace CarRental
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CarRentalDBEntities db = new CarRentalDBEntities();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            VehicleGrid.ItemsSource = db.Vehicle.Include("VehicleType").ToList();
            ClientGrid.ItemsSource = db.Client.ToList();
            ContractGrid.ItemsSource = db.RentalContract.Include("Client").Include("Vehicle").ToList();
            FirmGrid.ItemsSource = db.Firm.ToList();
            TypeGrid.ItemsSource = db.VehicleType.ToList();
        }

        private void AddContract_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddContractWindow();
            if (window.ShowDialog() == true)
            {
                db.RentalContract.Add(window.NewContract);
                db.SaveChanges();
                MessageBox.Show("Новый договор успешно добавлен!");
                LoadData();
            }
        }

        private void DeleteContract_Click(object sender, RoutedEventArgs e)
        {
            var selected = ContractGrid.SelectedItem as RentalContract;
            if (selected != null)
            {
                var result = MessageBox.Show("Удалить выбранный договор?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    db.RentalContract.Remove(selected);
                    db.SaveChanges();
                    MessageBox.Show("Договор удалён.");
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите договор для удаления.");
            }
        }

        private void OpenReportsWindow_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно отчетов
            ReportsWindow reportsWindow = new ReportsWindow();
            reportsWindow.ShowDialog();
        }
    }
}
