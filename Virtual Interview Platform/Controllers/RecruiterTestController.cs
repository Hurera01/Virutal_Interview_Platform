using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Virtual_Interview_Platform.Model;
using Virtual_Interview_Platform.Services.Interface;

namespace Virtual_Interview_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterTestController : ControllerBase
    {
        private readonly IGenericService<Recruiter> _genericService;
        public RecruiterTestController(IGenericService<Recruiter> genericService)
        {
            this._genericService = genericService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecruiter()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await _genericService.GetAllAsync();
                return Ok(new { data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
