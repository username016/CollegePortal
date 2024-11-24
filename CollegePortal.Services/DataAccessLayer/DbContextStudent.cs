using Microsoft.EntityFrameworkCore;
using CollegePortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegePortal.Entities.Models;

namespace CollegePortal.Services.DataAccessLayer
{
    public class DbContextStudent : DbContext
    {
        public DbContextStudent(DbContextOptions<DbContextStudent> options) : base(options)
        {

        }

        public DbSet<Student> student { get; set; }
        public DbSet<GymRoomBookings> gymRoomBookings { get; set; }
        public DbSet<LostAndFound> lostAndFound { get; set; }

        public DbSet<StudyRoomBookings> studyRoomBookings { get; set; }

        public DbSet<TutorBookings> tutorBookings { get; set; }

    }
}
