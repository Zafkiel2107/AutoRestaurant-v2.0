using AutoRestaurant.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace AutoRestaurant.Models
{
    public abstract class Person : BaseEntity
    {
        [Required, MaxLength(256)]
        public string Name { get; set; }
        [Required, MaxLength(256)]
        public string Surname { get; set; }
    }
}
