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
        private readonly IQuotationProviderRepository _QuotationProviderRepository;

        public QuotationProvidersServices(IQuotationProviderRepository quotationProviderRepository)
        {
            _QuotationProviderRepository = quotationProviderRepository;
        }

        public async Task<IEnumerable<QuotationProviderModel>> GetAllAsync()
        {
            return await _QuotationProviderRepository.GetAllAsync();
        }

        public async Task<QuotationProviderModel> GetByIdAsync(long id)
        {
            return await _QuotationProviderRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(QuotationProviderModel quotationProviderRepository)
        {
            await _QuotationProviderRepository.AddAsync(quotationProviderRepository);
        }

        public async Task UpdateAsync(QuotationProviderModel quotationProviderRepository)
        {
            await _QuotationProviderRepository.UpdateAsync(quotationProviderRepository);
        }

        public async Task DeleteAsync(long id)
        {
            await _QuotationProviderRepository.DeleteAsync(id);
        }
    }
}
