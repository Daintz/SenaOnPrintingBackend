using DataCape;

using Microsoft.EntityFrameworkCore;

using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.Repositories
{
    public class MachinesRepository : IMachinesRepository

    {
        private readonly SENAONPRINTINGContext _context;

        public MachinesRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Machine>> GetAllAsync()
        {
            return await _context.Machines.ToListAsync();
        }

        public async Task<Machine> GetByIdAsync(long id)
        {
            return await _context.Machines.FindAsync(id);
        }

        public async Task UpdateAsync(Machine machine)
        {
            _context.Entry(machine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Machine> AddAsync(Machine machine)
        {
            await _context.Machines.AddAsync(machine);
            await _context.SaveChangesAsync();
            return machine;
        }

        public async Task DeleteAsync(long id)
        {
            var machine = await _context.Machines.FindAsync(id);

            machine.StatedAt = !machine.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}

    

 