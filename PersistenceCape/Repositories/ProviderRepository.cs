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
        public async Task<IEnumerable<Provider>> GetAllAsync()
        {
            return await _context.Providers.ToListAsync();
        }
        public async Task<Provider> GetByIdAsync(long id)
        {
            return await _context.Providers.FindAsync(id);
        }
        public async Task UpdateAsync(Provider provider)
        {
            _context.Entry(provider).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Provider> AddAsync(Provider provider)
        {
          await _context.Providers.AddAsync(provider);
          await _context.SaveChangesAsync();
          return provider;

        }

        public async Task DeleteAsync(long id)
        {
          

            var provider=await _context.Providers.FindAsync(id);

            provider.StatedAt = !provider.StatedAt;
            await _context.SaveChangesAsync();
        }



    }
}
