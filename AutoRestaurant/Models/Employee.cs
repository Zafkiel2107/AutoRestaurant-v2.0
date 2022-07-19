using AutoRestaurant.Models.ClassExtension;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoRestaurant.Models
{
    public class Employee : Person
    {
        [Required]
        public virtual Autorization Autorization { get; set; }
        [Required]
        public Permission Permission { get; set; }
        [Required]
        public virtual Passport Passport { get; set; }
        [Required]
        public virtual Address Address { get; set; }
        [Required, MinLength(11), MaxLength(11)]
        public string Phone { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public DateTime EmpDate { get; set; }
        [Required]
        public virtual List<Order> Orders { get; set; }
        public Employee()
        {
            this.Orders = new List<Order>();
        }
    }
    public enum Permission : byte
    {
        Администратор = 1,
        Менеджер,
        Официант
    }
}
