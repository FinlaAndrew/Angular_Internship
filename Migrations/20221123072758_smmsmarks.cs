using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetcoretraining.Migrations
{
    public partial class smmsmarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Thirdmark",
                table: "marsub",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thirdmark",
                table: "marsub");
        }
    }
}
