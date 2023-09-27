using AutoMapper;
using BusinessCape.DTOs.QuotationClient;
using BusinessCape.DTOs.BuySuppliesDetail;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessCape.DTOs.QuotationProviders;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.AspNetCore.Authorization;

namespace SenaOnPrinting.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class BuySuppliesDetailController : ControllerBase
    {
        private readonly BuySupplyDetailsService _buySuppliesDetailService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly BlobServiceClient _blobServiceClient;

        public BuySuppliesDetailController(BuySupplyDetailsService BuySuppliesDetailService, IMapper mapper, IWebHostEnvironment hostEnvironment, BlobServiceClient blobServiceClient)
        {
            _buySuppliesDetailService = BuySuppliesDetailService;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            _blobServiceClient = blobServiceClient;
        }

        [HttpGet("file/{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            var BuySupplyDetail = await _buySuppliesDetailService.GetByIdAsync(id);

            if (BuySupplyDetail == null)
            {
                return NotFound();
            }
            var file = await DownloadBlob(BuySupplyDetail.SecurityFile, $"buysupply{BuySupplyDetail.BuySuppliesId}");
            if (file == null)
            {
                return UnprocessableEntity();
            }
            return file;
        }


        [NonAction]
        public async Task<IActionResult> DownloadBlob(string fileName, string dir = "default")
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            var blobContainerClient = _blobServiceClient.GetBlobContainerClient("buysupplies");
            var blobClient = blobContainerClient.GetBlobClient($"{dir}/{fileName}");

            if (!await blobClient.ExistsAsync())
                return null;

            var response = await blobClient.DownloadAsync();
            var stream = response.Value.Content;

            return File(stream, response.Value.ContentType, fileName);
        }
    }
}
