using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Interfaces;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
namespace PersistenceCape.Repositories

{
    public class QuotationProviderRepository : ControllerBase, IQuotationProviderRepository
    {
        private readonly SENAONPRINTINGContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public QuotationProviderRepository(SENAONPRINTINGContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;

        }

        public async Task<IEnumerable<QuotationProviderModel>> GetAllAsync()
        {
            return await _context.QuotationProviders.Select(x => new QuotationProviderModel
            {
                Id = x.Id,
                QuotationDate = x.QuotationDate,
                QuotationFile = x.QuotationFile,
                FullValue = x.FullValue,
                ProviderId = x.ProviderId,
                StatedAt = x.StatedAt,
            }).ToListAsync();

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
