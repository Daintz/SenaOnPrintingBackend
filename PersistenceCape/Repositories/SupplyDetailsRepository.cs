using DataCape.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PersistenceCape.Interfaces;


namespace persistencecape.repositories
{
    public class SupplyDetailsRepository : ControllerBase, ISupplyDetailsRepository
    {
        private readonly SENAONPRINTINGContext _context;
        public SupplyDetailsRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplyDetailModel>> GetAllAsync()
        {

            return await _context.SupplyDetails.Include(supplydetail => supplydetail.Supply)
                .ThenInclude(pbr => pbr.SupplyDetail)
                .ToListAsync();




            //return await _context.Roles.ToListAsync();
        }

        public async Task<SupplyDetailModel> GetByIdAsync(long id)
        {
            return await _context.SupplyDetails
                .Include(supplydetail => supplydetail.Supply)
                .ThenInclude(pbr => pbr.SupplyDetail)
                .FirstOrDefaultAsync(d => d.Id == id);
        }



        public async Task UpdateAsync(SupplyDetailModel supplyDetail)
        {
            _context.Entry(supplyDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    

        public async Task<SupplyDetailModel> AddAsync(SupplyDetailModel supplyDetail)
        {
            await _context.SupplyDetails.AddAsync(supplyDetail);
            await _context.SaveChangesAsync();
            return supplyDetail;
        }
        //public async Task<IEnumerable<SupplySupplyDetailsModel>> GetSupplyDetailsForSupplyAsync(long supplyDetail)
        //{
        //    var query = from det in _context.SupplySupplyDetails
        //                join com in _context.Supplies on det.SupplyId equals com.Id
        //                where det.SupplyDetailsId == supplyDetail
        //                select new SupplySupplyDetailsModel
        //                {
        //                    SupplyDetailsId = det.SupplyDetailsId,
        //                    SupplyId = com.Id,
        //                    Quantity = det.Quantity,
        //                    SupplyCost = det.SupplyCost
        //                };

        //    return await query.ToListAsync();
        //}


        public async Task ChangeState(long id)
        {
            var supplyDetailsRepository = await _context.SupplyDetails.FindAsync(id);

            supplyDetailsRepository.StatedAt = !supplyDetailsRepository.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
