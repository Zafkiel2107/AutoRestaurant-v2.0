using AutoRestaurant.Models.BaseModels;
using System.ComponentModel.DataAnnotations;

namespace AutoRestaurant.Models.ClassExtension
{
    public class Address : BaseEntity
    {
        [Required, MaxLength(256)]
        public string City { get; set; }
        [Required, MaxLength(256)]
        public string Street { get; set; }
        [Required, Range(6, 6)]
        public int PostalCode { get; set; }
        [Required]
        public int House { get; set; }
        public int? Building { get; set; }
        public int? Flat { get; set; }
    }
}
