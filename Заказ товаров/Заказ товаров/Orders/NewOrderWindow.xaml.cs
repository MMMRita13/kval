using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Orders
{
    public partial class NewOrderWindow : Window
    {
        OrderSystemEntities db = new OrderSystemEntities();
        List<OrderItem> items = new List<OrderItem>();
        int? editingOrderId = null;

        public NewOrderWindow(int? orderId = null)
        {
            InitializeComponent();
            editingOrderId = orderId;
            CmbClients.ItemsSource = db.Client.ToList();
            CmbProducts.ItemsSource = db.Product.ToList();

            if (editingOrderId.HasValue)
                LoadOrder(editingOrderId.Value);
        }

        private void LoadOrder(int orderId)
        {
            var order = db.Order.Include("OrderItem.Product").FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                CmbClients.SelectedItem = order.Client;
                items = order.OrderItem.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Product = i.Product
                }).ToList();
                ItemsGrid.ItemsSource = null;
                ItemsGrid.ItemsSource = items;
            }
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            if (CmbProducts.SelectedItem is Product product &&
                int.TryParse(TxtQuantity.Text, out int quantity) &&
                decimal.TryParse(TxtPrice.Text, out decimal price))
            {
                var item = new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = quantity,
                    UnitPrice = price,
                    Product = product
                };
                items.Add(item);
                ItemsGrid.ItemsSource = null;
                ItemsGrid.ItemsSource = items;
            }
            else
            {
                MessageBox.Show("Проверьте поля товара, количества и цены.");
            }
        }

        private void SaveOrder_Click(object sender, RoutedEventArgs e)
        {
            if (CmbClients.SelectedItem is Client client && items.Any())
            {
                if (editingOrderId.HasValue)
                {
                    var order = db.Order.Include("OrderItem").FirstOrDefault(o => o.Id == editingOrderId.Value);
                    if (order != null)
                    {
                        db.OrderItem.RemoveRange(order.OrderItem.ToList());
                        db.SaveChanges();

                        foreach (var item in items)
                        {
                            var newItem = new OrderItem
                            {
                                OrderId = order.Id,
                                ProductId = item.ProductId,
                                Quantity = item.Quantity,
                                UnitPrice = item.UnitPrice
                            };
                            db.OrderItem.Add(newItem);
                        }

                        order.ClientId = client.Id;
                        order.OrderDate = System.DateTime.Now;
                        db.Entry(order).State = EntityState.Modified;
                        db.SaveChanges();
                        MessageBox.Show("Заказ обновлён.");
                        this.Close();
                    }
                }
                else
                {
                    var newOrder = new Order
                    {
                        ClientId = client.Id,
                        OrderDate = System.DateTime.Now,
                        OrderItem = items.Select(i => new OrderItem
                        {
                            ProductId = i.ProductId,
                            Quantity = i.Quantity,
                            UnitPrice = i.UnitPrice
                        }).ToList()
                    };
                    db.Order.Add(newOrder);
                    db.SaveChanges();
                    MessageBox.Show("Новый заказ сохранён.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента и добавьте товары.");
            }
        }
    }
}