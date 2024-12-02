using CollegePortal.Entities.Models;

public interface IStudentRepository
{
    // Add a new student
    Student AddStudent(Student student);
    // Authenticate a student (login)
    Student AuthenticateStudent(string name, string password);
    // Get all students
}

