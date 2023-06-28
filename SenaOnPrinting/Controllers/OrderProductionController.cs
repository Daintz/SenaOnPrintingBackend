using AutoMapper;
using BusinessCape.DTOs.ImpositionPlanch;
using BusinessCape.DTOs.Lineature;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using BusinessCape.DTOs.OrderProduction;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductionController : ControllerBase
    {
        private readonly OrderProductionService _orderProductionService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public OrderProductionController(OrderProductionService orderProductionService, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _orderProductionService = orderProductionService;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        // GET: api/<OrderProductionController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderProduction = await _orderProductionService.GetAllAsync();
            var scheme = "https";
            var host = Request.Host;
            var pathBase = Request.PathBase.ToString();
            var impositionPlanches = await _orderProductionService.GetAllAsync();
            foreach (var impositionPlanch in impositionPlanches)
            {
                impositionPlanch.ImageSrc = string.Format("{0}://{1}/{2}Images/ImpositionPlanch/{3}",
                    scheme, host, pathBase, impositionPlanch.Scheme);
                impositionPlanch.Scheme = impositionPlanch.ImageSrc;
            }
            return Ok(impositionPlanches);

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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add([FromForm] OrderProductionCreateDto orderProductionDto)
        {
            orderProductionDto.Scheme = await SaveImages((Microsoft.AspNetCore.Http.IFormFile)orderProductionDto.SchemeInfo);
            orderProductionDto.Image = await SaveImages((Microsoft.AspNetCore.Http.IFormFile)orderProductionDto.ImageInfo);
            var orderProductionToCreate = _mapper.Map<OrderProductionModel>(orderProductionDto);

            await _orderProductionService.AddAsync(orderProductionToCreate);
            return Ok(orderProductionToCreate);
        }

        [NonAction]
        public async Task<string> SaveImages(Microsoft.AspNetCore.Http.IFormFile SchemeInfo)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(SchemeInfo.FileName).Take(10).ToArray()).Replace(' ', '_');
            imageName = imageName + Path.GetExtension(SchemeInfo.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images\\OrderProduction\\", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await SchemeInfo.CopyToAsync(fileStream);
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
    }
}
