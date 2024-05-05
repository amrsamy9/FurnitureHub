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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            List<ProductCategory> categories = new List<ProductCategory>()
            {
                new ProductCategory(){Id=1, Name="Chairs" ,Image="about.jpg"},
            new ProductCategory() { Id = 2, Name = "Sofas", Image = "bed2.jpeg" },
            new ProductCategory() { Id = 3, Name = "Tables", Image = "bed3.jpg" }
            };

            modelBuilder.Entity<ProductCategory>().HasData(categories);
        }





    }
}
