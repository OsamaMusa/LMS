using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class LMSContext : DbContext
    {
        public LMSContext(DbContextOptions<LMSContext> options): base(options)
        {

        }
        public DbSet<Users> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<ReserveBookByCustomer> BookCustomer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         

            modelBuilder.Entity<Users>()
                 .HasData(
                        new Users { ID = 1, fullName = "Admin", BirthDate = DateTime.UtcNow, address = "Ramallah", phone = "059", department = "IT" },
                        new Users { ID = 2, fullName = "Customer Service", BirthDate = DateTime.UtcNow, address = "Ramallah", phone = "059", department = "CS" }
              );
            modelBuilder.Entity<Customer>()
                   .HasData(
                          new Customer {ID=1, fullName = "Osama", BirthDate = DateTime.UtcNow, address = "Ramallah", joinDate = DateTime.UtcNow, phone = "059" , status=true , totalAmount=100 ,userID=1}
                );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { ID = 1, Adress = "Palestine-Nablus", Name = "LamyaH", PhoneNo = "0000",userID=1 }

                );
            modelBuilder.Entity<Book>()
                .HasData(
                  new Book { ID = 1, Title = "Book One", Author = "Yazan", Price = 10, TotalNum = 10, Avilable = 10 ,publisherID =1,userID=1},
                  new Book { ID = 2, Title = "Book Two", Author = "Osama", Price = 10, TotalNum = 10, Avilable = 10, publisherID = 1, userID = 1 },
                  new Book { ID = 3, Title = "Book Three", Author = "Lamya", Price = 10, TotalNum = 10, Avilable = 10, publisherID = 1, userID = 1 }

              );



        }
        //entities
    }
}
