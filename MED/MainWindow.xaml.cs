using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace MED
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MEDEntities db = new MEDEntities();
        public MainWindow()
        {
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            SchedulesGrid.ItemsSource = db.schedules.ToList();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {

            var window = new scheduleForm();
            if (window.ShowDialog() == true)
            {
                db.schedules.Add(window.Schedule);
                db.SaveChanges();
                LoadEmployees();
            }
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                using (var context = new MEDEntities())
                {
                    
                    var schedulesFromGrid = SchedulesGrid.ItemsSource as IEnumerable<schedules>;
                    if (schedulesFromGrid == null)
                    {
                        MessageBox.Show("Нет данных для сохранения!");
                        return;
                    }

                    foreach (var schedule in schedulesFromGrid)
                    {
                        
                        if (schedule.schedule_id == 0)
                        {
                            context.schedules.Add(schedule);
                            continue;
                        }

                        
                        var existing = context.schedules.Find(schedule.schedule_id);
                        if (existing != null)
                        {
                            context.Entry(existing).CurrentValues.SetValues(schedule);
                            context.Entry(existing).State = EntityState.Modified;
                        }
                        else
                        {
                            
                            MessageBox.Show($"Запись с ID {schedule.schedule_id} не найдена в БД!");
                            return;
                        }
                    }

                   
                    int savedCount = context.SaveChanges();
                    MessageBox.Show($"Успешно сохранено записей: {savedCount}");

                    
                    LoadEmployees();
                }
            }
            
            catch (Exception ex)
            {
                // 8. Общая обработка ошибок
                MessageBox.Show($"Критическая ошибка: {ex.Message}");
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (SchedulesGrid.SelectedItem is schedules selected)
            {
                if (MessageBox.Show("Удалить сотрудника?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    db.schedules.Remove(selected);
                    db.SaveChanges();
                    LoadEmployees();
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string schedulenumber = SearchTextBox.Text.Trim();

            using (var context = new MEDEntities())
            {
                var results = context.schedules
                    .Where(emp => emp.schedule_number.Contains(schedulenumber))
                    .ToList();

                SchedulesGrid.ItemsSource = results;
            }
        }

    }
}
