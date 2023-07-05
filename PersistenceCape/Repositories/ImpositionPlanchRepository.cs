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
    public class ImpositionPlanchRepository : ControllerBase, IImpositionPlanchRepository
    {
        private readonly SENAONPRINTINGContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImpositionPlanchRepository(SENAONPRINTINGContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IEnumerable<ImpositionPlanchModel>> GetAllAsync()
        {
            return await _context.ImpositionPlanches.ToListAsync();
        }
        
        public async Task<ImpositionPlanchModel> GetByIdAsync(long id)
        {
            return await _context.ImpositionPlanches.FindAsync(id);
        }

        public async Task UpdateAsync(ImpositionPlanchModel impositionPlate)
        {
            _context.Entry(impositionPlate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ImpositionPlanchModel> AddAsync(ImpositionPlanchModel impositionPlate)
        {

            await _context.ImpositionPlanches.AddAsync(impositionPlate);
            await _context.SaveChangesAsync();
            return impositionPlate;
        }

        public async Task ChangeState(long id)
        {
            var impositionPlates = await _context.ImpositionPlanches.FindAsync(id);

            impositionPlates.StatedAt = !impositionPlates.StatedAt;
            await _context.SaveChangesAsync();

        }

    }
}
