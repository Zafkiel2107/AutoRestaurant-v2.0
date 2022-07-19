using AutoRestaurant.Models;
using AutoRestaurant.Models.ControlModels;
using System;
using System.Windows;

namespace AutoRestaurant.Windows.ClassExtensionWindow
{
    public partial class AddressWindow : Window
    {
        private AutoRestaurantDbControl Db { get; set; }
        public AddressWindow(Guid? employeeId = null)
        {
            InitializeComponent();

            if (employeeId.HasValue)
            {
                Db = new AutoRestaurantDbControl();
                var address = Db.GetElementById<Employee>(employeeId.Value).Address;

                city.Text = address.City;
                street.Text = address.Street;
                postalCode.Text = address.PostalCode.ToString();
                house.Text = address.House.ToString();
                building.Text = address.Building.ToString();
                flat.Text = address.Flat.ToString();
            }
        }
        private void SaveInfo(object sender, RoutedEventArgs e) =>
            Close();
    }
}
