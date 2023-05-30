using AutoMapper;
using BusinessCape.DTOs.SupplyDetails;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplyDetailsController : ControllerBase
    {
        private readonly SupplyDetailsService _supplyDetailService;
        private readonly IMapper _mapper;

        public SupplyDetailsController(SupplyDetailsService supplyDetailService, IMapper mapper)
        {
            _supplyDetailService = supplyDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supplyDetails = await _supplyDetailService.GetAllAsync();
            return Ok(supplyDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var supplyDetail = await _supplyDetailService.GetByIdAsync(id);
            if (supplyDetail == null)
            {
                return NotFound();
            }
            return Ok(supplyDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SupplyDetailsCreateDto supplyDetailDto)
        {
            
            var supplyDetailToCreate = _mapper.Map<SupplyDetailModel>(supplyDetailDto);

            await _supplyDetailService.AddAsync(supplyDetailToCreate);
            return Ok(supplyDetailToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, SupplyDetailsUpdateDto supplyDetailDto)
        {
            if (id != supplyDetailDto.Id)
            {
                return BadRequest();
            }

            var supplyDetailToUpdate = await _supplyDetailService.GetByIdAsync(supplyDetailDto.Id);

            _mapper.Map(supplyDetailDto, supplyDetailToUpdate);

            await _supplyDetailService.UpdateAsync(supplyDetailToUpdate);
            return Ok(supplyDetailToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ChangeState(long id)
        {
            await _supplyDetailService.ChangeState(id);
            return NoContent();
        }

    }
}
