using AutoRestaurant.Models;
using AutoRestaurant.Models.ClassExtension;
using System.Data.Entity;

namespace AutoRestaurant.ConnectionDb
{
    public class AutoRestaurantDbContext : DbContext
    {
        public AutoRestaurantDbContext() : base("Connection") { }
        public DbSet<Autorization> Autorizations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<ExceptionDetail> ExceptionDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AutoRestaurantDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
