using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoRestaurant.Models
{
    public class Customer : Person
    {
        [Required]
        public virtual List<Order> Orders { get; set; }
        public Customer()
        {
            this.Orders = new List<Order>();
        }
    }
}
