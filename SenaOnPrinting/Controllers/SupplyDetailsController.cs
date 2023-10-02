using AutoMapper;
using BusinessCape.DTOs.QuotationClient;
using BusinessCape.DTOs.QuotationProviders;
using BusinessCape.DTOs.SupplyCategory;
using BusinessCape.DTOs.SupplyDetails;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using PersistenceCape.Interfaces;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    //[AuthorizationFilter(ApplicationPermission.Supply)]
    public class SupplyDetailsController : ControllerBase
    {
        private readonly SupplyDetailsService _supplyDetailService;
        private readonly IMapper _mapper;
        private readonly ISupplyDetailsRepository _supplyDetailsRepository;
        private readonly SENAONPRINTINGContext _context;
        private readonly SupplySupplyDetailsService _supplySupplyDetailService;

        public SupplyDetailsController(SupplyDetailsService supplyDetailService, IMapper mapper, ISupplyDetailsRepository supplyDetailsRepository, SENAONPRINTINGContext context)
        {
            _supplyDetailService = supplyDetailService;
            _mapper = mapper;
            _supplyDetailsRepository = supplyDetailsRepository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supplyDetails = await _supplyDetailService.GetAllAsync();
            ///
            return Ok(supplyDetails);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById(long id)
        {
            var supplyDetail = await _supplyDetailService.GetByIdAsync(id);

            if (supplyDetail == null)
            {
                return NotFound();
            }
            return Ok(supplyDetail); 
        }

        [HttpGet("SupplyDetail")]
        public async Task<IActionResult> GetAllSupplyDetail()
        {
            var supplySupplyDetail = await _supplyDetailService.GetSuppplySupplyAsync();
            return Ok(supplySupplyDetail);
        }



        [HttpPost]
        public async Task<IActionResult> Add(SupplyDetailsCreateDto supplyDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var supplyDetailToCreate = _mapper.Map<SupplyDetailModel>(supplyDetailDto);

            await _supplyDetailService.AddAsync(supplyDetailToCreate);
            var supplyDetailId = supplyDetailToCreate.Id;


            // Agregar el detalle de compra de insumos utilizando el nuevo ID

            //foreach (var detail in supplyDetailDto.supplySupplyDetailToCreateDto)
            //{
            //    var detail_detail = new SupplySupplyDetailsModel
            //    {
            //        supplydetails_id = supplyDetailId,
            //        SupplyId = detail.SupplyId,
            //        Quantity = detail.Quantity,
            //        SupplyCost = detail.SupplyCost
            //    };

            //    _context.SupplySupplyDetails.Add(detail_detail);
            //}

            //await _context.SaveChangesAsync();

            return Ok(supplyDetailToCreate.Id);
        }

        //public async Task<IActionResult> Add(SupplyDetailsCreateDto supplyDetailDto)
        //{

        //    var supplyDetailToCreate = _mapper.Map<SupplyDetailModel>(supplyDetailDto);

        //    await _supplyDetailService.AddAsync(supplyDetailToCreate);
        //    var supplyDetailId = supplyDetailToCreate.Id;


        //    // Agregar el detalle de compra de insumos utilizando el nuevo ID

        //    foreach (var detail in supplyDetailDto.supplySupplyDetailToCreateDto)
        //    {
        //        var detail_detail = new SupplySupplyDetailsModel
        //        {
        //            supplydetails_id = supplyDetailId,
        //            SupplyId = detail.SupplyId,
        //            Quantity = detail.Quantity,
        //            SupplyCost = detail.SupplyCost
        //        };

        //        _context.SupplySupplyDetails.Add(detail_detail);
        //    }

        //    await _context.SaveChangesAsync();
        //    return Ok(supplyDetailToCreate);
        //}



        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id, SupplyDetailsUpdateDto supplyDetailDto)
        {
            if (id != supplyDetailDto.Id)
            {
                return BadRequest();
            }

            var supplyDetailToUpdate = await _supplyDetailService.GetByIdAsync(supplyDetailDto.Id);

            _mapper.Map(supplyDetailDto, supplyDetailToUpdate);

            await _supplyDetailService.UpdateAsync(supplyDetailToUpdate);
            return Ok(supplyDetailToUpdate);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> ChangeState(long id)
        {
            await _supplyDetailService.ChangeState(id);
            return NoContent();
        }

    }
}
