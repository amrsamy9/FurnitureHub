using Microsoft.AspNetCore.Mvc;

namespace FurnitureHub.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
