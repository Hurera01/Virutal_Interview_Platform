using Microsoft.AspNetCore.Mvc;

namespace Virtual_Interview_Platform.Controllers
{
    public interface IGenericController<T, TDto> where T : class where TDto : class
    {
        Task<ActionResult<IEnumerable<TDto>>> GetAllAsync();
        Task<ActionResult<TDto>> GetByIdAsync(int id);
        Task<ActionResult<TDto>> AddAsync([FromBody] T entity);
        Task<ActionResult<TDto>> Update(int id, [FromBody] T entity);
        Task<ActionResult<TDto>> Delete(int id);
    }
}
