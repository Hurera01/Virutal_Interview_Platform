using Virtual_Interview_Platform.Helper;
using Virtual_Interview_Platform.Repository.Interface;
using Virtual_Interview_Platform.Services.Interface;

namespace Virtual_Interview_Platform.Services.Implementation
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;
        protected readonly AsyncOperationHandler _operationHandler;

        public GenericService(IGenericRepository<T> repository)
        {
            this._repository = repository;
            this._operationHandler = new AsyncOperationHandler();
        }

        public Task<ApiResponse<T>> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<T>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<IEnumerable<T>>> GetAllAsync()
        {
            return await _operationHandler.ExecuteAsync(async () =>
            {
                var result = await _repository.GetAllAsync();
                return result ?? Enumerable.Empty<T>();
            }, $"{typeof(T).Name} Fetched successfully.");
        }

        public Task<ApiResponse<T>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<T>> Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
