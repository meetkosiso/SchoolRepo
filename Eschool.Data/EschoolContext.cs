using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using Eschool.Model.Entities;

namespace Eschool.Data
{
   public class EschoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Classes> Classess { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public EschoolContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany( e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Student>()
                .ToTable("Student");

            modelBuilder.Entity<Student>()
                .Property(e => e.Classid)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .HasOne(s => s.classes)
                .WithMany(s => s.students);

            modelBuilder.Entity<Classes>()
                .ToTable("Classes");

            modelBuilder.Entity<Classes>()
                .Property(e => e.Name)
                .IsRequired();



            modelBuilder.Entity<Enrollment>()
                .ToTable("Enrollment");

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.Studentid);

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.Subjectid)
                .IsRequired();

            modelBuilder.Entity<Enrollment>()
              .HasOne(e => e.students)
              .WithMany(e => e.enrollment)
              .HasForeignKey(e => e.Studentid);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.subjects)
                .WithMany(e => e.enrollment)
                .HasForeignKey(e => e.Subjectid);

            modelBuilder.Entity<Subject>()
                .ToTable("Subject");
            modelBuilder.Entity<Subject>()
                .Property(e => e.Name)
                .IsRequired();
                

        }
    }
}
