using AutoMapper;
using BusinessCape.DTOs.QuotationClient;
using BusinessCape.DTOs.BuySuppliesDetail;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessCape.DTOs.QuotationProviders;

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuySuppliesDetailController : ControllerBase
    {
        private readonly BuySupplyDetailsService _buySuppliesDetailService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BuySuppliesDetailController(BuySupplyDetailsService BuySuppliesDetailService, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _buySuppliesDetailService = BuySuppliesDetailService;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet("file/{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            var file = await _buySuppliesDetailService.GetByIdAsync(id);

            if (file == null)
            {
                return NotFound();
            }
            var filePath = $"SecurityFiles/buySupply_{file.BuySuppliesId}/{file.SecurityFile}";
            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

            return new FileContentResult(fileBytes, "application/pdf");
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var scheme = "https";
            var host = Request.Host;
            var pathBase = Request.PathBase.ToString();
            var buySuppliesDetails = await _buySuppliesDetailService.GetAllAsync();
            foreach (var buySuppliesDetail in buySuppliesDetails)
            {
                buySuppliesDetail.SecurityFile = string.Format("{0}://{1}/{2}Images/BuySuppliesDetail/{3}",
                    scheme, host, pathBase, buySuppliesDetail.SecurityFile);
                buySuppliesDetail.SecurityFile = buySuppliesDetail.SecurityFile;
            }
            return Ok(buySuppliesDetails);
        }
        //[HttpGet("Approved")]

        //public async Task<IActionResult> GetAllApproved()
        //{
        //    var BuySuppliesDetail = await _BuySuppliesDetailService.GetApprovedQuotationAsync();
        //    return Ok(BuySuppliesDetail);
        //}
        // GET api/<BuySuppliesDetail>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var BuySuppliesDetail = await _buySuppliesDetailService.GetByIdAsync(id);
            if (BuySuppliesDetail == null)
            {
                return NotFound();
            }
            return Ok(BuySuppliesDetail);
        }

        // POST api/<BuySuppliesDetail>
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add([FromForm] BuySuppliesDetailsCreateDto buySuppliesDetailCreateDto, long id)
        {

            buySuppliesDetailCreateDto.SecurityFile = await SaveImages(buySuppliesDetailCreateDto.SecurityFileInfo);

            var BuySuppliesDetailToCreate = _mapper.Map<BuySuppliesDetailModel>(buySuppliesDetailCreateDto);

            // Aquí deberías configurar el ID usando el parámetro idCot
            BuySuppliesDetailToCreate.SupplyId = id;

            await _buySuppliesDetailService.AddAsync(BuySuppliesDetailToCreate);
            return Ok(BuySuppliesDetailToCreate);
        }
        [NonAction]

        public async Task<string> SaveImages(Microsoft.AspNetCore.Http.IFormFile SecurityFileInfo)
        {
            //string imageName = new string(Path.GetFileNameWithoutExtension(PictogramFileInfo.FileName).Take(10).ToArray()).Replace(' ','_');
            string imageName = new string(Path.GetFileNameWithoutExtension(SecurityFileInfo.FileName).Take(10).ToArray()).Replace(' ', '_');
            imageName = imageName + Path.GetExtension(SecurityFileInfo.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images\\BuySuppliesDetail\\", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await SecurityFileInfo.CopyToAsync(fileStream);
            }
            return imageName;
        }
        // PUT api/<BuySuppliesDetail>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, BuySuppliesDetailsUpdateDto BuySuppliesDetailUpdateDto)
        {
            var BuySuppliesDetailToUpdate = await _buySuppliesDetailService.GetByIdAsync(BuySuppliesDetailUpdateDto.Id);
            _mapper.Map(BuySuppliesDetailUpdateDto, BuySuppliesDetailToUpdate);
            await _buySuppliesDetailService.UpdateAsync(BuySuppliesDetailToUpdate);
            return NoContent();
        }

        // DELETE api/<BuySuppliesDetail>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _buySuppliesDetailService.DeleteAsync(id);
            return NoContent();
        }
    }
}
