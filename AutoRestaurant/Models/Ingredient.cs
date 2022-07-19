using AutoRestaurant.Models.BaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoRestaurant.Models
{
    public class Ingredient : BaseEntity
    {
        [Required, MaxLength(256)]
        public string Name { get; set; }
        [Required]
        public virtual List<Dish> Dishes { get; set; }
        public Ingredient()
        {
            this.Dishes = new List<Dish>();
        }
    }
}
