namespace FurnitureHub.Models
{
    public class Review
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
