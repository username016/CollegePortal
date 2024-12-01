using CollegePortal.Entities.Models;
using CollegePortal.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CollegePortal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyRoomController : ControllerBase
    {
        private readonly IStudyRoomRepository _studyRoomRepository;

        public StudyRoomController(IStudyRoomRepository studyRoomRepository)
        {
            _studyRoomRepository = studyRoomRepository;
        }

        // Get all study room bookings
        [HttpGet("GetAllStudyRoomBookings")]
        public IActionResult GetAllStudyRoomBookings(DateTime startTime, DateTime endTime)
        {
            try
            {
                var bookings = _studyRoomRepository.GetAllStudyRoomBookings(startTime, endTime);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Get bookings for a specific study room by student ID
        [HttpGet("GetStudyRoomBookingsByStudent/{studentId}")]
        public IActionResult GetStudyRoomBookingsByStudent(int studentId)
        {
            try
            {
                var bookings = _studyRoomRepository.GetStudyRoomBookingsByStudent(studentId);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Book a study room
        [HttpPost("BookStudyRoom")]
        public IActionResult BookStudyRoom([FromBody] StudyRoomBookingRequest request)
        {
            try
            {
                var booking = _studyRoomRepository.BookStudyRoom(request.StudentId, request.StudyRoomId, request.StartTime, request.EndTime);
                return CreatedAtAction(nameof(GetStudyRoomBookingsByStudent), new { studentId = request.StudentId }, booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update an existing study room booking
        [HttpPut("UpdateStudyRoomBooking/{bookingId}")]
        public IActionResult UpdateStudyRoomBooking(int bookingId, [FromBody] StudyRoomBookingUpdateRequest request)
        {
            try
            {
                var updatedBooking = _studyRoomRepository.UpdateStudyRoomBooking(bookingId, request.StartTime, request.EndTime);
                return Ok(updatedBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a study room booking
        [HttpDelete("DeleteStudyRoomBooking/{bookingId}")]
        public IActionResult DeleteStudyRoomBooking(int bookingId)
        {
            try
            {
                _studyRoomRepository.DeleteStudyRoomBooking(bookingId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    // Request DTO for booking a study room
    public class StudyRoomBookingRequest
    {
        public int StudentId { get; set; }
        public int StudyRoomId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

    // Request DTO for updating a booking
    public class StudyRoomBookingUpdateRequest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

