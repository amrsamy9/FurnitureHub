using FurnitureHub.Models;

namespace FurnitureHub.Repository
{
    public class GenericRepository<T> :IGenericRepositort<T> where T : class
    {
        private readonly StoreContext _storeContext;

        public GenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public IEnumerable<T> GetAll() 
        {
            return _storeContext.Set<T>().ToList();
        }

        public T GetbyId(int id) 
        {
            return _storeContext.Set<T>().Find(id);
        }


        public int Add(T item) 
        {
            _storeContext.Set<T>().Add(item);
            return _storeContext.SaveChanges();

        }

        public int Delete(T item)
        {
            _storeContext?.Set<T>().Remove(item);
            return _storeContext.SaveChanges();
        }

        public int Update(T item)
        {
            _storeContext.Set<T>().Update(item);
            return _storeContext.SaveChanges();
        }
    }
}
