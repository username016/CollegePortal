
using CollegePortal.Entities.Models;
using CollegePortal.Services.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CollegePortal.Services.Repositories
{
    public class GymRepository : IGymRepository
    {
        private readonly DbContextStudent _context;

        public GymRepository(DbContextStudent context)
        {
            _context = context;
        }

        // Get all gym rooms
        // Get available gym rooms for a given time range
        /*
        public IEnumerable<GymRoomBookings> ListAvailableGymRooms(DateTime startTime, DateTime endTime)
        {
            // Query to get rooms that are not booked during the time range
            var availableRooms = _context.GymRoomBookings
                .Where(r => !_context.GymRoomBookings
                    .Any(b => b.gymRoomId == r.gymRoomId &&
                              ((startTime >= b.startTime && startTime < b.endTime) ||
                               (endTime > b.startTime && endTime <= b.endTime) ||
                               (startTime <= b.startTime && endTime >= b.endTime))))
                .Select(r => new GymRoomBookings
                {
                    gymRoomId = r.gymRoomId,
                    startTime = startTime,
                    endTime = endTime
                })
                .ToList();

            return availableRooms;
        }*/ 
        //Work in Progress 

        public IEnumerable<GymRoomBookings> GetGymRoomBookings(int gymRoomId)
        {
            var bookings = _context.GymRoomBookings
                .Where(b => b.gymRoomId == gymRoomId)
                .Join(_context.Students,
                    booking => booking.studentId,
                    student => student.studentId,
                    (booking, student) => new GymRoomBookings
                    { 
                        studentName = student.name,
                        gymRoomId = booking.gymRoomId,
                        startTime = booking.startTime,
                        endTime = booking.endTime
                    })
                .ToList();

            return bookings;
        }
        // Check for booking conflicts
        public bool IsBookingConflict(int gymId, DateTime sTime, DateTime eTime)
        {
            return _context.GymRoomBookings.Any(b =>
                b.gymRoomId == gymId &&
                ((sTime >= b.startTime && sTime < b.endTime) ||
                 (eTime > b.startTime && eTime <= b.endTime) ||
                 (sTime <= b.startTime && eTime >= b.endTime)));
        }

        // Book a gym room
        public GymRoomBookings BookGymRoom(int studentId, int gymId, DateTime sTime, DateTime eTime)
        {
            if (IsBookingConflict(gymId, sTime, eTime))
                throw new InvalidOperationException("The gym room is already booked for the specified time.");

            var booking = new GymRoomBookings
            {
                studentId = studentId,
                gymRoomId = gymId,
                startTime = sTime,
                endTime = eTime
            };

            _context.GymRoomBookings.Add(booking);
            _context.SaveChanges();

            return booking;
        }

        // Update an existing booking
        public GymRoomBookings UpdateRoom(int bookingId, DateTime sTime, DateTime eTime)
        {
            var booking = _context.GymRoomBookings.Find(bookingId);
            if (booking == null)
                throw new KeyNotFoundException("Booking not found.");

            if (IsBookingConflict(booking.gymRoomId, sTime, eTime))
                throw new InvalidOperationException("The updated booking conflicts with an existing booking.");

            booking.startTime = sTime;
            booking.endTime = eTime;

            _context.SaveChanges();
            return booking;
        }

        // Delete an existing booking
        public void Delete(int bookingId)
        {
            var booking = _context.GymRoomBookings.Find(bookingId);
            if (booking == null)
                throw new KeyNotFoundException("Booking not found.");

            _context.GymRoomBookings.Remove(booking);
            _context.SaveChanges();
        }
    }
}
