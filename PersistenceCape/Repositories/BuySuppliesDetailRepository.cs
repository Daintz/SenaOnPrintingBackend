using DataCape.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf.Runtime;

namespace PersistenceCape.Repositories
{
    public class BuySuppliesDetailRepository : IBuySuppliesDetailRepository
    {
        private readonly SENAONPRINTINGContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BuySuppliesDetailRepository(SENAONPRINTINGContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IEnumerable<BuySuppliesDetailModel>> GetAllAsync()
        {
            return await _context.BuySuppliesDetails.ToListAsync();
        }
        //public async Task<IEnumerable<BuySuppliesDetailModel>> GetApprovedQuotationAsync()
        //{
        //    var BuySuppliesDetails = await _context.BuySuppliesDetails
        //.Where(q => q.QuotationClient.QuotationStatus == 2)
        //.Include(qcd => qcd.QuotationClient)
        //        .ThenInclude(qc => qc.Client)
        //.Include(qp => qp.Product)
        //.Include(qcd => qcd.TypeService)
        //.ToListAsync();

        //    var quotationClientIdsInProduction = await _context.OrderProductions
        //.Select(po => po.BuySuppliesDetailId)
        //.Distinct()
        //.ToListAsync();
        //    var filteredBuySuppliesDetails = BuySuppliesDetails
        //    .Where(qcd => !quotationClientIdsInProduction.Contains(qcd.Id))
        //    .Select(qtd => new BuySuppliesDetailModel
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

        //    return filteredBuySuppliesDetails;
        //}
        public async Task<BuySuppliesDetailModel> GetByIdAsync(long id)
        {
            return await _context.BuySuppliesDetails.FindAsync(id);
        }

        public async Task UpdateAsync(BuySuppliesDetailModel buySuppliesDetail)
        {
            _context.Entry(buySuppliesDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<BuySuppliesDetailModel> AddAsync(BuySuppliesDetailModel buySuppliesDetail)
        {
            await _context.BuySuppliesDetails.AddAsync(buySuppliesDetail);
            await _context.SaveChangesAsync();
            return buySuppliesDetail;
        }

        public async Task DeleteAsync(long id)
        {
            var buySuppliesDetail = await _context.BuySuppliesDetails.FindAsync(id);
            buySuppliesDetail.StatedAt = !buySuppliesDetail.StatedAt;
            await _context.SaveChangesAsync();

        }
    }
}
