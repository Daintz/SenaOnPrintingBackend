using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Interfaces;


namespace PersistenceCape.Repositories
{
    public class LineatureRepository : ILineatureRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public LineatureRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LineatureModel>> GetAllAsync()
        {
            return await _context.Lineatures.ToListAsync();
        }

        public async Task<LineatureModel> GetByIdAsync(long id)
        {
            return await _context.Lineatures.FindAsync(id);
        }

        public async Task UpdateAsync(LineatureModel lineture)
        {
            _context.Entry(lineture).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<LineatureModel> AddAsync(LineatureModel lineture)
        {
            await _context.Lineatures.AddAsync(lineture);
            await _context.SaveChangesAsync();
            return lineture;
        }

        public async Task ChangeState(long id)
        {
            var lineatures = await _context.Lineatures.FindAsync(id);
            
                lineatures.StatedAt = !lineatures.StatedAt;
                await _context.SaveChangesAsync();
            
        }



    }
}
