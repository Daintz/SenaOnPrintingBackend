using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplyController : ControllerBase
    {
        private readonly SupplyService _supplyCategoryService;

        public SupplyController(SupplyService supplyCategoryService)
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
        public async Task<IActionResult> Add(SupplyModel supplyCategory)
        {
            await _supplyCategoryService.AddAsync(supplyCategory);
            return Ok(supplyCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, SupplyModel supplyCategory)
        {
            await _supplyCategoryService.UpdateAsync(supplyCategory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _supplyCategoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
