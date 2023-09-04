using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Interfaces;

namespace PersistenceCape.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public ProductRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            return await _context.Products.Include(s => s.Supplies).ThenInclude(s => s.Supply).ToListAsync();
        }

        public async Task<ProductModel> GetByIdAsync(long id)
        {
            return await _context.Products.Include(s => s.Supplies).ThenInclude(s => s.Supply).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(ProductModel product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ProductModel> AddAsync(ProductModel product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(long id)
        {
            var ProductsModel = await _context.Products.FindAsync(id);
            ProductsModel.StatedAt = !ProductsModel.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}

