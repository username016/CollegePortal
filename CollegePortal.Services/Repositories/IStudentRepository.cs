using CollegePortal.Entities.Models;
using System.Collections.Generic;

namespace CollegePortal.Services.Repositories
{
    public interface IStudentRepository
    {
        // Get all students
        IEnumerable<Student> GetAllStudents();

        // Get a student by ID
        Student GetStudentById(int studentId);

        // Add a new student
        Student AddStudent(Student student);

        // Update an existing student
        Student UpdateStudent(Student student);

        // Delete a student by ID
        void DeleteStudent(int studentId);

        // Authenticate a student (login)
        Student AuthenticateStudent(string name, string password);
    }
}
