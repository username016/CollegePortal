using CollegePortal.Entities.Models;
using CollegePortal.Services.DataAccessLayer;
using CollegePortal.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegePortal.Controllers
{
    [Route("[controller]")]
    public class GymRoomController : Controller
    {
        private readonly IGymRepository _gymRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly DbContextStudent _context;

        public GymRoomController(IGymRepository gymRepository, IStudentRepository studentRepository, DbContextStudent context)
        {
            _gymRepository = gymRepository;
            _studentRepository = studentRepository;
            _context = context;
        }

        // List ALL Gym Room Bookings (GymRoomList.cshtml)
        [HttpGet]
        [Route("")]
        [Route("List")]
        public IActionResult ListGymBookings()
        {
            // Fetch all gym room bookings with student details using repository method
            var bookings = _context.GymRoomBookings
                .Include(b => b.Student)
                .OrderBy(b => b.startTime)
                .ToList();
            return View("GymRoomList", bookings);
        }

        // Book Gym Room (GymRoomBooking.cshtml)
        [HttpGet]
        [Route("Book")]
        public IActionResult BookGymRoom()
        {
            // Remove the non-existent method call
            // Instead, you might want to pass necessary data for booking
            return View("GymRoomBooking");
        }

        [HttpPost]
        [Route("Book")]
        [ValidateAntiForgeryToken]
        public IActionResult BookGymRoom(int studentId, int gymRoomId, DateTime startTime, DateTime endTime)
        {
            try
            {
                // Check for conflicts before booking
                if (_gymRepository.IsBookingConflict(gymRoomId, startTime, endTime))
                {
                    ModelState.AddModelError("", "Gym room is already booked for selected time.");
                    return View("GymRoomBooking");
                }

                // Book the room
                var booking = _gymRepository.BookGymRoom(studentId, gymRoomId, startTime, endTime);
                // Redirect to list of bookings to show confirmation
                return RedirectToAction(nameof(ListGymBookings));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("GymRoomBooking");
            }
        }

        // Update Booking
        [HttpGet]
        [Route("Update/{bookingId:int}")]
        public IActionResult UpdateBooking(int bookingId)
        {
            // Use context to find the booking directly
            var booking = _context.GymRoomBookings.Find(bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            return View("GymRoomUpdate", booking);
        }

        [HttpPost]
        [Route("Update/{bookingId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBooking(int bookingId, DateTime newStartTime, DateTime newEndTime)
        {
            try
            {
                var updatedBooking = _gymRepository.UpdateRoom(bookingId, newStartTime, newEndTime);
                return RedirectToAction(nameof(ListGymBookings));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("GymRoomUpdate");
            }
        }

        // Delete Booking
        [HttpPost]
        [Route("Delete/{bookingId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBooking(int bookingId)
        {
            try
            {
                _gymRepository.Delete(bookingId);
                return RedirectToAction(nameof(ListGymBookings));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(ListGymBookings));
            }
        }
    }
}
}



