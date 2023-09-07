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
    public class WarehauseRepository:IWarehauseRepository
    {
        private readonly SENAONPRINTINGContext _context;
        public WarehauseRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<WarehouseModel>> GetAllAsync()
        {
            return await _context.Warehouses.Include(x => x.TypeServices).ToListAsync(); 
        }
        public async Task<WarehouseModel> GetByIdAsync(long id)
        {
            return await _context.Warehouses.FindAsync(id);
        }
        public async Task UpdateAsync(WarehouseModel WarehouseModel)
        {
            _context.Entry(WarehouseModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<WarehouseModel> AddAsync(WarehouseModel WarehouseModel)
        {
            await _context.Warehouses.AddAsync(WarehouseModel);
            await _context.SaveChangesAsync();
            return WarehouseModel;

        }

        public async Task DeleteAsync(long id)
        {
            var WarehouseModel = await _context.Warehouses.FindAsync(id);
            WarehouseModel.StatedAt = !WarehouseModel.StatedAt;
            await _context.SaveChangesAsync();

        }
          
        
    }
}
