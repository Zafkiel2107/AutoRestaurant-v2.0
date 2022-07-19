using AutoRestaurant.Models;
using AutoRestaurant.Models.ControlModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AutoRestaurant.Windows
{
    public partial class OrderWindow : Window
    {
        private Guid OrderId { get; set; }
        private AutoRestaurantDbControl Db { get; set; }
        public OrderWindow(Guid? orderId = null)
        {
            InitializeComponent();

            Db = new AutoRestaurantDbControl();

            employee.ItemsSource = Db.GetElements<Employee>().Select(x => x.Surname);
            dishes.ItemsSource = Db.GetElements<Dish>().Select(x => x.Name);
            if (orderId.HasValue)
            {
                btn.Click -= CreateOrder;
                btn.Click += UpdateOrder;

                var order = Db.GetElementById<Order>(orderId.Value);
                price.Text = order.Price.ToString();
                employee.SelectedItem = order.Employee.Surname;
                customerSurname.Text = order.Customer.Surname;
                customerName.Text = order.Customer.Name;

                OrderId = orderId.Value;
            }
        }
        private void CreateOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = new Order()
                {
                    Dishes = Db.GetElements<Dish>().Where(x => dishes.SelectedItems.Cast<string>().Contains(x.Name)).ToList(),
                    Customer = new Customer() { Name = customerName.Text, Surname = customerSurname.Text },
                    Employee = Db.GetElements<Employee>().FirstOrDefault(x => x.Surname == employee.Text),
                    Price = double.Parse(price.Text),
                    Date = DateTime.Now,
                };

                Db.Create<Order>(order);
                Close();
            }
            catch (Exception ex)
            {
                ExceptionWindow exceptionWindow = new ExceptionWindow(ex);
                exceptionWindow.ShowDialog();
            }
        }
        private void UpdateOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = Db.GetElementById<Order>(OrderId);
                if (order == null)
                    throw new Exception();

                order.Dishes = Db.GetElements<Dish>().Where(x => dishes.SelectedItems.Cast<string>().Contains(x.Name)).ToList();
                order.Customer.Name = customerName.Text;
                order.Customer.Surname = customerSurname.Text;
                order.Employee.Surname = employee.Text;
                order.Price = double.Parse(price.Text);

                Db.Update<Order>(order);
                Close();
            }
            catch (Exception ex)
            {
                ExceptionWindow exceptionWindow = new ExceptionWindow(ex);
                exceptionWindow.ShowDialog();
            }
        }
        #region Расчет стоимости заказа
        private void Dishes_SelectionChanged(object sender, RoutedEventArgs e)
        {
            price.Text = CountPrice(dishes.SelectedItems.Cast<string>()).ToString();
        }
        private double CountPrice(IEnumerable<string> dishesName)
        {
            var dishes = Db.GetElements<Dish>().Where(x => dishesName.Contains(x.Name));
            double orderprice = 0;
            foreach (Dish dish in dishes)
            {
                orderprice += dish.Cost;
            }
            return orderprice;
        }
        #endregion
    }
}