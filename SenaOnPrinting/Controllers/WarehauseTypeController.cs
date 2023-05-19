using AutoMapper;
using BusinessCape.DTOs.Provider;
using BusinessCape.DTOs.Supply;
using BusinessCape.DTOs.WarehauseType;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehauseTypeController : ControllerBase
    {
        private readonly WarehauseTypeService _warehauseTypeService;
        private readonly IMapper _mapper;

        public WarehauseTypeController(WarehauseTypeService warehauseTypeService, IMapper mapper)
        {
            _warehauseTypeService = warehauseTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var warehauseTypeService = await _warehauseTypeService.GetAllAsync();
            return Ok(warehauseTypeService);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var warehauseTypeService = await _warehauseTypeService.GetByIdAsync(id);
            if (warehauseTypeService == null)
            {
                return NotFound();
            }
            return Ok(warehauseTypeService);
        }

        [HttpPost]
        public async Task<IActionResult> Add(WarehauseTypeCreateDto WarehauseTypeDto)
        {
            var warehauseToCreate = _mapper.Map<WarehouseTypeModel>(WarehauseTypeDto);

            await _warehauseTypeService.AddAsync(warehauseToCreate);
            return Ok(warehauseToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, WarehauseTypeUpdateDto WarehauseTypeDto)
        {
            if (id != WarehauseTypeDto.IdTypeWarehouse)
            {
                return BadRequest();
            }

            var warehauseType = await _warehauseTypeService.GetByIdAsync(WarehauseTypeDto.IdTypeWarehouse);

            //supplyToUpdate.Name = supplyCategoryDto.Name;
            //supplyToUpdate.Description = supplyCategoryDto.Description;
            _mapper.Map(WarehauseTypeDto, warehauseType);

            await _warehauseTypeService.UpdateAsync(warehauseType);
            return Ok(warehauseType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _warehauseTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
