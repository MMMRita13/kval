using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        private CarRentalDBEntities db;

        public ReportsWindow()
        {
            InitializeComponent();
            db = new CarRentalDBEntities();  // Инициализация контекста базы данных
        }

        // Запрос отчетов для руководителя фирмы
        private void DirectorReports_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = PromptDate("Введите дату начала периода:");
            DateTime end = PromptDate("Введите дату конца периода:");

                var vehiclesInRental = db.RentalContract
                .Where(r => r.StartDate >= start && r.EndDate <= end)
                .Include(r => r.Vehicle)  // Явно загружаем связанные объекты Vehicle
                .Include(r => r.Vehicle.VehicleType)  // Явно загружаем связанный объект VehicleType
                .GroupBy(r => r.Vehicle.VehicleType)
                .Select(g => new
                {
                    VehicleType = g.Key.Name,  // Используем Name, чтобы получить строковое представление типа ТС
                    Count = g.Count()
                }).ToList();

            ReportGrid.ItemsSource = vehiclesInRental;
        }

        private void VehiclesByTypeOnDate_Click(object sender, RoutedEventArgs e)
        {
            DateTime targetDate = DatePromptWindow.PromptDate("Введите дату для отчета:");

            var vehiclesInRental = db.RentalContract
                .Where(r => r.StartDate <= targetDate && r.EndDate >= targetDate)
                .Include(r => r.Vehicle)
                .Include(r => r.Vehicle.VehicleType)
                .GroupBy(r => r.Vehicle.VehicleType.Name)
                .Select(g => new
                {
                    ВидТС = g.Key,
                    Количество = g.Count()
                })
                .ToList();

            ReportGrid.ItemsSource = vehiclesInRental;
        }

        // Метод для выбора даты (для отчетов)
        private DateTime PromptDate(string message)
        {
            var dateWindow = new DatePromptWindow(message); // Создаем окно для выбора даты
            dateWindow.ShowDialog();

            return dateWindow.SelectedDate;  // Возвращаем выбранную дату
        }
    }
}
