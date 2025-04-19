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

namespace Diagnostick
{
    /// <summary>
    /// Логика взаимодействия для ManageEquipmentWindow.xaml
    /// </summary>
    public partial class ManageEquipmentWindow : Window
    {
        public ManageEquipmentWindow()
        {
            InitializeComponent();
            LoadEquipment();
        }

        private void LoadEquipment()
        {
            EquipmentGrid.ItemsSource = DiagnostikaDeviceEntities.GetContext().Equipment.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newEquipment = new Equipment
            {
                Number = "Новый",
                Name = "Оборудование",
                StartDate = DateTime.Today
            };
            DiagnostikaDeviceEntities.GetContext().Equipment.Add(newEquipment);
            DiagnostikaDeviceEntities.GetContext().SaveChanges();
            LoadEquipment();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EquipmentGrid.SelectedItem is Equipment selected)
            {
                DiagnostikaDeviceEntities.GetContext().Equipment.Remove(selected);
                DiagnostikaDeviceEntities.GetContext().SaveChanges();
                LoadEquipment();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DiagnostikaDeviceEntities.GetContext().SaveChanges();
            LoadEquipment();
        }
    }
}
