using AutoMapper;
using BusinessCape.DTOs.TypeServices;
using DataCape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessCape.Services;
using Microsoft.AspNetCore.Authorization;

namespace SenaOnPrinting.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TypeServicesController : ControllerBase
    {
        private readonly TypeServicesServices _typeServicesService;
        private readonly IMapper _mapper;

        public TypeServicesController(TypeServicesServices typeServicesService, IMapper mapper)
        {
            _typeServicesService = typeServicesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var typeServices = await _typeServicesService.GetAllAsync();
            return Ok(typeServices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var typeServices = await _typeServicesService.GetByIdAsync(id);
            if (typeServices == null)
            {
                return NotFound();
            }
            return Ok(typeServices);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TypeServicesCreateDto typeServicesDto)
        {
            var TypeServicesToCreate = _mapper.Map<TypeServiceModel>(typeServicesDto);

            await _typeServicesService.AddAsync(TypeServicesToCreate);
            return Ok(TypeServicesToCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, TypeServicesUpdateDto TypeServicesDto)
        {
            var TypeServicesToUpdate = await _typeServicesService.GetByIdAsync(TypeServicesDto.Id);
            _mapper.Map(TypeServicesDto, TypeServicesToUpdate);
            await _typeServicesService.UpdateAsync(TypeServicesToUpdate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _typeServicesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
