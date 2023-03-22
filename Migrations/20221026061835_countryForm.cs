using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetcoretraining.Migrations
{
    public partial class countryForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CountrysId",
                table: "studentsf",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "countrys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countrys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentsf_CountrysId",
                table: "studentsf",
                column: "CountrysId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentsf_countrys_CountrysId",
                table: "studentsf",
                column: "CountrysId",
                principalTable: "countrys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentsf_countrys_CountrysId",
                table: "studentsf");

            migrationBuilder.DropTable(
                name: "countrys");

            migrationBuilder.DropIndex(
                name: "IX_studentsf_CountrysId",
                table: "studentsf");

            migrationBuilder.DropColumn(
                name: "CountrysId",
                table: "studentsf");
        }
    }
}
