// Controllers/AccountController.cs
using CollegePortal.Operation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegePortal.Operations.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Replace with actual authentication logic
                if (model.Email == "test@example.com" && model.Password == "password123")
                {
                    // Store user email in session
              //      Session["UserEmail"] = model.Email;
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }

        // GET: Logout
        public ActionResult Logout()
        {
          //  Session.Clear(); // Clear session data
            return RedirectToAction("Login");
        }
    }
}
