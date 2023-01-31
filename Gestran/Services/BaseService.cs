using Gestran.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Gestran.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        public readonly GestranDbContext _gestranDbContext;

        public BaseService(GestranDbContext gestranDbContext)
        {
            _gestranDbContext = gestranDbContext;
        }

        public Task Add(T item)
        {
            _gestranDbContext.Add<T>(item);

            return _gestranDbContext.SaveChanges();
        }

        public Task<List<T>> All()
        {
            return _gestranDbContext.Set<T>().ToListAsync();
        }

        public Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return _gestranDbContext.Set<T>().AnyAsync(expression);
        }

        public Task Delete(T item)
        {
            _gestranDbContext.Set<T>().Remove(item);

            return _gestranDbContext.SaveChangesAsync();
        }

        public Task<T> Find(Expression<Func<T, bool>> expression)
        {
            return _gestranDbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public ValueTask<T> First(int id)
        {
            return _gestranDbContext.Set<T>().FindAsync(id);
        }

        public Task<List<T>> GetBy(Expression<Func<T, bool>> expression)
        {
            return _gestranDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public Task Update(T item)
        {
            _gestranDbContext.Entry<T>(item).State = EntityState.Modified;

            return _gestranDbContext.SaveChangesAsync();
        }
    }
}