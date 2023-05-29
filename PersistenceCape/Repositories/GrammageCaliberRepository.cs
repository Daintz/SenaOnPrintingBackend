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
    public class GrammageCaliberRepository:IGrammageCaliberRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public GrammageCaliberRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GrammageCaliberModel>> GetAllAsync()
        {
            return await _context.GrammageCalibers.ToListAsync();
        }

        public async Task<GrammageCaliberModel> GetByIdAsync(long id)
        {
            return await _context.GrammageCalibers.FindAsync(id);
        }

        public async Task UpdateAsync(GrammageCaliberModel grammageCaliber)
        {
            _context.Entry(grammageCaliber).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<GrammageCaliberModel> AddAsync(GrammageCaliberModel grammageCaliber)
        {
            await _context.GrammageCalibers.AddAsync(grammageCaliber);
            await _context.SaveChangesAsync();
            return grammageCaliber;
        }

        public async Task DeleteAsync(long id)
        {
            var grammageCaliber = await _context.GrammageCalibers.FindAsync(id);
            grammageCaliber.StatedAt = !grammageCaliber.StatedAt;
            await _context.SaveChangesAsync();

        }
    }
}
