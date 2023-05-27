using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Repositories
{
    public class WarehauseTypeRepository:IWarehausetypeRepository
    {
        private readonly SENAONPRINTINGContext _context;
        public WarehauseTypeRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<WarehouseType>> GetAllAsync()
        {
            return await _context.WarehouseTypes.ToListAsync();
        }
        public async Task<WarehouseType> GetByIdAsync(long id)
        {
            return await _context.WarehouseTypes.FindAsync(id);
        }
        public async Task UpdateAsync(WarehouseType warehouseType)
        {
            _context.Entry(warehouseType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<WarehouseType> AddAsync(WarehouseType warehouseType)
        {
            await _context.WarehouseTypes.AddAsync(warehouseType);
            await _context.SaveChangesAsync();
            return warehouseType;

        }

        public async Task DeleteAsync(long id)
        {
            var warehouseType = await _context.WarehouseTypes.FindAsync(id);
            warehouseType.StatedAt = !warehouseType.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
