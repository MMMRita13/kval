using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MedicalExaminationApp
{
    public partial class ReportWindow : Window
    {
        private MedicalExaminationEntities _context = new MedicalExaminationEntities();

        public ReportWindow()
        {
            InitializeComponent();
            ReportType.SelectedIndex = 0;
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            if (ReportType.SelectedIndex == 0)
            {
                DateTime start = StartDate.SelectedDate ?? DateTime.MinValue;
                DateTime end = EndDate.SelectedDate ?? DateTime.MaxValue;

                var data = _context.MedicalExams
                    .Where(me => me.ExamDate >= start && me.ExamDate <= end)
                    .Select(me => new
                    {
                        me.Employees.LastName,
                        me.Employees.FirstName,
                        me.ExamDate,
                        me.ExamResults.Name
                    })
                    .ToList();

                ReportGrid.ItemsSource = data;
            }
            else
            {
                var currentYear = DateTime.Now.Year;
                var data = _context.Notifications
                    .Where(n => n.NotificationDate.Year == currentYear &&
                           !_context.MedicalExams.Any(me => me.EmployeeId == n.EmployeeId))
                    .Select(n => new
                    {
                        n.Employees.LastName,
                        n.Employees.FirstName,
                        n.NotificationDate
                    })
                    .ToList();

                ReportGrid.ItemsSource = data;
            }
        }

    }
}