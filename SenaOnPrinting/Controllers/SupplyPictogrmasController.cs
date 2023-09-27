using AutoMapper;
using BusinessCape.DTOs.Client;
using BusinessCape.DTOs.SupplyPictograms;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;
using SenaOnPrinting.Helpers;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;

namespace SenaOnPrinting.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizationFilter(ApplicationPermission.Configuration)]
    public class SupplyPictogrmasController : ControllerBase
    {
        private readonly SupplyPictogramsServices _SupplyPictogramsServices;
        private readonly IMapper _mapper;
        private readonly BlobServiceClient _blobServiceClient;

        public SupplyPictogrmasController(SupplyPictogramsServices SupplyPictogramsServices, IMapper mapper, IWebHostEnvironment hostEnvironment, BlobServiceClient blobServiceClient)
        {
            _SupplyPictogramsServices = SupplyPictogramsServices;
            _mapper = mapper;
            _blobServiceClient = blobServiceClient;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supplyPictograms = await _SupplyPictogramsServices.GetAllAsync();
            foreach (var supplypictogram in supplyPictograms )
            {
                var Url = await CreateServiceSASBlob(supplypictogram.PictogramFile, null, "supplypictogram");
                supplypictogram.PictogramFile = Url.ToString();
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
            supplypictogramDto.PictogramFile = await SaveBlob(supplypictogramDto.PictogramFileInfo, "supplypictogram"); //Aquí está la conversión Explicita
        
            var supplyPictogramCreate = _mapper.Map<SupplyPictogramModel>(supplypictogramDto);

            await _SupplyPictogramsServices.AddAsync(supplyPictogramCreate);

            return Ok(supplyPictogramCreate);
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


            supplyPictogramUpdate.PictogramFile = await SaveBlob(supplyPictogramDto.PictogramFileInfo, "supplypictogram"); //Aquí está la conversión Explicita



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
