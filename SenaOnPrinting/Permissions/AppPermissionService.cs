
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
                .ThenInclude(x => x.Permissions)
                .Where(x => x.Id == id)
                .Select(x => x.Role)
                .ToArrayAsync();

            var permissions = role.SelectMany(x => x.Permissions).Select(x => x.Name).ToHashSet();

            return permissions;
        }
    }
}
