namespace AutoRestaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        City = c.String(nullable: false, maxLength: 256),
                        Street = c.String(nullable: false, maxLength: 256),
                        PostalCode = c.Int(nullable: false),
                        House = c.Int(nullable: false),
                        Building = c.Int(),
                        Flat = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Autorizations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(nullable: false, maxLength: 64),
                        Password = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Surname = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Price = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Customer_Id = c.Guid(nullable: false),
                        Employee_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Type = c.Byte(nullable: false),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Permission = c.Byte(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Salary = c.Double(nullable: false),
                        EmpDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Surname = c.String(nullable: false, maxLength: 256),
                        Address_Id = c.Guid(nullable: false),
                        Autorization_Id = c.Guid(nullable: false),
                        Passport_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .ForeignKey("dbo.Autorizations", t => t.Autorization_Id, cascadeDelete: true)
                .ForeignKey("dbo.Passports", t => t.Passport_Id, cascadeDelete: true)
                .Index(t => t.Address_Id)
                .Index(t => t.Autorization_Id)
                .Index(t => t.Passport_Id);
            
            CreateTable(
                "dbo.Passports",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IssuedBy = c.String(nullable: false, maxLength: 256),
                        IssuedDate = c.DateTime(nullable: false),
                        Code = c.String(nullable: false, maxLength: 7),
                        Type = c.Byte(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        BirthPlace = c.String(nullable: false, maxLength: 256),
                        Series = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExceptionDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Message = c.String(nullable: false),
                        Source = c.String(nullable: false),
                        StackTrace = c.String(nullable: false),
                        TargetSite = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IngredientDishes",
                c => new
                    {
                        Ingredient_Id = c.Guid(nullable: false),
                        Dish_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ingredient_Id, t.Dish_Id })
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Dishes", t => t.Dish_Id, cascadeDelete: true)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.Dish_Id);
            
            CreateTable(
                "dbo.DishOrders",
                c => new
                    {
                        Dish_Id = c.Guid(nullable: false),
                        Order_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dish_Id, t.Order_Id })
                .ForeignKey("dbo.Dishes", t => t.Dish_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Dish_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Passport_Id", "dbo.Passports");
            DropForeignKey("dbo.Employees", "Autorization_Id", "dbo.Autorizations");
            DropForeignKey("dbo.Employees", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.DishOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.DishOrders", "Dish_Id", "dbo.Dishes");
            DropForeignKey("dbo.IngredientDishes", "Dish_Id", "dbo.Dishes");
            DropForeignKey("dbo.IngredientDishes", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.DishOrders", new[] { "Order_Id" });
            DropIndex("dbo.DishOrders", new[] { "Dish_Id" });
            DropIndex("dbo.IngredientDishes", new[] { "Dish_Id" });
            DropIndex("dbo.IngredientDishes", new[] { "Ingredient_Id" });
            DropIndex("dbo.Employees", new[] { "Passport_Id" });
            DropIndex("dbo.Employees", new[] { "Autorization_Id" });
            DropIndex("dbo.Employees", new[] { "Address_Id" });
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropTable("dbo.DishOrders");
            DropTable("dbo.IngredientDishes");
            DropTable("dbo.ExceptionDetails");
            DropTable("dbo.Passports");
            DropTable("dbo.Employees");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Dishes");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Autorizations");
            DropTable("dbo.Addresses");
        }
    }
}
