using AutoMapper;
using BusinessCape.DTOs.ImpositionPlanch;
using BusinessCape.DTOs.Supply;
using BusinessCape.DTOs.SupplyDetails;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [AuthorizationFilter(ApplicationPermission.Supply)]
    public class SupplyController : ControllerBase
    {
        private readonly SupplyService _supplyService;
        private readonly IMapper _mapper;

        public SupplyController(SupplyService supplyService, IMapper mapper)
        {
            _supplyService = supplyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supply = await _supplyService.GetAllAsync();
            return Ok(supply);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var supply = await _supplyService.GetByIdAsync(id);
            if (supply == null)
            {
                return NotFound();
            }
            return Ok(supply);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SupplyCreateDto supplyDto)
        {
            var supplyToCreate = _mapper.Map<SupplyModel>(supplyDto);

            await _supplyService.AddAsync(supplyToCreate);
            return Ok(supplyToCreate);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id, SupplyUpdateDto supplyDto)
        {
            if (id != supplyDto.Id)
            {
                return BadRequest();
            }

            var supplyToUpdate = await _supplyService.GetByIdAsync(supplyDto.Id);

            _mapper.Map(supplyDto, supplyToUpdate);

            await _supplyService.UpdateAsync(supplyToUpdate);
            return Ok(supplyToUpdate);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> ChangeState(long id)
        {
            await _supplyService.ChangeState(id);
            return NoContent();
        }

    }
}
