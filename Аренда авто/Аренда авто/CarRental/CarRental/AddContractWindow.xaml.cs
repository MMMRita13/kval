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

namespace CarRental
{
    /// <summary>
    /// Логика взаимодействия для AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        private CarRentalDBEntities db = new CarRentalDBEntities();

        public RentalContract NewContract { get; private set; }

        public AddContractWindow()
        {
            InitializeComponent();
            ClientBox.ItemsSource = db.Client.ToList();
            VehicleBox.ItemsSource = db.Vehicle.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ClientBox.SelectedItem == null || VehicleBox.SelectedItem == null ||
                !DateTime.TryParse(StartDatePicker.Text, out DateTime start) ||
                !DateTime.TryParse(EndDatePicker.Text, out DateTime end) ||
                !decimal.TryParse(PriceBox.Text, out decimal price))
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.");
                return;
            }

            if (end <= start)
            {
                MessageBox.Show("Дата окончания должна быть позже даты начала.");
                return;
            }

            NewContract = new RentalContract
            {
                ContractNumber = "ДОГ-" + DateTime.Now.Ticks.ToString().Substring(10),
                ContractDate = DateTime.Now,
                StartDate = start,
                EndDate = end,
                DailyPrice = price,
                ClientId = ((Client)ClientBox.SelectedItem).Id,
                VehicleId = ((Vehicle)VehicleBox.SelectedItem).Id
            };

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
