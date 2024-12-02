using CollegePortal.Entities.Models;
using CollegePortal.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CollegePortal.Controllers
{
    [Route("[controller]")]
    public class StudyRoomController : Controller
    {
        private readonly IStudyRoomRepository _studyRoomRepository;

        public StudyRoomController(IStudyRoomRepository studyRoomRepository)
        {
            _studyRoomRepository = studyRoomRepository;
        }

        // Show all study room bookings
        [HttpGet("ShowStudyRooms")]
        public IActionResult ShowStudyRooms()
        {
            try
            {
                var bookings = _studyRoomRepository.GetStudyRoomBookingsByStudent(0); // Fetch all bookings
                return View("~/Views/Pages/StudyRoomViews/ShowStudyRoom.cshtml", bookings);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return RedirectToAction("Error", "Home");
            }
        }

        // Add a new study room booking (GET)
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View("~/Views/Pages/StudyRoomViews/StudyRoomBooking.cshtml");
        }

        // Add a new study room booking (POST)
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudyRoomBookings booking)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Pages/StudyRoomViews/StudyRoomBooking.cshtml", booking);
            }

            try
            {
                _studyRoomRepository.BookStudyRoom(booking.studentId, booking.studyRoomId, booking.startTime, booking.endTime);
                TempData["SuccessMessage"] = "Study room booked successfully.";
                return RedirectToAction("ShowStudyRooms");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("~/Views/Pages/StudyRoomViews/StudyRoomBooking.cshtml", booking);
            }
        }

        // Edit a booking (GET)
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var booking = _studyRoomRepository.GetStudyRoomBookingsByStudent(id);

            if (booking == null)
            {
                TempData["ErrorMessage"] = "Booking not found.";
                return RedirectToAction("ShowStudyRooms");
            }

            return View("~/Views/Pages/StudyRoomViews/StudyRoomUpdate.cshtml", booking);
        }

        // Edit a booking (POST)
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, StudyRoomBookings updatedBooking)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Pages/StudyRoomViews/StudyRoomUpdate.cshtml", updatedBooking);
            }

            try
            {
                _studyRoomRepository.UpdateStudyRoomBooking(id, updatedBooking.startTime, updatedBooking.endTime);
                TempData["SuccessMessage"] = "Booking updated successfully.";
                return RedirectToAction("ShowStudyRooms");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("~/Views/StudyRoomViews/StudyRoomUpdate.cshtml", updatedBooking);
            }
        }

        // Delete a booking
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                _studyRoomRepository.DeleteStudyRoomBooking(id);
                TempData["SuccessMessage"] = "Booking deleted successfully.";
                return RedirectToAction("ShowStudyRooms");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return RedirectToAction("ShowStudyRooms");
            }
        }
    }
}
