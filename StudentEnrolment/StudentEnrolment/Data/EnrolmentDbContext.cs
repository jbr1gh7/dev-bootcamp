#nullable disable
using Microsoft.EntityFrameworkCore;
using StudentEnrolment.Models;
using StudentEnrolment.Models.EntityModels;

namespace StudentEnrolment.Data
{
    public class EnrolmentDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CourseStudent>().HasKey(cs => new { cs.CourseId, cs.StudentId });
            builder.Entity<CourseStudent>()
                .HasOne<Course>(cs => cs.Course)
                .WithMany(c => c.CourseStudent)
                .HasForeignKey(c => c.CourseId);

            builder.Entity<CourseStudent>()
                .HasOne<Student>(cs => cs.Student)
                .WithMany(c => c.CourseStudent)
                .HasForeignKey(c => c.StudentId);

            builder.Entity<CourseSubject>().HasKey(cs => new { cs.CourseId, cs.SubjectId });
            builder.Entity<CourseSubject>()
                .HasOne<Course>(cs => cs.Course)
                .WithMany(c => c.CourseSubject)
                .HasForeignKey(c => c.CourseId);

            builder.Entity<CourseSubject>()
                .HasOne<Subject>(cs => cs.Subject)
                .WithMany(c => c.CourseSubject)
                .HasForeignKey(c => c.SubjectId);


        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
        public DbSet<CourseSubject> CourseSubject { get; set; }

        public EnrolmentDbContext(DbContextOptions<EnrolmentDbContext> options)
            : base(options)
        {
        }
    }
}
