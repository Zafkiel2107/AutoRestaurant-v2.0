using AutoRestaurant.Models;
using AutoRestaurant.Models.ControlModels;
using System;
using System.Windows;

namespace AutoRestaurant.Windows.ClassExtensionWindow
{
    public partial class LoginPasswordWindow : Window
    {
        private AutoRestaurantDbControl Db { get; set; }
        public LoginPasswordWindow(Guid? employeeId = null)
        {
            InitializeComponent();

            if (employeeId.HasValue)
            {
                Db = new AutoRestaurantDbControl();

                login.Text = Db.GetElementById<Employee>(employeeId.Value).Autorization.Login;
            }
        }

        private void SaveInfo(object sender, RoutedEventArgs e) =>
            Close();
    }
}
