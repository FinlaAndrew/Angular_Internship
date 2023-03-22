using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetcoretraining.Migrations
{
    public partial class studentformdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "studentsf",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "studentsf",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "studentsf",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "place",
                table: "studentsf",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "studentsf");

            migrationBuilder.DropColumn(
                name: "country",
                table: "studentsf");

            migrationBuilder.DropColumn(
                name: "email",
                table: "studentsf");

            migrationBuilder.DropColumn(
                name: "place",
                table: "studentsf");
        }
    }
}
