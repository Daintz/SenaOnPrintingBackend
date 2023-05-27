using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class ClientService
    {
        private readonly IClientsRepository _clientRepository;

        public ClientService(IClientsRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<ClientModel>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task<ClientModel> GetByIdAsync(long id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(ClientModel client)
        {
            await _clientRepository.AddAsync(client);
        }

        public async Task UpdateAsync(ClientModel client)
        {
            await _clientRepository.UpdateAsync(client);
        }

        public async Task DeleteAsync(long id)
        {
            await _clientRepository.DeleteAsync(id);
        }
    }
}
