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
        public IEnumerable<TutorBookings> GetAllTutorBookings()
        {
            return _context.tutorBookings.ToList();
        }

        // Get bookings for a specific tutor
        public IEnumerable<TutorBookings> GetTutorBookings(int tutorId)
        {
            return _context.tutorBookings.Where(t => t.tutorId == tutorId).ToList();
        }

        // Check if a booking conflicts with existing ones
        public bool IsBookingConflict(int tutorId, DateTime startTime, DateTime endTime)
        {
            return _context.tutorBookings.Any(b =>
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

            _context.tutorBookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        // Update an existing booking
        public TutorBookings UpdateTutorBooking(int bookingId, DateTime startTime, DateTime endTime)
        {
            var booking = _context.tutorBookings.Find(bookingId);
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
            var booking = _context.tutorBookings.Find(bookingId);
            if (booking == null)
                throw new Exception($"Booking with ID {bookingId} not found.");

            _context.tutorBookings.Remove(booking);
            _context.SaveChanges();
        }
    }

}

