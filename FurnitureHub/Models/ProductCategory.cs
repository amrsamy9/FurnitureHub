namespace FurnitureHub.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
