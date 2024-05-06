using Microsoft.AspNetCore.Mvc;
using FurnitureHub.Repository;
using FurnitureHub.Models;
using NuGet.Protocol.Core.Types;
using FurnitureHub.ViewModel;
using System.ComponentModel.DataAnnotations;
 using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
namespace FurnitureHub.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository ProductRepository;
        IProductCategoryRepository ProductCategoryRepository;
        public ProductController(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
        {
            ProductRepository = productRepository;
            ProductCategoryRepository = productCategoryRepository;

        }
        public IActionResult Index()
        {
            List<Product> ProductList = ProductRepository.GetAll();
            return View("Index", ProductList);
        }



        public IActionResult Search(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return RedirectToAction("Index");
            }

            var products = ProductRepository.SearchByName(searchString);
            return View("Index", products);
        }

        public IActionResult Details(int id)
        {
            Product product = ProductRepository.GetById(id);
            return View("Details", product);
        }


        [HttpGet]
        public IActionResult New()
        {
            var productviewModel = new ProductViewModel();


            ViewData["categoryList"] = ProductCategoryRepository.GetAll();
            return View(productviewModel);
        }







        [HttpPost]
        public IActionResult SaveNew(ProductViewModel product)
        {

            List<ProductCategory> categoriesList = ProductCategoryRepository.GetAll();

            Product prold = new Product();

            prold.ID = product.ID;
            prold.Name = product.Name;
            prold.Description = product.Description;
            prold.ImageURL = product.ImageURL;
            prold.Price = product.Price;
            prold.CategoryID = product.CategoryID;
            product.categoryList = categoriesList;


            if (ModelState.IsValid == true)
            {
                try
                {
                    ProductRepository.Insert(prold);
                    ProductRepository.Save();
                    return RedirectToAction("Index", "Product");
                }
                catch (Exception ex)
                {


                    //all errors
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }
            }
            ViewData["categoryList"] = ProductCategoryRepository.GetAll();
            return View("New", product);
        }

        public IActionResult Edit(int Id)
        {
            Product productModel = ProductRepository.GetById(Id);

            if (productModel != null)
            {
                List<ProductCategory> categoryList = ProductCategoryRepository.GetAll();

                ProductViewModel prviewmodel = new ProductViewModel
                {
                    ID = productModel.ID,
                    Name = productModel.Name,
                    Description = productModel.Description,
                    Price = productModel.Price,
                    ImageURL = productModel.ImageURL,
                    CategoryID = productModel.CategoryID,
                    categoryList = categoryList,
                };

                ViewData["categoryList"] = ProductCategoryRepository.GetAll();

                return View("Edit", prviewmodel);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        //savedit
        [HttpPost]
        public IActionResult SaveEdit(ProductViewModel productFromReq)
        {
            if (ModelState.IsValid)
            {
                Product productFromDB = ProductRepository.GetById(productFromReq.ID);

                if (productFromDB != null)
                {
                    productFromDB.Name = productFromReq.Name;
                    productFromDB.Description = productFromReq.Description;
                    productFromDB.Price = productFromReq.Price;
                    productFromDB.ImageURL = productFromReq.ImageURL;
                    productFromDB.CategoryID = productFromReq.CategoryID;

                    ProductRepository.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }

         
            return View("Edit", productFromReq);
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = ProductRepository.GetById(id);
            if (product != null)
            {
                ProductRepository.Delete(id);
                ProductRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}




