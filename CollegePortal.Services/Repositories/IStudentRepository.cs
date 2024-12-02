using CollegePortal.Entities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegePortal.Services.Repositories
{
    public interface IStudentRepository
    {
        // Add a new student
        Student AddStudent(Student student);

        // Authenticate a student (login)
        Student AuthenticateStudent(string name, string password);

        // Get all students
        IEnumerable<Student> GetAllStudents();

        // Get a student by name
        Student GetStudentByName(string name);

      
    }
}
