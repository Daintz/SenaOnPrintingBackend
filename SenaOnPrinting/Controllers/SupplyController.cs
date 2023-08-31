using AutoMapper;
using BusinessCape.DTOs.ImpositionPlanch;
using BusinessCape.DTOs.Supply;
using BusinessCape.DTOs.SupplyDetails;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SenaOnPrinting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplyController : ControllerBase
    {
        private readonly SupplyService _supplyService;
        private readonly IMapper _mapper;
        private readonly SENAONPRINTINGContext _context;

        public SupplyController(SupplyService supplyService, IMapper mapper, SENAONPRINTINGContext context)
        {
            _supplyService = supplyService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var supply = await _supplyService.GetAllAsync();
            return Ok(supply);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var supply = await _supplyService.GetByIdAsync(id);
            if (supply == null)
            {
                return NotFound();
            }
            return Ok(supply);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SupplyCreateDto supplyDto)
        //{
        //    var supplyToCreate = _mapper.Map<SupplyModel>(supplyDto);

        //    await _supplyService.AddAsync(supplyToCreate);
        //    return Ok(supplyToCreate);
        //}
        {
            var supplyToCreate = _mapper.Map<SupplyModel>(supplyDto);

            await _supplyService.AddAsync(supplyToCreate);

            foreach (var supplyCategoriesId in supplyDto.SupplyCategoriesId)
            {
                var supplyCategories = await _context.SupplyCategories.FindAsync(supplyCategoriesId);
                if (supplyCategories == null)
                {
                    return BadRequest("ERROR EN LAS CATEGORIAS");
                }

                var supplyCategoriesXSupply = new SupplyCategoriesXSupplyModel
                {
                    SupplyId = supplyToCreate.Id,
                    SupplyCategoryId = supplyCategories.Id
                };

                _context.SupplyCategoriesXSupplies.Add(supplyCategoriesXSupply);
            }
            //pictogramas
            foreach (var supplyPictogramsId in supplyDto.SupplyPictogramsId)
            {
                var supplyPictograms = await _context.SupplyPictograms.FindAsync(supplyPictogramsId);
                if (supplyPictograms == null)
                {
                    return BadRequest("ERROR EN LOS PICTOGRMAAS");
                }

                var supplyXSupplyPictogram = new SupplyXSupplyPictogramModel
                {
                    SupplyId = supplyToCreate.Id,
                    SupplyPictogramId = supplyPictograms.Id
                };

                _context.SupplyXSupplyPictograms.Add(supplyXSupplyPictogram);
            }
            //Unidad de medida
            foreach (var unitMeasuresId in supplyDto.UnitMeasuresId)
            {
                var unitMeasures = await _context.UnitMeasures.FindAsync(unitMeasuresId);
                if (unitMeasures == null)
                {
                    return BadRequest("ERROR EN LAS UNIDADES DE MEDIDA");
                }

                var unitMeasuresXSupplyModel = new UnitMeasuresXSupplyModel
                {
                    SupplyId = supplyToCreate.Id,
                    UnitMeasureId = unitMeasures.Id
                };

                _context.UnitMeasuresXSupplies.Add(unitMeasuresXSupplyModel);
            }


            //var permissions = _context.ApplicationPermissions.Where(p => roleDto.PermissionIds.Contains(p.Id)).ToList();
            //role.Permissions = permissions;

            await _context.SaveChangesAsync();
            return Ok(supplyToCreate);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(long id, SupplyUpdateDto supplyDto)
        {
            if (id != supplyDto.Id)
            {
                return BadRequest();
            }

            var supplyToUpdate = await _supplyService.GetByIdAsync(supplyDto.Id);

            _mapper.Map(supplyDto, supplyToUpdate);

            await _supplyService.UpdateAsync(supplyToUpdate);
            return Ok(supplyToUpdate);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> ChangeState(long id)
        {
            await _supplyService.ChangeState(id);
            return NoContent();
        }

    }
}
