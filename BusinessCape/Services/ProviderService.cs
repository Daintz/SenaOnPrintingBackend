using DataCape.Models;
using PersistenceCape.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCape.Services
{
    public class ProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository )
        {
            _providerRepository = providerRepository;
        }

        public async Task AddAsync(ProviderModel Provider)
        {
           await _providerRepository.AddAsync( Provider );
        }

        public Task DeleteAsync(long id)
        {
            return _providerRepository.DeleteAsync(id );
        }

        public Task<IEnumerable<ProviderModel>> GetAllAsync()
        {
            return _providerRepository.GetAllAsync();
        }

        public Task<ProviderModel> GetByIdAsync(long id)
        {
            return _providerRepository.GetByIdAsync( id );
        }

        public Task UpdateAsync(ProviderModel Provider)
        {
            return _providerRepository.UpdateAsync( Provider );
        }
    }
}
