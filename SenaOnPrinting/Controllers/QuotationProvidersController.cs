using AutoMapper;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using BusinessCape.DTOs.QuotationProviders;

namespace SenaOnPrinting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationProvidersController : ControllerBase
    {
        private readonly QuotationProvidersServices _quotation_providersServices;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;


        public QuotationProvidersController(QuotationProvidersServices quotation_providersServices, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _quotation_providersServices = quotation_providersServices;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var scheme = "https";
            var host = Request.Host;
            var pathBase = Request.PathBase.ToString();
            var quotationProviders = await _quotation_providersServices.GetAllAsync();
            foreach (var quotationProvider in quotationProviders)
            {
                quotationProvider.QuotationFile = string.Format("{0}://{1}/{2}Images/QuotationProvider/{3}",
                    scheme, host, pathBase, quotationProvider.QuotationFile);
                quotationProvider.QuotationFile = quotationProvider.QuotationFile;
            }
            return Ok(quotationProviders);
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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add([FromForm] QuotationProvidersCreateDto quotationProviderDto)
        {
            quotationProviderDto.QuotationFile = await SaveImages(quotationProviderDto.QuotationFileInfo);

            var QuotationProvidersToCreate = _mapper.Map<QuotationProviderModel>(quotationProviderDto);

            await _quotation_providersServices.AddAsync(QuotationProvidersToCreate);

            return Ok(QuotationProvidersToCreate);
        }
        [NonAction]
        public async Task<string> SaveImages(Microsoft.AspNetCore.Http.IFormFile QuotationFileInfo)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(QuotationFileInfo.FileName).Take(10).ToArray()).Replace(' ', '_');
            imageName = imageName + Path.GetExtension(QuotationFileInfo.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images\\QuotationProvider\\", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await QuotationFileInfo.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]

        public async Task<IActionResult> Update(long id, [FromForm] QuotationProvidersUpdateDto quotationProviderDto)
        {
            if (id != quotationProviderDto.Id)
            {
                return BadRequest();
            }

            var quotationProvidersToUpdate = await _quotation_providersServices.GetByIdAsync(quotationProviderDto.Id);
            quotationProvidersToUpdate.QuotationFile = await SaveImages(quotationProviderDto.QuotationFileInfo);

            _mapper.Map(quotationProviderDto, quotationProvidersToUpdate);
            await _quotation_providersServices.UpdateAsync(quotationProvidersToUpdate);

            return Ok(quotationProvidersToUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _quotation_providersServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
