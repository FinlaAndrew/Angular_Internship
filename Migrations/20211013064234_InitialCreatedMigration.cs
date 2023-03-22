using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetcoretraining.Migrations
{
    public partial class InitialCreatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryJays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryJays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentJays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    IndianCitizen = table.Column<bool>(type: "boolean", nullable: false),
                    Mobile = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentJays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentJays_CountryJays_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryJays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentJays_CountryId",
                table: "StudentJays",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentJays");

            migrationBuilder.DropTable(
                name: "CountryJays");
        }
    }
}
