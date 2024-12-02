using CollegePortal.Services.Repositories;
using CollegePortal.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegePortal.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: Login Page
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login Action
        [HttpPost]
        public IActionResult Login(string name, string password)
        {
            var student = _studentRepository.AuthenticateStudent(name, password);
            if (student != null)
            {
                // Redirect to a dashboard or another view upon successful login
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                // Add error message for failed login
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }
    }
}
