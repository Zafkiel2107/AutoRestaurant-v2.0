using AutoRestaurant.Models;
using AutoRestaurant.Models.ClassExtension;
using AutoRestaurant.Models.ControlModels;
using System;
using System.Windows;

namespace AutoRestaurant.Windows.ClassExtensionWindow
{
    public partial class PassportWindow : Window
    {
        private AutoRestaurantDbControl Db { get; set; }
        public PassportWindow(Guid? employeeId = null)
        {
            InitializeComponent();

            type.ItemsSource = Enum.GetValues(typeof(GenderType));
            if (employeeId.HasValue)
            {
                Db = new AutoRestaurantDbControl();
                var passport = Db.GetElementById<Employee>(employeeId.Value).Passport;

                issuedBy.Text = passport.IssuedBy;
                issuedDate.Text = passport.IssuedDate.ToString();
                code.Text = passport.Code;
                type.SelectedItem = passport.Type.ToString();
                birthday.Text = passport.Birthday.ToString();
                birthPlace.Text = passport.BirthPlace;
                series.Text = passport.Series.ToString();
                number.Text = passport.Number.ToString();
            }
        }
        private void SaveInfo(object sender, RoutedEventArgs e) =>
            Close();
    }
}
