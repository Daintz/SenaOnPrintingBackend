using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Interfaces;


namespace persistencecape.repositories
{
    public class SupplyDetailsRepository : ISupplyDetailsRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public SupplyDetailsRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplyDetailModel>> GetAllAsync()
        {
            return await _context.SupplyDetails.ToListAsync();
        }

        public async Task<SupplyDetailModel> GetByIdAsync(long id)
        {
            return await _context.SupplyDetails.FindAsync(id);
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

        public async Task ChangeState(long id)
        {
            var supplyDetailsRepository = await _context.SupplyDetails.FindAsync(id);

            supplyDetailsRepository.StatedAt = !supplyDetailsRepository.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
