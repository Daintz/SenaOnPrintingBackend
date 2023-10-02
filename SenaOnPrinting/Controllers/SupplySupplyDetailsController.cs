using AutoMapper;
using BusinessCape.DTOs.SupplySupplyDetails;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplySupplyDetailsController : ControllerBase
    {
        private readonly SupplySupplyDetailsService _supplySupplyDetailsService;
        private readonly IMapper _mapper;

        public SupplySupplyDetailsController(SupplySupplyDetailsService supplySupplyDetailsService, IMapper mapper)
        {
            _supplySupplyDetailsService = supplySupplyDetailsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supplySupplyDetail = await _supplySupplyDetailsService.GetAllAsync();
            return Ok(supplySupplyDetail);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var supplySupplyDetail = await _supplySupplyDetailsService.GetByIdAsync(id);
            if (supplySupplyDetail == null)
            {
                return NotFound();
            }
            return Ok(supplySupplyDetail);
        }

      
        [HttpPost]
        public async Task<IActionResult> Add(SupplySupplyDetailsCreateDto supplySupplyDetailDto, long idDet)
        {
            var supplySupplyDetailToCreate = _mapper.Map<SupplySupplyDetailsModel>(supplySupplyDetailDto);

            // Aquí deberías configurar el ID usando el parámetro idDet
            supplySupplyDetailToCreate.supplydetails_id = idDet;

            await _supplySupplyDetailsService.AddAsync(supplySupplyDetailToCreate);
            return Ok(supplySupplyDetailToCreate);
        }

        //// PUT api/<QuotationClientDetail>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(long id, QuotationClientDetailUpdateDto quotationclientDetailUpdateDto)
        //{
        //    var quotationclientDetailToUpdate = await _supplySupplyDetailsService.GetByIdAsync(quotationclientDetailUpdateDto.Id);
        //    _mapper.Map(quotationclientDetailUpdateDto, quotationclientDetailToUpdate);
        //    await _supplySupplyDetailsService.UpdateAsync(quotationclientDetailToUpdate);
        //    return NoContent();
        //}

    }
}
