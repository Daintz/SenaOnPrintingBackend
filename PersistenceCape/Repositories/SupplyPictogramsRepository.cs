using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Repositories
{
    public class SupplyPictogramsRepository : ISupplyPictogramsRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public SupplyPictogramsRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplyPictogramModel>> GetAllAsync()
        {
            return await _context.SupplyPictograms.ToListAsync();
        }

        public async Task<SupplyPictogramModel> GetByIdAsync(long id)
        {
            return await _context.SupplyPictograms.FindAsync(id);
        }

        public async Task UpdateAsync(SupplyPictogramModel supplyPictogram)
        {
            _context.Entry(supplyPictogram).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<SupplyPictogramModel> AddAsync(SupplyPictogramModel supplyPictogram)
        {
            await _context.SupplyPictograms.AddAsync(supplyPictogram);
            await _context.SaveChangesAsync();
            return supplyPictogram;
        }

        public async Task DeleteAsync(long id)
        {
            var supplyPictogram = await _context.SupplyPictograms.FindAsync(id);
            supplyPictogram.StatedAt = !supplyPictogram.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
