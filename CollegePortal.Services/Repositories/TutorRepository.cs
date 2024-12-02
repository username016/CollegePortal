using CollegePortal.Entities.Models;
using CollegePortal.Services.DataAccessLayer;
using System;
namespace CollegePortal.Services.Repositories
{
	public class TutorRepository : ITutorRepository
	{

        private readonly DbContextStudent _context;

        public TutorRepository(DbContextStudent context)
        {
            _context = context;
        }

        // Get all tutor bookings
   /*     public IEnumerable<TutorBookings> GetAllTutorBookings(int studentId, DateTime startTime, DateTime endTime)
        {
            return _context.TutorBookings
                .Where(b => b.studentId == studentId &&
                            b.startTime >= startTime &&
                            b.endTime <= endTime) // Filter by time range and studentId
                .ToList();
        }

        */

        // Get bookings for a specific tutor
        public IEnumerable<TutorBookings> GetTutorBookings(int tutorId, DateTime startTime, DateTime endTime)
        {
            return _context.TutorBookings
         .Where(b => b.tutorId == tutorId &&
                     b.startTime >= startTime &&
                     b.endTime <= endTime) // Filter by tutorId and the time window
         .ToList();
        }

        // Check if a booking conflicts with existing ones
        public bool IsBookingConflict(int tutorId, DateTime startTime, DateTime endTime)
        {
            return _context.TutorBookings.Any(b =>
                b.tutorId == tutorId &&
                (startTime < b.endTime && endTime > b.startTime)); // Check for overlaps
        }

        // Book a session with a tutor
        public TutorBookings BookTutorSession(int studentId, int tutorId, DateTime startTime, DateTime endTime)
        {
            if (IsBookingConflict(tutorId, startTime, endTime))
                throw new Exception("The tutor is already booked during this time. Please choose another time.");

            var booking = new TutorBookings
            {
                studentId = studentId,
                tutorId = tutorId,
                startTime = startTime,
                endTime = endTime,
                dateTime = DateTime.Now // Or set a specific booking date
            };

            _context.TutorBookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        // Update an existing booking
        public TutorBookings UpdateTutorBooking(int bookingId, DateTime startTime, DateTime endTime)
        {
            var booking = _context.TutorBookings.Find(bookingId);
            if (booking == null)
                throw new Exception($"Booking with ID {bookingId} not found.");

            if (IsBookingConflict(booking.tutorId, startTime, endTime))
                throw new Exception("The tutor is already booked during this time. Please choose another time.");

            booking.startTime = startTime;
            booking.endTime = endTime;
            _context.SaveChanges();
            return booking;
        }

        // Delete a booking
        public void DeleteTutorBooking(int bookingId)
        {
            var booking = _context.TutorBookings.Find(bookingId);
            if (booking == null)
                throw new Exception($"Booking with ID {bookingId} not found.");

            _context.TutorBookings.Remove(booking);
            _context.SaveChanges();
        }
    }

}

