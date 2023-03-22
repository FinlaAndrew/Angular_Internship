using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetcoretraining.Migrations
{
    public partial class mssmmssmmark : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marsub_studentsf_StudentnameStudentId",
                table: "marsub");

            migrationBuilder.DropForeignKey(
                name: "FK_marsub_subjects_SubjectnameSubjectId",
                table: "marsub");

            migrationBuilder.DropIndex(
                name: "IX_marsub_StudentnameStudentId",
                table: "marsub");

            migrationBuilder.DropIndex(
                name: "IX_marsub_SubjectnameSubjectId",
                table: "marsub");

            migrationBuilder.DropColumn(
                name: "StudentnameStudentId",
                table: "marsub");

            migrationBuilder.DropColumn(
                name: "SubjectnameSubjectId",
                table: "marsub");

            migrationBuilder.CreateIndex(
                name: "IX_marsub_StudentsId",
                table: "marsub",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_marsub_SubjectsId",
                table: "marsub",
                column: "SubjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_marsub_studentsf_StudentsId",
                table: "marsub",
                column: "StudentsId",
                principalTable: "studentsf",
                principalColumn: "studentid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_marsub_subjects_SubjectsId",
                table: "marsub",
                column: "SubjectsId",
                principalTable: "subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marsub_studentsf_StudentsId",
                table: "marsub");

            migrationBuilder.DropForeignKey(
                name: "FK_marsub_subjects_SubjectsId",
                table: "marsub");

            migrationBuilder.DropIndex(
                name: "IX_marsub_StudentsId",
                table: "marsub");

            migrationBuilder.DropIndex(
                name: "IX_marsub_SubjectsId",
                table: "marsub");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentnameStudentId",
                table: "marsub",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectnameSubjectId",
                table: "marsub",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_marsub_StudentnameStudentId",
                table: "marsub",
                column: "StudentnameStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_marsub_SubjectnameSubjectId",
                table: "marsub",
                column: "SubjectnameSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_marsub_studentsf_StudentnameStudentId",
                table: "marsub",
                column: "StudentnameStudentId",
                principalTable: "studentsf",
                principalColumn: "studentid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_marsub_subjects_SubjectnameSubjectId",
                table: "marsub",
                column: "SubjectnameSubjectId",
                principalTable: "subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
