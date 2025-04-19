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
    /// Логика взаимодействия для EquipmentPerSiteWindow.xaml
    /// </summary>
    public partial class EquipmentPerSiteWindow : Window
    {
        public EquipmentPerSiteWindow()
        {
            InitializeComponent();
            LoadEquipmentPerSite();
        }
        private void LoadEquipmentPerSite()
        {
            var context = DiagnostikaDeviceEntities.GetContext();
            var equipmentList = context.Equipment
                .Where(e => e.StartDate <= DateTime.Today &&
                            (e.EndDate == null || e.EndDate > DateTime.Today))
                .Join(context.Sites,
                      eq => eq.SiteId,
                      st => st.Id,
                      (eq, st) => new
                      {
                          EquipmentNumber = eq.Number,
                          EquipmentName = eq.Name,
                          SiteName = st.Name
                      })
                .ToList();
            EquipmentGrid.ItemsSource = equipmentList;
        }
    }
}
