using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureHub.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        
        public string ImageURL { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public ProductCategory Category { get; set; }
    }
}
