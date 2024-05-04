using FurnitureHub.Models;

namespace FurnitureHub.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        StoreContext context;

        public ProductCategoryRepository(StoreContext context)
        {
            this.context = context;
            
        }

        public List<ProductCategory> GetAll()
        {
            return context.productCategories.ToList();
        }

        public ProductCategory GetById(int id)
        {
            return context.productCategories.FirstOrDefault(x => x.Id == id);
        }

       

        public List<ProductCategory> SearchByName(string name)
        {
            return context.productCategories.Where(i => i.Name.Contains(name)).ToList();
        }

        public void Insert(ProductCategory Obj)
        {
            context.Add(Obj);
        }

        public void Update(ProductCategory Obj)
        {
            context.Update(Obj);
        }
        public void Delete(int id)
        {
            ProductCategory delobj = GetById(id);
            context.Remove(delobj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
