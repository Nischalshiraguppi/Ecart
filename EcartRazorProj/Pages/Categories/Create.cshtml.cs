using EcartRazorProj.Data;
using EcartRazorProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcartRazorProj.Pages.Categories
{
	[BindProperties]
	public class CreateModel : PageModel
	{
		private readonly ApplicationDbContext _db;
	
		public Category category { get; set; }
		public CreateModel(ApplicationDbContext db)
		{
			_db = db;
		}
		public void OnGet()
        {

        }
		public IActionResult OnPost(Category category) 
		{
			_db.categories.Add(category);
			_db.SaveChanges();
			TempData["success"] = "Category Added Successfully";
			return Redirect("Index");
		}
    }
}
