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

        public async Task<QuotationClientModel> GetByIdAsync(long id)
        {
            return await _context.QuotationClients.FindAsync(id);
        }

        public async Task UpdateAsync(QuotationClientModel quotationClient)
        {
            _context.Entry(quotationClient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<QuotationClientModel> AddAsync(QuotationClientModel quotationClient)
        {
            await _context.QuotationClients.AddAsync(quotationClient);
            await _context.SaveChangesAsync();
            return quotationClient;
        }

        public async Task DeleteAsync(long id)
        {
            var quotationClient = await _context.QuotationClients.FindAsync(id);
            quotationClient.StatedAt = !quotationClient.StatedAt;
            await _context.SaveChangesAsync();

        }
        public async Task ChangeQuotationStatus(long id)
        {
            var quotationClient = await _context.QuotationClients.FindAsync(id);
            if (quotationClient.QuotationStatus == 1)
            {
                quotationClient.QuotationStatus = 2;
            }
            else if (quotationClient.QuotationStatus == 2)
            {
                quotationClient.QuotationStatus = 3;
            }
            await _context.SaveChangesAsync();
        }
    }
}

