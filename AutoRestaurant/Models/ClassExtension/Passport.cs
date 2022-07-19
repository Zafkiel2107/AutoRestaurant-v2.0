using AutoRestaurant.Models.BaseModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace AutoRestaurant.Models.ClassExtension
{
    public class Passport : BaseEntity
    {
        [Required, MaxLength(256)]
        public string IssuedBy { get; set; }
        [Required]
        public DateTime IssuedDate { get; set; }
        [Required, MinLength(7), MaxLength(7)]
        public string Code { get; set; }
        [Required]
        public GenderType Type { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required, MaxLength(256)]
        public string BirthPlace { get; set; }
        [Required, Range(4, 4)]
        public int Series { get; set; }
        [Required, Range(6, 6)]
        public int Number { get; set; }
    }
    public enum GenderType : byte
    {
        Мужчина = 1,
        Женщина
    }
}
