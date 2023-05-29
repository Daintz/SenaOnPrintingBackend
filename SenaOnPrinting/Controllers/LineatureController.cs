using AutoMapper;
using BusinessCape.DTOs.Lineature;
using BusinessCape.DTOs.OrderProduction;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineatureController : ControllerBase

    {
        private readonly LineatureService _lineatureService;
        private readonly IMapper _mapper;

        public LineatureController(LineatureService lineaturaService, IMapper mapper)
        {
            _lineatureService = lineaturaService;
            _mapper = mapper;
        }
        // GET: api/<LineatureController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lineature = await _lineatureService.GetAllAsync();
            return Ok(lineature);
        }

        // GET api/<LineatureController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var lineature = await _lineatureService.GetByIdAsync(id);
            if (lineature == null)
            {
                return NotFound();
            }
            return Ok(lineature);
        }

        // POST api/<LineatureController>
        [HttpPost]
        public async Task<IActionResult> Add(LineatureCreateDto lineatureDto)
        {
            var lineatureToCreate = _mapper.Map<LineatureModel>(lineatureDto);

            await _lineatureService.AddAsync(lineatureToCreate);
            return Ok(lineatureToCreate);
        }

        // PUT api/<LineatureController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, LineatureUpdateDto lineatureDto)
        {
            if (id != lineatureDto.IdLineature)
            {
                return BadRequest();
            }

            var lineatureToUpdate = await _lineatureService.GetByIdAsync(lineatureDto.IdLineature);

            _mapper.Map(lineatureDto, lineatureToUpdate);

            await _lineatureService.UpdateAsync(lineatureToUpdate);
            return Ok(lineatureToUpdate);
        }


        // DELETE api/<LineatureController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> ChangeState(long id)
        {
            await _lineatureService.ChangeState(id);
            return NoContent();
        }
    }
}
