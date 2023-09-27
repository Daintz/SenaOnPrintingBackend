using AutoMapper;
using BusinessCape.DTOs.Product;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;
using Microsoft.EntityFrameworkCore;

namespace SenaOnPrinting.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    //[AuthorizationFilter(ApplicationPermission.Configuration)]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly IMapper _mapper;
        private readonly SENAONPRINTINGContext _context;

        public ProductController(ProductService productService, IMapper mapper, SENAONPRINTINGContext context)
        {
            _productService = productService;
            _mapper = mapper;
            _context = context;
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

            foreach (var supplyIds in supplyCategoryDto.SupplyIds)
            {
                var permission = await _context.Supplies.FindAsync(supplyIds);
                if (permission == null)
                {
                    return BadRequest("Uno de los Ids rol no existe, por favor rectifique");
                }

                var SupplyXProduct = new SupplyXProductModel
                {
                    SupplyId = permission.Id,
                    ProductId = productToCreate.Id
                };

                _context.SupplyXProducts.Add(SupplyXProduct);
            }

            _context.SaveChanges();
           
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

            _context.SupplyXProducts.RemoveRange(_context.SupplyXProducts.Where(d => d.ProductId == productToUpdate.Id));

            await _context.SaveChangesAsync();

            foreach (var supplyIds in productDto.SupplyIds)
            {
                var supplies = await _context.Supplies.FindAsync(supplyIds);
                if (supplies == null)
                {
                    return BadRequest("Uno de los Ids insumos no existe, por favor rectifique");
                }

                var SupplyXProduct = new SupplyXProductModel
                {
                    SupplyId = supplies.Id,
                    ProductId = productToUpdate.Id
                };

                _context.SupplyXProducts.Add(SupplyXProduct);
            }

            await _context.SaveChangesAsync();

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
