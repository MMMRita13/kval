using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace MedicalExaminationApp
{
    public partial class EmployeesWindow : Window
    {
        private MedicalExaminationEntities _context = new MedicalExaminationEntities();

        public EmployeesWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            _context.Employees.Load();
            EmployeesGrid.ItemsSource = _context.Employees.Local;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _context.Employees.Add(new Employees());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedItem is Employees employee)
            {
                _context.Employees.Remove(employee);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _context.SaveChanges();
                LoadData();     
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string errorMessage = "Ошибка валидации:\n";
                foreach (var validationError in ex.EntityValidationErrors)
                {
                    foreach (var error in validationError.ValidationErrors)
                    {
                        errorMessage += $"- {error.PropertyName}: {error.ErrorMessage}\n";
                    }
                }
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                
                _context.Dispose();
                _context = new MedicalExaminationEntities();
                LoadData();
            }
        }
    }
}