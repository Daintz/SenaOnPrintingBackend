using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;

namespace PersistenceCape.Repositories
{
    public class QuotationProviderRepository : IQuotationProviderRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public QuotationProviderRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuotationProviderModel>> GetAllAsync()
        {
            return await _context.QuotationProviders.ToListAsync();
        }

        public async Task<QuotationProviderModel> GetByIdAsync(long id)
        {
            return await _context.QuotationProviders.FindAsync(id);
        }

        public async Task UpdateAsync(QuotationProviderModel quotationProvider)
        {
            _context.Entry(quotationProvider).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<QuotationProviderModel> AddAsync(QuotationProviderModel quotationProvider)
        {
            await _context.QuotationProviders.AddAsync(quotationProvider);
            await _context.SaveChangesAsync();
            return quotationProvider;
        }

        public async Task DeleteAsync(long id)
        {
            var quotationProvider = await _context.QuotationProviders.FindAsync(id);
            quotationProvider.StatedAt=!quotationProvider.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
