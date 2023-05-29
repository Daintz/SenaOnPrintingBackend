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
    public class ImpositionPlanchRepository : IImpositionPlanchRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public ImpositionPlanchRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ImpositionPlanchModel>> GetAllAsync()
        {
            return await _context.ImpositionPlanches.ToListAsync();
        }

        public async Task<ImpositionPlanchModel> GetByIdAsync(long id)
        {
            return await _context.ImpositionPlanches.FindAsync(id);
        }

        public async Task UpdateAsync(ImpositionPlanchModel impositionPlate)
        {
            _context.Entry(impositionPlate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<ImpositionPlanchModel> AddAsync(ImpositionPlanchModel impositionPlate)
        {
            await _context.ImpositionPlanches.AddAsync(impositionPlate);
            await _context.SaveChangesAsync();
            return impositionPlate;
        }

        public async Task ChangeState(long id)
        {
            var impositionPlates = await _context.ImpositionPlanches.FindAsync(id);

            impositionPlates.StatedAt = !impositionPlates.StatedAt;
            await _context.SaveChangesAsync();

        }

    }
}
