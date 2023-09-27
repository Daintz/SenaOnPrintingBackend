using AutoMapper;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using BusinessCape.DTOs.QuotationProviders;
using BusinessCape.DTOs.SupplyPictograms;
using SenaOnPrinting.Permissions;
using Microsoft.AspNetCore.Authorization;
using SenaOnPrinting.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Data.SqlClient;
using SenaOnPrinting.Helpers;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;

namespace SenaOnPrinting.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    //[AuthorizationFilter(ApplicationPermission.Provider)]
    public class QuotationProvidersController : ControllerBase
    {
        private readonly QuotationProvidersServices _quotation_providersServices;
        private readonly IMapper _mapper;
        private readonly BlobServiceClient _blobServiceClient;

        public QuotationProvidersController(QuotationProvidersServices quotation_providersServices, IMapper mapper, IWebHostEnvironment hostEnvironment, BlobServiceClient blobServiceClient)
        {
            _quotation_providersServices = quotation_providersServices;
            _mapper = mapper;
            _blobServiceClient = blobServiceClient;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quotationProviders = await _quotation_providersServices.GetAllAsync();
            foreach (var quotationProvider in quotationProviders)
            {
                var Url = await CreateServiceSASBlob(quotationProvider.QuotationFile, null, "quotationprovider");
                quotationProvider.QuotationFile = Url.ToString();
            }
            return Ok(quotationProviders);
        }

        [Authorize]
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
        // POST api/<ClientController>
        [Authorize]
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add([FromForm] QuotationProvidersCreateDto quotationProvidersCreateDto)
        {
            quotationProvidersCreateDto.QuotationFile = await SaveBlob(quotationProvidersCreateDto.QuotationFileInfo, "quotationprovider"); //Aquí está la conversión Explicita

            var quotationProvidersCreate = _mapper.Map<QuotationProviderModel>(quotationProvidersCreateDto);

            await _quotation_providersServices.AddAsync(quotationProvidersCreate);

            return Ok(quotationProvidersCreate);
        }

        [Authorize]
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]

        public async Task<IActionResult> Update(long id, [FromForm] QuotationProvidersUpdateDto quotationProviderDto)
        {
            if (id != quotationProviderDto.Id)
            {
                return BadRequest();
            }

            var quotationProvidersToUpdate = await _quotation_providersServices.GetByIdAsync(quotationProviderDto.Id);
            quotationProvidersToUpdate.QuotationFile = await SaveBlob(quotationProviderDto.QuotationFileInfo, "quotationprovider");

            _mapper.Map(quotationProviderDto, quotationProvidersToUpdate);
            await _quotation_providersServices.UpdateAsync(quotationProvidersToUpdate);

            return Ok(quotationProvidersToUpdate);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _quotation_providersServices.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("file/{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            var quotationProvider = await _quotation_providersServices.GetByIdAsync(id);

            if (quotationProvider == null)
            {
                return NotFound();
            }
            var file = await DownloadBlob(quotationProvider.QuotationFile, "quotationprovider");
            if (file == null)
            {
                return UnprocessableEntity();
            }
            return file;
        }

        [NonAction]
        public async Task<string> SaveBlob(Microsoft.AspNetCore.Http.IFormFile blob, string dir = "default")
        {
            string blobName = new string(Path.GetFileNameWithoutExtension(blob.FileName).Take(10).ToArray()).Replace(' ', '_');
            blobName = blobName + Path.GetExtension(blob.FileName);

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(dir);

            await blobContainerClient.CreateIfNotExistsAsync();

            var blobClient = blobContainerClient.GetBlobClient(blobName);

            using (var fileStream = blob.OpenReadStream())
            {
                await blobClient.UploadAsync(fileStream, true);
            }
            return blobName;
        }

        [NonAction]
        public async Task<Uri> CreateServiceSASBlob(string fileName, string storedPolicyName = null, string dir = "default")
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return null;
            }
            else
            {

                var blobContainerClient = _blobServiceClient.GetBlobContainerClient(dir);

                var blobClient = blobContainerClient.GetBlobClient(fileName);


                // Check if BlobContainerClient object has been authorized with Shared Key
                if (blobClient.CanGenerateSasUri)
                {
                    // Create a SAS token that's valid for one day
                    BlobSasBuilder sasBuilder = new BlobSasBuilder()
                    {
                        BlobContainerName = blobClient.GetParentBlobContainerClient().Name,
                        BlobName = fileName,
                        Resource = "b"
                    };

                    if (storedPolicyName == null)
                    {
                        sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddDays(1);
                        sasBuilder.SetPermissions(BlobContainerSasPermissions.Read);
                    }
                    else
                    {
                        sasBuilder.Identifier = storedPolicyName;
                    }

                    Uri sasURI = blobClient.GenerateSasUri(sasBuilder);

                    return sasURI;
                }
                else
                {
                    // Client object is not authorized via Shared Key
                    return null;
                }
            }
        }

        [NonAction]
        public async Task<IActionResult> DownloadBlob(string fileName, string dir = "default")
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient(dir);
            var blobClient = blobContainerClient.GetBlobClient(fileName);

            if (!await blobClient.ExistsAsync())
                return null;

            var response = await blobClient.DownloadAsync();
            var stream = response.Value.Content;

            return File(stream, response.Value.ContentType, fileName);
        }
    }
}