using CollegePortal.Entities.Models;
using System;
namespace CollegePortal.Services.Repositories
{
	public interface ITutorRepository
	{

        // Get all tutor bookings
        IEnumerable<TutorBookings> GetAllTutorBookings();

        // Get bookings for a specific tutor
        IEnumerable<TutorBookings> GetTutorBookings(int tutorId);

        // Check if a booking conflicts with existing ones
        bool IsBookingConflict(int tutorId, DateTime startTime, DateTime endTime);

        // Book a session with a tutor
        TutorBookings BookTutorSession(int studentId, int tutorId, DateTime startTime, DateTime endTime);

        // Update an existing booking
        TutorBookings UpdateTutorBooking(int bookingId, DateTime startTime, DateTime endTime);

        // Delete a booking
        void DeleteTutorBooking(int bookingId);

    }
}

