using Microsoft.EntityFrameworkCore.Migrations;

namespace Cofee_Machine.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coffees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Water = table.Column<double>(type: "float", nullable: false),
                    Sugar = table.Column<double>(type: "float", nullable: false),
                    Coffee = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffees", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coffees");
        }
    }
}
