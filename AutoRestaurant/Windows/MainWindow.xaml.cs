using AutoRestaurant.Models;
using AutoRestaurant.Models.ControlModels;
using AutoRestaurant.Windows;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace AutoRestaurant
{
    public partial class MainWindow : Window
    {
        private readonly EventHandler updateData;
        private AutoRestaurantDbControl Db { get; set; }
        public MainWindow(string login)
        {
            InitializeComponent();

            Db = new AutoRestaurantDbControl();

            updateData += GetOrders;
            updateData += GetEmployees;
            updateData += GetDishes;
            updateData += GetIngredients;

            Login.Text = login;

            updateData.Invoke(this, EventArgs.Empty);
        }
        #region Методы загрузки окон
        private void LoadWindow(Window window)
        {
            window.Closed += updateData;
            window.ShowDialog();
        }
        private void IngredientWindow(object sender, RoutedEventArgs e) =>
            LoadWindow(new IngredientWindow());
        private void OrderWindow(object sender, RoutedEventArgs e) =>
            LoadWindow(new OrderWindow(SearchId(OrdersList)));
        private void EmployeeWindow(object sender, RoutedEventArgs e) =>
            LoadWindow(new EmployeeWindow(SearchId(EmployeesList)));
        private void DishWindow(object sender, RoutedEventArgs e) =>
            LoadWindow(new DishWindow(SearchId(DishesList)));
        #endregion
        #region Методы удаления
        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = Db.GetElementById<Order>(SearchId(OrdersList).Value);
                if (order == null)
                    throw new Exception();

                Db.Delete<Order>(order.Id);
                Close();
            }
            catch (Exception ex)
            {
                ExceptionWindow exceptionWindow = new ExceptionWindow(ex);
                exceptionWindow.ShowDialog();
            }
            updateData.Invoke(sender, e);
        }

        private void DeleteDish(object sender, RoutedEventArgs e)
        {
            try
            {
                var dish = Db.GetElementById<Dish>(SearchId(DishesList).Value);
                if (dish == null)
                    throw new Exception();

                Db.Delete<Dish>(dish.Id);
                Close();
            }
            catch (Exception ex)
            {
                ExceptionWindow exceptionWindow = new ExceptionWindow(ex);
                exceptionWindow.ShowDialog();
            }
            updateData.Invoke(sender, e);
        }
        private void DeleteIngredient(object sender, RoutedEventArgs e)
        {
            try
            {
                var ingredient = Db.GetElementById<Ingredient>(SearchId(IngredientsList).Value);
                if (ingredient == null)
                    throw new Exception();

                Db.Delete<Ingredient>(ingredient.Id);
                Close();
            }
            catch (Exception ex)
            {
                ExceptionWindow exceptionWindow = new ExceptionWindow(ex);
                exceptionWindow.ShowDialog();
            }
            updateData.Invoke(sender, e);
        }
        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = Db.GetElementById<Employee>(SearchId(EmployeesList).Value);
                if (employee == null)
                    throw new Exception();

                Db.Delete<Employee>(employee.Id);
                Close();
            }
            catch (Exception ex)
            {
                ExceptionWindow exceptionWindow = new ExceptionWindow(ex);
                exceptionWindow.ShowDialog();
            }
            updateData.Invoke(sender, e);
        }
        #endregion
        #region Методы поиска
        private void GetOrders(object sender, EventArgs e) => OrdersList.ItemsSource = Db.GetElements<Order>()
            .Where(x => x.Employee.Surname.Contains(OrderSearch.Text))
            .Select(y => new { ID = y.Id, Стоимость = y.Price, ДатаЗаказа = y.Date, ФамилияСотрудника = y.Employee.Surname, ФамилияЗаказчика = y.Customer.Surname });
        private void GetEmployees(object sender, EventArgs e) => EmployeesList.ItemsSource = Db.GetElements<Employee>()
            .Where(x => x.Surname.Contains(EmployeeSearch.Text))
            .Select(y => new { ID = y.Id, Имя = y.Name, Фамилия = y.Surname, Должность = y.Permission, ДеньРождения = y.Passport.Birthday, Телефон = y.Phone, Зарплата = y.Salary, ДатаПринятия = y.EmpDate });
        private void GetDishes(object sender, EventArgs e) => DishesList.ItemsSource = Db.GetElements<Dish>()
            .Where(x => x.Name.Contains(DishSearch.Text))
            .Select(y => new { ID = y.Id, Название = y.Name, Тип = y.Type, Стоимость = y.Cost });
        private void GetIngredients(object sender, EventArgs e) => IngredientsList.ItemsSource = Db.GetElements<Ingredient>()
            .Where(x => x.Name.Contains(IngredientSearch.Text))
            .Select(y => new { ID = y.Id, Название = y.Name });
        #endregion
        private Guid? SearchId(DataGrid dataGrid)
        {
            if (dataGrid.SelectedItem != null)
                return (Guid)dataGrid.SelectedItem.GetType().GetProperty("ID").GetValue(dataGrid.SelectedItem);
            else
                return null;
        }
    }
}
