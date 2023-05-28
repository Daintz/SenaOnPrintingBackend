using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;

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
            return await _context.Roles.ToListAsync();
        }

        public async Task<RoleModel> Show(long id)
        {
            return await _context.Roles.FindAsync(id);
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
            role.StatedAt = false;
            await _context.SaveChangesAsync();
        }
    }
}
