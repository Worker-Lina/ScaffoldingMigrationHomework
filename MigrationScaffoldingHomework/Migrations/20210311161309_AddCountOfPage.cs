using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationScaffoldingHomework.Migrations
{
    public partial class AddCountOfPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfPage",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfPage",
                table: "Articles");
        }
    }
}
