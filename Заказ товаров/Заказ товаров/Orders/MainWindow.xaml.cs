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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Orders
{
    public partial class MainWindow : Window
    {
        OrderSystemEntities db = new OrderSystemEntities();

        public MainWindow()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            OrdersGrid.ItemsSource = db.Order.Include("Client").Include("OrderItem").ToList();
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            var win = new NewOrderWindow();
            win.ShowDialog();
            LoadOrders();
        }

        private void EditOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersGrid.SelectedItem is Order selectedOrder)
            {
                var win = new NewOrderWindow(selectedOrder.Id);
                win.ShowDialog();
                LoadOrders();
            }
            else
            {
                MessageBox.Show("Выберите заказ для редактирования.");
            }
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersGrid.SelectedItem is Order selectedOrder)
            {
                if (MessageBox.Show("Удалить заказ?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var order = db.Order.Include("OrderItem").FirstOrDefault(o => o.Id == selectedOrder.Id);
                    if (order != null)
                    {
                        db.OrderItem.RemoveRange(order.OrderItem.ToList());
                        db.SaveChanges();

                        db.Order.Remove(order);
                        db.SaveChanges();

                        LoadOrders();
                        MessageBox.Show("Заказ удалён.");
                    }
                    else
                    {
                        MessageBox.Show("Не найден заказ в базе.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для удаления.");
            }
        }

        private void OpenReports_Click(object sender, RoutedEventArgs e)
        {
            var reportsWindow = new ReportsWindow();
            reportsWindow.ShowDialog();
        }
    }
}