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
    public class QuotationClientDetailRepository : IQuotationClientDetailRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public QuotationClientDetailRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuotationClientDetailModel>> GetAllAsync()
        {
            return await _context.QuotationClientDetails.ToListAsync();
        }

        public async Task<QuotationClientDetailModel> GetByIdAsync(long id)
        {
            return await _context.QuotationClientDetails.FindAsync(id);
        }

        public async Task UpdateAsync(QuotationClientDetailModel quotationclientDetail)
        {
            _context.Entry(quotationclientDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<QuotationClientDetailModel> AddAsync(QuotationClientDetailModel quotationclientDetail)
        {
            await _context.QuotationClientDetails.AddAsync(quotationclientDetail);
            await _context.SaveChangesAsync();
            return quotationclientDetail;
        }

        public async Task DeleteAsync(long id)
        {
            var quotationclientDetail = await _context.QuotationClientDetails.FindAsync(id);
            quotationclientDetail.StatedAt = !quotationclientDetail.StatedAt;
            await _context.SaveChangesAsync();

        }
    }
}
