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
        //public async Task<IEnumerable<QuotationClientDetailModel>> GetApprovedQuotationAsync()
        //{
        //    var quotationClientDetails = await _context.QuotationClientDetails
        //.Where(q => q.QuotationClient.QuotationStatus == 2)
        //.Include(qcd => qcd.QuotationClient)
        //        .ThenInclude(qc => qc.Client)
        //.Include(qp => qp.Product)
        //.Include(qcd => qcd.TypeService)
        //.ToListAsync();

        //    var quotationClientIdsInProduction = await _context.OrderProductions
        //.Select(po => po.QuotationClientDetailId)
        //.Distinct()
        //.ToListAsync();
        //    var filteredQuotationClientDetails = quotationClientDetails
        //    .Where(qcd => !quotationClientIdsInProduction.Contains(qcd.Id))
        //    .Select(qtd => new QuotationClientDetailModel
        //    {
        //        Id = qtd.Id,
        //        OrderDate = qtd.QuotationClient.OrderDate,
        //        DeliverDate = qtd.QuotationClient.DeliverDate,
        //        ProductName = qtd.Product.Name,
        //        Name = qtd.QuotationClient.Client.Name,
        //        QuotationClientId = qtd.QuotationClientId,
        //        TypeService = qtd.TypeService,
        //        Quantity = qtd.Quantity


        //    });

        //    return filteredQuotationClientDetails;
        //}
        public async Task<QuotationClientDetailModel> GetByIdAsync(long id)
        {

            return await _context.QuotationClientDetails
                .Include(supply => supply.Product)
                .ThenInclude(pbr => pbr.QuotationClientDetails)
                .FirstOrDefaultAsync(d => d.Id == id);


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
