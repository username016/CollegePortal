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
            var items = _lostAndFoundRepository.ListAllItems();
            return View(items);
        }

        // GET: Details of a specific lost-and-found item
        public IActionResult Details(int id)
        {
            var item = _lostAndFoundRepository.GetItemById(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // GET: Create a new lost-and-found post
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create a new lost-and-found post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LostAndFound lostAndFound)
        {
            if (!ModelState.IsValid)
                return View(lostAndFound);

            try
            {
                _lostAndFoundRepository.AddItem(lostAndFound);
                TempData["SuccessMessage"] = "Lost-and-found item added successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(lostAndFound);
            }
        }

        // GET: Edit a lost-and-found item
        public IActionResult Edit(int id)
        {
            var item = _lostAndFoundRepository.GetItemById(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Update a lost-and-found item
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LostAndFound lostAndFound)
        {
            if (!ModelState.IsValid)
                return View(lostAndFound);

            try
            {
                _lostAndFoundRepository.UpdateItem(id, lostAndFound);
                TempData["SuccessMessage"] = "Lost-and-found item updated successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(lostAndFound);
            }
        }

        // GET: Delete a lost-and-found item (confirmation)
        public IActionResult Delete(int id)
        {
            var item = _lostAndFoundRepository.GetItemById(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: Delete a lost-and-found item
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _lostAndFoundRepository.DeleteItem(id);
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
