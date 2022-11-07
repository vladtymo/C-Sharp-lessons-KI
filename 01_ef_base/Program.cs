using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Collections.Generic;

namespace _01_ef_base
{
    // DbContext - important class in Entity Framework API. It is a bridge between your domain or entity classes and the database.
    public class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {
            // Create database
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // connection string contains all information for connection including credentials etc.
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=OnlineShopDb2022; Integrated Security=True;";

            // add db connection
            optionsBuilder.UseSqlServer(connStr);
        }

        // Database object collections definition (db tables)
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sale> Salles { get; set; }
    }

    // Entity classes definition
    public class Product
    {
        // Entity properties definition (table columns)

        // Primary Key naming convention: Id, ID, EntityName+Id (ProductId) 
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsInStock { get; set; }

        // Navigation Properties

        public ICollection<Sale> Salles { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // Navigation Properties

        public ICollection<Sale> Salles { get; set; }
    }
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }

        // Navigation Properties

        // Relationship type: One to Many (1...*)
        // Sale has one Employee, Employee has many salles
        public Employee Employee { get; set; }

        // Relationship type: Many to Many (*...*)
        // Sale has many products, Product has many salles
        public ICollection<Product> Products { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Intro to Entity Framework Core!");

            // create an instance of the db context
            ShopDbContext context = new ShopDbContext();

            // add elemetns
            var emp = new Employee()
            {
                FirstName = "Oleg",
                LastName = "King",
                Email = "super@gmail.com"
            };

            context.Employees.Add(emp);

            context.SaveChanges(); // submit changes to db (insert command)

            // get elements
            var employees = context.Employees;
            foreach (var e in employees)
            {
                Console.WriteLine($"Employee: {e.FirstName} {e.LastName}");
            }

            // find element by id
            Employee? item = context.Employees.Find(1);

            if (item != null)
            {
                // delete elements
                context.Employees.Remove(item);

                context.SaveChanges(); // (delete command)
            }
            else Console.WriteLine("Employee with ID [1] not found!");
        }
    }
}