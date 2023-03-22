using dotnetcoretraining.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcoretraining.Models
{
    public class Subject
    {
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int SubjectOrder { get; set; }
    }
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject");
            builder.Property(s => s.SubjectId).HasColumnName("subjectId");
            builder.Property(s => s.SubjectName).HasColumnName("subjectName");
            builder.Property(s => s.SubjectOrder).HasColumnName("subjectOrder");

        }
    }
}
