using System.Linq.Expressions;

namespace TaskManagerDemo.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? match = null);
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
