using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using BusinessCape.DTOs.BuySuppliesDetail;
using BusinessCape.DTOs.BuySupply;
using BusinessCape.DTOs.QuotationProviders;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Helpers;
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Controllers
{
    //[Authorize]
    [Route("api/buy_supplies")]
    [ApiController]
    //[AuthorizationFilter(ApplicationPermission.Supply)]
    public class BuySuppliesController : ControllerBase
    {
        private readonly BuySupplyService _buySupplyService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly SENAONPRINTINGContext _context;

        public BuySuppliesController(BuySupplyService buySupplyService, IMapper mapper, SENAONPRINTINGContext context, IWebHostEnvironment hostEnvironment, BlobServiceClient blobServiceClient)
        {
            _buySupplyService = buySupplyService;
            _mapper = mapper;
            _context = context;
            _hostEnvironment = hostEnvironment;
            _blobServiceClient = blobServiceClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var buySupplies = await _context.BuySupplies
                .Include(a => a.Provider)
                .Include(a => a.BuySuppliesDetails)
                .ThenInclude(a => a.Supply)
                .ThenInclude(a => a.SupplyXSupplyPictogram)
                .ThenInclude(a => a.SupplyPictogram)
                .Include(a => a.BuySuppliesDetails)
                .ThenInclude(a => a.Warehouse)
                .Include(a => a.BuySuppliesDetails)
                .ThenInclude(a => a.UnitMeasures)
                .ToListAsync();

            foreach (var buySupply in buySupplies)
            {
                foreach (var detail in buySupply.BuySuppliesDetails)
                {
                    var UrlSecurityFile = await CreateServiceSASBlob(detail.SecurityFile, null, $"buysupply{buySupply.Id}", true);
                    detail.SecurityFile = UrlSecurityFile.ToString();

                    foreach (var pictogramXsupply in detail.Supply.SupplyXSupplyPictogram)
                    {
                        if (!pictogramXsupply.SupplyPictogram.PictogramFile.Contains("https"))
                        {
                            var UrlPictogram = await CreateServiceSASBlob(pictogramXsupply.SupplyPictogram.PictogramFile, null, "supplypictogram");
                            pictogramXsupply.SupplyPictogram.PictogramFile = UrlPictogram.ToString();
                        }
                    }
                }
            }

            return Ok(buySupplies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Show(long id)
        {
            var buySupply = await _context.BuySupplies
                .Include(a => a.Provider)
                .Include(a => a.BuySuppliesDetails)
                .ThenInclude(a => a.Supply)
                .ThenInclude(a => a.SupplyXSupplyPictogram)
                .ThenInclude(a => a.SupplyPictogram)
                .Include(a => a.BuySuppliesDetails)
                .ThenInclude(a => a.Warehouse)
                .Include(a => a.BuySuppliesDetails)
                .ThenInclude(a => a.UnitMeasures)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (buySupply == null)
            {
                return NotFound();
            }

            foreach (var detail in buySupply.BuySuppliesDetails)
            {
                var UrlSecurityFile = await CreateServiceSASBlob(detail.SecurityFile, null, $"buysupply{buySupply.Id}", true);
                detail.SecurityFile = UrlSecurityFile.ToString();

                foreach (var pictogramXsupply in detail.Supply.SupplyXSupplyPictogram)
                {

                    if (!pictogramXsupply.SupplyPictogram.PictogramFile.Contains("https")) { 
                        var UrlPictogram = await CreateServiceSASBlob(pictogramXsupply.SupplyPictogram.PictogramFile, null, "supplypictogram");
                        pictogramXsupply.SupplyPictogram.PictogramFile = UrlPictogram.ToString();
                    }
                }
            }
            return Ok(buySupply);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] BuySuppliesCreateDto buySupplyDto)
        {

            var buySupply = _mapper.Map<BuySupplyModel>(buySupplyDto);

            var lastBuySupply = await _context.BuySupplies.OrderBy(d => d.Id).LastOrDefaultAsync();
            long lastId = 0;
            if (lastBuySupply != null)
            {
                lastId = lastBuySupply.Id;
            }


            for (var index = 0; index < buySupplyDto.BuySuppliesDetails.Count(); index++)
            {
                var securityFile = await SaveBlob(buySupplyDto.BuySuppliesDetails[index].SecurityFileInfo, $"buysupply{lastId + 1}");
                buySupply.BuySuppliesDetails[index].SecurityFile = securityFile;
            }

            await _buySupplyService.Create(buySupply);
            var buySupplyId = buySupply.Id;

            return Ok(buySupply);
        }



        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id, BuySuppliesUpdateDto buySupplyDto)
        {
            if (id != buySupplyDto.Id)
            {
                return BadRequest();
            }

            var buySupplyToUpdate = await _buySupplyService.Show(buySupplyDto.Id);

            _mapper.Map(buySupplyDto, buySupplyToUpdate);

            await _buySupplyService.Update(buySupplyToUpdate);
            return Ok(buySupplyToUpdate);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> ChangeState(long id)
        {
            await _buySupplyService.ChangeState(id);
            return NoContent();
        }

        [NonAction]
        public async Task<string> SaveBlob(Microsoft.AspNetCore.Http.IFormFile blob, string dir = "default")
        {
            string blobName = new string(Path.GetFileNameWithoutExtension(blob.FileName).Take(10).ToArray()).Replace(' ', '_');
            blobName = blobName + Path.GetExtension(blob.FileName);

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient($"buysupplies");

            await blobContainerClient.CreateIfNotExistsAsync();

            var blobClient = blobContainerClient.GetBlobClient($"{dir}/{blobName}");

            using (var fileStream = blob.OpenReadStream())
            {
                await blobClient.UploadAsync(fileStream, true);
            }
            return blobName;
        }

        [NonAction]
        public async Task<Uri> CreateServiceSASBlob(string fileName, string storedPolicyName = null, string dir = "default", bool isBuySupply = false)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return null;
            }
            else
            {
                string containerName = "buysupplies";
                string blobName = $"{dir}/{fileName}";
                if (!isBuySupply)
                {
                    containerName = dir;
                    blobName = fileName;
                }
                var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                await blobContainerClient.CreateIfNotExistsAsync();

                var blobClient = blobContainerClient.GetBlobClient(blobName);


                // Check if BlobContainerClient object has been authorized with Shared Key
                if (blobClient.CanGenerateSasUri)
                {
                    // Create a SAS token that's valid for one day
                    BlobSasBuilder sasBuilder = new BlobSasBuilder()
                    {
                        BlobContainerName = blobClient.GetParentBlobContainerClient().Name,
                        BlobName = blobName,
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
