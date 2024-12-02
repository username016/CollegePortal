using CollegePortal.Entities.Models;
using CollegePortal.Services.Repositories;
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
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("StudentName") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View("~/Views/Pages/Student/Login.cshtml");
        }

        // POST: Authenticate Student
        [HttpPost]
        public IActionResult Login(Student model)
        {
            if (ModelState.IsValid)
            {
                var student = _studentRepository.AuthenticateStudent(model.name, model.password);

                if (student != null)
                {
                    HttpContext.Session.SetString("StudentName", student.name);
                    return RedirectToAction("Dashboard");
                }

                ModelState.AddModelError(string.Empty, "Invalid name or password.");
            }

            return View("~/Views/Pages/Student/Login.cshtml", model);
        }

        // GET: Register Page
        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Pages/Student/Register.cshtml");
        }

        // POST: Add New Student
        [HttpPost]
        public IActionResult Register(Student model)
        {
            if (ModelState.IsValid)
            {
                _studentRepository.AddStudent(model);
                return RedirectToAction("Login");
            }
            return View("~/Views/Pages/Student/Register.cshtml", model);
        }

        // GET: Dashboard Page
        [HttpGet]
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("StudentName") == null)
            {
                return RedirectToAction("Login");
            }
            return View("~/Views/Pages/Student/Dashboard.cshtml");
        }
    }
}
