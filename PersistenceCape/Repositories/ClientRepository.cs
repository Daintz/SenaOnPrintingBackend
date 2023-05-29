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
    public class ClientRepository : IClientsRepository
    {
        private readonly SENAONPRINTINGContext _context;

        public ClientRepository(SENAONPRINTINGContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientModel>> GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<ClientModel> GetByIdAsync(long id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task UpdateAsync(ClientModel client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ClientModel> AddAsync(ClientModel client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteAsync(long id)
        {
            var client = await _context.Clients.FindAsync(id);
            client.StatedAt = !client.StatedAt;
            await _context.SaveChangesAsync();
        }
    }
}
