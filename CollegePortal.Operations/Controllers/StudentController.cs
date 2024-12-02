using CollegePortal.Services.Repositories;
using CollegePortal.Operation.Models;
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
            return View(new LoginViewModel());
        }

        // POST: Login Action
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = _studentRepository.AuthenticateStudent(model.Email, model.Password);
                if (student != null)
                {
                    // Redirect to dashboard or a success page
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    // Add error message for failed login
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                }
            }
            return View(model); // Return the view with validation errors
        }
    }
}
