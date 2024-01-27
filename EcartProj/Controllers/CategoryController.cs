using Microsoft.AspNetCore.Mvc;

namespace EcartProj.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
