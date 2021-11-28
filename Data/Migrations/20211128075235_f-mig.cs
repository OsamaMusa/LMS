using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RoleID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    BirthDate = table.Column<DateTime>(nullable: false),
                    PermissionID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    userID = table.Column<long>(nullable: true),
                    PermissionID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customers_Permissions_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    BookId = table.Column<long>(nullable: true),
                    CustomerId = table.Column<long>(nullable: true),
                    reserveTime = table.Column<DateTime>(nullable: false),
                    isReturned = table.Column<bool>(nullable: false),
                    returnedTime = table.Column<DateTime>(nullable: false),
                    ReservedUserID = table.Column<long>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookCustomer_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookCustomer_Users_ReservedUserID",
                        column: x => x.ReservedUserID,
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

            migrationBuilder.CreateTable(
                name: "FinanceTransactions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<long>(nullable: true),
                    ReserveID = table.Column<long>(nullable: true),
                    totalAmount = table.Column<double>(nullable: false),
                    time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceTransactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FinanceTransactions_BookCustomer_ReserveID",
                        column: x => x.ReserveID,
                        principalTable: "BookCustomer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinanceTransactions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "BirthDate", "PermissionID", "address", "department", "fullName", "phone" },
                values: new object[] { 1L, new DateTime(2021, 11, 28, 7, 52, 35, 14, DateTimeKind.Utc).AddTicks(4886), null, "Ramallah", "IT", "Admin", "059" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "BirthDate", "PermissionID", "address", "department", "fullName", "phone" },
                values: new object[] { 2L, new DateTime(2021, 11, 28, 7, 52, 35, 14, DateTimeKind.Utc).AddTicks(5382), null, "Ramallah", "CS", "Customer Service", "059" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "BirthDate", "PermissionID", "address", "fullName", "joinDate", "phone", "status", "totalAmount", "userID" },
                values: new object[] { 1L, new DateTime(2021, 11, 28, 7, 52, 35, 15, DateTimeKind.Utc).AddTicks(1869), null, "Ramallah", "Osama", new DateTime(2021, 11, 28, 7, 52, 35, 15, DateTimeKind.Utc).AddTicks(2168), "059", true, 100L, 1L });

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
                name: "IX_BookCustomer_ReservedUserID",
                table: "BookCustomer",
                column: "ReservedUserID");

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
                name: "IX_Customers_PermissionID",
                table: "Customers",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_userID",
                table: "Customers",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceTransactions_ReserveID",
                table: "FinanceTransactions",
                column: "ReserveID");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceTransactions_UserID",
                table: "FinanceTransactions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleID",
                table: "Permissions",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_userID",
                table: "Publishers",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PermissionID",
                table: "Users",
                column: "PermissionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinanceTransactions");

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

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
