using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagerDemo.Data;
using TaskManagerDemo.Repository;

namespace ToDoList.Web.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetById(int id)
            => _dbContext.Set<T>().Find(id);

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? match = null)
            => match is null? _dbContext.Set<T>() : _dbContext.Set<T>().Where(match);

    }
}
