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
    /// Логика взаимодействия для DiagnosticsOrganizationsWindow.xaml
    /// </summary>
    public partial class DiagnosticsOrganizationsWindow : Window
    {
        public DiagnosticsOrganizationsWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var context = DiagnostikaDeviceEntities.GetContext();
            DateTime fromDate = FromDate.SelectedDate ?? DateTime.MinValue;
            DateTime toDate = ToDate.SelectedDate ?? DateTime.MaxValue;

            var orgList = context.Diagnostics
                .Where(d => d.MeasureDateTime >= fromDate && d.MeasureDateTime <= toDate
                            && d.ExternalOrganizationName != null)
                .Select(d => new
                {
                    d.ExternalOrganizationName,
                    d.ExternalOrganizationAddress
                })
                .Distinct()
                .ToList();

            OrganizationGrid.ItemsSource = orgList;
        }
    }
}
