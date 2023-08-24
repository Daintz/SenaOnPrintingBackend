using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Interfaces;
using PersistenceCape.Views;

namespace PersistenceCape.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public RoleRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleModel>> Index()
        {

            return await _context.Roles.Include(role => role.PermissionsByRoles)
                .ThenInclude(pbr => pbr.Permission).ToListAsync();
            //return await _context.Roles.ToListAsync();
        }

        public async Task<RoleModel> Show(long id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public Task<RoleView> ShowWithPermissions(long id)
        {
            return _context.Roles.Where(role => role.Id == id).Select(role =>
            new RoleView()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                StatedAt = role.StatedAt,
                Permissions = role.PermissionsByRoles
            }).FirstOrDefaultAsync();

            //return await _context.Roles.Include(role => role.PermissionsByRoles).Where(role => role.Id == id)
            //    .FirstOrDefaultAsync();

            //return await _context.Roles.FindAsync(id);
        }

        public async Task Update(RoleModel role)
        {
            _context.Entry(role).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<RoleModel> Create(RoleModel role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task Delete(long id)
        {
            var role = await _context.Roles.FindAsync(id);
            role.StatedAt = !role.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
