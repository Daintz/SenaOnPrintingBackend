using AutoMapper;
using BusinessCape.DTOs.QuotationClient;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?Linkid=397860

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationClientController : ControllerBase
    {
        private readonly QuotationClientService _quotationclientservice;
        private readonly IMapper _mapper;

        public QuotationClientController(QuotationClientService quotationclientservice, IMapper mapper)
        {
            _quotationclientservice = quotationclientservice;
            _mapper = mapper;
        }
        // GET: api/<QuotationClientController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quotationclientservices = await _quotationclientservice.GetAllAsync();
            return Ok(quotationclientservices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByid(long id)
        {
            var quotationclientservices = await _quotationclientservice.GetByIdAsync(id);
            if (quotationclientservices == null)
            {
                return NotFound();
            }
            return Ok(quotationclientservices);
        }

        [HttpPost]
        public async Task<IActionResult> Add(QuotationCreateDto quotationCreateDto)
        {
            var quotationclientToCreate = _mapper.Map<QuotationClientModel>(quotationCreateDto);
           
            await _quotationclientservice.AddAsync(quotationclientToCreate);
            return Ok(quotationclientToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, QuotationUpdateDto quotationUpdateDto)
        {
            var quotationclientToUpdate = await _quotationclientservice.GetByIdAsync(quotationUpdateDto.IdQuotationClient);
            _mapper.Map(quotationUpdateDto, quotationclientToUpdate);
            await _quotationclientservice.UpdateAsync(quotationclientToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _quotationclientservice.DeleteAsync(id);
            return NoContent();
        }
    }
}
