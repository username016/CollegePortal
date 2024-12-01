using CollegePortal.Entities.Models;
using System.Collections.Generic;

namespace CollegePortal.Services.Repositories
{
    public interface IStudentRepository
    {

        // Add a new student
        Student AddStudent(Student student);

        // Authenticate a student (login)
        Student AuthenticateStudent(string name, string password);
    }
}
