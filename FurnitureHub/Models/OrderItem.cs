using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureHub.Models
{
    public class OrderItem
    {
        public int ID { get; set; }


        [ForeignKey("Order")]
        public int OrderID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }


        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
