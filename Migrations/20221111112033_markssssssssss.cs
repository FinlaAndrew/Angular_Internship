using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetcoretraining.Migrations
{
    public partial class markssssssssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marsubs_studentsf_StudentnameStudentId",
                table: "marsubs");

            migrationBuilder.DropIndex(
                name: "IX_marsubs_StudentnameStudentId",
                table: "marsubs");

            migrationBuilder.DropColumn(
                name: "StudentnameStudentId",
                table: "marsubs");

            migrationBuilder.CreateIndex(
                name: "IX_marsubs_StudentsId",
                table: "marsubs",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_marsubs_studentsf_StudentsId",
                table: "marsubs",
                column: "StudentsId",
                principalTable: "studentsf",
                principalColumn: "studentid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marsubs_studentsf_StudentsId",
                table: "marsubs");

            migrationBuilder.DropIndex(
                name: "IX_marsubs_StudentsId",
                table: "marsubs");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentnameStudentId",
                table: "marsubs",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_marsubs_StudentnameStudentId",
                table: "marsubs",
                column: "StudentnameStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_marsubs_studentsf_StudentnameStudentId",
                table: "marsubs",
                column: "StudentnameStudentId",
                principalTable: "studentsf",
                principalColumn: "studentid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
