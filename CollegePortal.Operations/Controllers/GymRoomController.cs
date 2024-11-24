using CollegePortal.Entities.Models;
using CollegePortal.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CollegePortal.Controllers
{
    public class GymRoomController : Controller
    {
        private readonly IGymRepository _gymRepository;

        public GymRoomController(IGymRepository gymRepository)
        {
            _gymRepository = gymRepository;
        }

        // GET: List all gym rooms
        public IActionResult Index()
        {
            var gymRooms = _gymRepository.ListAllGymRooms();
            return View(gymRooms);
        }

        // GET: Details of a specific booking
        public IActionResult Details(int id)
        {
            var booking = _gymRepository.GetGymRoomBookings(id).FirstOrDefault();
            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // GET: Create a new booking
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create a new booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int studentId, int gymRoomId, DateTime startTime, DateTime endTime)
        {
            if (_gymRepository.IsBookingConflict(gymRoomId, startTime, endTime))
            {
                ModelState.AddModelError("", "The gym room is already booked for the selected time.");
                return View();
            }

            try
            {
                var booking = _gymRepository.BookGymRoom(studentId, gymRoomId, startTime, endTime);
                TempData["SuccessMessage"] = "Gym room booked successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Edit a booking
        public IActionResult Edit(int id)
        {
            var booking = _gymRepository.GetGymRoomBookings(id).FirstOrDefault();
            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // POST: Update a booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int bookingId, DateTime startTime, DateTime endTime)
        {
            try
            {
                var updatedBooking = _gymRepository.UpdateRoom(bookingId, startTime, endTime);
                TempData["SuccessMessage"] = "Booking updated successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Delete a booking (confirmation)
        public IActionResult Delete(int id)
        {
            var booking = _gymRepository.GetGymRoomBookings(id).FirstOrDefault();
            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // POST: Delete a booking
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _gymRepository.Delete(id);
                TempData["SuccessMessage"] = "Booking deleted successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
