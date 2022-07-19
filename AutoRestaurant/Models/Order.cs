using AutoRestaurant.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoRestaurant.Models
{
    public class Order : BaseEntity
    {
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public virtual Employee Employee { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
        [Required]
        public virtual List<Dish> Dishes { get; set; }
        public Order()
        {
            this.Dishes = new List<Dish>();
        }
    }
}
