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
        [Route("Student/Login")]
        public IActionResult Login()
        {
            return View("~/Views/Pages/Student/Login.cshtml"); // Explicit view path
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
}
