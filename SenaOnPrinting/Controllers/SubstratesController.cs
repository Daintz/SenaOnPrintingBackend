using AutoMapper;
using BusinessCape.DTOs.Substrate;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubstratesController : ControllerBase
    {
        private readonly SubstrateService _substrateService;
        private readonly IMapper _mapper;

        public SubstratesController(SubstrateService substrateService, IMapper mapper)
        {
            _substrateService = substrateService;
            _mapper = mapper;
        }
        // GET: api/<substrateController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var substrate = await _substrateService.GetAllAsync();
            return Ok(substrate);
        }

        // GET api/<substrateController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var substrate = await _substrateService.GetByIdAsync(id);
            if (substrate == null)
            {
                return NotFound();
            }
            return Ok(substrate);
        }

        // POST api/<substrateController>
        [HttpPost]
        public async Task<IActionResult> Add(SubstrateCreateDto substrateDto)
        {
            var substrateToCreate = _mapper.Map<SubstrateModel>(substrateDto);

            await _substrateService.AddAsync(substrateToCreate);
            return Ok(substrateToCreate);
        }

        // PUT api/<substrateController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, SubstrateUpdateDto substrateDto)
        {
            var substrateToUpdate = await _substrateService.GetByIdAsync(substrateDto.Id);
            _mapper.Map(substrateDto, substrateToUpdate);
            await _substrateService.UpdateAsync(substrateToUpdate);
            return NoContent();
        }

        // DELETE api/<substrateController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _substrateService.DeleteAsync(id);
            return NoContent();
        }
    }
}
