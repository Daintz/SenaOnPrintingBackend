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
    public class QuotationClientRepository : IQuotationClientRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public QuotationClientRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuotationClientModel>> GetAllAsync()
        {
            return await _context.QuotationClients.ToListAsync();
        }

        public async Task<QuotationClientModel> GetByIdAsync(long Id)
        {
            return await _context.QuotationClients.FindAsync(Id);
        }

        public async Task UpdateAsync(QuotationClientModel quotationclient)
        {
            _context.Entry(quotationclient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<QuotationClientModel> AddAsync(QuotationClientModel quotationclient)
        {
            await _context.QuotationClients.AddAsync(quotationclient);
            await _context.SaveChangesAsync();
            return quotationclient;
        }

        public async Task DeleteAsync(long Id)
        {
            var quotationclient = await _context.QuotationClients.FindAsync(Id);
            _context.QuotationClients.Remove(quotationclient);
            await _context.SaveChangesAsync();
        }
    }
}
