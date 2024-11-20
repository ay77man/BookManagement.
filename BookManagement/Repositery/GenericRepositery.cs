
using BookManagement.Models;

namespace BookManagement.Repositery
{
    public class GenericRepositery<T> : IGenericRepositery<T> where T : class
    {
        protected readonly BookManagementDbContext _Context;
        public GenericRepositery(BookManagementDbContext Context) {
        
            _Context = Context;
        }
        public int Add(T item)
        {
           _Context.Add(item);
            return _Context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
           return  _Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _Context.Find<T>(id);
        }

        public int Remove(T item)
        {
            _Context.Remove(item);
            return _Context.SaveChanges();
        }

        public int Update(T item)
        {
           _Context.Update(item);
            return (_Context.SaveChanges());
        }

        
    }
}
