using DataCape;

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
    public class UnitMeasurreRepository : IUnitMesure

    {
        private readonly SENAONPRINTINGContext _context;

        public UnitMeasurreRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UnitMeasureModel>> GetAllAsync()
        {
            return await _context.UnitMeasures.ToListAsync();
        }

        public async Task<UnitMeasureModel> GetByIdAsync(long id)
        {
            return await _context.UnitMeasures.FindAsync(id);
        }

        public async Task UpdateAsync(UnitMeasureModel Unit)
        {
            _context.Entry(Unit).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<UnitMeasureModel> AddAsync(UnitMeasureModel Unit)
        {
            await _context.UnitMeasures.AddAsync(Unit);
            await _context.SaveChangesAsync();
            return Unit;
        }

        public async Task DeleteAsync(long id)
        {
            var Unit = await _context.UnitMeasures.FindAsync(id);

            Unit.StatedAt = !Unit.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}

    

 