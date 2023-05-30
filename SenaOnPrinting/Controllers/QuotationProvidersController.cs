using AutoMapper;
using BusinessCape.DTOs.QuotationProviders;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationProvidersController : ControllerBase
    {
        private readonly QuotationProvidersServices _quotation_providersServices;
        private readonly IMapper _mapper;

        public QuotationProvidersController(QuotationProvidersServices quotation_providersServices, IMapper mapper)
        {
            _quotation_providersServices = quotation_providersServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quotation_providersCategories = await _quotation_providersServices.GetAllAsync();
            return Ok(quotation_providersCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var quotation_providersCategory = await _quotation_providersServices.GetByIdAsync(id);
            if (quotation_providersCategory == null)
            {
                return NotFound();
            }
            return Ok(quotation_providersCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Add(QuotationProvidersCreateDto quotationProviderDto)
        {
            var QuotationProvidersToCreate = _mapper.Map<QuotationProviderModel>(quotationProviderDto);

            await _quotation_providersServices.AddAsync(QuotationProvidersToCreate);
            return Ok(QuotationProvidersToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, QuotationProvidersUpdateDto quotationProviderDto)
        {
            var quotationProvidersToUpdate = await _quotation_providersServices.GetByIdAsync(quotationProviderDto.Id); 
            _mapper.Map(quotationProviderDto, quotationProvidersToUpdate);
            await _quotation_providersServices.UpdateAsync(quotationProvidersToUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _quotation_providersServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
