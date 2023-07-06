using AutoMapper;
using BusinessCape.DTOs.Role;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Mvc;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;
using System.Web.Http.Filters;

namespace SenaOnPrinting.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        private readonly IMapper _mapper;
        private readonly SENAONPRINTINGContext _context;

        public RoleController(RoleService roleService, IMapper mapper, SENAONPRINTINGContext context)
        {
            _roleService = roleService;
            _mapper = mapper;
            _context = context;
        }

       // [AuthorizationFilter(ApplicationPermission.ReadRole)]
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
            var role = _mapper.Map<RoleModel>(roleDto);

            //foreach (var permissionId in roleDto.PermissionIds)
            //{
            //    var permission = await _context.ApplicationPermissions.FindAsync(permissionId);
            //    if (permission == null)
            //    {
            //        return BadRequest("Uno de los Ids rol no existe, por favor rectifique");
            //    }
            //    role.Permissions.Add(permission);
            //}

            //var permissions = _context.ApplicationPermissions.Where(p => roleDto.PermissionIds.Contains(p.Id)).ToList();
            //role.Permissions = permissions; 

            await _roleService.Create(role);
            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, RoleUpdateDto roleDto)
        {
            var role = await _roleService.Show(roleDto.Id);
            _mapper.Map(roleDto, role);
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
