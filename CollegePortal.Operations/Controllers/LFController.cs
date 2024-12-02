using CollegePortal.Entities.Models;
using CollegePortal.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CollegePortal.Controllers
{
    public class LostAndFoundController : Controller
    {
        private readonly ILFRepository _repository;

        public LostAndFoundController(ILFRepository repository)
        {
            _repository = repository;
        }

        // Show all lost-and-found items
        public IActionResult ShowLFItems()
        {
            var items = _repository.GetAllLostFound();
            return View("~/Views/Pages/LFViews/ShowLFItems.cshtml", items); // Ensure this matches your folder structure
        }

        // Add a new lost-and-found item (GET)
        public IActionResult AddLFItem()
        {
            return View("~/Views/Pages/LFViews/AddLFItem.cshtml");
        }

        // Add a new lost-and-found item (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLFItem(LostAndFound model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Pages/LFViews/AddLFItem.cshtml", model);
            }

            try
            {
                _repository.CreateLostFound(model.studentId, model.itemDescription, model.foundDate, model.location);
                TempData["SuccessMessage"] = "Item added successfully.";
                return RedirectToAction(nameof(ShowLFItems));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("~/Views/Pages/LFViews/AddLFItem.cshtml", model);
            }
        }

        // Update a lost-and-found item (GET)
        public IActionResult LFUpdate(int id)
        {
            var item = _repository.GetLostFoundById(id);

            if (item == null)
            {
                TempData["ErrorMessage"] = "Item not found.";
                return RedirectToAction(nameof(ShowLFItems));
            }

            return View("~/Views/Pages/LFViews/LFUpdatecshtml.cshtml", item);
        }

        // Update a lost-and-found item (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LFUpdate(LostAndFound model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Pages/LFViews/LFUpdatecshtml.cshtml", model);
            }

            try
            {
                _repository.UpdateLostFound(model.postId, model.itemDescription, model.foundDate, model.location);
                TempData["SuccessMessage"] = "Item updated successfully.";
                return RedirectToAction(nameof(ShowLFItems));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("~/Views/Pages/LFViews/LFUpdatecshtml.cshtml", model);
            }
        }
    }
}
