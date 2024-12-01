using CollegePortal.Entities.Models;

public interface IStudentRepository
{
    // Add a new student
    Student AddStudent(Student student);
    // Authenticate a student (login)
    Student AuthenticateStudent(string name, string password);
    // Get all students
    IEnumerable<Student> GetAllStudents();
    // Get a student by ID
    Student GetStudentById(int studentId);
    // Update an existing student
    Student UpdateStudent(Student student);
    // Delete a student by ID
    void DeleteStudent(int studentId);
}
public class Student
{
    public int StudentId { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; }
}
