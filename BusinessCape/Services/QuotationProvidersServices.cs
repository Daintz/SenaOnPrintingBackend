using DataCape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersistenceCape.Interfaces;

namespace BusinessCape.Services
{
    public class QuotationProvidersServices
    {
        private readonly IQuotationProviderRepository _quotatioprovidersRepository;

        public QuotationProvidersServices(IQuotationProviderRepository quotatioprovidersRepository)
        {
            _quotatioprovidersRepository = quotatioprovidersRepository;
        }

        public async Task<IEnumerable<QuotationProviderModel>> GetAllAsync()
        {
            return await _quotatioprovidersRepository.GetAllAsync();
        }

        public async Task<QuotationProviderModel> GetByIdAsync(long id)
        {
            return await _quotatioprovidersRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(QuotationProviderModel quotatioproviders)
        {
            await _quotatioprovidersRepository.AddAsync(quotatioproviders);
        }

        public async Task UpdateAsync(QuotationProviderModel quotationprovider)
        {
            await _quotatioprovidersRepository.UpdateAsync(quotationprovider);
        }

        public async Task DeleteAsync(long id)
        {
            await _quotatioprovidersRepository.DeleteAsync(id);
        }
    }
}
