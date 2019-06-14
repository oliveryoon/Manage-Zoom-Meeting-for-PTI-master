using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebAPI.Models
{
    public class SchoolContext:DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
           : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("vStudentsAll", "dbo");
            modelBuilder.Entity<Student>().Property(s => s.BirthDate).HasColumnName("StudentBirthDate");
            modelBuilder.Entity<Student>().Property(s => s.Gender).HasColumnName("StudentGender");
            modelBuilder.Entity<Student>().Property(s => s.Given1).HasColumnName("StudentGiven1");
            modelBuilder.Entity<Student>().Property(s => s.Preferred).HasColumnName("StudentPreferred");
            modelBuilder.Entity<Student>().Property(s => s.Surname).HasColumnName("StudentSurname");
            modelBuilder.Entity<Student>().Property(s => s.YearLevel).HasColumnName("StudentYearLevel");
            
        }
    }
}
