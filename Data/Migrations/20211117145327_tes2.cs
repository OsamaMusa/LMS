using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class tes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "fullName",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "Customers",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropColumn(
                name: "fullName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
