using EcartRazorProj.Data;
using EcartRazorProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcartRazorProj.Pages.Categories
{
    public class EditModel : PageModel
    {
		private readonly ApplicationDbContext _db;
		public Category category { get; set; }
		public EditModel(ApplicationDbContext db)
		{
			_db = db;
		}

		public void OnGet(int? id)
		{
			if(id !=null && id != 0) 
			{
				category = _db.categories.Find(id);
			}
		}
		public IActionResult OnPost(Category category)
		{
			_db.categories.Update(category);
			_db.SaveChanges();
			TempData["success"] = "Category Edited Successfully";
			return Redirect("Index");
		}
	}
}
