using AutoMapper;
using BusinessCape.DTOs.Provider;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[AuthorizationFilter(ApplicationPermission.Provider)]
    public class ProviderController : ControllerBase
    {

        private readonly ProviderService _providerService;
        private readonly IMapper _mapper;
        public ProviderController(ProviderService Provider, IMapper mapper)
        {
            _providerService = Provider;
            _mapper = mapper;
        }

        // GET: api/<ProviderController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var provider = await _providerService.GetAllAsync();
            return Ok(provider);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var provider = await _providerService.GetByIdAsync(id);
            if (provider == null)
            {
                return NotFound();
            }
            return Ok(provider);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProviderCreateDto providerCreateDto)
        {
            //var supplyToCreate = new SupplyCategoryModel();
            //supplyToCreate.Name = supplyCategoryDto.Name;
            //supplyToCreate.Description = supplyCategoryDto.Description;
            //supplyToCreate.StatedAt = true;
            var ProviderCreate = _mapper.Map<ProviderModel>(providerCreateDto);

            await _providerService.AddAsync(ProviderCreate);
            return Ok(ProviderCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, ProviderUpdateDto providerUpdateDto)
        {
            if (id != providerUpdateDto.Id)
            {
                return BadRequest();
            }

            var provider = await _providerService.GetByIdAsync(providerUpdateDto.Id);

            //supplyToUpdate.Name = supplyCategoryDto.Name;
            //supplyToUpdate.Description = supplyCategoryDto.Description;
            _mapper.Map(providerUpdateDto,provider);

            await _providerService.UpdateAsync(provider);
            return Ok(provider);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _providerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
