using Microsoft.EntityFrameworkCore;
using CourseManager.Entities;

namespace CourseManager.Data
{
    public class CourseManagerDbContext : DbContext
    {
        public CourseManagerDbContext(DbContextOptions<CourseManagerDbContext> options) : base(options)
        {
        }

        // A DbSet for each entity class
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }


        // on model creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Student entity
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseID);

            modelBuilder.Entity<Student>()
                .Property(s => s.Status)
                .HasConversion<string>();

            // Seed the database with some initial data
            modelBuilder.Entity<Course>().HasData(
                new Course { 
                    CourseID = 1, 
                    Name = "Programming with C#", 
                    Instructor = "John Doe", 
                    StartDate = new DateOnly(2024, 11, 2), 
                    RoomNumber = "3G15" 
                },
                new Course { 
                    CourseID = 2, 
                    Name = "Introduction to Entity Framework", 
                    Instructor = "Jane Smith", 
                    StartDate = new DateOnly(2024, 11, 4), 
                    RoomNumber = "1C07" 
                }
            );
        }
    }
}
