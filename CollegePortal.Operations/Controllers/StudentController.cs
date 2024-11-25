using CollegePortal.Entities.Models;
using CollegePortal.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CollegePortal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // Get all students
        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            try
            {
                var students = _studentRepository.GetAllStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Get a student by ID
        [HttpGet("GetStudentById/{studentId}")]
        public IActionResult GetStudentById(int studentId)
        {
            try
            {
                var student = _studentRepository.GetStudentById(studentId);
                if (student == null)
                    return NotFound($"Student with ID {studentId} not found.");
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Add a new student
        [HttpPost("AddStudent")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            try
            {
                var newStudent = _studentRepository.AddStudent(student);
                return CreatedAtAction(nameof(GetStudentById), new { studentId = newStudent.StudentId }, newStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update an existing student
        [HttpPut("UpdateStudent/{studentId}")]
        public IActionResult UpdateStudent(int studentId, [FromBody] Student student)
        {
            try
            {
                if (studentId != student.StudentId)
                    return BadRequest("Student ID mismatch.");

                var updatedStudent = _studentRepository.UpdateStudent(student);
                return Ok(updatedStudent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete a student by ID
        [HttpDelete("DeleteStudent/{studentId}")]
        public IActionResult DeleteStudent(int studentId)
        {
            try
            {
                _studentRepository.DeleteStudent(studentId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Authenticate a student (login)
        [HttpPost("AuthenticateStudent")]
        public IActionResult AuthenticateStudent([FromBody] StudentLoginRequest request)
        {
            try
            {
                var student = _studentRepository.AuthenticateStudent(request.Name, request.Password);
                if (student == null)
                    return Unauthorized("Invalid username or password.");

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

    // DTO for student login request
    public class StudentLoginRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
