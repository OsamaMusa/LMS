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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCustomer> BookCustomer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasData(
                  new Book {ID=1, Title = "Book One", Author = "Yazan", Price = 10, TotalNum = 10, Avilable = 10 },
                  new Book {ID=2, Title = "Book Two", Author = "Osama", Price = 10, TotalNum = 10, Avilable = 10 },
                  new Book {ID=3, Title = "Book Three", Author = "Lamya", Price = 10, TotalNum = 10, Avilable = 10 }

              );
            modelBuilder.Entity<Customer>()
                   .HasData(
                          new Customer {ID=1, fullName = "Osama", BirthDate = DateTime.UtcNow, address = "Ramallah", joinDate = DateTime.UtcNow, phone = "059" }
                );
          
        }
        //entities
    }
}
