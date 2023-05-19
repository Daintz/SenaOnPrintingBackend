using AutoMapper;
using BusinessCape.DTOs.Role;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;

namespace SenaOnPrinting.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(RoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleService.Index();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Show(long id)
        {
            var role = await _roleService.Show(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleCreateDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);

            await _roleService.Create(role);
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, RoleUpdateDto roleDto)
        {
            var role = await _roleService.Show(roleDto.Id);

            await _roleService.Update(role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _roleService.Delete(id);
            return NoContent();
        }
    }
}
