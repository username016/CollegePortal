using CollegePortal.Entities.Models;
using CollegePortal.Services.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

namespace CollegePortal.Services.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbContextStudent _context;
        private string password;

        public StudentRepository(DbContextStudent context)
        {
            _context = context;
        }

        // Add a new student
        public Student AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        // Authenticate a student based on their name and password
        public Student AuthenticateStudent(string name, string password)
        {
            return _context.Students.FirstOrDefault(s => s.name == name && s.password == password);
        }

        // Get all students
        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        // Get a student by name
        public Student GetStudentByName(string name)
        {
            return _context.Students.FirstOrDefault(s => s.name == name);
           
        }

    }
}
