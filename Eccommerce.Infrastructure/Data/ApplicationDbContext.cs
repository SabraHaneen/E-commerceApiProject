using Eccommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eccommerce.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
        //constructor of dbcontext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //comosite key
            modelBuilder.Entity<OrderDetailes>().HasKey(t => new { t.OrdersId, t.ProductsId });

            //seeding data

            modelBuilder.Entity<Categories>().HasData(
               new Categories
               {
                   Id = 1,
                   Name = "Electronics",
                   Description = "Devices"
               },
                  new Categories
                  {
                      Id = 2,
                      Name = "Books",
                      Description = "Books,and novels"
                  },
 new Categories
 {
     Id = 3,
     Name = "Clothing",
     Description = "apparel and accessories"
 },
  new Categories
  {
      Id = 4,
      Name = "Home",
      Description = "apparel and accessories"
  }

                );
            modelBuilder.Entity<Users>().HasData(
   new Users
   {
       Id = 1,
       UserName = "Haneen",
       Email = "sabrahanien@gmail.com",
       Password = "12345678",
       Phone = "0597088628",
       Role = "user"
   },
      new Users
      {
          Id = 2,
          UserName = "Haneen2",
          Email = "sabrahanien2@gmail.com",
          Password = "1234567",
          Phone = "0597088629",
          Role = "Admin"
      }

    );
            modelBuilder.Entity<Products>().HasData(
                new Products { Id = 1, Name = "smartphone", Price = 400, CategoriesId = 1 },
                new Products { Id = 2, Name = "laptops", Price = 2500, CategoriesId = 1 },
                new Products { Id = 3, Name = "short", Price = 100, CategoriesId = 3 },
              new Products { Id = 4, Name = "smartphone", Price = 400, CategoriesId = 1 },
            new Products { Id = 5, Name = "davince code", Price = 400, CategoriesId = 2 }

                );
            modelBuilder.Entity<Orders>().HasData(
                new Orders { Id = 1, OrderDate = DateTime.Now, OrderStatus = "pending", UsersId = 1, amount = 19 },
             new Orders { Id = 2, OrderDate = DateTime.Now, OrderStatus = "pending", UsersId = 2, amount = 19 }

                );
            modelBuilder.Entity<OrderDetailes>().HasData(
                new OrderDetailes { Id = 1, OrdersId = 1, ProductsId = 1, Price = 345, Quantity = 3 },
                new OrderDetailes { Id = 2, OrdersId = 2, ProductsId = 3, Price = 245, Quantity = 2 }

                );



            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<OrderDetailes> OrderDetailes { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public DbSet<Categories> Categories { get; set; }
    }
}
