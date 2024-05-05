using FurnitureHub.Models;
using FurnitureHub.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureHub.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository ProductRepository;
    public ProductController(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }
    
        public IActionResult Index()
        {
            List<Product> products = ProductRepository.GetAll();

            return View();
        }
    }
}
