using AutoMapper;
using BusinessCape.DTOs.ImpositionPlate;
using BusinessCape.DTOs.Lineature;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpositionPlateController : ControllerBase
    {
        private readonly ImpositionPlateService _impositionPlateService;
        private readonly IMapper _mapper;

        public ImpositionPlateController(ImpositionPlateService impositionPlateService, IMapper mapper)
        {
            _impositionPlateService = impositionPlateService;
            _mapper = mapper;
        }
        // GET: api/<LineatureController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var impositionPlate = await _impositionPlateService.GetAllAsync();
            return Ok(impositionPlate);
        }

        // GET api/<LineatureController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var impositionPlate = await _impositionPlateService.GetByIdAsync(id);
            if (impositionPlate == null)
            {
                return NotFound();
            }
            return Ok(impositionPlate);
        }

        // POST api/<LineatureController>
        [HttpPost]
        public async Task<IActionResult> Add(ImpositionPlateCreateDto impositionPlateDto)
        {
            var impositionPlateToCreate = _mapper.Map<ImpositionPlateModel>(impositionPlateDto);

            await _impositionPlateService.AddAsync(impositionPlateToCreate);
            return Ok(impositionPlateToCreate);
        }

        // PUT api/<LineatureController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, ImpositionPlateUpdateDto impositionPlateDto)
        {
            if (id != impositionPlateDto.IdImpositionPlate)
            {
                return BadRequest();
            }

            var impositionPlateToUpdate = await _impositionPlateService.GetByIdAsync(impositionPlateDto.IdImpositionPlate);

            _mapper.Map(impositionPlateDto, impositionPlateToUpdate);

            await _impositionPlateService.UpdateAsync(impositionPlateToUpdate);
            return Ok(impositionPlateToUpdate);
        }


        // DELETE api/<LineatureController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> ChangeState(long id)
        {
            await _impositionPlateService.ChangeState(id);
            return NoContent();
        }
    }
}
