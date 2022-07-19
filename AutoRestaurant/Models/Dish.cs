using AutoRestaurant.Models.BaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoRestaurant.Models
{
    public class Dish : BaseEntity
    {
        [Required, MaxLength(256)]
        public string Name { get; set; }
        [Required]
        public DishType Type { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public virtual List<Ingredient> Ingredients { get; set; }
        [Required]
        public virtual List<Order> Orders { get; set; }
        public Dish()
        {
            this.Ingredients = new List<Ingredient>();
            this.Orders = new List<Order>();
        }
    }
    public enum DishType : byte
    {
        Салат = 1,
        Суп,
        Главное,
        Десерт,
        Напиток
    }
}
