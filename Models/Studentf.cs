using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetcoretraining.Models
{
    public class Studentf
    {
        [Key]
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobilenumber { get; set; }
        public DateTime? Dob { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Place { get; set; }
        public string Country { get; set; }
        public Guid CountrysId { get; set; }
        public country Countrys { get; set; }
        public bool? IsIndian { get; set; }

    }
    public class StudentfConfiguration : IEntityTypeConfiguration<Studentf>
    {
        public void Configure(EntityTypeBuilder<Studentf> builder)
        {
            builder.ToTable("studentsf");
            builder.Property(s => s.StudentId).HasColumnName("studentid");
            builder.Property(s => s.FirstName).HasColumnName("firstname");
            builder.Property(s => s.LastName).HasColumnName("lastname");
            builder.Property(s => s.Email).HasColumnName("email");
            builder.Property(s => s.Mobilenumber).HasColumnName("mobilenumber");
            builder.Property(s => s.Dob).HasColumnName("dob");
            builder.Property(s => s.Age).HasColumnName("age");
            builder.Property(s => s.Gender).HasColumnName("gender");
            builder.Property(s => s.Place).HasColumnName("place");
            builder.Property(s => s.Country).HasColumnName("country");
            builder.Property(s => s.IsIndian).HasColumnName("isIndian");
            //builder.HasIndex(p => new { p.SchoolId, p.StudentId, p.ModuleId });
        }

    }
}