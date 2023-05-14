using BusinessCape.DTOs.SupplyCategory;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplyCategoryController : ControllerBase
    {
        private readonly SupplyCategoryService _supplyCategoryService;

        public SupplyCategoryController(SupplyCategoryService supplyCategoryService)
        {
            _supplyCategoryService = supplyCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supplyCategories = await _supplyCategoryService.GetAllAsync();
            return Ok(supplyCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var supplyCategory = await _supplyCategoryService.GetByIdAsync(id);
            if (supplyCategory == null)
            {
                return NotFound();
            }
            return Ok(supplyCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SupplyCategoryCreateDto supplyCategoryDto)
        {
            var supplyToCreate = new SupplyCategoryModel();
            supplyToCreate.Name = supplyCategoryDto.Name;
            supplyToCreate.Description = supplyCategoryDto.Description;
            supplyToCreate.StatedAt = true;
            await _supplyCategoryService.AddAsync(supplyToCreate);
            return Ok(supplyToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, SupplyCategoryUpdateDto supplyCategoryDto)
        {
            if (id != supplyCategoryDto.IdSupplyCategory)
            {
                return BadRequest();
            }

            var supplyToUpdate = await _supplyCategoryService.GetByIdAsync(supplyCategoryDto.IdSupplyCategory);

            supplyToUpdate.Name = supplyCategoryDto.Name;
            supplyToUpdate.Description = supplyCategoryDto.Description;

            await _supplyCategoryService.UpdateAsync(supplyToUpdate);
            return Ok(supplyToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _supplyCategoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
