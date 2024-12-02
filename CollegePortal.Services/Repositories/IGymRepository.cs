using CollegePortal.Entities.Models;
using System;
namespace CollegePortal.Services.Repositories
{
	public interface IGymRepository 
	{
        //Get all gym rooms
      //  public IEnumerable<GymRoomBookings> ListAvailableGymRooms(DateTime startTime, DateTime endTime);

        //Show the singular gym rooms
        // Get bookings for a specific gym room
        public IEnumerable<GymRoomBookings> GetGymRoomBookings(int gymRoomId);

        // Check for conflicts
        public bool IsBookingConflict(int gymId, DateTime sTime, DateTime eTime);

        // Book a gym room
        public GymRoomBookings BookGymRoom(int studentId, int gymId, DateTime sTime, DateTime eTime);

        // Update an existing booking
        public GymRoomBookings UpdateRoom(int bookingId, DateTime sTime, DateTime eTime);

        // Delete an existing booking
        public void Delete(int bookingId);


    }
}

