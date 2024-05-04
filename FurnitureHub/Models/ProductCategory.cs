﻿namespace FurnitureHub.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image {  get; set; }   


        public ICollection<Product> Products { get; set; }
    }

}
