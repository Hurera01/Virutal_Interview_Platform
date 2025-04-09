namespace Virtual_Interview_Platform.Helper
{
    public class AsyncOperationHandler
    {
        public async Task<ApiResponse<TResult>> ExecuteAsync<TResult>(Func<Task<TResult>> action, string successMessage = null)
        {
            try
            {
                var result = await action();
                return new ApiResponse<TResult>
                {
                    Success = true,
                    Message = successMessage ?? MessageHelper.Success(typeof(TResult).Name, "retrieved"),
                    Data = result
                };
            }
            catch (KeyNotFoundException knfEx)
            {
                return new ApiResponse<TResult>
                {
                    Success = false,
                    Message = knfEx.Message
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<TResult>
                {
                    Success = false,
                    Message = MessageHelper.Exception(typeof(TResult).Name, "operation", ex.Message)
                };
            }
        }
    }
}
