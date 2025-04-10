using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Virtual_Interview_Platform.DTO.RecruiterDto;
using Virtual_Interview_Platform.Helper;
using Virtual_Interview_Platform.Model;
using Virtual_Interview_Platform.Services.Interface;

namespace Virtual_Interview_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IGenericService<Recruiter> _genericService;
        private readonly IMapper _mapper;

        public RecruiterController(IGenericService<Recruiter> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateRecruiterDto>> CreateRecruiter([FromBody] CreateRecruiterDto createRecruiterDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<Recruiter>(createRecruiterDto);
                var result = await _genericService.AddAsync(mappedEntity);
                if (!result.Success)
                {
                    return Conflict(result.Message);
                }
                var mappedDto = _mapper.Map<CreateRecruiterDto>(result.Data);
                return Ok(mappedDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }

        [HttpGet("Recruiters")]
        public async Task<ActionResult<IEnumerable<GetRecruitersDto>>> GetRecruiters()
        {
            try
            {
                var result = await _genericService.GetAllAsync();
                if (!result.Success)
                {
                    return NotFound(result.Message);
                }
                var mappedDto = _mapper.Map<IEnumerable<GetRecruitersDto>>(result.Data);
                return Ok(mappedDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult<GetRecruitersDto>> GetRecruiter(int id)
        {
            try
            {
                var result = await _genericService.GetByIdAsync(id);
                if (!result.Success)
                {
                    return NotFound(result.Message);
                }
                var mappedDto = _mapper.Map<GetRecruitersDto>(result.Data);
                return Ok(mappedDto);
            }
            catch(Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }


    }

}
