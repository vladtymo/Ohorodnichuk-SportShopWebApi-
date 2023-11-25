using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace DataAccess.Data
{
   public class SportShopDbContext : IdentityDbContext<User>
   {
      public SportShopDbContext() { }
      public SportShopDbContext(DbContextOptions options) : base(options) { }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         base.OnConfiguring(optionsBuilder);

         //optionsBuilder.UseSqlServer(@"Data Source=JULIAOHORODNICH\\SQLEXPRESS;Initial Catalog=SportShop_WebAPI;Trusted_Connection=True;MultipleActiveResultSets=true");

            optionsBuilder.UseSqlServer("Server=tcp:bulkywebdb.database.windows.net,1433;Initial Catalog=BulkyDb;Persist Security Info=False;User ID=admins;Password=Admin123*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<Sale>()
             .Property(s => s.Price)
             .HasColumnType("decimal(18, 2)");

         modelBuilder.Entity<Client>().HasData(new[]
         {
                new Client() { Id = 1, Fullname="Petruk Stepan Romanovych", Email="adsa@gmail.com", Phone="0979372948", Gender="M", PercentSale=10},
                new Client() { Id = 2, Fullname="Lyudmila Stepanivna Romanchuk", Email="fsud@gmail.com", Phone="0959375027", Gender="F", PercentSale=15}
            });

         modelBuilder.Entity<Employee>().HasData(new[]
         {
                new Employee() { Id = 1, Fullname="Yaroschuk Ivan Petrovych", HireDate= new DateTime(2020, 05, 30), Gender="M", Salary=8500},
                new Employee() { Id = 2, Fullname="Mykhalchuk Ruslana Romanivna", HireDate= new DateTime(2020, 05, 06), Gender="F", Salary=8500},
                new Employee() { Id = 3, Fullname="Tetyana Stepanivna Levchuk", HireDate= new DateTime(2020, 05, 07), Gender="F", Salary=8500},
                new Employee() { Id = 4, Fullname="Ihor Ivanovich Volos", HireDate= new DateTime(2020, 05, 15), Gender="M", Salary=8500}
            });

         modelBuilder.Entity<Product>().HasData(new[]
         {
                new Product() { Id = 1, Name="Gloves", Type="Accessories", Quantity=5, CostPrice=85, Producer="Turkey", Price=150},
                new Product() { Id = 2, Name="Glasses", Type="Accessories", Quantity=5, CostPrice=85, Producer="China", Price=150},
                new Product() { Id = 3, Name="Belt", Type="Clothes", Quantity=15, CostPrice=120, Producer="Turkey", Price=250},
                new Product() { Id = 4, Name="Backpack", Type="Accessories", Quantity=10, CostPrice=400, Producer="Poland", Price=700},
                new Product() { Id = 5, Name="Adidas sneakers", Type="Shoes", Quantity=20, CostPrice=800, Producer="Poland", Price=1500}
            });

         modelBuilder.Entity<Sale>().HasData(new[]
         {
                new Sale() { Id = 1, ProductId=1, Price=10000, Quantity=1, EmployeeId=1, ClientId=1},
                new Sale() { Id = 2, ProductId=1, Price=100, Quantity=1, EmployeeId=1, ClientId=1},
                new Sale() { Id = 3, ProductId=4, Price=1800, Quantity=1, EmployeeId=2, ClientId=2},
                new Sale() { Id = 4, ProductId=2, Price=10000, Quantity=3, EmployeeId=4, ClientId=2}
            });
      }

      public DbSet<Client> Clients { get; set; }
      public DbSet<Employee> Employees { get; set; }
      public DbSet<Product> Products { get; set; }
      public DbSet<Sale> Sales { get; set; }
   }
}

