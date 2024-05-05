using FurnitureHub.Models;
using FurnitureHub.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

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
            List<ProductCategory> categories = ProductCategoryRepository.GetAll();    

            return View("Index",categories);
        }

        public IActionResult Details(int id)    
        {
            ProductCategory category = ProductCategoryRepository.GetById(id);
            return View("Details", category);
        }

        [HttpGet]
        public IActionResult New()   
        {

            

            return View("New");
        }

        [HttpPost]
        public IActionResult SaveNew(ProductCategory category)
        {
            if (category.Name != null)
            {
                ProductCategoryRepository.Insert(category);
                ProductCategoryRepository.Save();
                return RedirectToAction("Index", "ProductCategory");
            }
            return View("New", category); // Return the "New" view with the invalid model
        }

        public IActionResult Search(string searchName)
        {
            List<ProductCategory> categoryList;

            if (!string.IsNullOrEmpty(searchName))
            {
                categoryList = ProductCategoryRepository.SearchByName(searchName);
            }
            else
            {
                categoryList = ProductCategoryRepository.GetAll();
            }

            return View("Index", categoryList);
        }


    }
}
