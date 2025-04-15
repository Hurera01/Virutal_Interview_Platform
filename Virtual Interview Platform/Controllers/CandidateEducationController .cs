using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Virtual_Interview_Platform.DTO.CandidateEducationDto;
using Virtual_Interview_Platform.Helper;
using Virtual_Interview_Platform.Model;
using Virtual_Interview_Platform.Services.Interface;

namespace Virtual_Interview_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateEducationController : ControllerBase
    {
        private readonly IGenericService<CandidateEducation> _genericService;
        private readonly IMapper _mapper;

        public CandidateEducationController(IGenericService<CandidateEducation> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateCandidateEducationDto>> Create([FromBody] CreateCandidateEducationDto dto)
        {
            try
            {
                var entity = _mapper.Map<CandidateEducation>(dto);
                var result = await _genericService.AddAsync(entity);
                if (!result.Success)
                    return Conflict(result.Message);

                var responseDto = _mapper.Map<CreateCandidateEducationDto>(result.Data);
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCandidateEducationDto>>> GetAll()
        {
            try
            {
                var result = await _genericService.GetAllAsync();
                if (!result.Success)
                    return NotFound(result.Message);

                var dto = _mapper.Map<IEnumerable<GetCandidateEducationDto>>(result.Data);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCandidateEducationDto>> Get(int id)
        {
            try
            {
                var result = await _genericService.GetByIdAsync(id);
                if (!result.Success)
                    return NotFound(result.Message);

                var dto = _mapper.Map<GetCandidateEducationDto>(result.Data);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCandidateEducationDto>> Update(int id, [FromBody] UpdateCandidateEducationDto dto)
        {
            try
            {
                var entity = _mapper.Map<CandidateEducation>(dto);
                var result = await _genericService.Update(id, entity);
                if (!result.Success)
                    return NotFound(result.Message);

                var updatedDto = _mapper.Map<UpdateCandidateEducationDto>(result.Data);
                return Ok(updatedDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _genericService.Delete(id);
                if (!result.Success)
                    return NotFound(result.Message);

                return Ok(result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }
    }
}
