using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetcoretraining.Migrations
{
    public partial class submar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marks_studentsf_StudentsId",
                table: "marks");

            migrationBuilder.DropForeignKey(
                name: "FK_marks_subjects_SubjectsId",
                table: "marks");

            migrationBuilder.DropIndex(
                name: "IX_marks_StudentsId",
                table: "marks");

            migrationBuilder.DropIndex(
                name: "IX_marks_SubjectsId",
                table: "marks");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentnameStudentId",
                table: "marks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectnameSubjectId",
                table: "marks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_marks_StudentnameStudentId",
                table: "marks",
                column: "StudentnameStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_marks_SubjectnameSubjectId",
                table: "marks",
                column: "SubjectnameSubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_marks_studentsf_StudentnameStudentId",
                table: "marks",
                column: "StudentnameStudentId",
                principalTable: "studentsf",
                principalColumn: "studentid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_marks_subjects_SubjectnameSubjectId",
                table: "marks",
                column: "SubjectnameSubjectId",
                principalTable: "subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marks_studentsf_StudentnameStudentId",
                table: "marks");

            migrationBuilder.DropForeignKey(
                name: "FK_marks_subjects_SubjectnameSubjectId",
                table: "marks");

            migrationBuilder.DropIndex(
                name: "IX_marks_StudentnameStudentId",
                table: "marks");

            migrationBuilder.DropIndex(
                name: "IX_marks_SubjectnameSubjectId",
                table: "marks");

            migrationBuilder.DropColumn(
                name: "StudentnameStudentId",
                table: "marks");

            migrationBuilder.DropColumn(
                name: "SubjectnameSubjectId",
                table: "marks");

            migrationBuilder.CreateIndex(
                name: "IX_marks_StudentsId",
                table: "marks",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_marks_SubjectsId",
                table: "marks",
                column: "SubjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_marks_studentsf_StudentsId",
                table: "marks",
                column: "StudentsId",
                principalTable: "studentsf",
                principalColumn: "studentid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_marks_subjects_SubjectsId",
                table: "marks",
                column: "SubjectsId",
                principalTable: "subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
