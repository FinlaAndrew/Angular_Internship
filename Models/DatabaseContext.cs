using System;
using dotnetcoretraining.Model;
using dotnetcoretraining.Models;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.Models.JayarajCJ;


namespace dotnetcoretraining.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentfConfiguration());
        }

        public DbSet<Stud> Studs { get; set; }
        public DbSet<CountryJay> CountryJays { get; set; }
        public DbSet<StudentJay> StudentJays { get; set; }
       // public DbSet<Studentdetail> studentdetails { get; set; }
        public DbSet<Studentf> students { get; set; } = null!;
        public DbSet<country> countrys { get; set; } 
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Mark> marsub { get; set; }
        public DbSet<Marsub> marsubs { get; set; }
    }

}
