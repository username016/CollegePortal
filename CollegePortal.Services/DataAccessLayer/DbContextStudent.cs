using Microsoft.EntityFrameworkCore;
using CollegePortal.Entities.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CollegePortal.Services.DataAccessLayer
{
    public class DbContextStudent : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        public DbContextStudent(DbContextOptions<DbContextStudent> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<GymRoomBookings> GymRoomBookings { get; set; }
        public DbSet<LostAndFound> LostAndFound { get; set; }
        public DbSet<StudyRoomBookings> StudyRoomBookings { get; set; }
        public DbSet<TutorBookings> TutorBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Configure relationships and constraints
            modelBuilder.Entity<GymRoomBookings>()
                .HasOne(g => g.Student)  // Use navigation property
                .WithMany(s => s.GymRoomBookings)  // Use collection in Student
                .HasForeignKey(g => g.studentId);  // Specify the foreign key

            modelBuilder.Entity<StudyRoomBookings>()
                .HasOne(s => s.Student)  // Use navigation property
                .WithMany(st => st.StudyRoomBookings)  // Use collection in Student
                .HasForeignKey(s => s.studentId);  // Specify the foreign key

            modelBuilder.Entity<LostAndFound>()
                .HasOne(l => l.Student)  // Use navigation property
                .WithMany(s => s.LostAndFoundPosts)  // Use collection in Student
                .HasForeignKey(l => l.studentId);  // Specify the foreign key

            modelBuilder.Entity<TutorBookings>()
                .HasOne(t => t.Student)  // Use navigation property
                .WithMany(s => s.TutorBookings)  // Use collection in Student
                .HasForeignKey(t => t.studentId);  // Specify the foreign key

            // Seed initial data
            modelBuilder.Seed();
        }

    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { studentId = 1, name = "John Doe", password = "password123" },
                new Student { studentId = 2, name = "Jane Smith", password = "securepass" },
                new Student { studentId = 3, name = "Mike Johnson", password = "studentpass" }
            );

            // Seed GymRoomBookings
            modelBuilder.Entity<GymRoomBookings>().HasData(
                new GymRoomBookings
                {
                    bookingId = 1,
                    studentId = 1,
                    studentName = "John Doe",
                    gymRoomId = 1,
                    startTime = DateTime.Now.AddDays(1).AddHours(9),
                    endTime = DateTime.Now.AddDays(1).AddHours(10)
                },
                new GymRoomBookings
                {
                    bookingId = 2,
                    studentId = 2,
                    studentName = "Jane Smith",
                    gymRoomId = 2,
                    startTime = DateTime.Now.AddDays(2).AddHours(14),
                    endTime = DateTime.Now.AddDays(2).AddHours(15)
                }
            );

            // Seed StudyRoomBookings
            modelBuilder.Entity<StudyRoomBookings>().HasData(
                new StudyRoomBookings
                {
                    bookingId = 1,
                    studentId = 1,
                    studyRoomId = 1,
                    dateTime = DateTime.Now,
                    startTime = DateTime.Now.AddDays(1).AddHours(10),
                    endTime = DateTime.Now.AddDays(1).AddHours(12)
                },
                new StudyRoomBookings
                {
                    bookingId = 2,
                    studentId = 2,
                    studyRoomId = 2,
                    dateTime = DateTime.Now,
                    startTime = DateTime.Now.AddDays(2).AddHours(13),
                    endTime = DateTime.Now.AddDays(2).AddHours(15)
                }
            );

            // Seed LostAndFound
            modelBuilder.Entity<LostAndFound>().HasData(
                new LostAndFound
                {
                    postId = 1,
                    studentId = 1,
                    itemDescription = "Blue Backpack",
                    foundDate = DateTime.Now.AddDays(-3),
                    location = "Library"
                },
                new LostAndFound
                {
                    postId = 2,
                    studentId = 2,
                    itemDescription = "Laptop Charger",
                    foundDate = DateTime.Now.AddDays(-1),
                    location = "Student Center"
                }
            );

            // Seed TutorBookings
            modelBuilder.Entity<TutorBookings>().HasData(
                new TutorBookings
                {
                    bookingId = 1,
                    studentId = 1,
                    tutorId = 101,
                    dateTime = DateTime.Now,
                    startTime = DateTime.Now.AddDays(3).AddHours(10),
                    endTime = DateTime.Now.AddDays(3).AddHours(11)
                },
                new TutorBookings
                {
                    bookingId = 2,
                    studentId = 2,
                    tutorId = 102,
                    dateTime = DateTime.Now,
                    startTime = DateTime.Now.AddDays(4).AddHours(14),
                    endTime = DateTime.Now.AddDays(4).AddHours(15)
                }
            );
        }


    }
}
