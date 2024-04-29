namespace FurnitureHub.Models
{
    public class PaymentMethod
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Payment Payment { get; set; }
    }
}
