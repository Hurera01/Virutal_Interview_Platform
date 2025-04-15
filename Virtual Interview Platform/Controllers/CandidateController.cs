using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Virtual_Interview_Platform.DTO.CandidateDto;
using Virtual_Interview_Platform.Helper;
using Virtual_Interview_Platform.Model;
using Virtual_Interview_Platform.Services.Interface;

namespace Virtual_Interview_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IGenericService<Candidate> _genericService;
        private readonly IMapper _mapper;

        public CandidateController(IGenericService<Candidate> genericService, IMapper mapper)
        {
            _genericService = genericService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CreateCandidateDto>> CreateCandidate([FromBody] CreateCandidateDto createCandidateDto)
        {
            try
            {
                var mappedEntity = _mapper.Map<Candidate>(createCandidateDto);
                var result = await _genericService.AddAsync(mappedEntity);
                if (!result.Success)
                {
                    return Conflict(result.Message);
                }
                var mappedDto = _mapper.Map<CreateCandidateDto>(result.Data);
                return Ok(mappedDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }

        [HttpGet("Candidates")]
        public async Task<ActionResult<IEnumerable<GetCandidateDto>>> GetCandidates()
        {
            try
            {
                var result = await _genericService.GetAllAsync();
                if (!result.Success)
                {
                    return NotFound(result.Message);
                }
                var mappedDto = _mapper.Map<IEnumerable<GetCandidateDto>>(result.Data);
                return Ok(mappedDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }

        [HttpGet]
        public async Task<ActionResult<GetCandidateDto>> GetCandidate(int id)
        {
            try
            {
                var result = await _genericService.GetByIdAsync(id);
                if (!result.Success)
                {
                    return NotFound(result.Message);
                }
                var mappedDto = _mapper.Map<GetCandidateDto>(result.Data);
                return Ok(mappedDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteCandidateDto>> DeleteCandidate(int id)
        {
            try
            {
                var result = await _genericService.Delete(id);
                if (!result.Success)
                {
                    return NotFound(result.Message);
                }
                return Ok(result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }

        [HttpPut]
        public async Task<ActionResult<UpdateCandidateDto>> UpdateCandidate(int id, UpdateCandidateDto updateCandidateDto)
        {
            try
            {
                var mapEntity = _mapper.Map<Candidate>(updateCandidateDto);
                var result = await _genericService.Update(id, mapEntity);
                if (!result.Success)
                {
                    return NotFound(result.Message);
                }

                var updateDto = _mapper.Map<UpdateCandidateDto>(result.Data);
                return Ok(result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
            }
        }
    }
}
