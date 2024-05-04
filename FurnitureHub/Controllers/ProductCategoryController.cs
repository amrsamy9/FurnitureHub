using FurnitureHub.Models;
using FurnitureHub.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureHub.Controllers
{
    public class ProductCategoryController : Controller
    {
        IProductCategoryRepository ProductCategoryRepository;
        public ProductCategoryController(IProductCategoryRepository productCategoryRepository) 
        {
            ProductCategoryRepository = productCategoryRepository;
        }

        public IActionResult Index()
        {
            List<ProductCategory> products = ProductCategoryRepository.GetAll();    

            return View("Index");
        }
    }
}
