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
    public class ProviderRepository:IProviderRepository
    {
        private readonly SENAONPRINTINGContext _context;
        public ProviderRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProviderModel>> GetAllAsync()
        {
            return await _context.Providers.ToListAsync();
        }
        public async Task<ProviderModel> GetByIdAsync(long id)
        {
            return await _context.Providers.FindAsync(id);
        }
        public async Task UpdateAsync(ProviderModel Provider)
        {
            _context.Entry(Provider).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ProviderModel> AddAsync(ProviderModel Provider)
        {
          await _context.Providers.AddAsync(Provider);
          await _context.SaveChangesAsync();
          return Provider;

        }

        public async Task DeleteAsync(long id)
        {
          var provider=await _context.Providers.FindAsync(id);
          _context.Remove(provider);
          await _context.SaveChangesAsync();
        }



    }
}
