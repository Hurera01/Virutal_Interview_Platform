using System.Linq.Expressions;

namespace Virtual_Interview_Platform.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);
    }
}
