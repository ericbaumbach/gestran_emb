using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Security.Principal;

namespace Gestran.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        ValueTask<T> First(int id);
        Task<T> Find(Expression<Func<T, bool>> expression);
        Task<List<T>> GetBy(Expression<Func<T, bool>> expression);
        Task<List<T>> All();
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);
        Task<bool> Any(Expression<Func<T, bool>> expression);
    }
}
