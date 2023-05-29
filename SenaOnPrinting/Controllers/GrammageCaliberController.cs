using AutoMapper;
using BusinessCape.DTOs.Client;
using BusinessCape.DTOs.GrammageCaliber;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrammageCaliberController : ControllerBase
    {
        private readonly GrammageCaliberService _grammageCaliberService;
        private readonly IMapper _mapper;

        public GrammageCaliberController(GrammageCaliberService grammageCaliberService, IMapper mapper)
        {
            _grammageCaliberService = grammageCaliberService;
            _mapper = mapper;
        }
        // GET: api/<grammageCaliberController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var grammageCaliber = await _grammageCaliberService.GetAllAsync();
            return Ok(grammageCaliber);
        }

        // GET api/<grammageCaliberController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var grammageCaliber = await _grammageCaliberService.GetByIdAsync(id);
            if (grammageCaliber == null)
            {
                return NotFound();
            }
            return Ok(grammageCaliber);
        }

        // POST api/<grammageCaliberController>
        [HttpPost]
        public async Task<IActionResult> Add(GrammageCaliberCreateDto grammageCaliberDto)
        {
            var grammageCaliberToCreate = _mapper.Map<GrammageCaliberModel>(grammageCaliberDto);

            await _grammageCaliberService.AddAsync(grammageCaliberToCreate);
            return Ok(grammageCaliberToCreate);
        }

        // PUT api/<grammageCaliberController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, GrammageCaliberUpdateDto grammageCaliberDto)
        {
            var grammageCaliberToUpdate = await _grammageCaliberService.GetByIdAsync(grammageCaliberDto.Id);
            _mapper.Map(grammageCaliberDto, grammageCaliberToUpdate);
            await _grammageCaliberService.UpdateAsync(grammageCaliberToUpdate);
            return NoContent();
        }

        // DELETE api/<grammageCaliberController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _grammageCaliberService.DeleteAsync(id);
            return NoContent();
        }
    }
}
