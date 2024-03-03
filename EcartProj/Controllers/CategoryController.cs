using Ecart.DataAccess.Data;
using Ecart.DataAccess.Repository.IRepository;
using Ecart.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcartProj.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryRepo categoryRepo;
		public CategoryController(ICategoryRepo db)
		{
			categoryRepo = db;
		}

		public IActionResult Index()
		{
			List<Category> db = categoryRepo.GetAll().ToList();
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
				categoryRepo.Add(category);
				categoryRepo.Save();
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
			Category? categoryFromDb = categoryRepo.Get(u=>u.Id==id);
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
				categoryRepo.Update(category);
				categoryRepo.Save();
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
			Category? categoryFromDb = categoryRepo.Get(u => u.Id == id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			Category? category = categoryRepo.Get(u => u.Id == id);
			//Category category1 = _db.categories.FirstOrDefault(u=>u.Id==id);
			//Category category2 = _db.categories.Where(u => u.Id == id).FirstOrDefault();
			if (category == null)
			{
				return NotFound();
			}
			categoryRepo.Remove(category);
			categoryRepo.Save();
			TempData["error"] = "Category Deleted";
			return RedirectToAction("Index");

		}
	}
}
