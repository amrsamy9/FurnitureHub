﻿namespace FurnitureHub.Models
{
    public class Cart
    {
        public int ID { get; set; }


        public int CustomerID { get; set; }

        public ICollection<CartItem> CartItem { get; set;}

        public Customer Customer { get; set; }
    }
}
