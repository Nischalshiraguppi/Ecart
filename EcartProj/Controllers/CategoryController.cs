using Ecart.DataAccess.Data;
using Ecart.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcartProj.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;
		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			List<Category> db = _db.categories.ToList();
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
				_db.categories.Add(category);
				_db.SaveChanges();
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
			Category? categoryFromDb = _db.categories.Find(id);
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
				_db.categories.Update(category);
				_db.SaveChanges();
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
			Category? categoryFromDb = _db.categories.Find(id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int? id)
		{
			Category? category = _db.categories.Find(id);
			//Category category1 = _db.categories.FirstOrDefault(u=>u.Id==id);
			//Category category2 = _db.categories.Where(u => u.Id == id).FirstOrDefault();
			if (category == null)
			{
				return NotFound();
			}
			_db.categories.Remove(category);
			_db.SaveChanges();
			TempData["error"] = "Category Deleted";
			return RedirectToAction("Index");

		}
	}
}
