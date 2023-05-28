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
    public class WarehauseRepository:IWarehauseRepository
    {
        private readonly SENAONPRINTINGContext _context;
        public WarehauseRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return await _context.Warehouses.ToListAsync(); 
        }
        public async Task<Warehouse> GetByIdAsync(long id)
        {
            return await _context.Warehouses.FindAsync(id);
        }
        public async Task UpdateAsync(Warehouse Warehouse)
        {
            _context.Entry(Warehouse).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Warehouse> AddAsync(Warehouse Warehouse)
        {
            await _context.Warehouses.AddAsync(Warehouse);
            await _context.SaveChangesAsync();
            return Warehouse;

        }

        public async Task DeleteAsync(long id)
        {
            var Warehouse = await _context.Warehouses.FindAsync(id);
            Warehouse.StatedAt = !Warehouse.StatedAt;
            await _context.SaveChangesAsync();

        }
          
        
    }
}
