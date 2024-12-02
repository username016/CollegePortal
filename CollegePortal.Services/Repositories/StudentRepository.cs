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
            return _context.Students.FirstOrDefault(s => s.name == name && s.password == password);
        }
    }
}

