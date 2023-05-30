using AutoMapper;
using BusinessCape.DTOs.Client;
using BusinessCape.DTOs.SupplyPictograms;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyPictogrmasController : ControllerBase
    {
        private readonly SupplyPictogramsServices _SupplyPictogramsServices;
        private readonly IMapper _mapper;

        public SupplyPictogrmasController(SupplyPictogramsServices SupplyPictogramsServices, IMapper mapper)
        {
            _SupplyPictogramsServices = SupplyPictogramsServices;
            _mapper = mapper;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supplyPictograms = await _SupplyPictogramsServices.GetAllAsync();
            return Ok(supplyPictograms);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var supplyPictograms = await _SupplyPictogramsServices.GetByIdAsync(id);
            if (supplyPictograms == null)
            {
                return NotFound();
            }
            return Ok(supplyPictograms);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<IActionResult> Add(SupplyPictogramsCreateDto SupplypictogramDto)
        {
            var supplyPictogramCreate = _mapper.Map<SupplyPictogramModel>(SupplypictogramDto);

            await _SupplyPictogramsServices.AddAsync(supplyPictogramCreate);
            return Ok(supplyPictogramCreate);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, SupplyPictogramsUpdateDto SupplyPictogramDto)
        {
            var SupplyPictogramUpdate = await _SupplyPictogramsServices.GetByIdAsync(SupplyPictogramDto.Id);
            _mapper.Map(SupplyPictogramDto, SupplyPictogramUpdate);
            await _SupplyPictogramsServices.UpdateAsync(SupplyPictogramUpdate);
            return NoContent();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _SupplyPictogramsServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
