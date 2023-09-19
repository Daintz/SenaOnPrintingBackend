using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Interfaces;


namespace persistencecape.repositories
{
    public class BuySupplyRepository : IBuySupplyRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public BuySupplyRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BuySupplyModel>> Index()
        {
            return await _context.BuySupplies.ToListAsync();
        }

        public async Task<BuySupplyModel> Show(long id)
        {
            return await _context.BuySupplies.FindAsync(id);
        }

        public async Task Update(BuySupplyModel buySupply)
        {
            _context.Entry(buySupply).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    

        public async Task<BuySupplyModel> Create(BuySupplyModel buySupply)
        {
            await _context.BuySupplies.AddAsync(buySupply);
            await _context.SaveChangesAsync();
            return buySupply;
        }

        public async Task ChangeState(long id)
        {
            var buySupply = await _context.BuySupplies.FindAsync(id);

            buySupply.StatedAt = !buySupply.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
