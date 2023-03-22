﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using dotnetcoretraining.Model;

namespace dotnetcoretraining.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221111111650_subjectsssss")]
    partial class subjectsssss
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Web.Models.JayarajCJ.CountryJay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CountryJays");
                });

            modelBuilder.Entity("Web.Models.JayarajCJ.StudentJay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<bool>("IndianCitizen")
                        .HasColumnType("boolean");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("StudentJays");
                });

            modelBuilder.Entity("Web.Models.Stud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("Mobile")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Studs");
                });

            modelBuilder.Entity("dotnetcoretraining.Models.Mark", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Marks")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("StudentnameStudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SubjectnameSubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectsId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("StudentnameStudentId");

                    b.HasIndex("SubjectnameSubjectId");

                    b.ToTable("marsub");
                });

            modelBuilder.Entity("dotnetcoretraining.Models.Marsub", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Marks")
                        .HasColumnType("text");

                    b.Property<string>("SecMark")
                        .HasColumnType("text");

                    b.Property<Guid?>("StudentnameStudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.Property<string>("ThirdMark")
                        .HasColumnType("text");

                    b.Property<decimal?>("TotalMark")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("StudentnameStudentId");

                    b.ToTable("marsubs");
                });

            modelBuilder.Entity("dotnetcoretraining.Models.Studentf", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("studentid");

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<string>("Country")
                        .HasColumnType("text")
                        .HasColumnName("country");

                    b.Property<Guid>("CountrysId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dob");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("Gender")
                        .HasColumnType("text")
                        .HasColumnName("gender");

                    b.Property<bool?>("IsIndian")
                        .HasColumnType("boolean")
                        .HasColumnName("isIndian");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("lastname");

                    b.Property<string>("Mobilenumber")
                        .HasColumnType("text")
                        .HasColumnName("mobilenumber");

                    b.Property<string>("Place")
                        .HasColumnType("text")
                        .HasColumnName("place");

                    b.HasKey("StudentId");

                    b.HasIndex("CountrysId");

                    b.ToTable("studentsf");
                });

            modelBuilder.Entity("dotnetcoretraining.Models.Subject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("SubjectName")
                        .HasColumnType("text");

                    b.Property<int>("SubjectOrder")
                        .HasColumnType("integer");

                    b.HasKey("SubjectId");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("dotnetcoretraining.Models.country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("countrys");
                });

            modelBuilder.Entity("Web.Models.JayarajCJ.StudentJay", b =>
                {
                    b.HasOne("Web.Models.JayarajCJ.CountryJay", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("dotnetcoretraining.Models.Mark", b =>
                {
                    b.HasOne("dotnetcoretraining.Models.Studentf", "Studentname")
                        .WithMany()
                        .HasForeignKey("StudentnameStudentId");

                    b.HasOne("dotnetcoretraining.Models.Subject", "Subjectname")
                        .WithMany()
                        .HasForeignKey("SubjectnameSubjectId");

                    b.Navigation("Studentname");

                    b.Navigation("Subjectname");
                });

            modelBuilder.Entity("dotnetcoretraining.Models.Marsub", b =>
                {
                    b.HasOne("dotnetcoretraining.Models.Studentf", "Studentname")
                        .WithMany()
                        .HasForeignKey("StudentnameStudentId");

                    b.Navigation("Studentname");
                });

            modelBuilder.Entity("dotnetcoretraining.Models.Studentf", b =>
                {
                    b.HasOne("dotnetcoretraining.Models.country", "Countrys")
                        .WithMany()
                        .HasForeignKey("CountrysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Countrys");
                });
#pragma warning restore 612, 618
        }
    }
}
