using AutoMapper;
using BusinessCape.DTOs.ImpositionPlanch;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using BusinessCape.DTOs.OrderProduction;
using SenaOnPrinting.Permissions;
using Microsoft.AspNetCore.Authorization;
using SenaOnPrinting.Filters;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[AuthorizationFilter(ApplicationPermission.Production)]
    public class OrderProductionController : ControllerBase
    {
        private readonly OrderProductionService _orderProductionService;
        private readonly QuotationClientService _quotationClientService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public OrderProductionController(OrderProductionService orderProductionService, IMapper mapper, IWebHostEnvironment hostEnvironment, QuotationClientService quotationClientService)
        {
            _orderProductionService = orderProductionService;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            _quotationClientService = quotationClientService;
        }

        // GET: api/<OrderProductionController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderProductions = await _orderProductionService.GetAllAsync();
            return Ok(orderProductions);
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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add([FromForm] OrderProductionCreateDto orderProductionDto)
        {
            orderProductionDto.Scheme = await SaveImages(orderProductionDto.SchemeInfo);
            orderProductionDto.Image = await SaveImages(orderProductionDto.ImageInfo);
            var orderProductionToCreate = _mapper.Map<OrderProductionModel>(orderProductionDto);

            await _orderProductionService.AddAsync(orderProductionToCreate);

            return Ok(orderProductionToCreate);
        }


        // Método para realizar los cambios automáticos
        

        [NonAction]
        public async Task<string> SaveImages(Microsoft.AspNetCore.Http.IFormFile img)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(img.FileName).Take(10).ToArray()).Replace(' ', '_');
            imageName = imageName + Path.GetExtension(img.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images\\OrderProduction\\", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await img.CopyToAsync(fileStream);
            }
            return imageName;
        }


        // PUT api/<OrderProductionController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, OrderProductionUpdateDto orderProductionDto)
        {
            if (id != orderProductionDto.Id)
            {
                return BadRequest();
            }

            var orderProductionToUpdate = await _orderProductionService.GetByIdAsync(orderProductionDto.Id);

            _mapper.Map(orderProductionDto, orderProductionToUpdate);

            await _orderProductionService.UpdateAsync(orderProductionToUpdate);
            return Ok(orderProductionToUpdate);
        }

        // DELETE api/<OrderProductionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> ChangeState(long id)
        {
            await _orderProductionService.ChangeState(id);
            return NoContent();
        }
        [HttpDelete("ChangeStatus/{id}")]
        public async Task<IActionResult> ChangeOrderStatus(long id)
        {
            await _orderProductionService.ChangeOrderStatus(id);
            return NoContent();
        }
    }
}
