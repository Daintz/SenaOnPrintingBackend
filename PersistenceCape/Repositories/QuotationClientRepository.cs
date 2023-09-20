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
    public class QuotationClientRepository : IQuotationClientRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public QuotationClientRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuotationClientModel>> GetAllAsync()
        {
            return await _context.QuotationClients
       .Include(x => x.Client) // Incluye los datos del cliente relacionado
       .Include(x => x.QuotationClientDetails) // Incluye los detalles de la cotización relacionados
           .ThenInclude(detail => detail.Product) // Incluye los productos relacionados en los detalles
       .ToListAsync();
        }

        public async Task<QuotationClientModel> GetByIdAsync(long id)
        {
            return await _context.QuotationClients.FindAsync(id);
        }

        public async Task<int> GetLastQuotationCodeAsync()
        {
            var lastQuotation = await _context.QuotationClients
                .OrderByDescending(qc => qc.Code)
                .FirstOrDefaultAsync();

            if (lastQuotation != null)
            {
                return lastQuotation.Code;
            }

            // Si no hay cotizaciones registradas, puedes devolver un valor predeterminado o lanzar una excepción.
            return 1; // Valor predeterminado si no hay cotizaciones.
        }

        public async Task UpdateAsync(QuotationClientModel quotationClient)
        {
            _context.Entry(quotationClient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<QuotationClientModel>> GetApprovedQuotationAsync()
        {
            var quotationClients = await _context.QuotationClients
                .Where(qc => qc.QuotationStatus == 2)
                .Include(qc => qc.Client)
                .Include(qc => qc.QuotationClientDetails)
                    .ThenInclude(qcd => qcd.Product)
                .Include(qc => qc.QuotationClientDetails)
                    .ThenInclude(qcd => qcd.TypeServiceModel)
                .Select(qc => new QuotationClientModel
                {
                    Id = qc.Id,
                    UserId = qc.UserId,
                    ClientId = qc.ClientId,
                    Code = qc.Code,
                    OrderDate = qc.OrderDate,
                    DeliverDate = qc.DeliverDate,
                    QuotationStatus = qc.QuotationStatus,
                    FullValue = qc.FullValue,
                    StatedAt = qc.StatedAt,
                    Name = qc.Client.Name
                })
                .ToListAsync();

            var quotationClientDetails = await _context.QuotationClientDetails
                .Select(qcd => new QuotationClientDetailModel
                {
                    Id = qcd.Id,
                    QuotationClientId = qcd.QuotationClientId,
                    TypeServiceId = qcd.TypeServiceId,
                    ProductId = qcd.ProductId,
                    Cost = qcd.Cost,
                    Quantity = qcd.Quantity,
                    StatedAt = qcd.StatedAt,
                    ProductName = qcd.Product.Name,
                    TypeServiceName = qcd.TypeServiceModel.Name,
                })
                .ToListAsync();

            var quotationClientIdsInProduction = await _context.OrderProductions
                .Select(po => po.QuotationClientDetailId)
                .Distinct()
                .ToListAsync();

            // Filtra las cotizaciones que ya están en orden de producción
            quotationClients = quotationClients
                .Where(qc => !quotationClientIdsInProduction.Contains(qc.Id))
                .ToList();

            // Combina las propiedades en la lista de cotizaciones cliente
            foreach (var quotationClient in quotationClients)
            {
                quotationClient.QuotationClientDetails = quotationClientDetails
                    .Where(qcd => qcd.QuotationClientId == quotationClient.Id)
                    .ToList();
            }

            return quotationClients;
        }


        public async Task<QuotationClientModel> AddAsync(QuotationClientModel quotationClient)
        {
            await _context.QuotationClients.AddAsync(quotationClient);
            await _context.SaveChangesAsync();
            return quotationClient;
        }

        public async Task DeleteAsync(long id)
        {
            var quotationClient = await _context.QuotationClients.FindAsync(id);
            quotationClient.StatedAt = !quotationClient.StatedAt;
            await _context.SaveChangesAsync();

        }
        public async Task ChangeStatusQuotation(long id)
        {
            var quotationClient = await _context.QuotationClients.FindAsync(id);
            if (quotationClient.QuotationStatus == 1)
            {
                quotationClient.QuotationStatus = 2;
            }
            else if (quotationClient.QuotationStatus == 2)
            {
                quotationClient.QuotationStatus = 3;
            }
            await _context.SaveChangesAsync();
        }
    }
}

