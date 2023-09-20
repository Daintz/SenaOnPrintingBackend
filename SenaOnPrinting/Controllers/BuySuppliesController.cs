using AutoMapper;
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
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[AuthorizationFilter(ApplicationPermission.Supply)]
    public class BuySuppliesController : ControllerBase
    {
        private readonly BuySupplyService _buySupplyService;
        private readonly BuySupplyDetailsService _buySupplyDetailsService;

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly SENAONPRINTINGContext _context;

        public BuySuppliesController(BuySupplyService buySupplyService, IMapper mapper, SENAONPRINTINGContext context, IWebHostEnvironment hostEnvironment)
        {
            _buySupplyService = buySupplyService;
            _mapper = mapper;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var quotationClient = await _buySupplyService.Index();
            return Ok(quotationClient);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Show(long id)
        {
            var buySupply = await _context.BuySupplies
                .Include(a => a.Provider)
                .Include(a => a.BuySuppliesDetails)
                .ThenInclude(a => a.Supply)
                .Include(a => a.BuySuppliesDetails)
                .ThenInclude(a => a.Warehouse)
                .Include(a => a.BuySuppliesDetails)
                .ThenInclude(a => a.UnitMeasures)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (buySupply == null)
            {
                return NotFound();
            }
            return Ok(buySupply);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add([FromForm] BuySuppliesCreateDto buySupplyDto)
        {
            var buySupplyCreate = _mapper.Map<BuySupplyModel>(buySupplyDto);
            await _buySupplyService.Create(buySupplyCreate);
            var buySupplyId = buySupplyCreate.Id;

            foreach (var detail in buySupplyDto.BuySuppliesDetailsCreateDto)
            {
                if (detail.SecurityFile != null && detail.SecurityFile.Length > 0)
                {
                    // Aquí puedes guardar el archivo como sea necesario, por ejemplo, en el sistema de archivos o en la base de datos.
                    // Por simplicidad, lo almacenaremos en el sistema de archivos.
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(detail.SecurityFileInfo.FileName);
                    var filePath = Path.Combine(_hostEnvironment.ContentRootPath, "Uploads", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await detail.SecurityFileInfo.CopyToAsync(fileStream);
                    }

                    var buySupplyDetail = new BuySuppliesDetailModel
                    {
                        BuySuppliesId = buySupplyId,
                        SupplyId = detail.SupplyId,
                        SecurityFile = fileName, // Aquí almacenamos el nombre del archivo
                        SupplyCost = detail.SupplyCost,
                        SupplyQuantity = detail.SupplyQuantity,
                        ExpirationDate = detail.ExpirationDate,
                        WarehouseId = detail.WarehouseId,
                        UnitMeasuresId = detail.UnitMeasuresId,
                        StatedAt = true
                    };

                    _context.BuySuppliesDetails.Add(buySupplyDetail);
                }
            }

            await _context.SaveChangesAsync();

            return Ok(buySupplyCreate);
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

    }
}
