using DataCape.Models;
using Microsoft.EntityFrameworkCore;

using PersistenceCape.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace PersistenceCape.Repositories
{
    public class OrderProductionRepository : IOrderProductionRepository
    {
        private readonly SENAONPRINTINGContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrderProductionRepository(SENAONPRINTINGContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<OrderProductionModel>> GetAllAsync()
        {
            var scheme = "https";
            var host = _httpContextAccessor.HttpContext.Request.Host.Value;
            var pathBase = _httpContextAccessor.HttpContext.Request.PathBase.Value;
            return await _context.OrderProductions
         .Include(op => op.QuotationClientDetail)
            .ThenInclude(qcd => qcd.QuotationClient)
                .ThenInclude(qc => qc.Client)
        .Include(op => op.QuotationClientDetail)
            .ThenInclude(qp => qp.Product)
        .Select(op => new OrderProductionModel()
        {
            Id = op.Id,
            QuotationClientDetailId = op.QuotationClientDetail.Id,
            OrderDate = op.QuotationClientDetail.QuotationClient.OrderDate,
            Name = op.QuotationClientDetail.QuotationClient.Client.Name,
            Product = op.QuotationClientDetail.Product.Name,
            DeliverDate = op.QuotationClientDetail.QuotationClient.DeliverDate,
            OrderStatus = op.OrderStatus,
            StatedAt = op.StatedAt,
            MaterialReception = op.MaterialReception,
            ProgramVersion = op.ProgramVersion,
            ColorProfile = op.ColorProfile,
            Image = $"{scheme}://{host}/{pathBase}Images/OrderProduction/{op.Image}",
            Observations = op.Observations,
            Program = op.Program,
            TypePoint = op.TypePoint,
            Scheme = $"{scheme}://{host}/{pathBase}Images/OrderProduction/{op.Scheme}",
            
        })
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
        public async Task ChangeOrderStatus(long id)
        {
            var orderProduction = await _context.OrderProductions.FindAsync(id);
            if (orderProduction.OrderStatus == 2)
            {
                orderProduction.OrderStatus = 3;
            }
            else if (orderProduction.OrderStatus == 3) { 
                orderProduction.OrderStatus = 4;
            }
            else
            {
                orderProduction.OrderStatus = 5;
            }
            await _context.SaveChangesAsync();
        }
    }
}
