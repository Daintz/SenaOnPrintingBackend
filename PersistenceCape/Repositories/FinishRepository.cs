
using DataCape;
using Microsoft.EntityFrameworkCore;
using PersistenceCape.Contexts;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Repositories
{
    public class FinishRepository:IFinishs
    {
       

        
            private readonly SENAONPRINTINGContext _context;

            public FinishRepository(SENAONPRINTINGContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<FinishModel>> GetAllAsync()
            {
                return await _context.Finishes.ToListAsync();
            }

            public async Task<FinishModel> GetByIdAsync(long id)
            {
                return await _context.Finishes.FindAsync(id);
            }

            public async Task UpdateAsync(FinishModel finish)
            {
                _context.Entry(finish).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            public async Task<FinishModel> AddAsync(FinishModel finish)
            {
                await _context.Finishes.AddAsync(finish);
                await _context.SaveChangesAsync();
                return finish;
            }

            public async Task DeleteAsync(long id)
            {
                var Finish= await _context.Finishes.FindAsync(id);

            Finish.StatedAt = !Finish.StatedAt;
            await _context.SaveChangesAsync();

        }

        }
    }

