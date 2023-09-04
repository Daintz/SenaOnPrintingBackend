using AutoMapper;
using BusinessCape.DTOs.PaperCut;
using BusinessCape.DTOs.QuotationClient;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[AuthorizationFilter(ApplicationPermission.Client)]
    public class QuotationClientController : ControllerBase
    {
        private readonly QuotationClientService _quotationClientService;
        private readonly QuotationClientDetailService _quotationClientDetailService;

        private readonly IMapper _mapper;

        public QuotationClientController(QuotationClientService quotationClientService, IMapper mapper, QuotationClientDetailService quotationClientDetailService)
        {
            _quotationClientService = quotationClientService;
            _mapper = mapper;
            _quotationClientDetailService = quotationClientDetailService;


        }
        // GET: api/<QuotationClient>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quotationClient = await _quotationClientService.GetAllAsync();
            return Ok(quotationClient);
        }

        // GET api/<QuotationClient>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var quotationClient = await _quotationClientService.GetByIdAsync(id);
            if (quotationClient == null)
            {
                return NotFound();
            }
            return Ok(quotationClient);
        }
        [HttpGet("Approved")]

        public async Task<IActionResult> GetAllApproved()
        {
            var quotationclientDetail = await _quotationClientService.GetApprovedQuotationAsync();
            return Ok(quotationclientDetail);
        }
        // POST api/<QuotationClient>
        [HttpPost]
        public async Task<IActionResult> Add(QuotationClientCreateDto quotationClientDto)
        {
            var quotationClientToCreate = _mapper.Map<QuotationClientModel>(quotationClientDto);

            await _quotationClientService.AddAsync(quotationClientToCreate);
            var newQuotationClientId = quotationClientToCreate.Id;
            


            // Agregar el detalle de cliente de cotización utilizando el nuevo ID
            var quotationClientDetailDto = quotationClientDto.quotationClientDetailCreateDto[0];
            var quotationClientDetailModel = _mapper.Map<QuotationClientDetailModel>(quotationClientDetailDto);
            quotationClientDetailModel.QuotationClientId = newQuotationClientId; // Asignar el ID correcto
            await _quotationClientDetailService.AddAsync(quotationClientDetailModel);

            return Ok(quotationClientToCreate);

        }

        // PUT api/<QuotationClient>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, QuotationClientUpdateDto quotationClientDto)
        {
            var quotationClientToUpdate = await _quotationClientService.GetByIdAsync(quotationClientDto.Id);
            _mapper.Map(quotationClientDto, quotationClientToUpdate);
            await _quotationClientService.UpdateAsync(quotationClientToUpdate);
            return NoContent();
        }

        // DELETE api/<QuotationClient>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _quotationClientService.DeleteAsync(id);
            return NoContent();
        }
        [HttpDelete("ChangeStatus/{id}")]
        public async Task<IActionResult> ChangeQuotationStatus(long id)
        {
            await _quotationClientService.ChangeQuotationStatus(id);
            return NoContent();
        }
    }
}
