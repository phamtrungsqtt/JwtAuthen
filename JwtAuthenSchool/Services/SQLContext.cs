using JwtAuthenSchool.Models;
using Microsoft.EntityFrameworkCore;
using JwtAuthenSchool.Models.Authentication;

namespace JwtAuthenSchool.Services
{
    public class SQLContext :DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Users> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Course>().ToTable("Course");
        //    modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        //    modelBuilder.Entity<Student>().ToTable("Student");
        //    modelBuilder.Entity<Users>().ToTable("Users");
        //}
    }
}
