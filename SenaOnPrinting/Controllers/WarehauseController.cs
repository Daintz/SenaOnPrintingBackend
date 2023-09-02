using AutoMapper;
using BusinessCape.DTOs.Warehause;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[AuthorizationFilter(ApplicationPermission.Warehouse)]
    public class WarehauseController : Controller
    {
        private readonly WarehauseService _warehauseService;
        private readonly IMapper _mapper;

        public WarehauseController(WarehauseService warehauseService, IMapper mapper)
        {
            _warehauseService = warehauseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var warehauseService = await _warehauseService.GetAllAsync();
            return Ok(warehauseService);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var warehauseService = await _warehauseService.GetByIdAsync(id);
            if (warehauseService == null)
            {
                return NotFound();
            }
            return Ok(warehauseService);
        }

        [HttpPost]
        public async Task<IActionResult> Add(WarehauseCreateDto WarehauseDto)
        {
            var warehauseToCreate = _mapper.Map<WarehouseModel>(WarehauseDto);

            await _warehauseService.AddAsync(warehauseToCreate);
            return Ok(warehauseToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, WarehauseUpdateDto WarehauseDto)
        {
            if (id != WarehauseDto.Id)
            {
                return BadRequest();
            }

            var warehauseType = await _warehauseService.GetByIdAsync(WarehauseDto.Id);

            //supplyToUpdate.Name = supplyCategoryDto.Name;
            //supplyToUpdate.Description = supplyCategoryDto.Description;
            _mapper.Map(WarehauseDto, warehauseType);

            await _warehauseService.UpdateAsync(warehauseType);
            return Ok(warehauseType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _warehauseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
