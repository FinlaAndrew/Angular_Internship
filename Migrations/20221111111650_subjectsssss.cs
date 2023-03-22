using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetcoretraining.Migrations
{
    public partial class subjectsssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marks_studentsf_StudentnameStudentId",
                table: "marks");

            migrationBuilder.DropForeignKey(
                name: "FK_marks_subjects_SubjectnameSubjectId",
                table: "marks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_marks",
                table: "marks");

            migrationBuilder.RenameTable(
                name: "marks",
                newName: "marsub");

            migrationBuilder.RenameIndex(
                name: "IX_marks_SubjectnameSubjectId",
                table: "marsub",
                newName: "IX_marsub_SubjectnameSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_marks_StudentnameStudentId",
                table: "marsub",
                newName: "IX_marsub_StudentnameStudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_marsub",
                table: "marsub",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "marsubs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentnameStudentId = table.Column<Guid>(type: "uuid", nullable: true),
                    Marks = table.Column<string>(type: "text", nullable: true),
                    SecMark = table.Column<string>(type: "text", nullable: true),
                    ThirdMark = table.Column<string>(type: "text", nullable: true),
                    TotalMark = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marsubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_marsubs_studentsf_StudentnameStudentId",
                        column: x => x.StudentnameStudentId,
                        principalTable: "studentsf",
                        principalColumn: "studentid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_marsubs_StudentnameStudentId",
                table: "marsubs",
                column: "StudentnameStudentId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_marsub_studentsf_StudentnameStudentId",
                table: "marsub");

            migrationBuilder.DropForeignKey(
                name: "FK_marsub_subjects_SubjectnameSubjectId",
                table: "marsub");

            migrationBuilder.DropTable(
                name: "marsubs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_marsub",
                table: "marsub");

            migrationBuilder.RenameTable(
                name: "marsub",
                newName: "marks");

            migrationBuilder.RenameIndex(
                name: "IX_marsub_SubjectnameSubjectId",
                table: "marks",
                newName: "IX_marks_SubjectnameSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_marsub_StudentnameStudentId",
                table: "marks",
                newName: "IX_marks_StudentnameStudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_marks",
                table: "marks",
                column: "Id");

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
    }
}
