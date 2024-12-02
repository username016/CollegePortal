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

        // List ALL Gym Room Bookings (ShowAllGymBookings.cshtml)
        [HttpGet]
        [Route("")]
        [Route("List")]
        public IActionResult ListGymBookings()
        {
            try
            {
                var bookings = _context.GymRoomBookings
                    .Include(b => b.Student)
                    .OrderBy(b => b.startTime)
                    .ToList();

                return View("~/Views/Pages/GymViews/ShowAllGymBookings.cshtml", bookings);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while fetching bookings: {ex.Message}";
                return RedirectToAction("Error", "Home");
            }
        }

        // Book Gym Room (GymRoomBooking.cshtml)
        [HttpGet]
        [Route("Book")]
        public IActionResult BookGymRoom()
        {
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Rooms = _context.GymRoomBookings.ToList();

            return View("~/Views/Pages/GymViews/GymRoomBooking.cshtml");
        }


        [HttpPost]
        [Route("Book")]
        [ValidateAntiForgeryToken]
        public IActionResult BookGymRoom(GymRoomBookings booking)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Reload necessary data for the view if validation fails
                    ViewBag.Students = _context.Students.ToList();
                    ViewBag.Rooms = _context.GymRoomBookings.ToList();

                    return View("~/Views/Pages/GymViews/GymRoomBooking.cshtml", booking);
                }

                // Check for booking conflicts
                if (_gymRepository.IsBookingConflict(booking.gymRoomId, booking.startTime, booking.endTime))
                {
                    ModelState.AddModelError("", "Gym room is already booked for the selected time.");

                    // Reload data for the view
                    ViewBag.Students = _context.Students.ToList();
                    ViewBag.Rooms = _context.GymRoomBookings.ToList();

                    return View("~/Views/Pages/GymViews/GymRoomBooking.cshtml", booking);
                }

                // Save the booking
                _context.GymRoomBookings.Add(booking);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Gym room booked successfully.";
                return RedirectToAction(nameof(ListGymBookings));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View("~/Views/Pages/GymViews/GymRoomBooking.cshtml", booking);
            }
        }

        // Update Booking (GymRoomUpdate.cshtml)
        [HttpGet]
        [Route("Update/{bookingId:int}")]
        public IActionResult UpdateBooking(int bookingId)
        {
            var booking = _context.GymRoomBookings.Find(bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            return View("~/Views/Pages/GymViews/GymRoomUpdate.cshtml", booking);
        }

        [HttpPost]
        [Route("Update/{bookingId:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateBooking(int bookingId, DateTime newStartTime, DateTime newEndTime)
        {
            var booking = _context.GymRoomBookings.Find(bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            try
            {
                // Update the booking
                _gymRepository.UpdateRoom(bookingId, newStartTime, newEndTime);
                TempData["SuccessMessage"] = "Booking updated successfully.";
                return RedirectToAction(nameof(ListGymBookings));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred: {ex.Message}");
                return View("~/Views/Pages/GymViews/GymRoomUpdate.cshtml", booking);
            }
        }

        // Delete Booking
        [HttpPost]
        [Route("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBooking(int bookingId)
        {
            try
            {
                _gymRepository.Delete(bookingId);
                TempData["SuccessMessage"] = "Booking deleted successfully.";
                return RedirectToAction(nameof(ListGymBookings));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return RedirectToAction(nameof(ListGymBookings));
            }
        }
    }
}
