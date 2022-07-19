using AutoRestaurant.Models;
using AutoRestaurant.Models.ControlModels;
using System;
using System.Windows;

namespace AutoRestaurant.Windows
{
    public partial class IngredientWindow : Window
    {
        private AutoRestaurantDbControl Db { get; set; }
        public IngredientWindow()
        {
            InitializeComponent();

            Db = new AutoRestaurantDbControl();
        }
        private void CreateIngredient(object sender, RoutedEventArgs e)
        {
            try
            {
                var ingredient = new Ingredient()
                {
                    Name = name.Text
                };
                
                Db.Create<Ingredient>(ingredient);
                Close();
            }
            catch (Exception ex)
            {
                ExceptionWindow exceptionWindow = new ExceptionWindow(ex);
                exceptionWindow.ShowDialog();
            }
        }
    }
}
