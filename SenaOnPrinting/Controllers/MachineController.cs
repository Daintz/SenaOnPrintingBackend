using AutoMapper;
using BusinessCape.DTOs.Machine;

using BusinessCape.Services;
using DataCape;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly MachineService _machineServices;
        private readonly IMapper _mapper;

        public MachineController(MachineService machineServices, IMapper mapper)
        {
            _machineServices = machineServices;
            _mapper = mapper;
        }
        // GET: api/<MachineController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var machine = await _machineServices.GetAllAsync();
            return Ok(machine);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var machine = await _machineServices.GetByIdAsync(id);
            if (machine == null)
            {
                return NotFound();
            }
            return Ok(machine);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MachineCreateDto machineDto)
        {
            var MachineToCreate = _mapper.Map<MachineModel>(machineDto);

            await _machineServices.AddAsync(MachineToCreate);
            return Ok(MachineToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, MachineCreateDto machineDto)
        {
            var MachineToCreate = await _machineServices.GetByIdAsync(machineDto.Id);
            _mapper.Map(machineDto, MachineToCreate);
            await _machineServices.UpdateAsync(MachineToCreate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _machineServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
