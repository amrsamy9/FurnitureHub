using FurnitureHub.Models;

namespace FurnitureHub.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int id);
        List<Product> SearchByName(string name);
        void Insert(Product Obj);
        void Update(Product Obj);
        void Delete(int id);
        void Save();
    }
}
