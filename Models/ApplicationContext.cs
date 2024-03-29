using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace Day_3_2.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            
        }
        public ApplicationContext(DbContextOptions options):base (options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source = . ; initial catalog = MVC1 ; integrated security = true ; Trust Server Certificate = true") ;
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>().HasKey(x => new { x.StudentId, x.CrsID });
                base.OnModelCreating(modelBuilder);
        }

    }
}
