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
        public IEnumerable<StudyRoomBookings> GetAllStudyRoomBookings()
        {
            return _context.studyRoomBookings.ToList();
        }

        // Get bookings for a specific study room
        public IEnumerable<StudyRoomBookings> GetStudyRoomBookings(int studyRoomId)
        {
            return _context.studyRoomBookings.Where(b => b.studyRoomId == studyRoomId).ToList();
        }

        // Check if a booking conflicts with existing ones
        public bool IsBookingConflict(int studyRoomId, DateTime startTime, DateTime endTime)
        {
            return _context.studyRoomBookings.Any(b =>
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
                endTime = endTime,
                dateTime = DateTime.Now // Or set a specific booking date
            };

            _context.studyRoomBookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        // Update an existing study room booking
        public StudyRoomBookings UpdateStudyRoomBooking(int bookingId, DateTime startTime, DateTime endTime)
        {
            var booking = _context.studyRoomBookings.Find(bookingId);
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
            var booking = _context.studyRoomBookings.Find(bookingId);
            if (booking == null)
                throw new Exception($"Booking with ID {bookingId} not found.");

            _context.studyRoomBookings.Remove(booking);
            _context.SaveChanges();
        }
    }
}

