using DataCape.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;
using System.IO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
namespace PersistenceCape.Repositories
{
    public class SupplyPictogramsRepository  : ControllerBase, ISupplyPictogramsRepository
    {
        private readonly SENAONPRINTINGContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public SupplyPictogramsRepository(SENAONPRINTINGContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IEnumerable<SupplyPictogramModel>> GetAllAsync()
        {
            return await _context.SupplyPictograms
                .Select(x => new SupplyPictogramModel()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    Description = x.Description,
                    PictogramFile=x.PictogramFile,
                    StatedAt = x.StatedAt
                })
                .ToListAsync();
        }

        public async Task<SupplyPictogramModel> GetByIdAsync(long id)
        {
            return await _context.SupplyPictograms.FindAsync(id);
        }

        public async Task UpdateAsync(SupplyPictogramModel supplyPictogram)
        {
            _context.Entry(supplyPictogram).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<SupplyPictogramModel> AddAsync(SupplyPictogramModel supplyPictogram)
        {
            await _context.SupplyPictograms.AddAsync(supplyPictogram);
            await _context.SaveChangesAsync();
            return supplyPictogram;
        }

        public async Task DeleteAsync(long id)
        {
            var supplyPictogram = await _context.SupplyPictograms.FindAsync(id);
            supplyPictogram.StatedAt = !supplyPictogram.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
