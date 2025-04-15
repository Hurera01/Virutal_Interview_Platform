using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Virtual_Interview_Platform.DTO.CandidateEducationDto;
using Virtual_Interview_Platform.DTO.CandidateExperienceDto;
using Virtual_Interview_Platform.Helper;
using Virtual_Interview_Platform.Model;
using Virtual_Interview_Platform.Services.Interface;

namespace Virtual_Interview_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateExperienceController: ControllerBase
    {
        private readonly IGenericService<CandidateExperience> _genericService;
        private readonly IMapper _mapper;

        public CandidateExperienceController(IGenericService<CandidateExperience> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateCandidateExperienceDto>> Create(CreateCandidateExperienceDto dto)
        {
            var entity = _mapper.Map<CandidateExperience>(dto);
            var result = await _genericService.AddAsync(entity);
            if (!result.Success) return Conflict(result.Message);

            var response = _mapper.Map<CreateCandidateExperienceDto>(result.Data);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCandidateExperienceDto>>> GetAll()
        {
            var result = await _genericService.GetAllAsync();
            if (!result.Success) return NotFound(result.Message);

            var response = _mapper.Map<IEnumerable<GetCandidateExperienceDto>>(result.Data);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCandidateExperienceDto>> GetById(int id)
        {
            var result = await _genericService.GetByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);

            var response = _mapper.Map<GetCandidateExperienceDto>(result.Data);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCandidateExperienceDto>> Update(int id, UpdateCandidateExperienceDto dto)
        {
            var entity = _mapper.Map<CandidateExperience>(dto);
            var result = await _genericService.Update(id, entity);
            if (!result.Success) return NotFound(result.Message);

            return Ok(_mapper.Map<UpdateCandidateExperienceDto>(result.Data));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _genericService.Delete(id);
            if (!result.Success) return NotFound(result.Message);

            return Ok(result.Message);
        }
    }
}
