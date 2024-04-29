using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureHub.Models
{
    public class Order
    {
        public int ID { get; set; }
       
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalPrice { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
        public List<Payment> payment { get; set; }
        public Employee Employee { get; set; }

    }
}
