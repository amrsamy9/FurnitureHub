﻿namespace FurnitureHub.Models
{
    public class Employee
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
