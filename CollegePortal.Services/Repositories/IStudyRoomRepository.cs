using CollegePortal.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegePortal.Services.Repositories
{
    public interface IStudyRoomRepository
    {

        // Get all study room bookings
        public IEnumerable<StudyRoomBookings> GetAllStudyRoomBookings(DateTime startTime, DateTime endTime);

        // Get bookings for a specific study room by studentID
       public IEnumerable<StudyRoomBookings> GetStudyRoomBookingsByStudent(int studentId);

        // Check if a booking conflicts with existing ones
        bool IsBookingConflict(int studyRoomId, DateTime startTime, DateTime endTime);

        // Book a study room
        StudyRoomBookings BookStudyRoom(int studentId, int studyRoomId, DateTime startTime, DateTime endTime);

        // Update an existing study room booking
        StudyRoomBookings UpdateStudyRoomBooking(int bookingId, DateTime startTime, DateTime endTime);

        // Delete a booking
        void DeleteStudyRoomBooking(int bookingId);

    }
}
