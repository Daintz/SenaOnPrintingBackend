using AutoMapper;
using BusinessCape.DTOs.Machine;
using BusinessCape.DTOs.UnitMesureCreate;
using BusinessCape.Services;
using DataCape;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitMesureController : ControllerBase
    {
        private readonly UnitMesureServices _UnitServices;
        private readonly IMapper _mapper;

        public UnitMesureController(UnitMesureServices UnitServices, IMapper mapper)
        {
            _UnitServices = UnitServices;
            _mapper = mapper;
        }
        // GET: api/<MachineController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Unit = await _UnitServices.GetAllAsync();
            return Ok(Unit);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var Unit = await _UnitServices.GetByIdAsync(id);
            if (Unit == null)
            {
                return NotFound();
            }
            return Ok(Unit);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UnitMesureCreate UnitDto)
        {
            var UnitToCreate = _mapper.Map<UnitMeasureModel>(UnitDto);

            await _UnitServices.AddAsync(UnitToCreate);
            return Ok(UnitToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, MachineCreateDto UnitDto)
        {
            var UnitToCreate = await _UnitServices.GetByIdAsync(UnitDto.Id);
            _mapper.Map(UnitDto, UnitToCreate);
            await _UnitServices.UpdateAsync(UnitToCreate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _UnitServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
