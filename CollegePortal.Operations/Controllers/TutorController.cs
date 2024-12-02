using CollegePortal.Entities.Models;
using CollegePortal.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CollegePortal.Controllers
{
    public class TutorController : Controller
    {
        private readonly ITutorRepository _tutorRepository;

        public TutorController(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        // GET: Show all tutor bookings
        public IActionResult ShowTutor()
        {
            try
            {
                var bookings = _tutorRepository.GetTutorBookings(0, DateTime.MinValue, DateTime.MaxValue);
                return View("~/Views/Pages/TutorViews/ShowTutor.cshtml", bookings);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error fetching tutor bookings: {ex.Message}";
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: Create a new tutor booking
        public IActionResult TutorBooking()
        {
            return View("~/Views/Pages/TutorViews/TutorBooking.cshtml");
        }

        // POST: Create a new tutor booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TutorBooking(int studentId, int tutorId, DateTime startTime, DateTime endTime)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please correct the form inputs.");
                    return View("~/Views/Pages/TutorViews/TutorBooking.cshtml");
                }

                _tutorRepository.BookTutorSession(studentId, tutorId, startTime, endTime);
                TempData["SuccessMessage"] = "Tutor session booked successfully.";
                return RedirectToAction(nameof(ShowTutor));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating tutor booking: {ex.Message}");
                return View("~/Views/Pages/TutorViews/TutorBooking.cshtml");
            }
        }

        // ...

        // GET: Update a tutor booking
        public IActionResult TutorUpdate(int id)
        {
            try
            {
                var booking = _tutorRepository.GetTutorBookings(0, DateTime.MinValue, DateTime.MaxValue).FirstOrDefault(b => b.bookingId == id);
                if (booking == null)
                {
                    TempData["ErrorMessage"] = "Tutor booking not found.";
                    return RedirectToAction(nameof(ShowTutor));
                }

                return View("~/Views/Pages/TutorViews/TutorUpdate.cshtml", booking);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error fetching tutor booking: {ex.Message}";
                return RedirectToAction(nameof(ShowTutor));
            }
        }

        // POST: Update a tutor booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TutorUpdate(int id, DateTime startTime, DateTime endTime)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please correct the form inputs.");
                    return View("~/Views/Pages/TutorViews/TutorUpdate.cshtml");
                }

                _tutorRepository.UpdateTutorBooking(id, startTime, endTime);
                TempData["SuccessMessage"] = "Tutor booking updated successfully.";
                return RedirectToAction(nameof(ShowTutor));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating tutor booking: {ex.Message}");
                return RedirectToAction(nameof(TutorUpdate), new { id });
            }
        }

        // POST: Delete a tutor booking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                _tutorRepository.DeleteTutorBooking(id);
                TempData["SuccessMessage"] = "Tutor booking deleted successfully.";
                return RedirectToAction(nameof(ShowTutor));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting tutor booking: {ex.Message}";
                return RedirectToAction(nameof(ShowTutor));
            }
        }
    }
}
