namespace BookManagement.Repositery
{
    public interface IGenericRepositery<T> 
    {
         int Add(T item);
         int Update(T item);
         int Remove(T item);
         T GetById(int id);
         IEnumerable<T> GetAll();

    }
}
