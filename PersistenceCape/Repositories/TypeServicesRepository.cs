using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;

namespace PersistenceCape.Repositories
{
    public class TypeServicesRepository : ITypeServicesRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public TypeServicesRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeServiceModel>> GetAllAsync()
        {
            return await _context.TypeServices.ToListAsync();
        }
        public async Task<TypeServiceModel> GetByIdAsync(long id)
        {
            return await _context.TypeServices.FindAsync(id);
        }

        public async Task UpdateAsync(TypeServiceModel typeService)
        {
            _context.Entry(typeService).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<TypeServiceModel> AddAsync(TypeServiceModel typeService)
        {
            await _context.TypeServices.AddAsync(typeService);
            await _context.SaveChangesAsync();
            return typeService;
        }

        public async Task DeleteAsync(long id)
        {
            var typeService = await _context.TypeServices.FindAsync(id);
            typeService.StatedAt = !typeService.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
