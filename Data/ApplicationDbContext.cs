using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Instructor> Instructors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(course =>
        {
            course.HasKey(c => c.Id);

            course.HasMany(c => c.Students)
                .WithMany(s => s.Courses);
        });

        modelBuilder.Entity<Instructor>(instructor =>
        {
            instructor.HasKey(i => i.Id);

            instructor.HasMany(i => i.Courses)
                .WithOne(c => c.Instructor);
        });

        modelBuilder.Entity<Student>(student =>
        {
            student.HasKey(s => s.Id);
        });
    }
}
