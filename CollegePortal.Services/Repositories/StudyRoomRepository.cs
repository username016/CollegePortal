using CollegePortal.Entities.Models;
using CollegePortal.Services.DataAccessLayer;
using System;
namespace CollegePortal.Services.Repositories
{
	public class StudyRoomRepository : IStudyRoomRepository
	{
        private readonly DbContextStudent _context;

        public StudyRoomRepository(DbContextStudent context)
        {
            _context = context;
        }

        // Get all study room bookings
     /*   public IEnumerable<StudyRoomBookings> GetAllStudyRoomBookings(DateTime startTime, DateTime endTime)
        {
            return _context.StudyRoomBookings
                .Where(b => (startTime < b.endTime && endTime > b.startTime)) // Check for overlap with selected times
                .ToList();
        }
     */
        // Get bookings for a specific study room
        public IEnumerable<StudyRoomBookings> GetStudyRoomBookingsByStudent(int studentId)
        {
            return _context.StudyRoomBookings
                .Where(b => b.studentId == studentId)  // Filter by studentId
                .ToList();
        }

        // Check if a booking conflicts with existing ones
        public bool IsBookingConflict(int studyRoomId, DateTime startTime, DateTime endTime)
        {
            return _context.StudyRoomBookings.Any(b =>
                b.studyRoomId == studyRoomId &&
                (startTime < b.endTime && endTime > b.startTime)); // Check for overlaps
        }

        // Book a study room
        public StudyRoomBookings BookStudyRoom(int studentId, int studyRoomId, DateTime startTime, DateTime endTime)
        {
            if (IsBookingConflict(studyRoomId, startTime, endTime))
                throw new Exception("The study room is already booked during this time. Please choose another time.");

            var booking = new StudyRoomBookings
            {
                studentId = studentId,
                studyRoomId = studyRoomId,
                startTime = startTime,
                endTime = endTime
            };

            _context.StudyRoomBookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        // Update an existing study room booking
        public StudyRoomBookings UpdateStudyRoomBooking(int bookingId, DateTime startTime, DateTime endTime)
        {
            var booking = _context.StudyRoomBookings.Find(bookingId);
            if (booking == null)
                throw new Exception($"Booking with ID {bookingId} not found.");

            if (IsBookingConflict(booking.studyRoomId, startTime, endTime))
                throw new Exception("The study room is already booked during this time. Please choose another time.");

            booking.startTime = startTime;
            booking.endTime = endTime;
            _context.SaveChanges();
            return booking;
        }

        // Delete a study room booking
        public void DeleteStudyRoomBooking(int bookingId)
        {
            var booking = _context.StudyRoomBookings.Find(bookingId);
            if (booking == null)
                throw new Exception($"Booking with ID {bookingId} not found.");

            _context.StudyRoomBookings.Remove(booking);
            _context.SaveChanges();
        }
    }
}

