using Microsoft.EntityFrameworkCore;

namespace FurnitureHub.Models
{
    public class StoreContext :DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Review> reviews { get; set; }


        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            
        }


        public StoreContext()
        {
                
        }





    }
}
