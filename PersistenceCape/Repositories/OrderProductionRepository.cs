using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PersistenceCape.Repositories
{
    public class OrderProductionRepository : IOrderProductionRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public OrderProductionRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderProductionModel>> GetAllAsync()
        {
            return await _context.OrderProductions
                .Include(op => op.QuotationClientDetail)
         .Where(op => op.QuotationClientDetail.QuotationClient.QuotationStatus == 2) // Comparar con el valor numérico para aprobado
         .ToListAsync();
        }

        public async Task<OrderProductionModel> GetByIdAsync(long id)
        {
            return await _context.OrderProductions.FindAsync(id);
        }

        public async Task UpdateAsync(OrderProductionModel orderProduction)
        {
            _context.Entry(orderProduction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<OrderProductionModel> AddAsync(OrderProductionModel orderProduction)
        {
            await _context.OrderProductions.AddAsync(orderProduction);
            await _context.SaveChangesAsync();
            return orderProduction;
        }

        public async Task ChangeState(long id)
        {
            var orderProduction = await _context.OrderProductions.FindAsync(id);
            orderProduction.StatedAt = !orderProduction.StatedAt;
            await _context.SaveChangesAsync();
        }      

    }
}
