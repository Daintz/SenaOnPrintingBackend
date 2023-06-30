using AutoMapper;
using BusinessCape.DTOs.Client;
using BusinessCape.DTOs.SupplyPictograms;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Hosting;


namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyPictogrmasController : ControllerBase
    {
        private readonly SupplyPictogramsServices _SupplyPictogramsServices;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SupplyPictogrmasController(SupplyPictogramsServices SupplyPictogramsServices, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _SupplyPictogramsServices = SupplyPictogramsServices;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var PictogramFile = "https";
            var host = Request.Host;
            var pathBase = Request.PathBase.ToString();
            var supplyPictograms = await _SupplyPictogramsServices.GetAllAsync();
            foreach (var supplypictogram in supplyPictograms )
            {
                supplypictogram.PictogramFile = string.Format("{0}://{1}/{2}Images/SupplyPictogram/{3}",
                    PictogramFile, host, pathBase, supplypictogram.PictogramFile);
                supplypictogram.PictogramFile = supplypictogram.PictogramFile;
            }
            return Ok(supplyPictograms);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var supplyPictograms = await _SupplyPictogramsServices.GetByIdAsync(id);
            if (supplyPictograms == null)
            {
                return NotFound();
            }
            return Ok(supplyPictograms);
        }

        // POST api/<ClientController>
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add([FromForm] SupplyPictogramsCreateDto supplypictogramDto)
        { 
            supplypictogramDto.PictogramFile = await SaveImages(supplypictogramDto.PictogramFileInfo); //Aquí está la conversión Explicita
        
            var supplyPictogramCreate = _mapper.Map<SupplyPictogramModel>(supplypictogramDto);

            await _SupplyPictogramsServices.AddAsync(supplyPictogramCreate);

            return Ok(supplyPictogramCreate);
        }
        [NonAction]
          
        public async Task<string> SaveImages(Microsoft.AspNetCore.Http.IFormFile PictogramFileInfo)
        {
            //string imageName = new string(Path.GetFileNameWithoutExtension(PictogramFileInfo.FileName).Take(10).ToArray()).Replace(' ','_');
            string imageName = new string(Path.GetFileNameWithoutExtension(PictogramFileInfo.FileName).Take(10).ToArray()).Replace(' ', '_');
            imageName = imageName + Path.GetExtension(PictogramFileInfo.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images\\SupplyPictogram\\", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await PictogramFileInfo.CopyToAsync(fileStream);
            }
            return imageName;
        }


        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(long id, [FromForm] SupplyPictogramsUpdateDto supplyPictogramDto)
        {
            if (id != supplyPictogramDto.Id)
            {
                return BadRequest();
            }

            var supplyPictogramUpdate = await _SupplyPictogramsServices.GetByIdAsync(supplyPictogramDto.Id);


            supplyPictogramUpdate.PictogramFile = await SaveImages(supplyPictogramDto.PictogramFileInfo); //Aquí está la conversión Explicita



            _mapper.Map(supplyPictogramDto, supplyPictogramUpdate);

            await _SupplyPictogramsServices.UpdateAsync(supplyPictogramUpdate);
            return Ok(supplyPictogramUpdate);
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _SupplyPictogramsServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
