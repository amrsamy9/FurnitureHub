using FurnitureHub.Models;

namespace FurnitureHub.Repository
{
    public class ProductRepository:IProductRepository
    {
        StoreContext context;

        public ProductRepository(StoreContext context)
        {
            this.context = context;

        }

        public List<Product> GetAll()
        {
            return context.products.ToList();
        }

        public Product GetById(int id)
        {
            return context.products.FirstOrDefault(x => x.ID == id);
        }



        public List<Product> SearchByName(string name)
        {
            return context.products.Where(i => i.Name.Contains(name)).ToList();
        }

        public void Insert(Product Obj)
        {
            context.Add(Obj);
        }

        public void Update(Product Obj)
        {
            context.Update(Obj);
        }
        public void Delete(int id)
        {
            Product delobj = GetById(id);
            context.Remove(delobj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}

