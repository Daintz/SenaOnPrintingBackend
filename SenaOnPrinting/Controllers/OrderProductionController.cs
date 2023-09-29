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
using Azure.Storage.Sas;
using SenaOnPrinting.Helpers;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SenaOnPrinting.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[AuthorizationFilter(ApplicationPermission.Production)]
    public class OrderProductionController : ControllerBase
    {
        private readonly OrderProductionService _orderProductionService;
        private readonly QuotationClientService _quotationClientService;
        private readonly IMapper _mapper;
        private readonly BlobServiceClient _blobServiceClient;
        public OrderProductionController(OrderProductionService orderProductionService, IMapper mapper, IWebHostEnvironment hostEnvironment, QuotationClientService quotationClientService, BlobServiceClient blobServiceClient)
        {
            _orderProductionService = orderProductionService;
            _mapper = mapper;
            _quotationClientService = quotationClientService;
            _blobServiceClient = blobServiceClient;
        }   

        

        // GET: api/<OrderProductionController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderProductions = await _orderProductionService.GetAllAsync();

            foreach (var item in orderProductions)
            {
                var UrlScheme = await CreateServiceSASBlob(item.Scheme, null, "orderproduction");
                var UrlImage = await CreateServiceSASBlob(item.Image, null, "orderproduction");

                item.Scheme = UrlScheme.ToString();
                item.Image = UrlImage.ToString();
            }

            return Ok(orderProductions);
        }

        // GET api/<OrderProductionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var orderProduction = await _orderProductionService.GetByIdAsync(id);

            var UrlScheme = await CreateServiceSASBlob(orderProduction.Scheme, null, "orderproduction");
            var UrlImage = await CreateServiceSASBlob(orderProduction.Image, null, "orderproduction");

            orderProduction.Scheme = UrlScheme.ToString();
            orderProduction.Image = UrlImage.ToString();

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
            orderProductionDto.Scheme = await SaveBlob(orderProductionDto.SchemeInfo, "orderproduction");
            orderProductionDto.Image = await SaveBlob(orderProductionDto.ImageInfo, "orderproduction");
            var orderProductionToCreate = _mapper.Map<OrderProductionModel>(orderProductionDto);

            await _orderProductionService.AddAsync(orderProductionToCreate);

            return Ok(orderProductionToCreate);
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
    }
}
