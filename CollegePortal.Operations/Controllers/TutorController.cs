using CollegePortal.Entities.Models;
using CollegePortal.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CollegePortal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutorController : ControllerBase
    {
        private readonly ITutorRepository _tutorRepository;

        public TutorController(ITutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

      
        /* 
          // Get all tutor bookings
        [HttpGet("GetAllTutorBookings")]
        public IActionResult GetAllTutorBookings(int studentId, DateTime startTime, DateTime endTime)
        {
            try
            {
                var bookings = _tutorRepository.GetAllTutorBookings(studentId, startTime, endTime);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        */

        // Get bookings for a specific tutor
        [HttpGet("GetTutorBookings/{tutorId}")]
        public IActionResult GetTutorBookings(int tutorId, DateTime startTime, DateTime endTime)
        {
            try
            {
                var bookings = _tutorRepository.GetTutorBookings(tutorId, startTime, endTime);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Book a session with a tutor
        [HttpPost("BookTutorSession")]
        public IActionResult BookTutorSession([FromBody] TutorBookingRequest request)
        {
            try
            {
                var booking = _tutorRepository.BookTutorSession(request.StudentId, request.TutorId, request.StartTime, request.EndTime);
                return CreatedAtAction(nameof(GetTutorBookings), new { tutorId = request.TutorId }, booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update an existing booking
        [HttpPut("UpdateTutorBooking/{bookingId}")]
        public IActionResult UpdateTutorBooking(int bookingId, [FromBody] TutorBookingUpdateRequest request)
        {
            try
            {
                var updatedBooking = _tutorRepository.UpdateTutorBooking(bookingId, request.StartTime, request.EndTime);
                return Ok(updatedBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a booking
        [HttpDelete("DeleteTutorBooking/{bookingId}")]
        public IActionResult DeleteTutorBooking(int bookingId)
        {
            try
            {
                _tutorRepository.DeleteTutorBooking(bookingId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    // Request DTO for booking a session
    public class TutorBookingRequest
    {
        public int StudentId { get; set; }
        public int TutorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    // Request DTO for updating a booking
    public class TutorBookingUpdateRequest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
