using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;

namespace PersistenceCape.Repositories
{
    public class SupplyCategoryRepository : ISupplyCategoryRepository
    {
        private readonly SENAContext _context;

        public SupplyCategoryRepository(SENAContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplyCategoryModel>> GetAllAsync()
        {
            return await _context.SupplyCategories.ToListAsync();
        }

        public async Task<SupplyCategoryModel> GetByIdAsync(long id)
        {
            return await _context.SupplyCategories.FindAsync(id);
        }

        public async Task UpdateAsync(SupplyCategoryModel supplyCategory)
        {
            _context.Entry(supplyCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<SupplyCategoryModel> AddAsync(SupplyCategoryModel supplyCategory)
        {
            await _context.SupplyCategories.AddAsync(supplyCategory);
            await _context.SaveChangesAsync();
            return supplyCategory;
        }

        public async Task DeleteAsync(long id)
        {
            var supplyCategory = await _context.SupplyCategories.FindAsync(id);
            _context.SupplyCategories.Remove(supplyCategory);
            await _context.SaveChangesAsync();
        }
    }
}
