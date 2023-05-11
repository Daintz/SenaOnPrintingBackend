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
        public async Task<IActionResult> GetById(long id)
        {
            var supplyCategory = await _supplyCategoryService.GetByIdAsync(id);
            if (supplyCategory == null)
            {
                return NotFound();
            }
            return Ok(supplyCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SupplyCategoryModel supplyCategory)
        {
            await _supplyCategoryService.AddAsync(supplyCategory);
            return Ok(supplyCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, SupplyCategoryModel supplyCategory)
        {
            if (id != supplyCategory.IdSupplyCategory)
            {
                return BadRequest();
            }
            await _supplyCategoryService.UpdateAsync(supplyCategory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _supplyCategoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
