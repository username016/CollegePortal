using CollegePortal.Entities.Models;
using System;
namespace CollegePortal.Services.Repositories
{
	public interface IGymRepository 
	{
        //Get all gym rooms
        public IEnumerable<GymRoomBookings> ListAllGymRooms();

        //Show the singular gym rooms
        // Get bookings for a specific gym room
        IEnumerable<GymRoomBookings> GetGymRoomBookings(int gymRoomId);

        // Check for conflicts
        bool IsBookingConflict(int gymId, DateTime sTime, DateTime eTime);

        // Book a gym room
        GymRoomBookings BookGymRoom(int studentId, int gymId, DateTime sTime, DateTime eTime);

        // Update an existing booking
        GymRoomBookings UpdateRoom(int bookingId, DateTime sTime, DateTime eTime);

        // Delete an existing booking
        void Delete(int bookingId);


    }
}

