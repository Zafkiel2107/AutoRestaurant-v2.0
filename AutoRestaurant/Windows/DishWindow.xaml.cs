using AutoRestaurant.Models;
using AutoRestaurant.Models.ControlModels;
using System;
using System.Linq;
using System.Windows;

namespace AutoRestaurant.Windows
{
    public partial class DishWindow : Window
    {
        private Guid DishId { get; set; }
        private AutoRestaurantDbControl Db { get; set; }
        public DishWindow(Guid? dishId = null)
        {
            InitializeComponent();

            Db = new AutoRestaurantDbControl();

            type.ItemsSource = Enum.GetValues(typeof(DishType));
            ingredients.ItemsSource = Db.GetElements<Ingredient>().Select(x => x.Name);
            if (dishId.HasValue)
            {
                btn.Click -= CreateDish;
                btn.Click += UpdateDish;

                var dish = Db.GetElementById<Dish>(dishId.Value);
                name.Text = dish.Name;
                type.SelectedItem = dish.Type;
                cost.Text = dish.Cost.ToString();

                DishId = dishId.Value;
            }
        }
        private void CreateDish(object sender, RoutedEventArgs e)
        {
            try
            {
                var dish = new Dish()
                {
                    Ingredients = Db.GetElements<Ingredient>().Where(x => ingredients.SelectedItems.Cast<string>().Contains(x.Name)).ToList(),
                    Name = name.Text,
                    Type = (DishType)Enum.Parse(typeof(DishType), type.Text),
                    Cost = double.Parse(cost.Text)
                };

                Db.Create<Dish>(dish);
                Close();
            }
            catch (Exception ex)
            {
                ExceptionWindow exceptionWindow = new ExceptionWindow(ex);
                exceptionWindow.ShowDialog();
            }
        }
        private void UpdateDish(object sender, RoutedEventArgs e)
        {
            try
            {
                var dish = Db.GetElementById<Dish>(DishId);
                if (dish == null)
                    throw new Exception();

                dish.Ingredients = Db.GetElements<Ingredient>().Where(x => ingredients.SelectedItems.Cast<string>().Contains(x.Name)).ToList();
                dish.Name = name.Text;
                dish.Type = (DishType)Enum.Parse(typeof(DishType), type.Text);
                dish.Cost = double.Parse(cost.Text);

                Db.Update<Dish>(dish);
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
