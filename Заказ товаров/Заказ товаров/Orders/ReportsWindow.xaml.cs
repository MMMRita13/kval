using System;
using System.Linq;
using System.Windows;

namespace Orders
{
    public partial class ReportsWindow : Window
    {
        OrderSystemEntities db = new OrderSystemEntities();

        public ReportsWindow()
        {
            InitializeComponent();
        }

        private void GenerateInvoice_Click(object sender, RoutedEventArgs e)
        {
            var orderItems = db.OrderItem
                .Join(db.Product, oi => oi.ProductId, p => p.Id, (oi, p) => new { oi, p })
                .ToList();

            var invoiceDetails = orderItems.Select(i => new
            {
                ProductName = i.p.Name,
                Quantity = i.oi.Quantity,
                UnitPrice = i.oi.UnitPrice,
                TotalPrice = i.oi.Quantity * i.oi.UnitPrice
            });

            string invoiceText = "Товарная накладная:\n\n";
            foreach (var item in invoiceDetails)
            {
                invoiceText += $"{item.ProductName} - {item.Quantity} шт. по {item.UnitPrice:C} за шт. = {item.TotalPrice:C}\n";
            }

            ReportText.Text = invoiceText;
        }

        private void GenerateManagerReport_Click(object sender, RoutedEventArgs e)
        {
            var dateFrom = DateTime.Now.AddMonths(-1);
            var dateTo = DateTime.Now;

            var reportData = db.OrderItem
                               .Join(db.Product, oi => oi.ProductId, p => p.Id, (oi, p) => new { oi, p })
                               .Where(i => i.oi.Order.OrderDate >= dateFrom && i.oi.Order.OrderDate <= dateTo)
                               .GroupBy(i => i.p.Name)
                               .Select(g => new
                               {
                                   ProductName = g.Key,
                                   TotalOrdered = g.Sum(i => i.oi.Quantity),
                                   TotalSold = g.Sum(i => i.oi.Quantity * i.oi.UnitPrice)
                               }).ToList();

            string reportText = $"Отчет за период с {dateFrom:dd.MM.yyyy} по {dateTo:dd.MM.yyyy}:\n\n";
            foreach (var item in reportData)
            {
                reportText += $"{item.ProductName}: Кол-во заказано - {item.TotalOrdered}, Объем реализации - {item.TotalSold:C}\n";
            }

            ReportText.Text = reportText;
        }
    }
}
