﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(LMSContext))]
    [Migration("20211128070210_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Avilable")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalNum")
                        .HasColumnType("int");

                    b.Property<long>("publisherID")
                        .HasColumnType("bigint");

                    b.Property<long?>("userID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("publisherID");

                    b.HasIndex("userID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Author = "Yazan",
                            Avilable = 10,
                            Price = 10f,
                            Title = "Book One",
                            TotalNum = 10,
                            publisherID = 1L,
                            userID = 1L
                        },
                        new
                        {
                            ID = 2L,
                            Author = "Osama",
                            Avilable = 10,
                            Price = 10f,
                            Title = "Book Two",
                            TotalNum = 10,
                            publisherID = 1L,
                            userID = 1L
                        },
                        new
                        {
                            ID = 3L,
                            Author = "Lamya",
                            Avilable = 10,
                            Price = 10f,
                            Title = "Book Three",
                            TotalNum = 10,
                            publisherID = 1L,
                            userID = 1L
                        });
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("joinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<long>("totalAmount")
                        .HasColumnType("bigint");

                    b.Property<long?>("userID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("userID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            BirthDate = new DateTime(2021, 11, 28, 7, 2, 9, 770, DateTimeKind.Utc).AddTicks(8825),
                            RoleID = 0L,
                            address = "Ramallah",
                            fullName = "Osama",
                            joinDate = new DateTime(2021, 11, 28, 7, 2, 9, 770, DateTimeKind.Utc).AddTicks(9474),
                            phone = "059",
                            status = true,
                            totalAmount = 100L,
                            userID = 1L
                        });
                });

            modelBuilder.Entity("Domain.Entities.FinanceTransactions", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("ReserveID")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("time")
                        .HasColumnType("datetime2");

                    b.Property<double>("totalAmount")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("ReserveID");

                    b.HasIndex("UserID");

                    b.ToTable("FinanceTransactions");
                });

            modelBuilder.Entity("Domain.Entities.Permission", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Domain.Entities.Publisher", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("userID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("userID");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            Adress = "Palestine-Nablus",
                            Name = "LamyaH",
                            PhoneNo = "0000",
                            userID = 1L
                        });
                });

            modelBuilder.Entity("Domain.Entities.ReserveBookByCustomer", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("BookId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ReservedUserID")
                        .HasColumnType("bigint");

                    b.Property<long?>("ReturnedUserID")
                        .HasColumnType("bigint");

                    b.Property<bool>("isReturned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("reserveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("returnedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("BookId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ReservedUserID");

                    b.HasIndex("ReturnedUserID");

                    b.ToTable("BookCustomer");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Entities.Users", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1L,
                            BirthDate = new DateTime(2021, 11, 28, 7, 2, 9, 769, DateTimeKind.Utc).AddTicks(6357),
                            address = "Ramallah",
                            department = "IT",
                            fullName = "Admin",
                            phone = "059"
                        },
                        new
                        {
                            ID = 2L,
                            BirthDate = new DateTime(2021, 11, 28, 7, 2, 9, 769, DateTimeKind.Utc).AddTicks(7211),
                            address = "Ramallah",
                            department = "CS",
                            fullName = "Customer Service",
                            phone = "059"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.HasOne("Domain.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("publisherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Users", "User")
                        .WithMany()
                        .HasForeignKey("userID");
                });

            modelBuilder.Entity("Domain.Entities.Customer", b =>
                {
                    b.HasOne("Domain.Entities.Users", "User")
                        .WithMany()
                        .HasForeignKey("userID");
                });

            modelBuilder.Entity("Domain.Entities.FinanceTransactions", b =>
                {
                    b.HasOne("Domain.Entities.ReserveBookByCustomer", "Reserve")
                        .WithMany()
                        .HasForeignKey("ReserveID");

                    b.HasOne("Domain.Entities.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("Domain.Entities.Publisher", b =>
                {
                    b.HasOne("Domain.Entities.Users", "User")
                        .WithMany()
                        .HasForeignKey("userID");
                });

            modelBuilder.Entity("Domain.Entities.ReserveBookByCustomer", b =>
                {
                    b.HasOne("Domain.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("Domain.Entities.Users", "ReservedUser")
                        .WithMany()
                        .HasForeignKey("ReservedUserID");

                    b.HasOne("Domain.Entities.Users", "ReturnedUser")
                        .WithMany()
                        .HasForeignKey("ReturnedUserID");
                });
#pragma warning restore 612, 618
        }
    }
}
