using FurnitureHub.Models;
using FurnitureHub.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace FurnitureHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCategoryController : Controller
    {
        IProductCategoryRepository ProductCategoryRepository;
        public ProductCategoryController(IProductCategoryRepository productCategoryRepository)
        {
            ProductCategoryRepository = productCategoryRepository;
        }

        public IActionResult Index()
        {
            List<ProductCategory> categoryList = ProductCategoryRepository.GetAll();

            return View("Index", categoryList);
        }
        public IActionResult Details(int id)    //get the instructor by id 
        {
            ProductCategory category = ProductCategoryRepository.GetById(id);
            return View("Details", category);
        }

        [HttpGet]
        public IActionResult New()   //methof for view the form to add new instructor 
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
            List<ProductCategory> CategoryList;

            if (!string.IsNullOrEmpty(searchName))
            {
                CategoryList = ProductCategoryRepository.SearchByName(searchName);
            }
            else
            {
                CategoryList = ProductCategoryRepository.GetAll();
            }

            return View("Index", CategoryList);
        }

        public IActionResult Delete(int id)
        {
            var category = ProductCategoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            ProductCategoryRepository.Delete(id);
            ProductCategoryRepository.Save();


            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var category = ProductCategoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            ProductCategoryRepository.Delete(id);
            ProductCategoryRepository.Save();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ProductCategory category = ProductCategoryRepository.GetById(id);


            return View("Edit", category);
        }

        [HttpPost]
        public IActionResult SaveEdit(ProductCategory category)
        {
            ProductCategory existingCategory = ProductCategoryRepository.GetById(category.Id);

            if (existingCategory == null)
            {
                return NotFound();
            }


            existingCategory.Name = category.Name;
            existingCategory.Image = category.Image;


            ProductCategoryRepository.Save();

            return RedirectToAction("Index");


            return View("Edit", category);
        }



    }
}
