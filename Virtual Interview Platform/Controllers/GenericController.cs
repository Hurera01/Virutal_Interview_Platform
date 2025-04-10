//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Virtual_Interview_Platform.Helper;
//using Virtual_Interview_Platform.Services.Interface;

//namespace Virtual_Interview_Platform.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GenericController<T, TDto> : ControllerBase, IGenericController<T, TDto> where T: class where TDto : class
//    {
//        private readonly IGenericService<T> _genericService;
//        private readonly IMapper _mapper;

//        public GenericController(IGenericService<T> genericService, IMapper mapper)
//        {
//            _genericService = genericService;
//            _mapper = mapper;
//        }

//        [HttpPost]
//        public async Task<ActionResult<TDto>> AddAsync([FromBody] T entity)
//        {
//            try
//            {
//                var mapEntity = _mapper.Map<T>(entity);
//                var result = await _genericService.AddAsync(mapEntity);
//                if (!result.Success)
//                {
//                    return Conflict(result.Message);
//                }
//                var addDto = _mapper.Map<TDto>(entity);
//                return CreatedAtAction(nameof(GetByIdAsync), new { id = (result.Data as dynamic).Id }, addDto);
//            }
//            catch (Exception ex) 
//            {
//                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
//            }
            
//        }

//        [HttpDelete]
//        public async Task<ActionResult<TDto>> Delete(int id)
//        {
//            try
//            {
//                var result = await _genericService.Delete(id);
//                if (!result.Success)
//                {
//                    return NotFound(result.Message);
//                }
//                return Ok(result.Message);
//            }
//            catch (Exception ex) 
//            {
//                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
//            }
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<TDto>>> GetAllAsync()
//        {
//            try
//            {
//                var result = await _genericService.GetAllAsync();
//                if (!result.Success)
//                {
//                    return NotFound(result.Message);
//                }
//                var getDto = _mapper.Map<IEnumerable<TDto>>(result.Data);
//                return Ok(getDto);
//            }
//            catch (Exception ex) 
//            {
//                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
//            }
//        }

//        [HttpGet("getbyid")]
//        public async Task<ActionResult<TDto>> GetByIdAsync(int id)
//        {
//            try
//            {
//                var result = await _genericService.GetByIdAsync(id);
//                if (!result.Success)
//                {
//                    return NotFound(result.Message);
//                }
//                var getIdDto = _mapper.Map<TDto>(result.Data);
//                return Ok(getIdDto);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
//            }
//        }

//        [HttpPut]
//        public async Task<ActionResult<TDto>> Update(int id, [FromBody] T entity)
//        {
//            try
//            {
//                var mapEntity = _mapper.Map<T>(entity);
//                var result = await _genericService.Update(id, mapEntity);
//                if (!result.Success)
//                {
//                    return NotFound(result.Message);
//                }
//                var updateDto = _mapper.Map<TDto>(result.Data);
//                return Ok(updateDto);
//            }
//            catch (Exception ex) 
//            {
//                return StatusCode(500, MessageHelper.ErrorOccured(ex.Message));
//            }
//        }
//    }
//}
