using AutoMapper;
using BusinessCape.DTOs.BuySuppliesDetail;
using BusinessCape.DTOs.BuySupply;
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
    [ApiController]
    [Route("api/buy_supplies")]
    //[AuthorizationFilter(ApplicationPermission.Supply)]
    public class BuySuppliesController : ControllerBase
    {
        private readonly BuySupplyService _buySupplyService;        
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
        public async Task<IActionResult> Index()
        {
            var buySupplies = await _context.BuySupplies
                .Include(a => a.Provider)
                .Include(a => a.BuySuppliesDetails)
                .ThenInclude(a => a.Supply)
                .Include(a => a.BuySuppliesDetails)
                .ThenInclude(a => a.Warehouse)
                .Include(a => a.BuySuppliesDetails)
                .ThenInclude(a => a.UnitMeasures)
                .ToListAsync();
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
        public async Task<IActionResult> Create([FromForm] BuySuppliesCreateDto buySupplyDto)
        {
            
            var buySupply = _mapper.Map<BuySupplyModel>(buySupplyDto);

            var lastBuySupply = await _context.BuySupplies.OrderBy(d => d.Id).LastOrDefaultAsync();

            for (var index = 0; index < buySupplyDto.BuySuppliesDetails.Count(); index++)
            {
                var securityFile = await SaveFile(buySupplyDto.BuySuppliesDetails[index].SecurityFileInfo, lastBuySupply.Id+1);
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

        [NonAction]

        public async Task<string> SaveFile(Microsoft.AspNetCore.Http.IFormFile securityFileInfo, long buySupplyId)
        {
            //string imageName = new string(Path.GetFileNameWithoutExtension(PictogramFileInfo.FileName).Take(10).ToArray()).Replace(' ','_');
            string fileName = new string(Path.GetFileNameWithoutExtension(securityFileInfo.FileName).Take(10).ToArray()).Replace(' ', '_');
            fileName = fileName + Path.GetExtension(securityFileInfo.FileName);            
            var buySupplyPath = Path.Combine(_hostEnvironment.ContentRootPath, $"SecurityFiles\\{"buySupply_"+ buySupplyId}\\");
            if (!Directory.Exists(buySupplyPath))
            {
                Directory.CreateDirectory(buySupplyPath);
            }

            var filePath = Path.Combine(buySupplyPath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await securityFileInfo.CopyToAsync(fileStream);
            }
            return fileName;
        }

    }
}
