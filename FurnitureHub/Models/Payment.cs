namespace FurnitureHub.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public List<PaymentMethod> paymentMethod {  get; set; }

        public Order Order { get; set; }

    }
}
