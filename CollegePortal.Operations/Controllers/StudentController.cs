using CollegePortal.Entities.Models;
using CollegePortal.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

/*namespace CollegePortal.Controllers
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
            return View("~/Views/Pages/Student/Login.cshtml"); // Explicit path to the Login view
        }

        // POST: Authenticate Student
        [HttpPost]
        [Route("Student/Login")]
        public IActionResult Login(Student model)
        {
            if (ModelState.IsValid)
            {
                var student = _studentRepository.AuthenticateStudent(model.name, model.password);

                if (student != null)
                {
                    return RedirectToAction("Dashboard", "Home"); // Redirect on success
                }

                ModelState.AddModelError(string.Empty, "Invalid name or password.");
            }
            return View("~/Views/Pages/Student/Login.cshtml", model);
        }
    }
} */

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

        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Pages/Student/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(Student model)
        {
            if (ModelState.IsValid)
            {
                var student = _studentRepository.AuthenticateStudent(model.name, model.password);

                if (student != null)
                {
                    return RedirectToAction("Dashboard", "Home");
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
    }
}

