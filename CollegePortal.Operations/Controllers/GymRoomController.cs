using System;
using Microsoft.AspNetCore.Mvc;
using CollegePortal.Services.Repositories;

namespace CollegePortal.Controllers
{
    public class GymRoomController : Controller
    {
        public IActionResult Index()
        {
            // Your logic here
            return View();
        }
    }
}
