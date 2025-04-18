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

namespace MED
{
    /// <summary>
    /// Логика взаимодействия для scheduleForm.xaml
    /// </summary>
    public partial class scheduleForm : Window
    {
        public schedules Schedule { get; set; }

        public scheduleForm(schedules existing = null)
        {
            InitializeComponent();
            Schedule = existing ?? new schedules();
            // Устанавливаем DataContext для привязки данных
            DataContext = Schedule;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем значения из полей ввода в объект Schedule
            Schedule.schedule_id= int.Parse(LastNameBox.Text);

            Schedule.schedule_number = FirstNameBox.Text;
            Schedule.obsled_date = ObsledDatePicker.SelectedDate ?? DateTime.Now;

            if (int.TryParse(DepartmentIdBox.Text, out int departmentId))
            {
                Schedule.department_id = departmentId;
            }
            else
            {
                MessageBox.Show("Некорректный ID подразделения!");
                return;
            }

            DialogResult = true;
            Close();
        }
    }
}
