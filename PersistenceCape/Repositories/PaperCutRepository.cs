using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PersistenceCape.Repositories
{
    public class PaperCutRepository:IPaperCutRepository
    {

        private readonly SENAONPRINTINGContext _context;

        public PaperCutRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PaperCutModel>> GetAllAsync()
        {
            return await _context.PaperCuts.ToListAsync();
        }

        public async Task<PaperCutModel> GetByIdAsync(long id)
        {
            return await _context.PaperCuts.FindAsync(id);
        }

        public async Task UpdateAsync(PaperCutModel paperCut)
        {
            _context.Entry(paperCut).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<PaperCutModel> AddAsync(PaperCutModel paperCut)
        {
            await _context.PaperCuts.AddAsync(paperCut);
            await _context.SaveChangesAsync();
            return paperCut;
        }

        public async Task DeleteAsync(long id)
        {
            var paperCut = await _context.PaperCuts.FindAsync(id);
            paperCut.StatedAt = !paperCut.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
