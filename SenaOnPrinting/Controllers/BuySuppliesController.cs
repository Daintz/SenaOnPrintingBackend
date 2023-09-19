using AutoMapper;
using BusinessCape.DTOs.BuySupply;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("api/buy_supplies")]
    //[AuthorizationFilter(ApplicationPermission.Supply)]
    public class BuySuppliesController : ControllerBase
    {
        private readonly BuySupplyService _buySupplyService;        
        private readonly IMapper _mapper;

        private readonly SENAONPRINTINGContext _context;
        public BuySuppliesController(BuySupplyService buySupplyService, IMapper mapper, SENAONPRINTINGContext context)
        {
            _buySupplyService = buySupplyService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var buySupplies = await _context.BuySupplies.Include(a => a.Provider).ToListAsync();
            return Ok(buySupplies);
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
        public async Task<IActionResult> Create(BuySuppliesCreateDto buySupplyDto)
        {
            
            var buySupply = _mapper.Map<BuySupplyModel>(buySupplyDto);

            await _buySupplyService.Create(buySupply);
            var buySupplyId = buySupply.Id;

            foreach (var detail in buySupplyDto.BuySuppliesDetails)
            {
                var buySupplyDetail = new BuySuppliesDetailModel
                {
                    BuySuppliesId = buySupplyId,
                    SupplyId = detail.SupplyId,
                    SecurityFile = detail.SecurityFile,
                    SupplyCost = detail.SupplyCost,
                    SupplyQuantity = detail.SupplyQuantity,
                    ExpirationDate = detail.ExpirationDate,
                    WarehouseId = detail.WarehouseId,
                    UnitMeasuresId = detail.UnitMeasuresId,
                    StatedAt = true
                };

                _context.BuySuppliesDetails.Add(buySupplyDetail);

            }

            await _context.SaveChangesAsync();

            return Ok(buySupply);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id, BuySuppliesUpdateDto buySupplyDto)
        {
            if (id != buySupplyDto.Id)
            {
                return BadRequest();
            }

            var buySupply = await _buySupplyService.Show(buySupplyDto.Id);

            _mapper.Map(buySupplyDto, buySupply);

            await _buySupplyService.Update(buySupply);
            return Ok(buySupply);
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> ChangeState(long id)
        {
            await _buySupplyService.ChangeState(id);
            return NoContent();
        }

    }
}
