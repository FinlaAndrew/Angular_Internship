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
    [Migration("20221018070005_dbstudents")]
    partial class dbstudents
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

            modelBuilder.Entity("dotnetcoretraining.Models.Studentf", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("studentid");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dob");

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

                    b.HasKey("StudentId");

                    b.ToTable("studentsf");
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
#pragma warning restore 612, 618
        }
    }
}