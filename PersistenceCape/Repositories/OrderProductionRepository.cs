﻿using DataCape.Models;
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
         .Where(op => op.QuotationClientDetail.QuotationClient.QuotationStatus == 1) // Comparar con el valor numérico para aprobado
         .Include(op => op.QuotationClientDetail)
            .ThenInclude(qcd => qcd.QuotationClient)
                .ThenInclude(qc => qc.Client)
        .Include(op => op.QuotationClientDetail)
            .ThenInclude(qp => qp.Product)
        .Select(op => new OrderProductionModel
        {
            Id = op.Id,
            QuotationClientDetailId = op.QuotationClientDetail.QuotationClient.Id,
            OrderDate = op.QuotationClientDetail.QuotationClient.OrderDate,
            Name = op.QuotationClientDetail.QuotationClient.Client.Name,
            Product = op.QuotationClientDetail.Product.Name,
            DeliverDate = op.QuotationClientDetail.QuotationClient.DeliverDate,
            OrderStatus = op.OrderStatus,
            StatedAt = op.StatedAt,
            MaterialReception = op.MaterialReception,
            ProgramVersion = op.ProgramVersion,
            ColorProfile = op.ColorProfile,
            SpecialInk = op.SpecialInk,
            InkCode = op.InkCode,
            IdPaperCut = op.IdPaperCut,
            Image = op.Image,
            Observations = op.Observations,
            Program = op.Program,
            TypePoint = op.TypePoint,
            Scheme = op.Scheme
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

    }
}
