using Ecart.DataAccess.Data;
using Ecart.DataAccess.Repository.IRepository;
using Ecart.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcartProj.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryController(IUnitOfWork db)
        {
            unitOfWork = db;
        }

        public IActionResult Index()
        {
            List<Category> db = unitOfWork.CategoryRepo.GetAll().ToList();
            return View(db);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display Order can't be same as Name.");
            }
            if (ModelState.IsValid)
            {
                unitOfWork.CategoryRepo.Add(category);
                unitOfWork.Save();
                TempData["success"] = "Category Created";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = unitOfWork.CategoryRepo.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                unitOfWork.CategoryRepo.Update(category);
                unitOfWork.Save();
                TempData["error"] = "Category Edited";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = unitOfWork.CategoryRepo.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = unitOfWork.CategoryRepo.Get(u => u.Id == id);
            //Category category1 = _db.categories.FirstOrDefault(u=>u.Id==id);
            //Category category2 = _db.categories.Where(u => u.Id == id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            unitOfWork.CategoryRepo.Remove(category);
            unitOfWork.Save();
            TempData["error"] = "Category Deleted";
            return RedirectToAction("Index");

        }
    }
}
