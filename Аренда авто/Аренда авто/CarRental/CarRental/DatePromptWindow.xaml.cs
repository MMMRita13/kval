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
    /// Логика взаимодействия для DatePromptWindow.xaml
    /// </summary>
    public partial class DatePromptWindow : Window
    {
        public DateTime SelectedDate { get; private set; }

        public DatePromptWindow(string message)
        {
            InitializeComponent();
            this.Title = message;
        }

        // Обработчик нажатия кнопки "ОК"
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate.HasValue)
            {
                SelectedDate = DatePicker.SelectedDate.Value;
                this.DialogResult = true; // Закрывает окно, если дата выбрана
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите дату.");
            }
        }
        public static DateTime PromptDate(string prompt)
        {
            DatePromptWindow window = new DatePromptWindow(prompt);
            if (window.ShowDialog() == true)
            {
                return window.SelectedDate;
            }
            else
            {
                return DateTime.Now;
            }
        }
    }
}
