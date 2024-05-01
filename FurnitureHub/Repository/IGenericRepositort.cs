namespace FurnitureHub.Repository
{
    public interface IGenericRepositort<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetbyId(int id);
        int Add(T item);
        int Delete(T item);
        int Update(T item);



    }
}
