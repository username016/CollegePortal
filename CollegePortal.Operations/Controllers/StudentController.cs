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

      /*  // Add a new student
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
      */


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
        public required string Name { get; set; }
        public required string Password { get; set; }
    }
}
