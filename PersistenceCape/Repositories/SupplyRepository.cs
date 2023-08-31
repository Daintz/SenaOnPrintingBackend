using DataCape.Models;
using Microsoft.EntityFrameworkCore;

using PersistenceCape.Interfaces;
using System.Data;

namespace PersistenceCape.Repositories
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public SupplyRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplyModel>> GetAllAsync()
        //{
        //    return await _context.Supplies.ToListAsync();
        //}
        {

            return await _context.Supplies.Include(supply => supply.SupplyCategoriesXSupply)
                .ThenInclude(pbr => pbr.SupplyCategoryId)
                //.Include(supply => supply.SupplyXSupplyPictogram)
                //.ThenInclude(pbr => pbr.SupplyPictogram)
                .Include(supply => supply.UnitMeasuresXSupply)
                .ThenInclude(pbr => pbr.UnitMeasure)
                .ToListAsync();

          


            //return await _context.Roles.ToListAsync();
        }

    public async Task<SupplyModel> GetByIdAsync(long id)
        {
            return await _context.Supplies.FindAsync(id);
        }
        public async Task UpdateAsync(SupplyModel supply)
        {
            _context.Entry(supply).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task<SupplyModel> AddAsync(SupplyModel supply)
        {
            await _context.Supplies.AddAsync(supply);
            await _context.SaveChangesAsync();
            return supply;
        }

        public async Task ChangeState(long id)
        {
            var supplyRepository = await _context.Supplies.FindAsync(id);

            supplyRepository.StatedAt = !supplyRepository.StatedAt;
            await _context.SaveChangesAsync();
        }


     
    }
}
