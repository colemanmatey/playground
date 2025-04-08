using Microsoft.EntityFrameworkCore;
using BPTracker.Models;

namespace BPTracker.Data
{
    public class BPTrackerDbContext : DbContext
    {
        public BPTrackerDbContext(DbContextOptions<BPTrackerDbContext> options) : base(options)
        {
        }

        public DbSet<BloodPressure> Readings { get; set; }

        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BloodPressure>()
                .HasOne(bp => bp.Position)
                .WithMany()
                .HasForeignKey(bp => bp.PositionId);

            modelBuilder.Entity<BloodPressure>().HasData(
                new BloodPressure
                {
                    Id = 1,
                    Systolic = 120,
                    Diastolic = 80,
                    Date = new DateOnly(2021, 10, 1),
                    PositionId = "1"
                },
                new BloodPressure
                {
                    Id = 2,
                    Systolic = 130,
                    Diastolic = 90,
                    Date = new DateOnly(2021, 10, 2),
                    PositionId = "3"
                },
                new BloodPressure
                {
                    Id = 3,
                    Systolic = 140,
                    Diastolic = 100,
                    Date = new DateOnly(2021, 10, 3),
                    PositionId = "1"
                },
                new BloodPressure
                {
                    Id = 4,
                    Systolic = 150,
                    Diastolic = 110,
                    Date = new DateOnly(2021, 10, 4),
                    PositionId = "2"
                },
                new BloodPressure
                {
                    Id = 5,
                    Systolic = 160,
                    Diastolic = 120,
                    Date = new DateOnly(2021, 10, 5),
                    PositionId = "2"
                }
            );

            modelBuilder.Entity<Position>().HasData(
                new Position
                {
                    Id = "1",
                    Name = "Standing"
                },
                new Position
                {
                    Id = "2",
                    Name = "Sitting"
                },
                new Position
                {
                    Id = "3",
                    Name = "Lying down"
                }
            );
        }
    }
}
