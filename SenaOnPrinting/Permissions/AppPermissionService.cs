
using DataCape.Models;
using Microsoft.EntityFrameworkCore;


namespace SenaOnPrinting.Permissions
{
    public class AppPermissionService : IAppPermissionService
    {
        private readonly SENAONPRINTINGContext _context;

        public AppPermissionService(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<HashSet<string>> GetPermissionsAsync(long id)
        {
            ICollection<RoleModel> role = await _context.Set<UserModel>()
                .Include(x => x.Role)
                .ThenInclude(x => x.PermissionsByRoles)
                .ThenInclude(x => x.Permission)
                .Where(x => x.Id == id)
                .Select(x => x.Role)
                .ToArrayAsync();

            var permissions = role.SelectMany(x => x.PermissionsByRoles).Select(x => x.Permission.Name).ToHashSet();

            return permissions;
        }
    }
}
