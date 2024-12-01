using Microsoft.EntityFrameworkCore;
using CollegePortal.Entities.Models;

namespace CollegePortal.Services.DataAccessLayer
{
    public class DbContextStudent : DbContext
    {
        public DbContextStudent(DbContextOptions<DbContextStudent> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<GymRoomBookings> GymRoomBookings { get; set; }
        public DbSet<LostAndFound> LostAndFound { get; set; }
        public DbSet<StudyRoomBookings> StudyRoomBookings { get; set; }
        public DbSet<TutorBookings> TutorBookings { get; set; }


    }
}
