using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoretraining.Models
{
    public class Mark
    {
        public Guid Id { get; set; }
        public Guid StudentsId { get; set; }
        public Studentf Students { get; set; }
        public Guid SubjectsId { get; set; }
        public Subject Subjects { get; set; }
        public decimal Marks { get; set; }
        public decimal Thirdmark { get; set; }
        public decimal Total { get; set; }
        public decimal Percentage { get; set; }
    }
    public class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.ToTable("Mark");
            builder.Property(s => s.Id).HasColumnName("id");
            builder.Property(s => s.StudentsId).HasColumnName("studentsId");
            builder.Property(s => s.SubjectsId).HasColumnName("subjectsId");
            builder.Property(s => s.Marks).HasColumnName("marks");
            builder.Property(s => s.Thirdmark).HasColumnName("thirdmark");
            builder.Property(s => s.Total).HasColumnName("total");
            builder.Property(s => s.Total).HasColumnName("percentage");
        }
    }
}
