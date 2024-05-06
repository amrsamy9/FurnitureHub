using FurnitureHub.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureHub.ViewModel
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        [Display(Name = " Select a Category")]
        public int CategoryID { get; set; }
     
        public List<ProductCategory>? categoryList { get; set; }

    }
}
