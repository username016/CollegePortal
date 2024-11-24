using CollegePortal.Entities.Models;
using CollegePortal.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CollegePortal.Controllers
{
    public class LostAndFoundController : Controller
    {
        private readonly ILFRepository _lostAndFoundRepository;

        public LostAndFoundController(ILFRepository lostAndFoundRepository)
        {
            _lostAndFoundRepository = lostAndFoundRepository;
        }

        // GET: List all lost-and-found items
        public IActionResult Index()
        {
            var items = _lostAndFoundRepository.GetAllLostFound();
            return View(items);
        }

        // GET: Details of a specific lost-and-found item
        public IActionResult Details(int id)
        {
            try
            {
                var item = _lostAndFoundRepository.GetLostFoundById(id);
                return View(item);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // GET: Create a new lost-and-found post
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create a new lost-and-found post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int studentId, string itemDescription, DateTime foundDate, string location)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _lostAndFoundRepository.CreateLostFound(studentId, itemDescription, foundDate, location);
                TempData["SuccessMessage"] = "Lost-and-found item added successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Edit a lost-and-found item
        public IActionResult Edit(int id)
        {
            try
            {
                var item = _lostAndFoundRepository.GetLostAndFoundById(id);
                return View(item);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Update a lost-and-found item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string itemDescription, DateTime foundDate, string location)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _lostAndFoundRepository.UpdateLostFound(id, itemDescription, foundDate, location);
                TempData["SuccessMessage"] = "Lost-and-found item updated successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Delete a lost-and-found item (confirmation)
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _lostAndFoundRepository.GetLostFoundById(id);
                return View(item);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        // POST: Delete a lost-and-found item
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _lostAndFoundRepository.DeleteLostFound(id);
                TempData["SuccessMessage"] = "Lost-and-found item deleted successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("Index");
            }
        }
    }
}
