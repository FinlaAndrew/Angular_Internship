using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoretraining.Models
{
    public class Marsub
    {public Guid Id { get; set; }
        public Guid StudentsId { get; set; }
        public Studentf Students { get; set; }
        public string Marks { get; set; }
        public string SecMark { get; set; }
        public string ThirdMark { get; set; }
        public decimal? TotalMark { get; set; }
    }
    public class MarsubConfiguration : IEntityTypeConfiguration <Marsub>
    {
        public void Configure(EntityTypeBuilder<Marsub> builder)
        {
            builder.ToTable("Marsub");
            builder.Property(s => s.Id).HasColumnName("id");
            builder.Property(s => s.StudentsId).HasColumnName("studentsId");
            builder.Property(s => s.Students).HasColumnName("studentname");
            builder.Property(s => s.Marks).HasColumnName("marks");
            builder.Property(s => s.SecMark).HasColumnName("SecMark");
            builder.Property(s => s.ThirdMark).HasColumnName("ThirdMark");
            builder.Property(s => s.TotalMark).HasColumnName("TotalMark");
        }
    }
}
