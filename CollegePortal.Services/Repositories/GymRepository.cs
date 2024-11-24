using System;
using CollegePortal.Entities.Models;
using CollegePortal.Services.DataAccessLayer;
namespace CollegePortal.Services.Repositories
{
	public class GymRepository : IGymRepository
	{
        private readonly DbContextStudent _context;

        public GymRepository(DbContextStudent context)
        {
            _context = context;
        }

        // Get all gym room bookings
        public IEnumerable<GymRoomBookings> ListAllGymRooms()
        {
            return _context.gymRoomBookings.ToList();
        }

        public IEnumerable<GymRoomBookings> GetGymRoomBookings(int gymRoomId)
        {
            return _context.gymRoomBookings
                .Where(b => b.gymRoomID == gymRoomId)
                .ToList();
        }


        // Check for booking conflicts
        public bool IsBookingConflict(int gymId, DateTime sTime, DateTime eTime)
        {
            return _context.gymRoomBookings.Any(b =>
                b.gymRoomID == gymId &&
                (sTime < b.endTime && eTime > b.startTime)); // Overlap check
        }

        // Book a gym room
        public GymRoomBookings BookGymRoom(int studentId, int gymId, DateTime sTime, DateTime eTime)
        {
            if (IsBookingConflict(gymId, sTime, eTime))
                throw new Exception("Time slot is not available. Please choose another time.");

            var booking = new GymRoomBookings
            {
                studentId = studentId,
                gymRoomID = gymId,
                startTime = sTime,
                endTime = eTime
            };

            _context.gymRoomBookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        // Update an existing booking
        public GymRoomBookings UpdateRoom(int bookingId, DateTime sTime, DateTime eTime)
        {
            var booking = _context.gymRoomBookings.Find(bookingId);
            if (booking == null)
                throw new Exception("Booking not found.");

            if (IsBookingConflict(booking.gymRoomID, sTime, eTime))
                throw new Exception("Time slot is not available. Please choose another time.");

            booking.startTime = sTime;
            booking.endTime = eTime;
            _context.SaveChanges();
            return booking;
        }

        // Delete an existing booking
        public void Delete(int bookingId)
        {
            var booking = _context.gymRoomBookings.Find(bookingId);
            if (booking == null)
                throw new Exception("Booking not found.");

            _context.gymRoomBookings.Remove(booking);
            _context.SaveChanges();
        }
    }
}

