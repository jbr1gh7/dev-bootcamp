#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentEnrolment.Models;

namespace StudentEnrolment.Data
{
    public class EnrolmentDbContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<CourseMembership> CourseMembership { get; set; }
        public DbSet<CourseSubject> CourseSubject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server = 127.0.0.1; Database = studentenrolment; Uid = devuser; Password = ****",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
        }
    }
}
