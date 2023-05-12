using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;

namespace PersistenceCape.Repositories
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly SENAContext _context;

        public SupplyRepository(SENAContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplyModel>> GetAllAsync()
        {
            return await _context.Supplies.ToListAsync();
        }

        public async Task<SupplyModel> GetByIdAsync(Guid id)
        {
            return await _context.Supplies.FindAsync(id);
        }

        public async Task UpdateAsync(SupplyModel supplyCategory)
        {
            _context.Entry(supplyCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<SupplyModel> AddAsync(SupplyModel supplyCategory)
        {
            await _context.Supplies.AddAsync(supplyCategory);
            await _context.SaveChangesAsync();
            return supplyCategory;
        }

        public async Task DeleteAsync(Guid id)
        {
            var supplyCategory = await _context.Supplies.FindAsync(id);
            _context.Supplies.Remove(supplyCategory);
            await _context.SaveChangesAsync();
        }
    }
}
