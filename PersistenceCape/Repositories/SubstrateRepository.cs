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
    public class SubstrateRepository:ISubstratesRepository
    {

        private readonly SENAONPRINTINGContext _context;

        public SubstrateRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubstrateModel>> GetAllAsync()
        {
            return await _context.Substrates.ToListAsync();
        }

        public async Task<SubstrateModel> GetByIdAsync(long id)
        {
            return await _context.Substrates.FindAsync(id);
        }

        public async Task UpdateAsync(SubstrateModel substrate)
        {
            _context.Entry(substrate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<SubstrateModel> AddAsync(SubstrateModel substrate)
        {
            await _context.Substrates.AddAsync(substrate);
            await _context.SaveChangesAsync();
            return substrate;
        }

        public async Task DeleteAsync(long id)
        {
            var substrate = await _context.Substrates.FindAsync(id);
            substrate.StatedAt = !substrate.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
