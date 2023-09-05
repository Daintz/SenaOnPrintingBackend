using AutoMapper;
using BusinessCape.DTOs.Role;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Controllers
{

    //[Authorize]
    [ApiController]
    [Route("api/role")]
    //[AuthorizationFilter(ApplicationPermission.User)]
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await _roleService.Index();
            return Ok(roles);
        }

        [HttpGet("test/{id}")]
        public async Task<IActionResult> Show(long id)
        {
            var role = await _roleService.Show(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> ShowWithPermissions(long id)
        {
            var role = await _roleService.ShowWithPermissions(id);
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
            await _roleService.Create(role);

            foreach (var permissionId in roleDto.PermissionIds)
            {
                var permission = await _context.ApplicationPermissions.FindAsync(permissionId);
                if (permission == null)
                {
                    return BadRequest("Uno de los Ids rol no existe, por favor rectifique");
                }

                var permissionsByRole = new PermissionsByRoleModel
                {
                    RoleId = role.Id,
                    PermissionId = permission.Id
                };

                _context.PermissionsByRoles.Add(permissionsByRole);
            }

            //var permissions = _context.ApplicationPermissions.Where(p => roleDto.PermissionIds.Contains(p.Id)).ToList();
            //role.Permissions = permissions;

            await _context.SaveChangesAsync();
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
