using AutoRestaurant.Models.ControlModels;
using System;
using System.Windows;

namespace AutoRestaurant.Windows
{
    public partial class AutorizationWindow : Window
    {
        private AutoRestaurantDbControl Db { get; set; }
        public AutorizationWindow()
        {
            InitializeComponent();

            Db = new AutoRestaurantDbControl();
        }
        private void LogIn(object sender, RoutedEventArgs e)
        {
            if (loginBox.Text != string.Empty && passwordBox.Password != string.Empty)
            {
                var auth = Db.Authenticate(loginBox.Text, passwordBox.Password);
                if (auth != null)
                {
                    MainWindow main = new MainWindow(auth.Login);
                    main.Show();
                    Close();
                }
                else
                {
                    Message.Text = "Неверный логин или пароль";
                    Message.Visibility = Visibility.Visible;
                }
            }
            else
            {
                Message.Text = "Требуется ввести логин или пароль";
                Message.Visibility = Visibility.Visible;
            }
        }
        private void CancelLogIn(object sender, RoutedEventArgs e) =>
            Environment.Exit(0);
    }
}
