using CollegePortal.Entities.Models;
using CollegePortal.Services.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollegePortal.Services.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DbContextStudent _context;

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

        // Authenticate a student (login)
        public Student? AuthenticateStudent(string name, string password)
        {
            return _context.Students.FirstOrDefault(s => s.Name == name && s.Password == password);
        }

        // Get all students
        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        // Get a student by ID
        public Student GetStudentById(int studentId)
        {
            return _context.Students.Find(studentId) ?? throw new Exception($"Student with ID {studentId} not found.");
        }

        // Update an existing student
        public Student UpdateStudent(Student student)
        {
            var existingStudent = _context.Students.Find(student.StudentId);
            if (existingStudent == null)
                throw new Exception($"Student with ID {student.StudentId} not found.");

            existingStudent.Name = student.Name;
            existingStudent.Password = student.Password;

            _context.SaveChanges();
            return existingStudent;
        }

        // Delete a student by ID
        public void DeleteStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student == null)
                throw new Exception($"Student with ID {studentId} not found.");

            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}

