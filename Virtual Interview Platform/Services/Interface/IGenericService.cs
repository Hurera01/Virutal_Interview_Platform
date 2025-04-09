using Virtual_Interview_Platform.Helper;

namespace Virtual_Interview_Platform.Services.Interface
{
    public interface IGenericService<T> where T : class
    {
        Task<ApiResponse<T>> GetByIdAsync(int id);
        Task<ApiResponse<IEnumerable<T>>> GetAllAsync();
        Task<ApiResponse<T>> AddAsync(T entity);
        Task<ApiResponse<T>> Update(int id, T entity);
        Task<ApiResponse<T>> Delete(int id);
    }
}
