using AutoMapper;
using BusinessCape.DTOs.ImpositionPlanch;
using BusinessCape.DTOs.Lineature;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class impositionPlanchController : ControllerBase
    {
        private readonly ImpositionPlanchService _impositionPlanchService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public impositionPlanchController(ImpositionPlanchService impositionPlanchService, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _impositionPlanchService = impositionPlanchService;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }
        // GET: api/<LineatureController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var scheme = "https";
            var host = Request.Host;
            var pathBase = Request.PathBase.ToString();
            var impositionPlanches = await _impositionPlanchService.GetAllAsync();
            foreach (var impositionPlanch in impositionPlanches)
            {
                impositionPlanch.ImageSrc = string.Format("{0}://{1}/{2}Images/ImpositionPlanch/{3}",
                    scheme, host, pathBase, impositionPlanch.Scheme);
                impositionPlanch.Scheme = impositionPlanch.ImageSrc;
            }
            return Ok(impositionPlanches);
        }

        // GET api/<LineatureController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var impositionPlanch = await _impositionPlanchService.GetByIdAsync(id);
            if (impositionPlanch == null)
            {
                return NotFound();
            }
            return Ok(impositionPlanch);
        }

        // POST api/<LineatureController>
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add([FromForm] ImpositionPlanchCreateDto impositionPlanchDto)
        {
            impositionPlanchDto.Scheme = await SaveImages(impositionPlanchDto.SchemeInfo);

            var impositionPlanchToCreate = _mapper.Map<ImpositionPlanchModel>(impositionPlanchDto);

            await _impositionPlanchService.AddAsync(impositionPlanchToCreate);
            return Ok(impositionPlanchToCreate);
        }
        [NonAction]
        public async Task<string> SaveImages(Microsoft.AspNetCore.Http.IFormFile SchemeInfo)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(SchemeInfo.FileName).Take(10).ToArray()).Replace(' ', '_');
            imageName = imageName + Path.GetExtension(SchemeInfo.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images\\ImpositionPlanch\\", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await SchemeInfo.CopyToAsync(fileStream);
            }
            return imageName;
        }
        // PUT api/<LineatureController>/5
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(long id, [FromForm] ImpositionPlanchUpdateDto impositionPlanchDto)
        {
            if (id != impositionPlanchDto.Id)
            {
                return BadRequest();
            }

            var impositionPlanchToUpdate = await _impositionPlanchService.GetByIdAsync(impositionPlanchDto.Id);

            

                impositionPlanchToUpdate.Scheme = await SaveImages(impositionPlanchDto.SchemeInfo);

            

            _mapper.Map(impositionPlanchDto, impositionPlanchToUpdate);

            await _impositionPlanchService.UpdateAsync(impositionPlanchToUpdate);
            return Ok(impositionPlanchToUpdate);
        }


        // DELETE api/<LineatureController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> ChangeState(long id)
        {
            await _impositionPlanchService.ChangeState(id);
            return NoContent();
        }
    }
}
