using AutoMapper;
using BusinessCape.DTOs.Product;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(ProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductCreateDto supplyCategoryDto)
        {
            var productToCreate = _mapper.Map<ProductModel>(supplyCategoryDto);

            await _productService.AddAsync(productToCreate);
            return Ok(productToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, ProductUpdateDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }

            var productToUpdate = await _productService.GetByIdAsync(productDto.Id);

            _mapper.Map(productDto, productToUpdate);

            await _productService.UpdateAsync(productToUpdate);
            return Ok(productToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
