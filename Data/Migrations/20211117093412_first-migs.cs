using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class firstmigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
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
                    returnedTime = table.Column<DateTime>(nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCustomer_BookId",
                table: "BookCustomer",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCustomer_CustomerId",
                table: "BookCustomer",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCustomer");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
