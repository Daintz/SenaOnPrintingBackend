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
    public class ImpositionPlateRepository : IImpositionPlateRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public ImpositionPlateRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ImpositionPlateModel>> GetAllAsync()
        {
            return await _context.ImpositionPlates.ToListAsync();
        }

        public async Task<ImpositionPlateModel> GetByIdAsync(long id)
        {
            return await _context.ImpositionPlates.FindAsync(id);
        }

        public async Task UpdateAsync(ImpositionPlateModel impositionPlate)
        {
            _context.Entry(impositionPlate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<ImpositionPlateModel> AddAsync(ImpositionPlateModel impositionPlate)
        {
            await _context.ImpositionPlates.AddAsync(impositionPlate);
            await _context.SaveChangesAsync();
            return impositionPlate;
        }

        public async Task ChangeState(long id)
        {
            var impositionPlates = await _context.ImpositionPlates.FindAsync(id);

            impositionPlates.StatedAt = !impositionPlates.StatedAt;
            _context.ImpositionPlates.Update(impositionPlates);
            await _context.SaveChangesAsync();

        }

    }
}
