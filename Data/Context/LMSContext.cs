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
        public DbSet<FinanceTransactions> FinanceTransactions { get; set; }

        public DbSet<Role> Roles { set; get; }

        public DbSet<Permission> Permissions { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         

            modelBuilder.Entity<Users>()
                 .HasData(
                        new Users { ID = 1, username = "Admin", BirthDate = DateTime.UtcNow, address = "Ramallah", phone = "059", department = "IT" ,roleID=1, password= EncreptPassword.EncodePass("123456") },
                        new Users { ID = 2, username = "Customer Service", BirthDate = DateTime.UtcNow, address = "Ramallah", phone = "059", department = "CS", roleID = 4, password = EncreptPassword.EncodePass("123456") },
                        new Users { ID = 3, username = "Finance Service", BirthDate = DateTime.UtcNow, address = "Ramallah", phone = "059", department = "CS", roleID = 3, password = EncreptPassword.EncodePass("123456") },
                        new Users { ID = 4, username = "CTO", BirthDate = DateTime.UtcNow, address = "Ramallah", phone = "059", department = "CS", roleID = 2, password = EncreptPassword.EncodePass("123456") }
              );
            modelBuilder.Entity<Customer>()
                   .HasData(
                          new Customer {ID=1, fullName = "Osama", BirthDate = DateTime.UtcNow, address = "Ramallah", joinDate = DateTime.UtcNow, phone = "059" , status=true , totalAmount=100 ,userID=1, isBlocked=false}
                );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { ID = 1, Adress = "Palestine-Nablus", Name = "LamyaH", PhoneNo = "0000",userID=1 }

                );
            modelBuilder.Entity<Book>()
                .HasData(
                  new Book { ID = 1, Title = "Book One", Author = "Yazan", Price = 10, TotalNum = 10, Avilable = 10, publisherID = 1, userID = 1 },
                  new Book { ID = 2, Title = "Book Two", Author = "Osama", Price = 10, TotalNum = 10, Avilable = 10, publisherID = 1, userID = 1 },
                  new Book { ID = 3, Title = "Book Three", Author = "Lamya", Price = 10, TotalNum = 10, Avilable = 10, publisherID = 1, userID = 1 }

              );
            modelBuilder.Entity<Role>()
              .HasData(
                new Role { ID = 1, Name = "Admin Role", Description = "Admin Role" },
                new Role { ID = 2, Name = "CTO Role", Description = "CTO Role" },
                new Role { ID = 3, Name = "Finance Role", Description = "Finance Role" },
                new Role { ID = 4, Name = "Librarian Role", Description = "Librarian Role" }

            );
            modelBuilder.Entity<Permission>()
                 .HasData(
                   new Permission { ID = 1, Name = "Maintanance Users", Description = "Admin Role", RoleID = 1 },
                   new Permission { ID = 2, Name = "Show Entites Data", Description = "Admin Role", RoleID = 1 },
                   new Permission { ID = 3, Name = "Reports", Description = "Admin Role", RoleID = 1 },
                   new Permission { ID = 4, Name = "Maintanance Reservations", Description = "Librarian permission", RoleID = 4 },
                   new Permission { ID = 5, Name = "Maintanance Finance Transactions", Description = "Finance permission", RoleID = 3 },
                   new Permission { ID = 6, Name = "Maintanance & Data Entry", Description = "CTO permission", RoleID = 2 }

            );



        }
       
        //entities
    }
}
