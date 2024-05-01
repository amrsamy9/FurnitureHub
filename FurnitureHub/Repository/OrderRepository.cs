using FurnitureHub.Models;

namespace FurnitureHub.Repository
{
    public class OrderRepository : GenericRepository<Order> , IOrderRepository
    {
        public OrderRepository(StoreContext context) : base(context) 
        {
            
        }
    }
}
