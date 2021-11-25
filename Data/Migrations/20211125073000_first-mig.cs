﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class firstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    department = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(nullable: false),
                    phone = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    joinDate = table.Column<DateTime>(nullable: false),
                    totalAmount = table.Column<long>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customers_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Publishers_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Avilable = table.Column<int>(nullable: false),
                    TotalNum = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    publisherID = table.Column<long>(nullable: false),
                    userID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_publisherID",
                        column: x => x.publisherID,
                        principalTable: "Publishers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookCustomer",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<long>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    reserveTime = table.Column<DateTime>(nullable: false),
                    isReturned = table.Column<bool>(nullable: false),
                    returnedTime = table.Column<DateTime>(nullable: false),
<<<<<<< HEAD:Data/Migrations/20211125073000_first-mig.cs
                    ReservedUserID = table.Column<long>(nullable: true),
=======
                    ReserveUserID = table.Column<long>(nullable: true),
>>>>>>> e0a60081572d5d7d901270defa1ca83034938661:Data/Migrations/20211124142639_first-mig.cs
                    ReturnedUserID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCustomer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookCustomer_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCustomer_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
<<<<<<< HEAD:Data/Migrations/20211125073000_first-mig.cs
                        name: "FK_BookCustomer_Users_ReservedUserID",
                        column: x => x.ReservedUserID,
=======
                        name: "FK_BookCustomer_Users_ReserveUserID",
                        column: x => x.ReserveUserID,
>>>>>>> e0a60081572d5d7d901270defa1ca83034938661:Data/Migrations/20211124142639_first-mig.cs
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookCustomer_Users_ReturnedUserID",
                        column: x => x.ReturnedUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "BirthDate", "address", "department", "fullName", "phone" },
<<<<<<< HEAD:Data/Migrations/20211125073000_first-mig.cs
                values: new object[] { 1L, new DateTime(2021, 11, 25, 7, 30, 0, 506, DateTimeKind.Utc).AddTicks(6899), "Ramallah", "IT", "Admin", "059" });
=======
                values: new object[] { 1L, new DateTime(2021, 11, 24, 14, 26, 39, 61, DateTimeKind.Utc).AddTicks(553), "Ramallah", "IT", "Admin", "059" });
>>>>>>> e0a60081572d5d7d901270defa1ca83034938661:Data/Migrations/20211124142639_first-mig.cs

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "BirthDate", "address", "department", "fullName", "phone" },
<<<<<<< HEAD:Data/Migrations/20211125073000_first-mig.cs
                values: new object[] { 2L, new DateTime(2021, 11, 25, 7, 30, 0, 506, DateTimeKind.Utc).AddTicks(7464), "Ramallah", "CS", "Customer Service", "059" });
=======
                values: new object[] { 2L, new DateTime(2021, 11, 24, 14, 26, 39, 61, DateTimeKind.Utc).AddTicks(1113), "Ramallah", "CS", "Customer Service", "059" });
>>>>>>> e0a60081572d5d7d901270defa1ca83034938661:Data/Migrations/20211124142639_first-mig.cs

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "BirthDate", "address", "fullName", "joinDate", "phone", "status", "totalAmount", "userID" },
<<<<<<< HEAD:Data/Migrations/20211125073000_first-mig.cs
                values: new object[] { 1L, new DateTime(2021, 11, 25, 7, 30, 0, 507, DateTimeKind.Utc).AddTicks(4277), "Ramallah", "Osama", new DateTime(2021, 11, 25, 7, 30, 0, 507, DateTimeKind.Utc).AddTicks(4565), "059", true, 100L, 1L });
=======
                values: new object[] { 1L, new DateTime(2021, 11, 24, 14, 26, 39, 61, DateTimeKind.Utc).AddTicks(8448), "Ramallah", "Osama", new DateTime(2021, 11, 24, 14, 26, 39, 61, DateTimeKind.Utc).AddTicks(8781), "059", true, 100L, 1L });
>>>>>>> e0a60081572d5d7d901270defa1ca83034938661:Data/Migrations/20211124142639_first-mig.cs

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "ID", "Adress", "Name", "PhoneNo", "userID" },
                values: new object[] { 1L, "Palestine-Nablus", "LamyaH", "0000", 1L });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "Avilable", "Price", "Title", "TotalNum", "publisherID", "userID" },
                values: new object[] { 1L, "Yazan", 10, 10f, "Book One", 10, 1L, 1L });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "Avilable", "Price", "Title", "TotalNum", "publisherID", "userID" },
                values: new object[] { 2L, "Osama", 10, 10f, "Book Two", 10, 1L, 1L });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "Avilable", "Price", "Title", "TotalNum", "publisherID", "userID" },
                values: new object[] { 3L, "Lamya", 10, 10f, "Book Three", 10, 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_BookCustomer_BookId",
                table: "BookCustomer",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCustomer_CustomerId",
                table: "BookCustomer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
<<<<<<< HEAD:Data/Migrations/20211125073000_first-mig.cs
                name: "IX_BookCustomer_ReservedUserID",
                table: "BookCustomer",
                column: "ReservedUserID");
=======
                name: "IX_BookCustomer_ReserveUserID",
                table: "BookCustomer",
                column: "ReserveUserID");
>>>>>>> e0a60081572d5d7d901270defa1ca83034938661:Data/Migrations/20211124142639_first-mig.cs

            migrationBuilder.CreateIndex(
                name: "IX_BookCustomer_ReturnedUserID",
                table: "BookCustomer",
                column: "ReturnedUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_publisherID",
                table: "Books",
                column: "publisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_userID",
                table: "Books",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_userID",
                table: "Customers",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_userID",
                table: "Publishers",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCustomer");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
