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
    public class SupplySupplyDetailsRepository : ISupplySupplyDetailsRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public SupplySupplyDetailsRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplySupplyDetailsModel>> GetAllAsync()
        {
            return await _context.SupplySupplyDetails.ToListAsync();
        }

        public async Task<SupplySupplyDetailsModel> GetByIdAsync(long id)
        {
            return await _context.SupplySupplyDetails.FindAsync(id);
        }


        public async Task UpdateAsync(SupplySupplyDetailsModel supplySupplyDetail)
        {
            _context.Entry(supplySupplyDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //public async Task<IEnumerable<SupplyDetailModel>> GetSuppplySupplyAsync()
        //{
        //    var supplyDetails = await _context.SupplyDetails
        //        .Include(ss => ss.Supplies)
        //            .ThenInclude(ssd => ssd.Supply)
        //        .Select(ss => new SupplyDetailModel
        //        {
        //            Id = ss.Id,
        //            ProviderId = ss.ProviderId,
        //            Description = ss.Description,
        //            EntryDate = ss.EntryDate,
        //            FullValue = ss.FullValue,
        //            StatedAt = ss.StatedAt,
        //        })
        //        .ToListAsync();

        //    var supplySupplyDetails = await _context.SupplySupplyDetails
        //        .Select(ssd => new SupplySupplyDetailsModel
        //        {
        //            Id = ssd.Id,
        //            SupplyId = ssd.SupplyId,
        //            supplydetails_id = ssd.supplydetails_id,
        //            Quantity = ssd.Quantity,
        //            SupplyCost = ssd.SupplyCost,
        //            SupplyName = ssd.Supply.Name,
        //        })
        //        .ToListAsync();



        //    // Combina las propiedades en la lista de cotizaciones cliente
        //    foreach (var supplyDetail in supplyDetails)
        //    {
        //        supplyDetail.Supplies = supplySupplyDetails
        //            .Where(ssd => ssd.supplydetails_id == supplyDetail.Id)
        //            .ToList();
        //    }

        //    return supplyDetails;
        //}

        public async Task<SupplySupplyDetailsModel> AddAsync(SupplySupplyDetailsModel supplySupplyDetail)
        {
            await _context.SupplySupplyDetails.AddAsync(supplySupplyDetail);
            await _context.SaveChangesAsync();
            return supplySupplyDetail;
        }

        


    }
}
