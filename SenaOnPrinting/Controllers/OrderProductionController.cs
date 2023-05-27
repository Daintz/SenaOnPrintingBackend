using AutoMapper;
using BusinessCape.DTOs.OrderProduction;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductionController : ControllerBase
    {
        private readonly OrderProductionService _orderProductionService;
        private readonly IMapper _mapper;

        public OrderProductionController(OrderProductionService orderProductionService, IMapper mapper)
        {
            _orderProductionService = orderProductionService;
            _mapper = mapper;
        }

        // GET: api/<OrderProductionController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderProduction = await _orderProductionService.GetAllAsync();
            return Ok(orderProduction);
        }

        // GET api/<OrderProductionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var orderProduction = await _orderProductionService.GetByIdAsync(id);
            if (orderProduction == null)
            {
                return NotFound();
            }
            return Ok(orderProduction);
        }

        // POST api/<OrderProductionController>
        [HttpPost]
        public async Task<IActionResult> Add(OrderProductionCreateDto orderProductionDto)
        {
            var orderProductionToCreate = _mapper.Map<OrderProductionModel>(orderProductionDto);

            await _orderProductionService.AddAsync(orderProductionToCreate);
            return Ok(orderProductionToCreate);
        }

        // PUT api/<OrderProductionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, OrderProductionUpdateDto orderProductionDto)
        {
            if (id != orderProductionDto.IdOrderProduction)
            {
                return BadRequest();
            }

            var orderProductionToUpdate = await _orderProductionService.GetByIdAsync(orderProductionDto.IdOrderProduction);

            _mapper.Map(orderProductionDto, orderProductionToUpdate);

            await _orderProductionService.UpdateAsync(orderProductionToUpdate);
            return Ok(orderProductionToUpdate);
        }

        // DELETE api/<OrderProductionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _orderProductionService.DeleteAsync(id);
            return NoContent();
        }
    }
}
