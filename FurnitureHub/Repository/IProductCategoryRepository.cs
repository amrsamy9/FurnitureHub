using FurnitureHub.Models;

namespace FurnitureHub.Repository
{
    public interface IProductCategoryRepository
    {
        List<ProductCategory> GetAll();
        ProductCategory GetById(int id);
        List<ProductCategory> SearchByName(string name);
        void Insert(ProductCategory Obj);
        void Update(ProductCategory Obj);
        void Delete(int id);
        void Save();
    }
}
