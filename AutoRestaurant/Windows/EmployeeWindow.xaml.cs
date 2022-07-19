using AutoRestaurant.Models;
using AutoRestaurant.Models.ClassExtension;
using AutoRestaurant.Models.ControlModels;
using AutoRestaurant.Windows.ClassExtensionWindow;
using System;
using System.Windows;

namespace AutoRestaurant.Windows
{
    public partial class EmployeeWindow : Window
    {
        private Guid? EmployeeId { get; set; }
        private LoginPasswordWindow LPWindow { get; set; }
        private AddressWindow AWindow { get; set; }
        private PassportWindow PWindow { get; set; }
        private AutoRestaurantDbControl Db { get; set; }
        public EmployeeWindow(Guid? employeeId = null)
        {
            InitializeComponent();

            Db = new AutoRestaurantDbControl();

            permission.ItemsSource = Enum.GetValues(typeof(Permission));
            if (employeeId.HasValue)
            {
                btn.Click -= CreateEmployee;
                btn.Click += UpdateEmployee;

                var employee = Db.GetElementById<Employee>(employeeId.Value);
                name.Text = employee.Name;
                surname.Text = employee.Surname;
                permission.SelectedItem = employee.Permission;
                phone.Text = employee.Phone;
                salary.Text = employee.Salary.ToString();

                EmployeeId = employeeId;
            }
        }
        private void CreateEmployee(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = new Employee()
                {
                    Address = new Address()
                    {
                        City = AWindow.city.Text,
                        Building = int.Parse(AWindow.building.Text),
                        House = int.Parse(AWindow.house.Text),
                        Street = AWindow.street.Text,
                        PostalCode = int.Parse(AWindow.postalCode.Text),
                        Flat = int.Parse(AWindow.flat.Text)
                    },

                    Passport = new Passport()
                    {
                        IssuedBy = PWindow.issuedBy.Text,
                        IssuedDate = DateTime.Parse(PWindow.issuedDate.Text),
                        Code = PWindow.code.Text,
                        Birthday = DateTime.Parse(PWindow.birthday.Text),
                        BirthPlace = PWindow.birthPlace.Text,
                        Type = (GenderType)Enum.Parse(typeof(GenderType), PWindow.type.Text),
                        Series = int.Parse(PWindow.series.Text),
                        Number = int.Parse(PWindow.number.Text)
                    },

                    Autorization = new Autorization()
                    {
                        Login = LPWindow.login.Text,
                        Password = LPWindow.password.Text
                    },

                    Name = name.Text,
                    Surname = surname.Text,
                    Permission = (Permission)Enum.Parse(typeof(Permission), permission.Text),
                    Phone = phone.Text,
                    Salary = double.Parse(salary.Text),
                    EmpDate = DateTime.Now
                };

                Db.Create<Employee>(employee);
                Close();
            }
            catch (Exception ex)
            {
                ExceptionWindow exceptionWindow = new ExceptionWindow(ex);
                exceptionWindow.ShowDialog();
            }
        }
        private void UpdateEmployee(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = Db.GetElementById<Employee>(EmployeeId.Value);
                if (employee == null)
                    throw new Exception();

                employee.Address = new Address() 
                { 
                    City = AWindow.city.Text, 
                    Building = int.Parse(AWindow.building.Text), 
                    House = int.Parse(AWindow.house.Text),  
                    Street = AWindow.street.Text, 
                    PostalCode = int.Parse(AWindow.postalCode.Text), 
                    Flat = int.Parse(AWindow.flat.Text)
                };

                employee.Passport = new Passport()
                {
                    IssuedBy = PWindow.issuedBy.Text,
                    IssuedDate = DateTime.Parse(PWindow.issuedDate.Text),
                    Code = PWindow.code.Text,
                    Birthday = DateTime.Parse(PWindow.birthday.Text),
                    BirthPlace = PWindow.birthPlace.Text,
                    Type = (GenderType)Enum.Parse(typeof(GenderType), PWindow.type.Text),
                    Series = int.Parse(PWindow.series.Text),
                    Number = int.Parse(PWindow.number.Text)
                };

                employee.Autorization = new Autorization()
                {
                    Login = LPWindow.login.Text,
                    Password = LPWindow.password.Text
                };

                employee.Name = name.Text;
                employee.Surname = surname.Text;
                employee.Permission = (Permission)Enum.Parse(typeof(Permission), permission.Text);
                employee.Phone = phone.Text;
                employee.Salary = double.Parse(salary.Text);
                employee.EmpDate = DateTime.Now;

                Db.Update<Employee>(employee);
                Close();
            }
            catch (Exception ex)
            {
                ExceptionWindow exceptionWindow = new ExceptionWindow(ex);
                exceptionWindow.ShowDialog();
            }
        }
        #region Окна для установки доп. сведений работника
        private void LoginPasswordWindow(object sender, RoutedEventArgs e)
        {
            LPWindow = new LoginPasswordWindow(EmployeeId);
            LPWindow.ShowDialog();
        }
        private void AddressWindow(object sender, RoutedEventArgs e)
        {
            AWindow = new AddressWindow(EmployeeId);
            AWindow.ShowDialog();
        }
        private void PassportWindow(object sender, RoutedEventArgs e)
        {
            PWindow = new PassportWindow(EmployeeId);
            PWindow.ShowDialog();
        }
        #endregion
    }
}
