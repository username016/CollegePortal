
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
        public IEnumerable<GymRoomBookings> ListAvailableGymRooms(DateTime startTime, DateTime endTime)
        {
            // Query to get rooms that are not booked during the time range
            var availableRooms = _context.GymRoomBookings
                .Where(r => !_context.GymRoomBookings
                    .Any(b => b.GymRoomId == r.GymRoomId &&
                              ((startTime >= b.StartTime && startTime < b.EndTime) ||
                               (endTime > b.StartTime && endTime <= b.EndTime) ||
                               (startTime <= b.StartTime && endTime >= b.EndTime))))
                .Select(r => new GymRoomBookings
                {
                    GymRoomId = r.GymRoomId,
                    StartTime = startTime,
                    EndTime = endTime
                })
                .ToList();

            return availableRooms;
        }

        public IEnumerable<GymRoomBookings> GetGymRoomBookings(int gymRoomId)
        {
            var bookings = _context.GymRoomBookings
                .Where(b => b.GymRoomId == gymRoomId)
                .Join(_context.Students,
                    booking => booking.StudentId,
                    student => student.StudentId,
                    (booking, student) => new GymRoomBookings
                    { 
                        StudentName = student.Name,
                        GymRoomId = booking.GymRoomId,
                        StartTime = booking.StartTime,
                        EndTime = booking.EndTime
                    })
                .ToList();

            return bookings;
        }
        // Check for booking conflicts
        public bool IsBookingConflict(int gymId, DateTime sTime, DateTime eTime)
        {
            return _context.GymRoomBookings.Any(b =>
                b.GymRoomId == gymId &&
                ((sTime >= b.StartTime && sTime < b.EndTime) ||
                 (eTime > b.StartTime && eTime <= b.EndTime) ||
                 (sTime <= b.StartTime && eTime >= b.EndTime)));
        }

        // Book a gym room
        public GymRoomBookings BookGymRoom(int studentId, int gymId, DateTime sTime, DateTime eTime)
        {
            if (IsBookingConflict(gymId, sTime, eTime))
                throw new InvalidOperationException("The gym room is already booked for the specified time.");

            var booking = new GymRoomBookings
            {
                StudentId = studentId,
                GymRoomId = gymId,
                StartTime = sTime,
                EndTime = eTime
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

            if (IsBookingConflict(booking.GymRoomId, sTime, eTime))
                throw new InvalidOperationException("The updated booking conflicts with an existing booking.");

            booking.StartTime = sTime;
            booking.EndTime = eTime;

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
