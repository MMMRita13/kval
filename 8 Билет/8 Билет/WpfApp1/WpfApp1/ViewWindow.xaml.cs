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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ViewWindow.xaml
    /// </summary>
    public partial class ViewWindow : Window
    {
        RepairMMEntities db;
        public ViewWindow()
        {
            InitializeComponent();
            db = new RepairMMEntities();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBoxDays.Text, out int days))
            {
                DateTime startDate = DateTime.Now.AddDays(-days);
                DateTime endDate = DateTime.Now;

                    var repairReceipts = db.Receipt
                        .Where(r => r.Receipt_Date >= startDate && r.Receipt_Date <= endDate)
                        .GroupBy(r => new { r.RepeirCause_Id, r.CompanyUsers_Id })
                        .Select(g => new
                        {
                            CauseId = g.Key.RepeirCause_Id,
                            UserId = g.Key.CompanyUsers_Id,
                            Count = g.Count(),
                        }).ToList();

                    DtUnit.ItemsSource = repairReceipts;
            }
            else
            {
                MessageBox.Show("Введите корректное число.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog p = new PrintDialog();
            if (p.ShowDialog() == true)
                p.PrintVisual(DtUnit, "Print");
        }
    }
}
