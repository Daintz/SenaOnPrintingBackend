using AutoMapper;
using BusinessCape.DTOs.QuotationClient;
using BusinessCape.DTOs.QuotationClientDetail;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationClientDetailController : ControllerBase
    {
        private readonly QuotationClientDetailService _quotationclientDetailService;
        private readonly IMapper _mapper;

        public QuotationClientDetailController(QuotationClientDetailService quotationclientDetailService, IMapper mapper)
        {
            _quotationclientDetailService = quotationclientDetailService;
            _mapper = mapper;
        }
        // GET: api/<QuotationClientDetail>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quotationclientDetail = await _quotationclientDetailService.GetAllAsync();
            return Ok(quotationclientDetail);
        }
        //[HttpGet("Approved")]

        //public async Task<IActionResult> GetAllApproved()
        //{
        //    var quotationclientDetail = await _quotationclientDetailService.GetApprovedQuotationAsync();
        //    return Ok(quotationclientDetail);
        //}
        // GET api/<QuotationClientDetail>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var quotationclientDetail = await _quotationclientDetailService.GetByIdAsync(id);
            if (quotationclientDetail == null)
            {
                return NotFound();
            }
            return Ok(quotationclientDetail);
        }

        // POST api/<QuotationClientDetail>
        [HttpPost]
        public async Task<IActionResult> Add(QuotationClientDetailCreateDto quotationclientDetailDto, long idCot)
        {
            var quotationclientDetailToCreate = _mapper.Map<QuotationClientDetailModel>(quotationclientDetailDto);

            // Aquí deberías configurar el ID usando el parámetro idCot
            quotationclientDetailToCreate.QuotationClientId = idCot;

            await _quotationclientDetailService.AddAsync(quotationclientDetailToCreate);
            return Ok(quotationclientDetailToCreate);
        }

        // PUT api/<QuotationClientDetail>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, QuotationClientDetailUpdateDto quotationclientDetailUpdateDto)
        {
            var quotationclientDetailToUpdate = await _quotationclientDetailService.GetByIdAsync(quotationclientDetailUpdateDto.Id);
            _mapper.Map(quotationclientDetailUpdateDto, quotationclientDetailToUpdate);
            await _quotationclientDetailService.UpdateAsync(quotationclientDetailToUpdate);
            return NoContent();
        }

        // DELETE api/<QuotationClientDetail>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _quotationclientDetailService.DeleteAsync(id);
            return NoContent();
        }
    }
}
